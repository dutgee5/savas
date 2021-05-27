using Savas.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savas.Library.Concrete
{
    internal class Mermi:Cisim
    {
        public Mermi(Size hareketAlaniBoyutlari, int namlucu) : base(hareketAlaniBoyutlari)
        {
            BaslangicKonumunuAyarla(namlucu);
            HareketMesafesi = (int)(Height * 1.5);
        }

        private void BaslangicKonumunuAyarla(int namlucu)
        {
            Bottom = HareketAlaniBoyutlari.Height;
            Center = namlucu;
        }
    }
}
