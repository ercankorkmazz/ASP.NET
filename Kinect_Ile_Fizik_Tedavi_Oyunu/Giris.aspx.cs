using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Giris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] != null)
            Response.Redirect("~/Default.aspx");
    }

    protected void girisYapBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mesajGetir = FindControl("mesajTXT") as Literal;

        baglanti kullanici = new baglanti();
        kullanici.verileriGetir("select * from kullanicilar where kadi='" + kadiTXT.Text + "' and sifre='" + sifreTXT.Text + "'");
        if (kullanici.SQLTablo.Rows.Count > 0)
        {
            Session[Request.Url.Authority + "oturum"] = kullanici.SQLTablo.Rows[0][0].ToString();
            Session[Request.Url.Authority + "hastaID"] = kullanici.SQLTablo.Rows[0][1].ToString();
            Session[Request.Url.Authority + "kullaniciTuru"] = kullanici.SQLTablo.Rows[0][5].ToString();
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            mesajGetir.Text = mesaj.goster("2", "Kullanıcı adı ya da şifre hatalı.");
        }
    }
}