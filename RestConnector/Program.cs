using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace AgmRestConnector
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
            Application.ThreadException += OnThreadException;
            AppDomain.CurrentDomain.UnhandledException += OnDomainException;
            Application.Run(new MainForm());
        }

        static void OnException(Exception e)
        {
            DialogResult dr = DialogResult.None;
            try
            {
                string message = e.Message + Environment.NewLine + "Do you want to continue?";
                dr = MessageBox.Show(message, Application.ProductName, MessageBoxButtons.YesNo);

            }
            catch
            {
            }
            finally
            {
                if (dr != DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            OnException(e.Exception);
        }

        static void OnDomainException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                OnException(ex);
            }
        }
    }
}
