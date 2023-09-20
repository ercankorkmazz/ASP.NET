using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_yonetim_egitmenKaydi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "1")
        {
            Response.Redirect("~/Default.aspx");
        }
        listeleBTN.Visible = true;
        GridView_egitmen.Visible = false;
        sorguSonucu.Visible = false;
        egitmenSilBTN.Visible = false;
    }
    public void tabloListele()
    {
        baglanti sorgu = new baglanti();
        listeleBTN.Visible = false;
        int kontrol = 1;
        sorgu.verileriGetir("select id from kullanici where kontrol='2'");
        if (sorgu.SQLTablo.Rows.Count > 0)
            kontrol = 1;
        else
        {
            kontrol = 0;
            GridView_egitmen.Visible = false;
            sorguSonucu.Visible = true;
            egitmenSilBTN.Visible = false;
        }

        if (kontrol == 1)
        {
            GridView_egitmen.Visible = true;
            sorguSonucu.Visible = false;
            egitmenSilBTN.Visible = true;

            baglanti Listele = new baglanti();
            Listele.verileriGetir("select * from kullanici where kontrol='2' order by id");
            if (Listele.SQLTablo.Rows.Count > 0)
            {
                GridView_egitmen.DataSource = Listele.SQLTablo;
                GridView_egitmen.DataBind();
                tabloDuzenle();
            }
        }
    }
    public void tabloDuzenle()
    {
        foreach (GridViewRow satirbilgi in GridView_egitmen.Rows)
        {
            baglanti Listele = new baglanti();
            Listele.verileriGetir("select guncelleme from kullanici where id='" + satirbilgi.Cells[1].Text + "'");
            if (Listele.SQLTablo.Rows.Count > 0)
            {
                string durum = Listele.SQLTablo.Rows[0][0].ToString();
                if (durum == "1")
                    satirbilgi.Cells[6].Text = "Güncellendi";
            }
        }
    }
    protected void egitmenEkleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (egitmenAdiTXT.Text != "")
        {
            baglanti kullaniciEkle = new baglanti();

            Random rastgele = new Random();
            string sifre = "";
            string kadi = "Eğitmen";
            for (int i = 0; i < 5; i++)
            {
                int kontrol = rastgele.Next(1, 3);
                if (kontrol == 1)
                    sifre += rastgele.Next(10);
                else if (kontrol == 2)
                {
                    int ascii = rastgele.Next(65, 91);
                    char karakter = Convert.ToChar(ascii);
                    sifre += karakter.ToString();
                }
            }

            String egitmenAdi = egitmenAdiTXT.Text;
            if (egitmenAdiTXT.Text.Length >= 30)
                egitmenAdi = egitmenAdi.Remove(29).ToString();

            int yardimci = 0;
            if (kullaniciEkle.komutCalistir("insert into kullanici (kadi,sifre,kontrol,adSoyad) values ('" + kadi + "', '" + sifre + "', '2', '" + egitmenAdi + "')") == "1")
            {
                yardimci = 1;
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
            if (yardimci == 1)
            {
                string kullaniciID = "";
                baglanti kullaniciGetir = new baglanti();
                kullaniciGetir.verileriGetir("select TOP 1 * from kullanici order by id desc");
                if (kullaniciGetir.SQLTablo.Rows.Count > 0)
                {
                    kullaniciID = kullaniciGetir.SQLTablo.Rows[0][0].ToString();
                    kadi = "Eğitmen" + kullaniciID;
                }

                baglanti egitmenEkle = new baglanti();
                if (egitmenEkle.komutCalistir("update kullanici set kadi='" + kadi + "' where id='" + kullaniciID + "'") == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "Kayıt Başarılı");
                    egitmenAdiTXT.Text = "";
                    tabloListele();
                }
                else
                {
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
            }
        }
        else
        {
            mainMesaj.Text = mesaj.goster("2", "Eğitmen adını yazınız!");
        }
    }
    protected void egitmenSilBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        string idler = "";
        string yardim = "";
        string testIDler = "";
        string soruIDler = "";
        string cevapIDler = "";
        foreach (GridViewRow satirbilgi in GridView_egitmen.Rows)
        {
            CheckBox secimKutusu = (CheckBox)satirbilgi.FindControl("secim");
            if (secimKutusu != null && secimKutusu.Checked)
            {
                baglanti yorulariSil = new baglanti();
                    yorulariSil.komutCalistir("delete from yorumlar where egitmenID='" + satirbilgi.Cells[1].Text + "'");
                
                baglanti egiticiVideoSil = new baglanti();
                    egiticiVideoSil.komutCalistir("delete from egiticivideolar where egitmenID='" + satirbilgi.Cells[1].Text + "'");
                
                baglanti testListele = new baglanti();
                testListele.verileriGetir("select id from testler where egitmenID='" + satirbilgi.Cells[1].Text + "'");
                
                if (testListele.SQLTablo.Rows.Count > 0)
                {
                    for (int i = 0; i <= testListele.SQLTablo.Rows.Count - 1; i++)
                    {
                        testIDler += "id=" + testListele.SQLTablo.Rows[i][0] + " or ";
                        soruIDler += "testID=" + testListele.SQLTablo.Rows[i][0] + " or ";

                        baglanti soruListele = new baglanti();
                        soruListele.verileriGetir("select id from sorular where testID='" + testListele.SQLTablo.Rows[i][0] + "' and turu='1'");
                        if (soruListele.SQLTablo.Rows.Count > 0)
                        {
                            for (int k = 0; k <= soruListele.SQLTablo.Rows.Count - 1; k++)
                            {
                                cevapIDler += "soruID=" + soruListele.SQLTablo.Rows[k][0] + " or ";
                            }
                        }
                    }
                }
                idler += "id=" + satirbilgi.Cells[1].Text + " or ";
            }
        }
        if(cevapIDler != String.Empty)
        {
            baglanti cevapSil = new baglanti();
            cevapSil.komutCalistir("delete from cevaplar where " + cevapIDler.Remove(cevapIDler.Length - 4, 4));
        }
        if(soruIDler != String.Empty)
        {
            baglanti soruSil = new baglanti();
            soruSil.komutCalistir("delete from sorular where " + soruIDler.Remove(soruIDler.Length - 4, 4));
        }
        if(testIDler != String.Empty)
        {
            baglanti testSil = new baglanti();
            testSil.komutCalistir("delete from testler where " + testIDler.Remove(testIDler.Length - 4, 4));
        }
        if(idler != String.Empty)
        {
            baglanti egitmenSil = new baglanti();
            if (egitmenSil.komutCalistir("delete from kullanici where " + idler.Remove(idler.Length - 4, 4)) == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Seçili eğitmenler silindi.");
                tabloListele();
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
    }
    protected void grubaGoreListeleBTN_Click(object sender, EventArgs e)
    {
        tabloListele();
    }
}