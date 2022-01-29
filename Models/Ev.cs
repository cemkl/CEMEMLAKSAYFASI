using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemEmlakV1._0.Models
{
    public class Ev
    {
        public int ID { get; set; }
        public string Baslik { get; set; }
        public string Adres { get; set; }
        public int OdaSayisi { get; set; }
        public int BanyoSayisi { get; set; }
        public string Aciklama { get; set; }
        public int Fiyat { get; set; }

    }
}