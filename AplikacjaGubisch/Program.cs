
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * Co czyta:
 *  I34.0
 *  DB206.dbd10
 *  
 * 
 * 
 */
namespace AplikacjaGubisch
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        /// 
       
        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
           
        }

       
       
   
    }

    class ThreadClass
    {
        public ThreadClass()
        {

        }

        public void Run()
        {
            Console.WriteLine("Rozpoczyna prace");

        }
    }

}
