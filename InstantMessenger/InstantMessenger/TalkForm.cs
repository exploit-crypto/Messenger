using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
namespace InstantMessenger
{
    public partial class TalkForm : MaterialForm
    {
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public IMClient im;
        public string sendTo;
        public TalkForm(IMClient im, string user)
        {
            //Form Creator
            InitializeComponent();
            textBox1.Visible = false;
            ///////////////////////////////////////////////////////////////////////////////////////
            materialLabel1.BackColor = Color.DeepSkyBlue;
            textBox1.BackColor = Color.DeepSkyBlue;
            button1.BackColor = Color.DeepSkyBlue;
            radioButton1.ForeColor = Color.Black;
            radioButton2.ForeColor = Color.Black;
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(MaterialSkin.Primary.Blue300, MaterialSkin.Primary.Blue500, MaterialSkin.Primary.Blue100, MaterialSkin.Accent.Orange700, MaterialSkin.TextShade.WHITE);
            skinManager.AddFormToManage(this);
            ///////////////////////////////////////////////////////////////////////////////////////

            //End Form Creator
            talkText.Enabled = true;
            talkText.ReadOnly = true;
            this.im = im;
            this.sendTo = user;

        }

        private void ChangeTheme(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                materialLabel1.BackColor = Color.DeepSkyBlue;
                textBox1.BackColor = Color.DeepSkyBlue;
                button1.BackColor = Color.DeepSkyBlue;
                radioButton1.ForeColor = Color.Black;
                radioButton2.ForeColor = Color.Black;
                skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                skinManager.ColorScheme = new ColorScheme(MaterialSkin.Primary.Blue300, MaterialSkin.Primary.Blue500, MaterialSkin.Primary.Blue100, MaterialSkin.Accent.Orange700, MaterialSkin.TextShade.WHITE);
            }
            if (radioButton2.Checked)
            {
                materialLabel1.BackColor = Color.DarkGray;
                textBox1.BackColor = Color.DarkGray;
                button1.BackColor = Color.DarkGray;
                radioButton1.ForeColor = Color.White;
                radioButton2.ForeColor = Color.White;
                skinManager.Theme = MaterialSkinManager.Themes.DARK;
                skinManager.ColorScheme = new ColorScheme(MaterialSkin.Primary.Grey500, MaterialSkin.Primary.Grey800, MaterialSkin.Primary.Blue100, MaterialSkin.Accent.Orange700, MaterialSkin.TextShade.WHITE);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        IMAvailEventHandler availHandler;
        IMReceivedEventHandler receivedHandler;

        private void TalkForm_Load(object sender, EventArgs e)
        {
            this.Text = sendTo;
            availHandler = new IMAvailEventHandler(im_UserAvailable);
            receivedHandler = new IMReceivedEventHandler(im_MessageReceived);
            im.UserAvailable += availHandler;
            im.MessageReceived += receivedHandler;
            im.IsAvailable(sendTo);
        }

        private void TalkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            im.UserAvailable -= availHandler;
            im.MessageReceived -= receivedHandler;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            im.SendMessage(sendTo, sendText.Text);
            talkText.Text += String.Format("[{0}] {1}\r\n", im.UserName, sendText.Text);
            sendText.Text = "";
            status.Text = "Sended";
        }

        bool lastAvail = false;

        void im_UserAvailable(object sender, IMAvailEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                if (e.UserName == sendTo)
                {
                    if (lastAvail != e.IsAvailable)
                    {
                        lastAvail = e.IsAvailable;
                        string avail = (e.IsAvailable ? "available" : "unavailable");
                        this.Text = String.Format("{0} - {1}", sendTo, avail);
                        talkText.Text += String.Format("[{0} is {1}]\r\n", sendTo, avail);
                    }
                }
            }));
        }

        void im_MessageReceived(object sender, IMReceivedEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                if (e.From == sendTo)
                {
                    talkText.Text += String.Format("[{0}] {1}\r\n", e.From, e.Message);
                }
            }));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            im.IsAvailable(sendTo);
        }

        private void AddFile_Click(object sender, EventArgs e)
        {

            byte[] tmp;
            OpenFileDialog op;
            TcpClient client = new TcpClient(im.Server, im.Port); ;
            op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
                Clipboard.SetText(op.FileName);
            status.Text = "Uploading...";
            tmp = File.ReadAllBytes(op.FileName);
            //s.Write(tmp, 0, tmp.Length);
            im.SendFile(sendTo,tmp);
            //client.Close();
        }


    }
}
