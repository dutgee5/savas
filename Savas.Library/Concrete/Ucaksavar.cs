using Savas.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Savas.Library.Concrete
{
    internal class Ucaksavar : Cisim
    {
        public Ucaksavar(int panelGeenisligi)
        {
            Left = (panelGeenisligi - Width) / 2;
        }
    }
}
