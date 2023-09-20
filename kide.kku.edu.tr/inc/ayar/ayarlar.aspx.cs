using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class ayarlar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null)
            Response.Redirect("~/giris.aspx");

        if (Page.IsPostBack == false)
        {
            baglanti bilgileriGetir = new baglanti();
            bilgileriGetir.verileriGetir("select kadi,sifre,eposta,telefon,adSoyad from kullanici where id='" + Session[Request.Url.Authority + "oturum"].ToString() + "'");
            if (bilgileriGetir.SQLTablo.Rows.Count > 0)
            {
                kadiTXT.Text = bilgileriGetir.SQLTablo.Rows[0][0].ToString();
                sifre.Value = bilgileriGetir.SQLTablo.Rows[0][1].ToString();
                postaTXT.Text = bilgileriGetir.SQLTablo.Rows[0][2].ToString();
                telTXT.Text = bilgileriGetir.SQLTablo.Rows[0][3].ToString();

                if (Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "3")
                    adSoyadTXT.Text = bilgileriGetir.SQLTablo.Rows[0][4].ToString();
                else
                {
                    baglanti adSoyadGetir = new baglanti();
                    adSoyadGetir.verileriGetir("select adSoyad from ogrenciler where id='" + Session[Request.Url.Authority + "ogrenciID"].ToString() + "'");
                    if (adSoyadGetir.SQLTablo.Rows.Count > 0)
                    {
                        adSoyadTXT.Text = adSoyadGetir.SQLTablo.Rows[0][0].ToString();
                    }
                }
            }
        }
    }
    protected void kadiGuncelleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = Master.FindControl("mesajTXT") as Literal;

        if (kadiTXT.Text != "")
        {
            baglanti kadiSorgula = new baglanti();
            kadiSorgula.verileriGetir("select id from kullanici where kadi='" + kadiTXT.Text + "'");
            if (kadiSorgula.SQLTablo.Rows.Count > 0)
                mainMesaj.Text = mesaj.goster("2", "Kullanıcı adı aktif. Farklı bir kullanıcı adı deneyiniz.");
            else
            {
                baglanti kadiGuncelle = new baglanti();
                if (kadiGuncelle.komutCalistir("update kullanici set kadi='" + kadiTXT.Text + "' where id='" + Session[Request.Url.Authority + "oturum"].ToString() + "'") == "1")
                    mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
                else
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
        }
        else
            mainMesaj.Text = mesaj.goster("2", "Kullanıcı adı yazınız!");
    }
    protected void iletisimGuncelleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = Master.FindControl("mesajTXT") as Literal;

        baglanti kadiGuncelle = new baglanti();
        if (kadiGuncelle.komutCalistir("update kullanici set eposta='" + postaTXT.Text + "', telefon='" + telTXT.Text + "' where id='" + Session[Request.Url.Authority + "oturum"].ToString() + "'") == "1")
            mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
        else
            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
    }
    protected void adSoyadGuncelleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = Master.FindControl("mesajTXT") as Literal;

        baglanti kadiGuncelle = new baglanti();
        if (Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "3")
        {
            if (adSoyadTXT.Text != String.Empty)
            {
                if (kadiGuncelle.komutCalistir("update kullanici set adSoyad='" + adSoyadTXT.Text + "' where id='" + Session[Request.Url.Authority + "oturum"].ToString() + "'") == "1")
                    mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
                else
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
            else
                mainMesaj.Text = mesaj.goster("2", "Ad Soyad yazınız.");
        }
        else
        {
            if (adSoyadTXT.Text != String.Empty)
            {
                if (kadiGuncelle.komutCalistir("update ogrenciler set adSoyad='" + adSoyadTXT.Text + "' where id='" + Session[Request.Url.Authority + "ogrenciID"].ToString() + "'") == "1")
                    mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
                else
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
            else
                mainMesaj.Text = mesaj.goster("2", "Ad Soyad yazınız.");
        }
    }
    protected void sifreGuncelleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = Master.FindControl("mesajTXT") as Literal;

        if (mevcut.Text == sifre.Value)
        {
            if (ySifre.Text != string.Empty && tSifre.Text != string.Empty)
            {
                if (ySifre.Text == tSifre.Text)
                {
                    baglanti sifreGuncelle = new baglanti();
                    if (sifreGuncelle.komutCalistir("update kullanici set sifre='" + ySifre.Text + "', guncelleme='1' where id='" + Session[Request.Url.Authority + "oturum"].ToString() + "'") == "1")
                        mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
                    else
                        mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
                else
                    mainMesaj.Text = mesaj.goster("2", "Yeni şifre ile tekrarı uyuşmuyor.");
            }
            else
                mainMesaj.Text = mesaj.goster("2", "Yeni şifre veya tekrarı boş bırakılamaz.");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "Mevcut şifre yanlış.");
    }
}