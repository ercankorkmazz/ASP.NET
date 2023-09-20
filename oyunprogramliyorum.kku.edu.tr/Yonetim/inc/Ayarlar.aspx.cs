using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_inc_Ayarlar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            baglanti bilgileriGetir = new baglanti();
            bilgileriGetir.verileriGetir("select kadi,adSoyad,ePosta from kullanici where id='" + Session[Request.Url.Authority + "kullaniciID"].ToString() + "'");
            if (bilgileriGetir.SQLTablo.Rows.Count > 0)
            {
                kadiTXT.Text = bilgileriGetir.SQLTablo.Rows[0][0].ToString();
                adSoyadTXT.Text = bilgileriGetir.SQLTablo.Rows[0][1].ToString();
                postaTXT.Text = bilgileriGetir.SQLTablo.Rows[0][2].ToString();
            }
        }
    }
    protected void adSoyadGuncelleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = Master.FindControl("mesajTXT") as Literal;

        baglanti kadiGuncelle = new baglanti();
        if (adSoyadTXT.Text != String.Empty)
        {
            if (kadiGuncelle.komutCalistir("update kullanici set adSoyad='" + adSoyadTXT.Text + "' where id='" + Session[Request.Url.Authority + "kullaniciID"].ToString() + "'") == "1")
            {
                Session[Request.Url.Authority + "adSoyad"] = adSoyadTXT.Text;
                mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "Ad Soyad yazınız.");
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
                if (kadiGuncelle.komutCalistir("update kullanici set kadi='" + kadiTXT.Text + "' where id='" + Session[Request.Url.Authority + "kullaniciID"].ToString() + "'") == "1")
                {
                    Session[Request.Url.Authority + "kadi"] = kadiTXT.Text;
                    mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
                }
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
        if (kadiGuncelle.komutCalistir("update kullanici set ePosta='" + postaTXT.Text + "' where id='" + Session[Request.Url.Authority + "kullaniciID"].ToString() + "'") == "1")
            mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
        else
            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
    }
    protected void sifreGuncelleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = Master.FindControl("mesajTXT") as Literal;

        string mevcutSifre = string.Empty;
        baglanti bilgileriGetir = new baglanti();
        bilgileriGetir.verileriGetir("select sifre from kullanici where id='" + Session[Request.Url.Authority + "kullaniciID"].ToString() + "'");
        if (bilgileriGetir.SQLTablo.Rows.Count > 0)
            mevcutSifre = bilgileriGetir.SQLTablo.Rows[0][0].ToString();

        if (mevcut.Text == mevcutSifre)
        {
            if (ySifre.Text != string.Empty && tSifre.Text != string.Empty)
            {
                if (ySifre.Text == tSifre.Text)
                {
                    baglanti sifreGuncelle = new baglanti();
                    if (sifreGuncelle.komutCalistir("update kullanici set sifre='" + ySifre.Text + "', kontrol='1' where id='" + Session[Request.Url.Authority + "kullaniciID"].ToString() + "'") == "1")
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