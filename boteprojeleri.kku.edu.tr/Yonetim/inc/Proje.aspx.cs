using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_inc_Proje : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "projeID"] == null)
            Response.Redirect("~/Yonetim/inc/Projeler.aspx");
        if (Page.IsPostBack == false)
        {
            projeListele();
        }
    }
    public void projeListele()
    {
        baglanti bilgileriGetir = new baglanti();
        bilgileriGetir.verileriGetir("select * from projeler where id='" + Session[Request.Url.Authority + "projeID"].ToString() + "'");
        if (bilgileriGetir.SQLTablo.Rows.Count > 0)
        {
            projeBasligiLABEL.Text = bilgileriGetir.SQLTablo.Rows[0][2].ToString();
            projeBasligiTXT.Text = bilgileriGetir.SQLTablo.Rows[0][2].ToString();
            kisaAciklamaTXT.InnerText = bilgileriGetir.SQLTablo.Rows[0][3].ToString();
            projeHakkindaTXT.InnerText = bilgileriGetir.SQLTablo.Rows[0][4].ToString();
            projeEkibiTXT.InnerText = bilgileriGetir.SQLTablo.Rows[0][5].ToString();
            yayinlarTXT.InnerText = bilgileriGetir.SQLTablo.Rows[0][6].ToString();
            duyurularTXT.InnerText = bilgileriGetir.SQLTablo.Rows[0][7].ToString();
            urlTXT.Text = bilgileriGetir.SQLTablo.Rows[0][9].ToString();
            kategoriListele();
            urlKontrolu();

            if (bilgileriGetir.SQLTablo.Rows[0][8].ToString() == string.Empty)
            {
                resimSilBTN.Visible = false;
                resimGoruntuleBTN.Visible = false;
                resimBilgiLABEL.Visible = true;
            }
            else
            {
                resimSilBTN.Visible = true;
                resimGoruntuleBTN.Visible = true;
                resimBilgiLABEL.Visible = false;
                resimGoruntuleBTN.HRef = "~/img/projeler/" + bilgileriGetir.SQLTablo.Rows[0][8].ToString();
            }
        }
    }
    public void kategoriListele()
    {
        int kategoriID = 1;
        baglanti bilgileriGetir = new baglanti();
        bilgileriGetir.verileriGetir("select kategoriID from projeler where id='" + Session[Request.Url.Authority + "projeID"].ToString() + "'");
        if (bilgileriGetir.SQLTablo.Rows.Count > 0)
            kategoriID = Convert.ToInt32(bilgileriGetir.SQLTablo.Rows[0][0].ToString());

        baglanti kategorileriGetir = new baglanti();
        kategorileriGetir.verileriGetir("select * from kategoriler");
        if (kategorileriGetir.SQLTablo.Rows.Count > 0)
        {
            if (kategorilerDropDownList.Items.Count == 0)
            {
                for (int i = 0; i <= kategorileriGetir.SQLTablo.Rows.Count - 1; i++)
                {
                    kategorilerDropDownList.Items.Insert(i, new ListItem(kategorileriGetir.SQLTablo.Rows[i][1].ToString(), kategorileriGetir.SQLTablo.Rows[i][0].ToString()));
                    if (kategoriID.ToString() == kategorileriGetir.SQLTablo.Rows[i][0].ToString())
                        kategorilerDropDownList.SelectedIndex = i;
                }
            }
        }
        else
        {
            kategorilerDropDownList.Items.Clear();
            kategorilerDropDownList.Items.Add(new ListItem("Kategori ekleyiniz.", "0"));
        }
    }
    public void urlKontrolu()
    {
        baglanti bilgileriGetir = new baglanti();
        bilgileriGetir.verileriGetir("select kontrol from projeler where id='" + Session[Request.Url.Authority + "projeID"].ToString() + "'");
        if (bilgileriGetir.SQLTablo.Rows.Count > 0)
        {
            if(bilgileriGetir.SQLTablo.Rows[0][0].ToString()=="0")
            {
                kontrolBTN.CssClass = "KapaliBTN";
                kontrolBTN.Text = "Pasif";
            }
            else if(bilgileriGetir.SQLTablo.Rows[0][0].ToString() == "1")
            {
                kontrolBTN.CssClass = "AcikBTN";
                kontrolBTN.Text = "Aktif";
            }
        }
    }
    protected void kontrolBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        baglanti bilgileriGetir = new baglanti();
        bilgileriGetir.verileriGetir("select kontrol from projeler where id='" + Session[Request.Url.Authority + "projeID"].ToString() + "'");
        if (bilgileriGetir.SQLTablo.Rows.Count > 0)
        {
            if (bilgileriGetir.SQLTablo.Rows[0][0].ToString() == "0")
            {
                baglanti durumGucelle = new baglanti();
                if (durumGucelle.komutCalistir("update projeler set kontrol='1' where id='" + Session[Request.Url.Authority + "projeID"].ToString() + "'") == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "URL Aktif");
                }
                else
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
            else if(bilgileriGetir.SQLTablo.Rows[0][0].ToString() == "1")
            {
                baglanti durumGucelle = new baglanti();
                if (durumGucelle.komutCalistir("update projeler set kontrol='0' where id='" + Session[Request.Url.Authority + "projeID"].ToString() + "'") == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "URL Pasif");
                }
                else
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
        }
        urlKontrolu();
    }
    protected void kaydetBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (projeBasligiTXT.Text != string.Empty)
        {
            if (kategorilerDropDownList.SelectedIndex != 0)
            {
                HttpPostedFile yuklenecekDosya = fluDosya.PostedFile;
                if (yuklenecekDosya.FileName.ToString() != "")
                {
                    if (yuklenecekDosya != null)
                    {
                        string dosyauzantisi = Path.GetExtension(yuklenecekDosya.FileName);
                        if (dosyauzantisi.ToLower() == ".jpg" || dosyauzantisi.ToLower() == ".jpeg" || dosyauzantisi.ToLower() == ".png")
                        {
                            int kontrol = 0;
                            baglanti bilgileriGetir = new baglanti();
                            bilgileriGetir.verileriGetir("select img from projeler where id='" + Session[Request.Url.Authority + "projeID"].ToString() + "'");
                            if (bilgileriGetir.SQLTablo.Rows.Count > 0)
                            {
                                if (bilgileriGetir.SQLTablo.Rows[0][0].ToString() != string.Empty)
                                {
                                    File.Delete(Server.MapPath("~/img/projeler/" + bilgileriGetir.SQLTablo.Rows[0][0].ToString()));
                                    baglanti resimURLSil = new baglanti();
                                    if (resimURLSil.komutCalistir("update projeler set img='' where id='" + Session[Request.Url.Authority + "projeID"].ToString() + "'") == "1")
                                        kontrol = 1;
                                }
                                else
                                    kontrol = 1;
                            }
                            if (kontrol == 1)
                            {
                                //FileInfo dosyaBilgisi = new FileInfo(yuklenecekDosya.FileName);
                                DateTime dosyaAdi = DateTime.Now;
                                string dosya = dosyaAdi.ToString() + dosyauzantisi.ToString();
                                dosya = dosya.Replace(':', '-');
                                dosya = dosya.Replace(' ', '-');

                                string yuklemeYeri = Server.MapPath("~/img/projeler/" + dosya);
                                fluDosya.SaveAs(yuklemeYeri);

                                //string videoName = dosyaBilgisi.Name.ToString();
                                baglanti resimliGüncellemeYap = new baglanti();
                                string kisaAciklama = kisaAciklamaTXT.InnerText;
                                string[] html = new string[] { "<p>", "</p>", "<h1>", "</h1>", "<h2>", "</h2>", "<h3>", "</h3>", "<h4>", "</h4>", "<h5>", "</h5>", "<h6>", "</h6>", "<pre>", "</pre>", "<address>", "</address>", "<div>", "</div>", "<hr />" };
                                foreach (string deger in html)
                                {
                                    kisaAciklama = kisaAciklama.Replace(deger, string.Empty);
                                }
                                if (resimliGüncellemeYap.komutCalistir("update projeler set kategoriID='" + kategorilerDropDownList.SelectedValue + "', projeBasligi='" + projeBasligiTXT.Text + "', kisaAciklama='" + kisaAciklama + "', projeHakkinda='" + projeHakkindaTXT.InnerText + "', projeEkibi='" + projeEkibiTXT.InnerText + "', yayinlar='" + yayinlarTXT.InnerText + "', duyurular='" + duyurularTXT.InnerText + "', img='" + dosya + "', url='" + urlTXT.Text + "' where id='" + Session[Request.Url.Authority + "projeID"].ToString() + "'") == "1")
                                {
                                    mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
                                    projeListele();
                                }
                                else
                                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                            }
                        }
                        else
                            mainMesaj.Text = mesaj.goster("2", dosyauzantisi.ToLower() + " dosya türünü sisteme yükleyemezsiniz.");
                    }
                }
                else
                {
                    baglanti resimsizGüncellemeYap = new baglanti();
                    string kisaAciklama = kisaAciklamaTXT.InnerText;
                    string[] html = new string[] { "<p>", "</p>", "<h1>", "</h1>", "<h2>", "</h2>", "<h3>", "</h3>", "<h4>", "</h4>", "<h5>", "</h5>", "<h6>", "</h6>", "<pre>", "</pre>", "<address>", "</address>", "<div>", "</div>", "<hr />" };
                    foreach (string deger in html)
                    {
                        kisaAciklama = kisaAciklama.Replace(deger, string.Empty);
                    }
                    if (resimsizGüncellemeYap.komutCalistir("update projeler set kategoriID='" + kategorilerDropDownList.SelectedValue + "', projeBasligi='" + projeBasligiTXT.Text + "', kisaAciklama='" + kisaAciklama + "', projeHakkinda='" + projeHakkindaTXT.InnerText + "', projeEkibi='" + projeEkibiTXT.InnerText + "', yayinlar='" + yayinlarTXT.InnerText + "', duyurular='" + duyurularTXT.InnerText + "', url='" + urlTXT.Text + "' where id='" + Session[Request.Url.Authority + "projeID"].ToString() + "'") == "1")
                    {
                        mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
                        projeListele();
                    }
                    else
                        mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
            }
            else
                mainMesaj.Text = mesaj.goster("2", "Kategori seçiniz.");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "Proje başlığı yazınız!");
    }
    protected void resimSilBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        baglanti bilgileriGetir = new baglanti();
        bilgileriGetir.verileriGetir("select img from projeler where id='" + Session[Request.Url.Authority + "projeID"].ToString() + "'");
        if (bilgileriGetir.SQLTablo.Rows.Count > 0)
        {
            if (bilgileriGetir.SQLTablo.Rows[0][0].ToString() != string.Empty)
            {
                File.Delete(Server.MapPath("~/img/projeler/" + bilgileriGetir.SQLTablo.Rows[0][0].ToString()));
                baglanti resimURLSil = new baglanti();
                if (resimURLSil.komutCalistir("update projeler set img='' where id='" + Session[Request.Url.Authority + "projeID"].ToString() + "'") == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "Resim Silindi");
                    projeListele();
                }   
            }
            else
                mainMesaj.Text = mesaj.goster("2", "Yüklü Resim Yok");
        }
    }
}