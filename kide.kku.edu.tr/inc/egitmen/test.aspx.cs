using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_egitmen_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "2")
        {
            Response.Redirect("~/Default.aspx");
        }

        baglanti testBilgileri = new baglanti();
        int egitmenID = Convert.ToInt32(Session[Request.Url.Authority + "oturum"]);
        int testID = Convert.ToInt32(Session[Request.Url.Authority + "testID"]);

        if (Page.IsPostBack == false)
        {
            testBilgileri.verileriGetir("select * from testler where id=" + testID);
            if (testBilgileri.SQLTablo.Rows.Count > 0)
            {
                if (Convert.ToInt32(testBilgileri.SQLTablo.Rows[0][1]) == egitmenID)
                {
                    testadiTXT.Text = testBilgileri.SQLTablo.Rows[0][2].ToString();

                    if (testBilgileri.SQLTablo.Rows[0][3].ToString() == "0")
                        durumu.Checked = false;
                    else if (testBilgileri.SQLTablo.Rows[0][3].ToString() == "1")
                        durumu.Checked = true;

                    tabloListele();
                    grupChkSorgula();
                    soruListele();
                    soruListesiDuzenle();
                }
                else
                    Response.Redirect("~/inc/egitmen/testler.aspx");
            }
            else
            {
                Response.Redirect("~/inc/egitmen/testler.aspx");
            }
        }
    }
    protected void testGuncelleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (testadiTXT.Text != "")
        {
            baglanti grupGuncelle = new baglanti();
            
            int testID = Convert.ToInt32(Session[Request.Url.Authority + "testID"]);
            String testAdi = testadiTXT.Text;
            if (testadiTXT.Text.Length >= 100)
                testAdi = testAdi.Remove(99).ToString();

            string idler = "";
            foreach (GridViewRow satirbilgi in GridView_gruplar.Rows)
            {
                CheckBox secimKutusu = (CheckBox)satirbilgi.FindControl("secim");
                if (secimKutusu.Checked)
                {
                    idler += satirbilgi.Cells[1].Text + ".";
                }
            }

            string durum = "0";
            if (durumu.Checked == true)
                durum = "1";

            if (idler.Length != 0)
            {
                int stringUzunlugu = Convert.ToInt32(idler.Length.ToString());
                stringUzunlugu -= 1;

                if (grupGuncelle.komutCalistir("update testler set testadi='" + testAdi + "', kontrol='" + durum + "', gruplar='" + idler.Substring(0, stringUzunlugu) + "' where id='" + testID + "'") == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "Test bilgileri güncellendi.");
                }
                else
                {
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
            }
            else
            {
                if (grupGuncelle.komutCalistir("update testler set testadi='" + testAdi + "', kontrol='" + durum + "', gruplar='' where id='" + testID + "'") == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "Test bilgileri güncellendi.");
                }
                else
                {
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
            }
            tabloListele();
            grupChkSorgula();
        }
        else
        {
            mainMesaj.Text = mesaj.goster("2", "Test başlığını yazınız!");
        }
    }
    public void tabloListele()
    {
        baglanti sorgu = new baglanti();

        int kontrol = 1;
        sorgu.verileriGetir("select id from gruplar");
        if (sorgu.SQLTablo.Rows.Count > 0)
        {
            GridView_gruplar.Visible = true;
            kontrol = 1;
        }
        else
        {
            kontrol = 0;
            GridView_gruplar.Visible = false;
        }

        if (kontrol == 1)
        {
            baglanti gruplarSecListele = new baglanti();
            gruplarSecListele.verileriGetir("select * from gruplar order by id");
            if (gruplarSecListele.SQLTablo.Rows.Count > 0)
            {
                GridView_gruplar.DataSource = gruplarSecListele.SQLTablo;
                GridView_gruplar.DataBind();
            }
        }
    }
    public void grupChkSorgula()
    {
        baglanti gruplarSorgu = new baglanti();
        gruplarSorgu.verileriGetir("select gruplar from testler where id='" + Session[Request.Url.Authority + "testID"] + "'");
        if (gruplarSorgu.SQLTablo.Rows.Count > 0)
        {
            if (gruplarSorgu.SQLTablo.Rows[0][0] != "")
            {
                String grpIdler = gruplarSorgu.SQLTablo.Rows[0][0].ToString();
                string[] grupIdler = grpIdler.Split('.');

                foreach (GridViewRow satirbilgi in GridView_gruplar.Rows)
                {
                    CheckBox chk = (CheckBox)satirbilgi.FindControl("secim");
                    for (int i = 0; i < grupIdler.Count(); i++)
                    {
                        if (satirbilgi.Cells[1].Text == grupIdler[i].ToString())
                            chk.Checked = true;
                    }
                }
            }
        }
    }
    public void soruListele()
    {
        baglanti sorgu = new baglanti();

        int kontrol = 1;
        sorgu.verileriGetir("select id from sorular where testID='" + Session[Request.Url.Authority + "testID"] + "'");
        if (sorgu.SQLTablo.Rows.Count > 0)
        {
            GridView_sorular.Visible = true;
            soruSilBTN.Visible = true;
            sorguSonucuSorular.Visible = false;
            kontrol = 1;
        }
        else
        {
            kontrol = 0;
            GridView_sorular.Visible = false;
            soruSilBTN.Visible = false;
            sorguSonucuSorular.Visible = true;
        }

        if (kontrol == 1)
        {
            baglanti gruplarSecListele = new baglanti();
            gruplarSecListele.verileriGetir("select id,soru,yanit,cevap,turu from sorular where testID='"+ Session[Request.Url.Authority + "testID"] +"' order by id");
            if (gruplarSecListele.SQLTablo.Rows.Count > 0)
            {
                GridView_sorular.DataSource = gruplarSecListele.SQLTablo;
                GridView_sorular.DataBind();
            }
        }
    }
    public void soruListesiDuzenle()
    {
        foreach (GridViewRow satirbilgi in GridView_sorular.Rows)
        {
            /*Regex html = new Regex("<.*?>", RegexOptions.Compiled);
            string gelenMetin = (satirbilgi.Cells[2].Text).ToString();
            string sonuc = html.Replace((string)gelenMetin, string.Empty);

            satirbilgi.Cells[2].Text = sonuc;*/
            if (satirbilgi.Cells[5].Text == "1")
            {
                if (satirbilgi.Cells[4].Text == "1")
                {
                    satirbilgi.Cells[4].Text = "A";
                }
                else if (satirbilgi.Cells[4].Text == "2")
                {
                    satirbilgi.Cells[4].Text = "B";
                }
                else if (satirbilgi.Cells[4].Text == "3")
                {
                    satirbilgi.Cells[4].Text = "C";
                }
                else if (satirbilgi.Cells[4].Text == "4")
                {
                    satirbilgi.Cells[4].Text = "D";
                }
                else if (satirbilgi.Cells[4].Text == "5")
                {
                    satirbilgi.Cells[4].Text = "E";
                }
            }
            else if (satirbilgi.Cells[5].Text == "3")
            {
                if (satirbilgi.Cells[4].Text == "1")
                {
                    satirbilgi.Cells[4].Text = "D";
                }
                else if (satirbilgi.Cells[4].Text == "2")
                {
                    satirbilgi.Cells[4].Text = "Y";
                }
            }
            if (satirbilgi.Cells[5].Text == "1")
                satirbilgi.Cells[5].Text = "Çoktan Seçmeli";
            else if (satirbilgi.Cells[5].Text == "2")
                satirbilgi.Cells[5].Text = "Boşluk Doldurma";
            else if (satirbilgi.Cells[5].Text == "3")
                satirbilgi.Cells[5].Text = "Doğru Yanlış";
        }
    }
    protected void bilgiBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        mainMesaj.Text = mesaj.bilgi("Testin görüntülenmesini istediğiniz grupları yandaki tablodan seçiniz.", 7000);
    }
    protected void boslukDoldurBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        int testID = Convert.ToInt32(Session[Request.Url.Authority + "testID"]);

        if (boslukDoldurmaSorusu.InnerText != "")
        {
            if (boslukDoldurCevabi.Text != "")
            {
                baglanti coktanSecmeliSoruEkle = new baglanti();
                if (coktanSecmeliSoruEkle.komutCalistir("insert into sorular (testID,soru,cevap,turu) values ('" + testID + "', '" + boslukDoldurmaSorusu.InnerText + "', '" + boslukDoldurCevabi.Text + "', '2')") == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "Soru Kaydedildi");
                    boslukDoldurmaSorusu.InnerText = "";
                    boslukDoldurCevabi.Text = "";

                    soruListele();
                    soruListesiDuzenle();
                }
                else
                {
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "Cevap yazınız.");
            }
        }
        else
        {
            mainMesaj.Text = mesaj.goster("2", "Soruyu yazınız.");
        }
    }
    protected void dogruYanlisKaydet_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        int testID = Convert.ToInt32(Session[Request.Url.Authority + "testID"]);

        if (dogruYanlisCevap.SelectedValue != String.Empty)
        {
            if (dogruYanlisSorusu.InnerText != "")
            {
                baglanti dogruYanlisSoruEkle = new baglanti();
                if (dogruYanlisSoruEkle.komutCalistir("insert into sorular (testID,soru,yanit,turu) values ('" + testID + "', '" + dogruYanlisSorusu.InnerText + "', '" + dogruYanlisCevap.SelectedValue + "', '3')") == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "Soru Kaydedildi");
                    dogruYanlisCevap.SelectedIndex = -1;
                    dogruYanlisSorusu.InnerText = "";

                    soruListele();
                    soruListesiDuzenle();
                }
                else
                {
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "Soruyu yazınız.");
            }
        }
        else
        {
            mainMesaj.Text = mesaj.goster("2", "Yanıtı işaretleyiniz.");
        }
    }
    protected void coktanSecKaydetBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        int testID = Convert.ToInt32(Session[Request.Url.Authority + "testID"]);

        if (coktanSecmeliCevaplar.SelectedValue != String.Empty)
        {
            if (coktanSecSoru.InnerText != "")
            {
                int yardimci = 0;
                baglanti coktanSecmeliSoruEkle = new baglanti();
                if (coktanSecmeliSoruEkle.komutCalistir("insert into sorular (testID,soru,yanit,turu) values ('" + testID + "', '" + coktanSecSoru.InnerText + "', '" + coktanSecmeliCevaplar.SelectedValue + "', '1')") == "1")
                {
                    yardimci = 1;
                    coktanSecmeliCevaplar.SelectedIndex = -1;
                    coktanSecSoru.InnerText = "";
                }
                else
                {
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
                if (yardimci == 1)
                {
                    string soruID = "";
                    baglanti soruGetir = new baglanti();
                    soruGetir.verileriGetir("select TOP 1 * from sorular order by id desc");
                    if (soruGetir.SQLTablo.Rows.Count > 0)
                    {
                        soruID = soruGetir.SQLTablo.Rows[0][0].ToString();
                    }

                    yardimci=0;
                    for (int i = 1; i <= 5; i++)
                    {
                        if (i == 1)
                        {
                            baglanti cevap1Ekle = new baglanti();
                            if (cevap1Ekle.komutCalistir("insert into cevaplar (soruID,yanitNo,yanit) values ('" + soruID + "', '" + i + "', '" + secenek1.Text + "')") == "1")
                            {
                                secenek1.Text = "";
                                yardimci=1;
                            }
                        }
                        else if (i == 2)
                        {
                            baglanti cevap2Ekle = new baglanti();
                            if (cevap2Ekle.komutCalistir("insert into cevaplar (soruID,yanitNo,yanit) values ('" + soruID + "', '" + i + "', '" + secenek2.Text + "')") == "1")
                            {
                                secenek2.Text = "";
                                yardimci = 1;
                            }
                        }
                        else if (i == 3)
                        {
                            baglanti cevap3Ekle = new baglanti();
                            if (cevap3Ekle.komutCalistir("insert into cevaplar (soruID,yanitNo,yanit) values ('" + soruID + "', '" + i + "', '" + secenek3.Text + "')") == "1")
                            {
                                secenek3.Text = "";
                                yardimci = 1;
                            }
                        }
                        else if (i == 4)
                        {
                            baglanti cevap4Ekle = new baglanti();
                            if (cevap4Ekle.komutCalistir("insert into cevaplar (soruID,yanitNo,yanit) values ('" + soruID + "', '" + i + "', '" + secenek4.Text + "')") == "1")
                            {
                                secenek4.Text = "";
                                yardimci = 1;
                            }
                        }
                        else if (i == 5)
                        {
                            baglanti cevap5Ekle = new baglanti();
                            if (cevap5Ekle.komutCalistir("insert into cevaplar (soruID,yanitNo,yanit) values ('" + soruID + "', '" + i + "', '" + secenek5.Text + "')") == "1")
                            {
                                secenek5.Text = "";
                                yardimci = 1;
                            }
                        }
                    }
                    if (yardimci == 1)
                    {
                        mainMesaj.Text = mesaj.goster("1", "Soru Kaydedildi");

                        soruListele();
                        soruListesiDuzenle();
                    }
                }
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "Soruyu yazınız.");
            }
        }
        else
        {
            mainMesaj.Text = mesaj.goster("2", "Yanıtı işaretleyiniz.");
        }
    }
    protected void soruSilBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        string idler = "";
        foreach (GridViewRow satirbilgi in GridView_sorular.Rows)
        {
            CheckBox secimKutusu = (CheckBox)satirbilgi.FindControl("secim");
            if (secimKutusu != null && secimKutusu.Checked)
            {
                idler += "id=" + satirbilgi.Cells[1].Text + " or ";

                baglanti yanitSil = new baglanti();
                yanitSil.komutCalistir("delete from cevaplar where soruID=" + satirbilgi.Cells[1].Text);
            }
        }

        if (idler != "")
        {
            baglanti soruSil = new baglanti();
            if (soruSil.komutCalistir("delete from sorular where " + idler.Remove(idler.Length - 4, 4)) == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Seçili sorular silindi.");
                soruListele();
                soruListesiDuzenle();
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
    }
    protected void GridView_sorular_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex = GridView_sorular.SelectedIndex;
        GridViewRow row = GridView_sorular.Rows[selectedRowIndex];
        int soruID = Convert.ToInt32(row.Cells[1].Text);

        int soruTuru = 0;
        if (row.Cells[5].Text == "Çoktan Seçmeli")
            soruTuru = 1;
        else if (row.Cells[5].Text == "Boşluk Doldurma")
            soruTuru = 2;
        else if (row.Cells[5].Text == "Doğru Yanlış")
            soruTuru = 3;

        Session[Request.Url.Authority + "soruID"] = soruID;
        Session[Request.Url.Authority + "soruTuru"] = soruTuru;
        Response.Redirect("~/inc/egitmen/soru.aspx");
    }
}