using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;

namespace frmPinnacle
{
    public partial class frmLogin : Form
    {
        //Test
        //string strDB = resPinnacle.testDB;

        //Live
        string strDB = resPinnacle.liveDB;
        public bool LogonSuccessful;
        public string User;
        public string Role;


        public frmLogin()
        {
            InitializeComponent();
            LoadForm();
            
        }

        private void LoadForm()
        {
           txtUser.Text = Environment.UserName;
           txtPassword.Focus(); 
        }

        private void Login()
        {
            PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain, "HTC", txtUser.Text, txtPassword.Text);
            bool blValid = oPrincipalContext.ValidateCredentials(txtUser.Text, txtPassword.Text);
            if (blValid == true)
            {
                UserPrincipal objUser = UserPrincipal.FindByIdentity(oPrincipalContext, txtUser.Text);

                string strRole = findRole(objUser.Name);
                if (strRole != "")
                {
                    LoadRightForm(objUser.Name, strRole);
                }
                else
                {
                    lblStatus.Text = "The user does not have a Pinnacle DB account. Please consult IT.";
                }
            }
            else
            {
                lblStatus.Text = "Bad Login. If problem persists, please consult IT.";
            }
        }

        private string findRole(string Name)
        {
            string[] strFullName = Name.Split(' ');
            clsDB objDB = new clsDB(strDB);
            string strRole = objDB.returnRole(strFullName[0], strFullName[1]);

            return strRole;
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void LoadRightForm(string strName, string strRole)
        {
            User = strName;
            Role = strRole;
            DialogResult = DialogResult.Yes;
            this.Hide();
        }

        private void butLogin_Enter(object sender, EventArgs e)
        {
            Login();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                Login();
            }
        }
    }
}
