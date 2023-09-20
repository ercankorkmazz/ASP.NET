using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bilgiIMG.Visible = false;
        bilgiTXT.Text = "";
        if (Session["oturum"] == null)
            Response.Redirect("giris.aspx");

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
 /*   protected void Button1_Click(object sender, EventArgs e)
    {
        baglanti sinifKaydet = new baglanti();
        if (sinifKaydet.komutCalistir("DELETE FROM ogretmenler") == "1")
        {
            bilgiTXT.Text = "Sınıf SİLİNDİ.";
            bilgiIMG.Visible = true;
        }
    }*/
    protected void btnGonder_Click(object sender, EventArgs e)
    {
        baglanti kursKaydet = new baglanti();
        if (kursKaydet.komutCalistir("insert into kurs (kursAdi,fiyati,kontenjan,kursSuresi,ogretmenId) values ('" + kursTXT.Text + "','" + fiyatTXT.Text + "','" + kontenjanTXT.Text + "','" +kusSuresi.SelectedValue+ "','" + ogretmenler.SelectedValue + "')") == "1")
        {
            bilgiTXT.Text = "Kurs Eklendi.";
            bilgiIMG.Visible = true;
            kursTXT.Text = "";
            fiyatTXT.Text = "";
            kontenjanTXT.Text = "";
            kusSuresi.SelectedIndex = 0;
            ogretmenler.SelectedIndex = 0;

            baglanti kursGetir = new baglanti();
            kursGetir.verileriGetir("select top 1 * from kurs order by id desc");
            if (kursGetir.SQLTablo.Rows.Count > 0)
            {
                for (int i = 1; i <= 8; i++)
                {
                    string saat = "";
                    switch (i)
                    {
                        case 1:
                            saat = "08:30";
                            break;
                        case 2:
                            saat = "09:30";
                            break;
                        case 3:
                            saat = "10:30";
                            break;
                        case 4:
                            saat = "11:30";
                            break;
                        case 5:
                            saat = "13:00";
                            break;
                        case 6:
                            saat = "14:00";
                            break;
                        case 7:
                            saat = "15:00";
                            break;
                        case 8:
                            saat = "16:00";
                            break;

                    }
                    baglanti programKaydet = new baglanti();
                    if (programKaydet.komutCalistir("insert into programlar (kursId,saat,g1,g2,g3,g4,g5,g6,g7) values ('" + kursGetir.SQLTablo.Rows[0][0].ToString() + "','" + saat + "','','','','','','','')") == "0")
                    {
                        bilgiTXT.Text = "Program eklenmedi.";
                        bilgiIMG.Visible = true;
                    }
                }
            }
        }
        else
        {
            bilgiTXT.Text = "İşlem Başarısız. Lütfen Daha Sonra Tekrar Deneyiniz.";
            bilgiIMG.Visible = true;
        }
    }
}
