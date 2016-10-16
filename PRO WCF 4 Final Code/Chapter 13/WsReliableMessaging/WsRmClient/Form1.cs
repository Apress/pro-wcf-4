using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WsRmClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        byte[] GetFile( string fileName )
        {
            FileService.FileServiceProxy proxy = new FileService.FileServiceProxy();
            byte[] result = proxy.GetFile( fileName );
            proxy.Close();
            return result;
        }

        private void button1_Click( object sender, EventArgs e )
        {
            byte[] result = GetFile( textBox1.Text );
            textBox2.Text = ASCIIEncoding.ASCII.GetString( result );
        }

        private void button2_Click( object sender, EventArgs e )
        {
            byte[] result = GetFile( textBox3.Text );
            Image jpg = Image.FromStream( new MemoryStream( result ) );
            pictureBox1.Image = jpg;
        }



    }
}