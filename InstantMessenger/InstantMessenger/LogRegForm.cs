using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace InstantMessenger
{
    public partial class LogRegForm : MaterialForm
    {
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;
        public LogRegForm()
        {
            InitializeComponent();
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(MaterialSkin.Primary.Blue300, MaterialSkin.Primary.Blue500, MaterialSkin.Primary.Blue100, MaterialSkin.Accent.Orange700, MaterialSkin.TextShade.WHITE);
            skinManager.AddFormToManage(this);
        }

        public string UserName;
        public string Password;

        private void okButton_Click(object sender, EventArgs e)
        {
            

            UserName = userText.Text;
            Password = passText.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    
    }
}
