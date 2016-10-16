using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QuickReturn
{
    public partial class FormViewXML : Form
    {
        private string fileName = null;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public FormViewXML()
        {
            InitializeComponent();
        }

        private void FormViewXML_Load(object sender, EventArgs e)
        {
            if (fileName != null && fileName.Length > 0)
                webBrowser1.Navigate(fileName);
        }


        //private bool WriteFile()
        //{
        //    bool returnValue = false;

        //    if (fileName != null && fileName.Length > 0 && xmlData != null && xmlData.Length > 0)
        //    {
        //        using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
        //        {
        //            byte[] info = new UTF8Encoding(true).GetBytes(xmlData);
        //            fileStream.Write(info, 0, info.Length);
        //        }

        //        returnValue = true;
        //    }

        //    return returnValue;
        //}
    }
}