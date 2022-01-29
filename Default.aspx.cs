using CemEmlakV1._0.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CemEmlakV1._0
{
    public partial class _Default : Page
    {
        List<Ev> evList = new List<Ev>();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabani"].ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * from EV";
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
                evList.Add(ev);
            }
            dr.Close();
            con.Close();
            GridView1.DataSource = evList;
            GridView1.DataBind();
            GridView1.AutoGenerateColumns = false;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "duzenle")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Ev ev = evList[index];
                Page.Response.Redirect($"~/EditHome/{ev.ID}");
            }
            if (e.CommandName == "sil")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["veritabani"].ConnectionString);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                int index = Convert.ToInt32(e.CommandArgument);
                Ev ev = evList[index];
                cmd.CommandText = $"delete from ev where ID={ev.ID}";
                cmd.ExecuteNonQuery();
                string script1 = $"alert('{ev.ID} ID li Ev Kaydı Silindi');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script1, true);
                Page.Response.Redirect("~/Default");
                con.Close();
            }
        }
    }
}