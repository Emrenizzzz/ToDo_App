using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ToDo_App.Buyuklukler;
using static ToDo_App.Kolonlar;

namespace ToDo_App
{
    public class Kart
    {
        public Kart(string _baslik,string _icerik,Buyukluk _buyukluk,Kisi _kisi,Kolon _kolon)
        {
            this.Baslik = _baslik;
            this.icerik = _icerik;
            this.Buyukluk = _buyukluk;
            this.Kisi = _kisi;
            this.Kolon = _kolon;
        }

        string baslik, icerik;
        Buyukluk buyukluk;
        Kisi kisi;
        Kolon kolon;

        public string Baslik { get => baslik; set => baslik = value; }
        public string Icerik { get => icerik; set => icerik = value; }
        public Buyukluk Buyukluk { get => buyukluk; set => buyukluk = value; }
        public Kisi Kisi { get => kisi; set => kisi = value; }
        public Kolon Kolon { get => kolon; set => kolon = value; }
    }
}
