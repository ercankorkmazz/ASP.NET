using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_Kilitli : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session[Request.Url.Authority + "oturum"] == null)
        {
            Response.Redirect("~/Yonetim/Login.aspx");
        }
        else if (Session[Request.Url.Authority + "oturum"] == "aktif")
        {
            Response.Redirect("~/Yonetim/Default.aspx");
        }
        adSoyadTXT.Text = Session[Request.Url.Authority + "adSoyad"].ToString() + ", tekrar giriş yapmak için şifreni girmelisin.";
    }
    protected void girisBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mesajGetir = FindControl("mesajTXT") as Literal;

        baglanti kullanici = new baglanti();
        kullanici.verileriGetir("select sifre from kullanici where id='" + Session[Request.Url.Authority + "kullaniciID"].ToString() + "'");
        if (kullanici.SQLTablo.Rows.Count > 0)
        {
            if (sifreTXT.Text == kullanici.SQLTablo.Rows[0][0].ToString())
            {
                Session[Request.Url.Authority + "oturum"] = "aktif";
                Response.Redirect("~/Yonetim/Default.aspx");
            }
            else
            {
                mesajGetir.Text = mesaj.goster("2", "Hatalı şifre girdiniz.");
            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("~/Yonetim/Login.aspx");
        }
    }
}