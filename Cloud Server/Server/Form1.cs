using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cloud.GetData += Cloud_GetData;

        }

        CloudTCPIP cloud = new CloudTCPIP("Server");


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Cloud_GetData(object sender, SendData data)
        {
            this?.Invoke(new MethodInvoker(delegate()
            {
                listBox1.Items.Add("[" + data.ID + "] : " + data.Content);
            }));

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendData sd = new SendData(textBox1.Text, textBox2.Text);
            cloud.Send(sd);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            cloud.ID = textBox3.Text;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
