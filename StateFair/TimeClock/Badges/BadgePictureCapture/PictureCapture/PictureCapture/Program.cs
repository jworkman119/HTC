using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PictureCapture
{
       
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmPictureCapture());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Error - make sure the camera is plugged into the usb port", "Critical Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

    }
}
