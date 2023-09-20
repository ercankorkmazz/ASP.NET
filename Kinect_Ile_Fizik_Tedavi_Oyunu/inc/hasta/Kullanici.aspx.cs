using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_hasta_Kullanici : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "2")
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }

        if (Page.IsPostBack == false)
        {
            baglanti bilgiGetir = new baglanti();

            bilgiGetir.verileriGetir("select adSoyad, kadi from kullanicilar where id='" + Session[Request.Url.Authority + "oturum"] + "'");
            if (bilgiGetir.SQLTablo.Rows.Count > 0)
            {
                uyeAdSoyadTXT.Text = bilgiGetir.SQLTablo.Rows[0][0].ToString();
                uyeKadiTXT.Text = bilgiGetir.SQLTablo.Rows[0][1].ToString();
                uyeSifreTXT.Text = "";
            }
        }
    }

    protected void GuncelleBtn_Click(object sender, EventArgs e)
    {
        
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (uyeSifreTXT.Text != "" && uyeKadiTXT.Text != "" && uyeAdSoyadTXT.Text != "")
        {
            baglanti KullaniciGuncelle = new baglanti();

            if (KullaniciGuncelle.komutCalistir("update kullanicilar set adSoyad='" + uyeAdSoyadTXT.Text + "', kadi='" + uyeKadiTXT.Text + "', sifre='" + uyeSifreTXT.Text + "', kontrol='1' where id='" + Session[Request.Url.Authority + "oturum"] + "'") == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "Tüm alanları doldurunuz.");
    }
}