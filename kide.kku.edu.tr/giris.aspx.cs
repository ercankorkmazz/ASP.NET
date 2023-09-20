using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class giris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        baglanti bilgiGetir = new baglanti();
        bilgiGetir.verileriGetir("select hakkinda,ekip,yayinlar from bilgiler where id='1'");
        if (bilgiGetir.SQLTablo.Rows.Count > 0)
        {
            hakkindaTXT.Text = bilgiGetir.SQLTablo.Rows[0][0].ToString();
            ekipTXT.Text = bilgiGetir.SQLTablo.Rows[0][1].ToString();
            yayinlarTXT.Text = bilgiGetir.SQLTablo.Rows[0][2].ToString();
        }
    }
    protected void girisBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mesajGetir = FindControl("mesajTXT") as Literal;

        baglanti kullanici = new baglanti();
        kullanici.verileriGetir("select * from kullanici where kadi='" + kadiTXT.Text + "' and sifre='" + sifreTXT.Text + "'");
        if (kullanici.SQLTablo.Rows.Count > 0)
        {
            Session[Request.Url.Authority + "oturum"] = kullanici.SQLTablo.Rows[0][0].ToString();
            Session[Request.Url.Authority + "kullaniciTuru"] = kullanici.SQLTablo.Rows[0][5].ToString();
            if (kullanici.SQLTablo.Rows[0][5].ToString() == "3")
            {
                baglanti ogrenciBilgileri = new baglanti();
                ogrenciBilgileri.verileriGetir("select id,grupID from ogrenciler where kullaniciID='" + kullanici.SQLTablo.Rows[0][0].ToString() + "'");
                if (ogrenciBilgileri.SQLTablo.Rows.Count > 0)
                {
                    Session[Request.Url.Authority + "ogrenciID"] = ogrenciBilgileri.SQLTablo.Rows[0][0].ToString();
                    Session[Request.Url.Authority + "grupID"] = ogrenciBilgileri.SQLTablo.Rows[0][1].ToString();
                }
            }
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            mesajGetir.Text = mesaj.goster("2", "Kullanıcı adı ya da şifre hatalı.");
        }
    }
}