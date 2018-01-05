using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kdcnovAutoWinForms
{
    static class Diagnostic
    {
        private static System.Diagnostics.Stopwatch swatch;
        public static void Start()
        {
            swatch = new System.Diagnostics.Stopwatch(); // создаем объект
            swatch.Start(); // старт
        }

        public static void Stop()
        {
            swatch.Stop(); // стоп
            MessageBox.Show(swatch.Elapsed.ToString()); // выводим результат в консоль
            swatch = null;
        }

    }
}
