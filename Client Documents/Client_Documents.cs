using System;
using Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DAL;
using LSExtensionControlLib;
using LSSERVICEPROVIDERLib;

namespace Client_Documents
{
    [ComVisible(true)]
    [ProgId("NautilusExtensions.Client_Documents")]
    public partial class Client_Documents : UserControl, IExtensionControl
    {
        public Client_Documents()
        {
            InitializeComponent();
            BackColor = Color.FromName("Control");
        }
        string _path = null;
        #region Private members

        /// <summary>
        ///     Process XML service provider string
        /// </summary>
        private const string PROCESS_XML_SP = "ProcessXML";

        /// <summary>
        ///     Table name
        /// </summary>
        private const string TABLE_NAME = "TABLE";

        /// <summary>
        ///     ID Field Name
        /// </summary>
        private const string FIELD_NAME_ID = "TABLE_ID";

        private Client client;
        private IDataLayer dal;

        /// <summary>
        ///     XML Processor object
        /// </summary>
        private INautilusProcessXML nautilusProcessXML;

        private INautilusDBConnection ntlCon;

        /// <summary>
        ///     Id of the record selected
        /// </summary>
        private double recordID;

        /// <summary>
        ///     Service Provider object
        /// </summary>
        private INautilusServiceProvider serviceProvider;

        private IExtensionControlSite site;

        #endregion

        #region IExtensionControl

        public void EnterPage()
        {
            Utils.CreateConstring(ntlCon);
            lblError.Visible = false;
            GetClientById(recordID);
        }


        public void ExitPage()
        {
            dal.Close();
            // throw new NotImplementedException();
        }

        public void Internationalise()
        {
            //   throw new NotImplementedException();
        }

        public void PreDisplay()
        {
            //   throw new NotImplementedException();
        }

        public void RestoreSettings(int hKey)
        {
            //  throw new NotImplementedException();
        }

        public void SaveData()
        {
            //  throw new NotImplementedException();
        }

        public void SaveSettings(int hKey)
        {
            //  throw new NotImplementedException();
        }

        public void SetReadOnly(bool readOnly)
        {
            //throw new NotImplementedException();
        }


        public void SetServiceProvider(object sp)
        {
            // Check the service provider object is not null
            if (sp != null)
            {
                // Cast the object to the correct type
                serviceProvider = sp as INautilusServiceProvider;

                // Using the service provider object get the XML Processor interface
                // We will use this object to get information from the database
                nautilusProcessXML = Utils.GetXmlProcessor(serviceProvider);


                ntlCon = Utils.GetNtlsCon(serviceProvider);
            }
        }

        /// <summary>
        ///     Called once at the start of the extension page’s life.
        ///     It is used to pass in a reference to a site object that the page can use to call back into Nautilus.
        /// </summary>
        /// <param name="cs">Site object</param>
        public void SetSite(object cs)
        {
            // Check site object is not null
            if (cs != null)
            {
                // Cast the object to the correct type
                site = cs as IExtensionControlSite;
            }
        }

        /// <summary>
        ///     Called once at the start of an Extension page’s life to tell the page to load information from the record.
        ///     The Extension page should use the site object to read the required information.
        ///     It should make sure to read all the information it will require during the SetupData method as calls to the site
        ///     object to read information are only allowed during the SetupData method.
        /// </summary>
        public void SetupData()
        {
            bool flag;
            // Check site object is not null
            if (site != null)
            {
                // Set the page name
                site.SetPageName("Documents");

                // Get the record id
                site.GetDoubleValue("CLIENT_ID", out recordID, out flag);
            }
        }

        #endregion

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            string path = _path;// client.LocationFile + client.ContractFileName + "\\";
            object wordName = listBox1.SelectedItem;
            string uri = Path.Combine(path, wordName.ToString());
            webBrowser1.Navigate(new Uri(uri));


        }

        private void GetClientById(double clientId)
        {
            listBox1.Items.Clear();
            dal = new DataLayer();
            dal.Connect();
            client = dal.GetClientByID(clientId);

            //get path
            //     _path = dal.GetPathOfContractFiles(client.ClientId);

            var ph = dal.GetPhraseByName("Location folders");
            var pe = ph.PhraseEntries.Where(p => p.PhraseDescription == "Client documents").FirstOrDefault();
            var clientDocumentsPath = pe.PhraseName;



            if (client.ContractFileName != null)
            {
                _path = Path.Combine(clientDocumentsPath, client.ContractFileName);
                try
                {
                    //get directory
                    var dirInfo = new DirectoryInfo(_path);

                    //get word Documents from  directory
                    FileInfo[] wordFiles = dirInfo.GetFiles("*.pdf");
                    //get files names for this client
                    string[] fileNames = wordFiles.Where(x => x.Name.Contains(client.Name)).Select(x => x.Name).ToArray();

                    listBox1.Items.AddRange(fileNames);
                }
                catch (Exception ex)
                {

                    lblError.Visible = true;
                    lblError.Text = "אין אפשרות למצוא את התיקייה המבוקשת.";
                    Logger.WriteLogFile(ex);

                }
            }
            else
            {
                lblError.Visible = true;
            }
        }



        private PhraseEntry contractPath;
        private PhraseEntry contractFolder;
        private void GetFolderLocations()
        {
            try
            {
                var phraseH = dal.GetPhraseByName("Location folders");
                contractPath = phraseH.PhraseEntries.FirstOrDefault(x => x.PhraseDescription == "Client documents");
                contractFolder = phraseH.PhraseEntries.FirstOrDefault(x => x.PhraseDescription == "Contract documents");
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "שגיאה ביצירת כתובת המסמך";
            }
        }
        private void Client_Documents_Resize(object sender, EventArgs e)
        {
            lblHeader.Location = new Point(Width / 2 - lblHeader.Width / 2, lblHeader.Location.Y);
        }


    }
}