using Savas.Library.Enum;
using System.Drawing;
using Savas.Library.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Savas.Library.Concrete
{
    
    public class Oyun : IOyun
    {
        #region Alanlar

        private readonly Timer _gecenSureTimer = new Timer { Interval = 1000 };
        private readonly Timer _hareketTimer = new Timer { Interval = 100 };
        private readonly Timer _ucakolusturmaTimer = new Timer { Interval = 2000 };
        private TimeSpan _gecenSure;
        private readonly Panel _ucaksavarPanel;
        private readonly Panel _savasAlaniPanel;
        private Ucaksavar _ucaksavar;
        private readonly List<Mermi> _mermiler = new List<Mermi>();
        private readonly List<Ucak> _ucaklar = new List<Ucak>();

        #endregion

        #region Olaylar

        public event EventHandler GecenSureDegisti;

        #endregion

        #region Özellikler

        public bool DevamEdiyorMu { get; private set; }

        public TimeSpan GecenSure 
        {
            get => _gecenSure;
            private set 
            {
                _gecenSure = value;

                GecenSureDegisti?.Invoke(this, EventArgs.Empty);
            } 
        }

        #endregion

        #region Metotlar

        public Oyun(Panel ucaksavarPanel, Panel savasAlaniPanel)
        {
            _ucaksavarPanel = ucaksavarPanel;
            _savasAlaniPanel = savasAlaniPanel;

            _gecenSureTimer.Tick += GecenSureTimer_Tick;
            _hareketTimer.Tick += HareketTimer_Tick;
            _ucakolusturmaTimer.Tick += UcakOLusturmaTimer_Tick;
        }

        private void GecenSureTimer_Tick(object sender, EventArgs e)
        {
            GecenSure += TimeSpan.FromSeconds(1);
        }

        private void HareketTimer_Tick(object sender, EventArgs e)
        {
            MermileriHareketEttir();
        }

        private void UcakOLusturmaTimer_Tick(object sender, EventArgs e)
        {
            UcakOlustur();
        }

        private void MermileriHareketEttir()
        {
            for (int i = _mermiler.Count-1; i >=0; i--)
            {
                var mermi = _mermiler[i];
                var ulastiMi = mermi.HareketEttir(Yon.Yukari);
                if (ulastiMi)
                {
                    _mermiler.Remove(mermi);
                    _savasAlaniPanel.Controls.Remove(mermi);
                }
            }
            
        }

        public void AtesEt()
        {
            if (!DevamEdiyorMu) return;

            var mermi = new Mermi(_savasAlaniPanel.Size, _ucaksavar.Center);
            _mermiler.Add(mermi);
            _savasAlaniPanel.Controls.Add(mermi);
      

        }

        public void Baslat()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = true;

            ZamanlayicilariBaslat();

            UcaksavarOlustur();
            UcakOlustur();

        }

        private void UcakOlustur()
        {
            var ucak = new Ucak(_savasAlaniPanel.Size);
            _ucaklar.Add(ucak);
            _savasAlaniPanel.Controls.Add(ucak);
        }

        private void ZamanlayicilariBaslat()
        {
            _gecenSureTimer.Start();
            _hareketTimer.Start();
            _ucakolusturmaTimer.Start();
        }

        private void UcaksavarOlustur()
        {
            _ucaksavar = new Ucaksavar(_ucaksavarPanel.Width, _ucaksavarPanel.Size);

            _ucaksavarPanel.Controls.Add(_ucaksavar);
        }

        private void Bitir()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;

            ZamanlayicilariDurdur();
        }

        private void ZamanlayicilariDurdur()
        {
            _gecenSureTimer.Stop();
            _hareketTimer.Stop();
            _ucakolusturmaTimer.Stop();
        }

        public void UcaksavariHareketEttir(Yon yon)
        {
            if (DevamEdiyorMu) return;

            _ucaksavar.HareketEttir(yon);
        }

        #endregion

        
    }
}
