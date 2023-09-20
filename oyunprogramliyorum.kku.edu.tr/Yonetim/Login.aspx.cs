using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == "aktif")
        {
            Response.Redirect("~/Yonetim/Default.aspx");
        }
        else if (Session[Request.Url.Authority + "oturum"] == "kilitli")
        {
            Response.Redirect("~/Yonetim/Kilitli.aspx");
        }
    }
    protected void girisYapBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mesajGetir = FindControl("mesajTXT") as Literal;

        baglanti kullanici = new baglanti();
        kullanici.verileriGetir("select id,kadi,adSoyad,uyelikTipi from kullanici where kadi='" + kadiTXT.Text + "' and sifre='" + sifreTXT.Text + "'");
        if (kullanici.SQLTablo.Rows.Count > 0)
        {
            Session[Request.Url.Authority + "oturum"] = "aktif";
            Session[Request.Url.Authority + "kullaniciID"] = kullanici.SQLTablo.Rows[0][0].ToString();
            Session[Request.Url.Authority + "kadi"] = kullanici.SQLTablo.Rows[0][1].ToString();
            Session[Request.Url.Authority + "adSoyad"] = kullanici.SQLTablo.Rows[0][2].ToString();
            Session[Request.Url.Authority + "kullaniciTuru"] = kullanici.SQLTablo.Rows[0][3].ToString();
            Response.Redirect("~/Yonetim/Default.aspx");
        }
        else
        {
            mesajGetir.Text = mesaj.goster("2", "Kullanıcı adı ya da şifre hatalı.");
        }
    }
}