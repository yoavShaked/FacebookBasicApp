using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FacebookBasicApplication
{
    // $G$ RUL-006 (-80) Late submission (-2 days)

    // $G$ THE-001 (-13) Your grade on diagrams document - 87. Please see comments inside the document.

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormWall());
        }
    }
}
