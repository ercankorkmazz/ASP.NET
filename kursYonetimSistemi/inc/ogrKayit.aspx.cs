using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ogrKayit : System.Web.UI.Page
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

        baglanti sinifListele = new baglanti();
        sinifListele.verileriGetir("select * from siniflar");
        if (sinifListele.SQLTablo.Rows.Count > 0)
        {
            if (sinif.Items.Count == 0)
            {
                sinif.Items.Add(new ListItem("Sınıf Seçiniz", "0"));

                for (int i = 0; i <= sinifListele.SQLTablo.Rows.Count - 1; i++)
                {
                    sinif.Items.Add(new ListItem(sinifListele.SQLTablo.Rows[i][1].ToString(), sinifListele.SQLTablo.Rows[i][0].ToString()));
                }
            }
        }
        else
        {
            sinif.Items.Clear();
            sinif.Items.Add(new ListItem("Sınıf Bulunamadı.", "0"));
        }
    }
    protected void dersSecBTN_Click(object sender, EventArgs e)
    {
        if (kursSecListele.SelectedValue == "0")
        {
            bilgiTXT.Text = "Kurs Seçiniz";
            bilgiIMG.Visible = true;

            kusID.Text = String.Empty;
            kusAdiTXT.Text = "-";
            kursSuresi.Text = "-";
            fiyatTXT.Text = "-";
            kontenjanTXT.Text = "-";
        }
        else
        {
            baglanti kursBilgisiListele = new baglanti();
            kursBilgisiListele.verileriGetir("select * from kurs where id='" + kursSecListele.SelectedValue + "'");
            if (kursBilgisiListele.SQLTablo.Rows.Count > 0)
            {
                kusID.Text = kursBilgisiListele.SQLTablo.Rows[0][0].ToString();
                kusAdiTXT.Text = kursBilgisiListele.SQLTablo.Rows[0][1].ToString();
                fiyatTXT.Text = kursBilgisiListele.SQLTablo.Rows[0][2].ToString() + " TL";
                kontenjanTXT.Text = kursBilgisiListele.SQLTablo.Rows[0][3].ToString();
                switch (kursBilgisiListele.SQLTablo.Rows[0][4].ToString())
                {
                    case "0":
                        kursSuresi.Text = "1 Hafta";
                        break;
                    case "1":
                        kursSuresi.Text = "2 Hafta";
                        break;
                    case "2":
                        kursSuresi.Text = "3 Hafta";
                        break;
                    case "3":
                        kursSuresi.Text = "4 Hafta";
                        break;
                    case "4":
                        kursSuresi.Text = "2 Ay";
                        break;
                    case "5":
                        kursSuresi.Text = "3 Ay";
                        break;
                    case "6":
                        kursSuresi.Text = "4 Ay";
                        break;
                    case "7":
                        kursSuresi.Text = "6 Ay";
                        break;
                }
            }
        }
    }
    protected void ornKaydetBTN_Click(object sender, EventArgs e)
    {
        if (kusID.Text == String.Empty)
        {
            bilgiTXT.Text = "Kurs Seçiniz";
            bilgiIMG.Visible = true;
        }
        else
        {
            baglanti ogrenciKaydet = new baglanti();
            if (ogrenciKaydet.komutCalistir("insert into ogrenciler (kursId, adSoyad, yas, cinsiyet, tc, sinif, tel, ePosta, adres) values ('" + kusID.Text + "','" + adSoyadTXT.Text + "','" + yasTXT.Text + "','" + cinsiyetRADIO.SelectedValue + "','" + tcTXT.Text + "','" + sinif.SelectedValue + "','" + telTXT.Text + "','" + ePostaTXT.Text + "','" + adresTXT.InnerText + "')") == "1")
            {
                bilgiTXT.Text = "Kayıt başarılı.";
                bilgiIMG.Visible = true;

                adSoyadTXT.Text = "";
                yasTXT.Text = "";
                tcTXT.Text = "";
                sinif.SelectedIndex = 0;
                telTXT.Text = "";
                ePostaTXT.Text = "";
                adresTXT.InnerText = "";
            }
            else
            {
                bilgiTXT.Text = "İşlem başarısız. İstenilen bilgileri doğru girdiğinizden emin olunuz.";
                bilgiIMG.Visible = true;
            }
        }
    }
}
