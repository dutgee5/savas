﻿using Savas.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savas.Library.Concrete
{
    internal class Ucak : Cisim
    {
        private static readonly Random rnd= new Random();

        public Ucak(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
         
            Left = rnd.Next(HareketAlaniBoyutlari.Width - Width + 1);
        }
    }
}
