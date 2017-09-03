using System;
using System.Windows.Forms;

namespace OriginStudio
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
            Application.Run(new MainMenu());
        }

        public static void showErrorDialog(string message)
        {
            DialogResult result = MessageBox.Show(message, "Errore",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (result == DialogResult.Yes)
            {
                //code for Yes
            }
        }
    }
}
