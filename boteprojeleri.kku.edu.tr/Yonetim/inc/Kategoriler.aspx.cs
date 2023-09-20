using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_inc_Kategoriler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            kategoriIslemleri ki = new kategoriIslemleri();
            rptKategoriler.DataSource = ki.kategorileriGetir();
            rptKategoriler.DataBind();
        }
    }
    protected void kaydetBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        baglanti sayfaGuncelle = new baglanti();
        if (sayfaGuncelle.komutCalistir("insert into kategoriler (baslik,kontrol) values ('" + kategoriTXT.Text + "', '1')") == "1")
        {
            kategoriTXT.Text = string.Empty;
            mainMesaj.Text = mesaj.goster("1", "Kategori Oluşturuldu");
            kategoriIslemleri ki = new kategoriIslemleri();
            rptKategoriler.DataSource = ki.kategorileriGetir();
            rptKategoriler.DataBind();
        }
        else
            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
    }
    protected void rptKategoriler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (e.CommandName == "CheckBoxKontrol")
        {
            int kategoriID = Convert.ToInt32(e.CommandArgument.ToString());

            baglanti kategoriBilgileri = new baglanti();
            kategoriBilgileri.verileriGetir("select kontrol from kategoriler where id='" + kategoriID.ToString() + "'");
            if (kategoriBilgileri.SQLTablo.Rows.Count > 0)
            {
                if (kategoriBilgileri.SQLTablo.Rows[0][0].ToString() == "1")
                {
                    baglanti durumGucelle = new baglanti();
                    if (durumGucelle.komutCalistir("update kategoriler set kontrol='0' where id='" + kategoriID.ToString() + "'") == "1")
                    {
                        kategoriIslemleri ki = new kategoriIslemleri();
                        rptKategoriler.DataSource = ki.kategorileriGetir();
                        rptKategoriler.DataBind();
                    }
                    else
                        mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
                else if (kategoriBilgileri.SQLTablo.Rows[0][0].ToString() == "0")
                {
                    baglanti durumGucelle = new baglanti();
                    if (durumGucelle.komutCalistir("update kategoriler set kontrol='1' where id='" + kategoriID.ToString() + "'") == "1")
                    {
                        kategoriIslemleri ki = new kategoriIslemleri();
                        rptKategoriler.DataSource = ki.kategorileriGetir();
                        rptKategoriler.DataBind();
                    }
                    else
                        mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
            }
        }
        if (e.CommandName == "GuncelleBTN")
        {
            int kategoriID = Convert.ToInt32(e.CommandArgument.ToString());
            TextBox baslikTXT = (TextBox)e.Item.FindControl("baslikTXT");

            baglanti durumGucelle = new baglanti();
            if (durumGucelle.komutCalistir("update kategoriler set baslik='" + baslikTXT.Text + "' where id='" + kategoriID.ToString() + "'") == "1")
            {
                kategoriIslemleri ki = new kategoriIslemleri();
                rptKategoriler.DataSource = ki.kategorileriGetir();
                rptKategoriler.DataBind();
                mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
        if (e.CommandName == "ProjeSilBTN")
        {
            int kategoriID = Convert.ToInt32(e.CommandArgument.ToString());
            int konrol= 0;
            baglanti bilgileriGetir = new baglanti();
            bilgileriGetir.verileriGetir("select id from projeler where kategoriID='" + kategoriID.ToString() + "'");
            if (bilgileriGetir.SQLTablo.Rows.Count > 0)
            {
                baglanti kategoriGucelle = new baglanti();
                if (kategoriGucelle.komutCalistir("update projeler set kategoriID='1' where kategoriID='" + kategoriID.ToString() + "'") == "1")
                    konrol = 1;
            }
            else
                konrol = 1;

            if (konrol == 1)
            {
                baglanti sil = new baglanti();
                if (sil.komutCalistir("delete from kategoriler where id='" + kategoriID.ToString() + "'") == "1")
                {
                    kategoriIslemleri ki = new kategoriIslemleri();
                    rptKategoriler.DataSource = ki.kategorileriGetir();
                    rptKategoriler.DataBind();
                    mainMesaj.Text = mesaj.goster("1", "Silindi");
                }
                else
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
        }
    }
}
