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
            bilgileriGetir.verileriGetir("select UserName,Password,Email,PhoneNumber,Name,Surname from UserTable where UserID='" + Session[Request.Url.Authority + "oturum"].ToString() + "'");
            if (bilgileriGetir.SQLTablo.Rows.Count > 0)
            {
                kadiTXT.Text = bilgileriGetir.SQLTablo.Rows[0][0].ToString();
                sifre.Value = bilgileriGetir.SQLTablo.Rows[0][1].ToString();
                postaTXT.Text = bilgileriGetir.SQLTablo.Rows[0][2].ToString();
                telTXT.Text = bilgileriGetir.SQLTablo.Rows[0][3].ToString();
                adTXT.Text = bilgileriGetir.SQLTablo.Rows[0][4].ToString();
                soyadTXT.Text = bilgileriGetir.SQLTablo.Rows[0][5].ToString();
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
            kadiSorgula.verileriGetir("select UserID from UserTable where UserName='" + kadiTXT.Text + "'");
            if (kadiSorgula.SQLTablo.Rows.Count > 0)
                mainMesaj.Text = mesaj.goster("2", "Kullanıcı adı aktif. Farklı bir kullanıcı adı deneyiniz.");
            else
            {
                baglanti kadiGuncelle = new baglanti();
                if (kadiGuncelle.komutCalistir("update UserTable set UserName='" + kadiTXT.Text + "' where UserID='" + Session[Request.Url.Authority + "oturum"].ToString() + "'") == "1")
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

        baglanti iletisimBilgileriGuncelle = new baglanti();
        if (iletisimBilgileriGuncelle.komutCalistir("update UserTable set Email='" + postaTXT.Text + "', PhoneNumber='" + telTXT.Text + "' where UserID='" + Session[Request.Url.Authority + "oturum"].ToString() + "'") == "1")
            mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
        else
            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
    }
    protected void adSoyadGuncelleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = Master.FindControl("mesajTXT") as Literal;

        baglanti kadiGuncelle = new baglanti();
        if (adTXT.Text != String.Empty || soyadTXT.Text != String.Empty)
        {
            if (kadiGuncelle.komutCalistir("update UserTable set Name='" + adTXT.Text + "', Surname='" + soyadTXT.Text + "' where UserID='" + Session[Request.Url.Authority + "oturum"].ToString() + "'") == "1")
                mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "Ad Soyad yazınız.");
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
                    if (sifreGuncelle.komutCalistir("update UserTable set Password='" + ySifre.Text + "' where UserID='" + Session[Request.Url.Authority + "oturum"].ToString() + "'") == "1")
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