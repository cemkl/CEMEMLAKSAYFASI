using CemEmlakV1._0.Models;
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
    public partial class EditHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string url = HttpContext.Current.Request.Path;
                string[] urlArray = url.Split('/');
                int ID = Convert.ToInt32(urlArray[2]);

                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabani"].ConnectionString);
                SqlConnection con = sqlConnection;
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"Select * from EV where ID = {ID}";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Ev ev = new Ev();
                    ev.Baslik = dr["Baslik"].ToString();
                    ev.Aciklama = dr["Aciklama"].ToString();
                    ev.Adres = dr["Adres"].ToString();
                    ev.BanyoSayisi = Convert.ToInt32(dr["BanyoSayisi"]);
                    ev.OdaSayisi = Convert.ToInt32(dr["OdaSayisi"]);
                    ev.Fiyat = Convert.ToInt32(dr["Fiyat"]);
                    ev.ID = Convert.ToInt32(dr["ID"]);
                    txtAciklama.Text = ev.Aciklama;
                    txtAdres.Text = ev.Adres;
                    txtBanyoSayisi.Text = ev.BanyoSayisi.ToString();
                    txtOdaSayisi.Text = ev.OdaSayisi.ToString();
                    txtFiyat.Text = ev.Fiyat.ToString();
                    TxtBaslik.Text = ev.Baslik;
                }
            }
        }

        protected void btnDuzenle_Click(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Path;
            string[] urlArray = url.Split('/');
            int ID = Convert.ToInt32(urlArray[2]);
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabani"].ConnectionString);
            SqlConnection con = sqlConnection;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            if (string.IsNullOrEmpty(TxtBaslik.Text) || string.IsNullOrEmpty(txtAdres.Text) || string.IsNullOrEmpty(txtOdaSayisi.Text) || string.IsNullOrEmpty(txtFiyat.Text) || string.IsNullOrEmpty(txtBanyoSayisi.Text))
            {
                string script2 = "alert('Zorunlu alanları lütfen doldurunuz');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script2, true);
                return;
            }
            cmd.CommandText = 
                $"Update EV set " +
                $"Baslik='{TxtBaslik.Text}'," +
                $"Adres='{txtAdres.Text}'," +
                $"OdaSayisi={Convert.ToInt32(txtOdaSayisi.Text)}," +
                $"BanyoSayisi={Convert.ToInt32(txtBanyoSayisi.Text)}," +
                $"Aciklama='{txtAciklama.Text}'," +
                $"Fiyat={Convert.ToInt32(txtFiyat.Text)} where ID={ID}";
            cmd.ExecuteNonQuery();
            con.Close();
            string script1 = $"alert('{ID} ID li kayıt güncellendi');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script1, true);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Default");
        }
    }
}