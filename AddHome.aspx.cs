using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CemEmlakV1._0
{
    public partial class AddHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabani"].ConnectionString);
            SqlCommand cmd = con.CreateCommand();
            if (string.IsNullOrEmpty(TxtBaslik.Text) || string.IsNullOrEmpty(txtAdres.Text) || string.IsNullOrEmpty(txtOdaSayisi.Text) || string.IsNullOrEmpty(txtFiyat.Text) || string.IsNullOrEmpty(txtBanyoSayisi.Text))
            {
                string script1 = "alert('Zorunlu alanları lütfen doldurunuz');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script1, true);
                return;
            }
            int odaSayisi = Convert.ToInt32(txtOdaSayisi.Text);
            int banyoSayisi = Convert.ToInt32(txtBanyoSayisi.Text);
            int fiyat = Convert.ToInt32(txtFiyat.Text);
            cmd.CommandText = $"INSERT INTO EV(Baslik,Adres,OdaSayisi,BanyoSayisi,Aciklama,Fiyat) VALUES ('{TxtBaslik.Text}','{txtAdres.Text}',{odaSayisi},{banyoSayisi},'{txtAciklama.Text}',{fiyat})";
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            string script = "alert('Ev Ekleme Başarılı');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            txtAciklama.Text = "";
            txtAdres.Text = "";
            txtBanyoSayisi.Text = "";
            txtFiyat.Text = "";
            txtOdaSayisi.Text = "";
            TxtBaslik.Text = "";
        }
    }
}