using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuickReturn;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.CodeDom.Compiler;

namespace QuoteClient
{
    public partial class FormQuoteClient : Form
    {
        QuickReturnQuoteServiceClient theService = new QuickReturnQuoteServiceClient();
        object tempQuote = null;
        string fileName = null;
        string xmlData = null;
        int operation;

        public FormQuoteClient()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Binds the data contract to the specified datagridviw
        /// </summary>
        /// <param name="dataGrid">Ref to the datagrid which needs to be bound to.</param>
        /// <param name="data">The data that needs to be bound</param>
        private void BindData(ref DataGridView dataGrid, object data)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data;

            dataGrid.DataSource = bindingSource;
            dataGrid.Columns["ExtensionData"].Visible = false;
        }

        private void buttonGetPortfolio_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //We hard code to an array of a few stocks that we want the service to return.
            //In the real world this would be retrieved from some persistant store
            string[] stocks = { "INTU", "MSFT", "GOOG", "IBM" };

            //Invoke the Service
            StockQuote[] portfolio = theService.GetPortfolio(stocks);
            
            //flag used to track which service was called. This is
            //used in other parts of the application to trach which
            //object is used.
            operation = 1;

            //Bind the data contract returned by the service to the grid.
            BindData(ref dataGridView, portfolio);

            tempQuote = portfolio;
            this.Cursor = Cursors.Default;
        }

        private void buttonGetStock_Click(object sender, EventArgs e)
        {
            //Ensure something was selected first
            if (comboBoxTicker.SelectedIndex != -1)
            {
                this.Cursor = Cursors.WaitCursor;

                StockQuote quote = theService.GetQuote(comboBoxTicker.SelectedItem.ToString());
                BindData(ref dataGridView, quote);
                operation = 2;

                tempQuote = quote;

                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Returns the XML Representation of a Data Contract.
        /// </summary>
        /// <param name="theObject">DataContract that needs to be "serialized"</param>
        /// <returns></returns>
        private string GetXML(object theObject)
        {
            //Ensure the object is not null.
            if (theObject != null)
            {
                DataContractSerializer serializer;

                //Flag used to track which type to use depending on the operation called.
                if(operation == 2)
                    serializer = new DataContractSerializer(typeof(StockQuote));
                else
                    serializer = new DataContractSerializer(typeof(StockQuote[]));

                StringWriter stringWriter = new StringWriter();
                XmlWriter xmlWriter = XmlWriter.Create(stringWriter);

                serializer.WriteObject(xmlWriter, theObject);

                xmlWriter.Flush();
                stringWriter.Flush();

                return stringWriter.ToString();
            }
            else
                return null;
        }

        private void viewXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PrepareData())
            {
                FormViewXML viewXML = new FormViewXML();
                viewXML.FileName = fileName;
                viewXML.Show();
            }
        }

        private void viewXMLInNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(PrepareData())
                System.Diagnostics.Process.Start("notepad.exe", fileName);
            else
                MessageBox.Show("Could not write file.");
        }

        /// <summary>
        /// Ensures we have a some valid data to serialized and then creates a temp file
        /// which can be loaded later. Also ensures the application has write priveleges
        /// to the temp folder to create the file.
        /// </summary>
        /// <returns>True, if all operations were sucessful. Else returns a false.</returns>
        private bool PrepareData()
        {
            bool response = false;

            try
            {
                if (tempQuote != null)
                {
                    xmlData = GetXML(tempQuote); ;

                    if (!WriteFile())
                        MessageBox.Show("Could not write file");
                    else
                        response = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not write file. Error details below.\n" + ex.Message);
            }

            return response;
        }

        /// <summary>
        /// Creates a temp xml file to the default Windows temp directory and stores the file name.
        /// </summary>
        /// <returns>True if the file was created successfuly.</returns>
        private bool WriteFile()
        {
            bool returnValue = false;

            if (!(fileName != null && fileName.Length > 0 && xmlData != null && xmlData.Length > 0))
            {
                TempFileCollection tempFiles = new TempFileCollection();
                fileName = tempFiles.AddExtension("xml");
            }

            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(xmlData);
                fileStream.Write(info, 0, info.Length);

                returnValue = true;
            }

            return returnValue;
        }
    }
}