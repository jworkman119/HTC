using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace frmPinnacle
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            frmLogin objLogin = new frmLogin();

            if (objLogin.ShowDialog() == DialogResult.Yes)
            {
                string strUser = objLogin.User;
                string strRole = objLogin.Role;
                frmPinnacle objPinnacle = new frmPinnacle(strUser,strRole);

                Application.Run(objPinnacle);
            }

        }
    }
}
