using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class kursGuncelle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bilgiIMG.Visible = false;
        bilgiTXT.Text = "";

        baglanti kursListele = new baglanti();
        kursListele.verileriGetir("select * from kurs");
        if (kursListele.SQLTablo.Rows.Count > 0)
        {
            if (kursSecListele.Items.Count == 0)
            {
                kursSecListele.Items.Add(new ListItem("Kurs Seçiniz", "0"));

                for (int i = 0; i <= kursListele.SQLTablo.Rows.Count - 1; i++)
                {
                    kursSecListele.Items.Add(new ListItem(kursListele.SQLTablo.Rows[i][1].ToString(), kursListele.SQLTablo.Rows[i][0].ToString()));
                }
            }
        }
        else
        {
            kursSecListele.Items.Clear();
            kursSecListele.Items.Add(new ListItem("Kurs Bulunamadı.", "0"));
        }

        baglanti ogretmenListele = new baglanti();
        ogretmenListele.verileriGetir("select * from ogretmenler");
        if (ogretmenListele.SQLTablo.Rows.Count > 0)
        {
            if (ogretmenler.Items.Count == 0)
            {
                ogretmenler.Items.Add(new ListItem("Öğretmen Seçiniz", "0"));

                for (int i = 0; i <= ogretmenListele.SQLTablo.Rows.Count - 1; i++)
                {
                    ogretmenler.Items.Add(new ListItem(ogretmenListele.SQLTablo.Rows[i][2].ToString(), ogretmenListele.SQLTablo.Rows[i][0].ToString()));
                }
            }
        }
        else
        {
            ogretmenler.Items.Clear();
            ogretmenler.Items.Add(new ListItem("Öğretmen Bulunamadı.", "0"));
        }
    }
    protected void kursSec_Click(object sender, EventArgs e)
    {
        if (kursSecListele.SelectedValue == "0")
        {
            bilgiTXT.Text = "Kurs Seçiniz";
            bilgiIMG.Visible = true;
        }
        else
        {
            baglanti kursBilgisiListele = new baglanti();
            kursBilgisiListele.verileriGetir("select * from kurs where id='" + kursSecListele.SelectedValue + "'");
            if (kursBilgisiListele.SQLTablo.Rows.Count > 0)
            {
                kusID.Text = kursBilgisiListele.SQLTablo.Rows[0][0].ToString();
                kusAdiTXT.Text = kursBilgisiListele.SQLTablo.Rows[0][1].ToString();
                fiyatTXT.Text = kursBilgisiListele.SQLTablo.Rows[0][2].ToString();
                kontenjanTXT.Text = kursBilgisiListele.SQLTablo.Rows[0][3].ToString();
                switch (kursBilgisiListele.SQLTablo.Rows[0][4].ToString())
                {
                    case "0":
                        kursSuresi.SelectedIndex = 0;
                        break;
                    case "1":
                        kursSuresi.SelectedIndex = 1;
                        break;
                    case "2":
                        kursSuresi.SelectedIndex = 2;
                        break;
                    case "3":
                        kursSuresi.SelectedIndex = 3;
                        break;
                    case "4":
                        kursSuresi.SelectedIndex = 4;
                        break;
                    case "5":
                        kursSuresi.SelectedIndex = 5;
                        break;
                    case "6":
                        kursSuresi.SelectedIndex = 6;
                        break;
                    case "7":
                        kursSuresi.SelectedIndex = 7;
                        break;
                }
                ogretmenler.Items.Clear();
                baglanti ogretmenListele = new baglanti();
                ogretmenListele.verileriGetir("select * from ogretmenler");
                if (ogretmenListele.SQLTablo.Rows.Count > 0)
                {
                    if (ogretmenler.Items.Count == 0)
                    {
                        ogretmenler.Items.Add(new ListItem("Öğretmen Seçiniz", "0"));

                        for (int i = 0; i <= ogretmenListele.SQLTablo.Rows.Count - 1; i++)
                        {
                            ogretmenler.Items.Add(new ListItem(ogretmenListele.SQLTablo.Rows[i][2].ToString(), ogretmenListele.SQLTablo.Rows[i][0].ToString()));
                            if (ogretmenListele.SQLTablo.Rows[i][0].ToString() == kursBilgisiListele.SQLTablo.Rows[0][5].ToString())
                            {
                                ogretmenler.SelectedIndex = i + 1;
                            }
                        }
                    }
                }
                else
                {
                    ogretmenler.Items.Clear();
                    ogretmenler.Items.Add(new ListItem("Öğretmen Bulunamadı.", "0"));
                }
            }
        }
    }
    protected void  kursGuncelle_Click(object sender, EventArgs e)
    {
        if (kusID.Text == String.Empty)
        {
            bilgiTXT.Text = "Kurs Seçiniz";
            bilgiIMG.Visible = true;
        }
        else
        {
            baglanti kursGuncelle = new baglanti();
            if (kursGuncelle.komutCalistir("update kurs set kursAdi='" + kusAdiTXT.Text + "' , fiyati='" + fiyatTXT.Text + "' , kontenjan='" + kontenjanTXT.Text + "' , kursSuresi='" + kursSuresi.SelectedValue + "' , ogretmenId='" + ogretmenler.SelectedValue + "' where id='" + kusID.Text + "'") == "1")
            {
                bilgiTXT.Text = "Kurs Güncellendi.";
                bilgiIMG.Visible = true;
                kusAdiTXT.Text = "";
                kontenjanTXT.Text = "";
                fiyatTXT.Text = "";
                kusID.Text = String.Empty;
                kursSuresi.SelectedIndex = 0;
                ogretmenler.SelectedIndex = 0;

                kursSecListele.Items.Clear();
                baglanti kursListele = new baglanti();
                kursListele.verileriGetir("select * from kurs");
                if (kursListele.SQLTablo.Rows.Count > 0)
                {
                    if (kursSecListele.Items.Count == 0)
                    {
                        kursSecListele.Items.Add(new ListItem("Kurs Seçiniz", "0"));

                        for (int i = 0; i <= kursListele.SQLTablo.Rows.Count - 1; i++)
                        {
                            kursSecListele.Items.Add(new ListItem(kursListele.SQLTablo.Rows[i][1].ToString(), kursListele.SQLTablo.Rows[i][0].ToString()));
                        }
                    }
                }
                else
                {
                    kursSecListele.Items.Clear();
                    kursSecListele.Items.Add(new ListItem("Kurs Bulunamadı.", "0"));
                }
            }
            else
            {
                bilgiTXT.Text = "İşlem Başarısız. Lütfen Daha Sonra Tekrar Deneyiniz.";
                bilgiIMG.Visible = true;
            }
        }
    }
    protected void kursSil_Click(object sender, EventArgs e)
    {
        if (kusID.Text == String.Empty)
        {
            bilgiTXT.Text = "Kurs Seçiniz";
            bilgiIMG.Visible = true;
        }
        else 
        {
            baglanti kursSil = new baglanti();
            if (kursSil.komutCalistir("delete from kurs where id='" + kusID.Text + "'") == "1")
            {
                baglanti programSil = new baglanti();
                programSil.komutCalistir("delete from programlar where kursId='" + kusID.Text + "'");

                bilgiTXT.Text = "Kurs Silindi.";
                bilgiIMG.Visible = true;

                kusAdiTXT.Text = "";
                kontenjanTXT.Text = "";
                fiyatTXT.Text = "";
                kusID.Text = String.Empty;
                kursSuresi.SelectedIndex = 0;
                ogretmenler.SelectedIndex = 0;

                kursSecListele.Items.Clear();
                baglanti kursListele = new baglanti();
                kursListele.verileriGetir("select * from kurs");
                if (kursListele.SQLTablo.Rows.Count > 0)
                {
                    if (kursSecListele.Items.Count == 0)
                    {
                        kursSecListele.Items.Add(new ListItem("Kurs Seçiniz", "0"));

                        for (int i = 0; i <= kursListele.SQLTablo.Rows.Count - 1; i++)
                        {
                            kursSecListele.Items.Add(new ListItem(kursListele.SQLTablo.Rows[i][1].ToString(), kursListele.SQLTablo.Rows[i][0].ToString()));
                        }
                    }
                }
                else
                {
                    kursSecListele.Items.Clear();
                    kursSecListele.Items.Add(new ListItem("Kurs Bulunamadı.", "0"));
                }
            }
            else
            {
                bilgiTXT.Text = "İşlem Başarısız. Lütfen Daha Sonra Tekrar Deneyiniz.";
                bilgiIMG.Visible = true;
            }
        }
    }
}
