using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //GetInputForm gg = new GetInputForm();
            //gg.Run();
            //MessageBox.Show(Convert.ToString(gg.Input));

            var engine = new Engine();
            engine.Run();
        }
    }
}
