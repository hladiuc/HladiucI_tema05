using App.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (APPWindow app = new APPWindow()) 
            {
                app.Run(30.0, 0.0);
            }
        }
    }
}
