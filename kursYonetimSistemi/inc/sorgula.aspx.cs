using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sorgula : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        seciliyiGucelle.Visible = false;
        ogretmenGuncelle.Visible = false;

        bilgiTXT.Text = "";
        bilgiIMG.Visible = false;

        if (kontrolTXT.Text == String.Empty)
        {
            GridView_ogretmen.Visible = false;
            GridView_ogrenci.Visible = false;
            silBTN.Visible = false;
            karsilama.Visible = true;
        }
        else if (kontrolTXT.Text == "1")
        {
            GridView_ogrenci.Visible = true;
            GridView_ogretmen.Visible = false;
            silBTN.Visible = true;
            karsilama.Visible = false;
        }
        else if (kontrolTXT.Text == "2")
        {
            GridView_ogrenci.Visible = false;
            GridView_ogretmen.Visible = true;
            silBTN.Visible = true;
            karsilama.Visible = false;
        }
    }
    protected void dersSecBTN_Click(object sender, EventArgs e)
    {
        if (tabloSelect.SelectedValue == "1")
        {
            silBTN.Visible = true;
            kontrolTXT.Text = "1";
            karsilama.Visible = false;

            GridView_ogrenci.Visible = true;
            GridView_ogretmen.Visible = false;

            GridView_ogrenci.DataSource = null;
            GridView_ogrenci.DataBind();

            if (sorgulaTXT.Text == String.Empty)
            {
                sqlSorgu.Text = String.Empty;
            }
            else
            {
                sqlSorgu.Text = " where tc like '%" + sorgulaTXT.Text + "%' or adSoyad like '%" + sorgulaTXT.Text + "%'";
                sorgulaTXT.Text = String.Empty;
            }

            baglanti Listele = new baglanti();
            Listele.verileriGetir("select * from ogrenciler" + sqlSorgu.Text);
            if (Listele.SQLTablo.Rows.Count > 0)
            {
                GridView_ogrenci.DataSource = Listele.SQLTablo;
                GridView_ogrenci.DataBind();
            }
        }
        
        else if (tabloSelect.SelectedValue == "2")
        {
            silBTN.Visible = true;
            kontrolTXT.Text = "2";
            karsilama.Visible = false;

            GridView_ogrenci.Visible = false;
            GridView_ogretmen.Visible = true;

            GridView_ogretmen.DataSource = null;
            GridView_ogretmen.DataBind();

            if (sorgulaTXT.Text == String.Empty)
            {
                sqlSorgu.Text = String.Empty;
            }
            else
            {
                sqlSorgu.Text = " where sicilNo like '%" + sorgulaTXT.Text + "%' or adSoyad like '%" + sorgulaTXT.Text + "%'";
                sorgulaTXT.Text = String.Empty;
            }

            baglanti Listele = new baglanti();
            Listele.verileriGetir("select * from ogretmenler" + sqlSorgu.Text);
            if (Listele.SQLTablo.Rows.Count > 0)
            {
                GridView_ogretmen.DataSource = Listele.SQLTablo;
                GridView_ogretmen.DataBind();
            }
        }
    }
    protected void GridView_ogrenci_SelectedIndexChanged(object sender, EventArgs e)
    {
        seciliyiGucelle.Visible = true;
        silBTN.Visible = true;
        int selectedRowIndex = GridView_ogrenci.SelectedIndex;
        GridViewRow row = GridView_ogrenci.Rows[selectedRowIndex];

        int satir1ID = Convert.ToInt32(row.Cells[1].Text);

        baglanti ogrListele = new baglanti();
        ogrListele.verileriGetir("select * from ogrenciler where id='" + satir1ID.ToString() + "'");
        if (ogrListele.SQLTablo.Rows.Count > 0)
        {
            if (ogrListele.SQLTablo.Rows[0][4].ToString() == "1")
                cinsiyetRADIO.SelectedIndex = 0;
            else if (ogrListele.SQLTablo.Rows[0][4].ToString() == "2")
                cinsiyetRADIO.SelectedIndex = 1;

            secimID.Text = ogrListele.SQLTablo.Rows[0][0].ToString();
            adSoyad.Text=ogrListele.SQLTablo.Rows[0][2].ToString();
            yas.Text=ogrListele.SQLTablo.Rows[0][3].ToString();
            tc.Text = ogrListele.SQLTablo.Rows[0][5].ToString();
            tel.Text = ogrListele.SQLTablo.Rows[0][7].ToString();
            ePosta.Text = ogrListele.SQLTablo.Rows[0][8].ToString();
            adres.InnerText = ogrListele.SQLTablo.Rows[0][9].ToString();

            siniflar.Items.Clear();
            baglanti sinifListele = new baglanti();
            sinifListele.verileriGetir("select * from siniflar");
            if (sinifListele.SQLTablo.Rows.Count > 0)
            {
                if (siniflar.Items.Count == 0)
                {
                    siniflar.Items.Add(new ListItem("Sınıf Seçiniz", "0"));

                    for (int i = 0; i <= sinifListele.SQLTablo.Rows.Count - 1; i++)
                    {
                        siniflar.Items.Add(new ListItem(sinifListele.SQLTablo.Rows[i][1].ToString(), sinifListele.SQLTablo.Rows[i][0].ToString()));
                        if (sinifListele.SQLTablo.Rows[i][0].ToString() == ogrListele.SQLTablo.Rows[0][6].ToString())
                        {
                            siniflar.SelectedIndex = i + 1;
                        }
                    }
                }
            }
            else
            {
                siniflar.Items.Clear();
                siniflar.Items.Add(new ListItem("Sınıf Bulunamadı.", "0"));
            }

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
                        if (kursListele.SQLTablo.Rows[i][0].ToString() == ogrListele.SQLTablo.Rows[0][1].ToString())
                        {
                            kursSecListele.SelectedIndex = i + 1;
                        }
                    }
                }
            }
            else
            {
                kursSecListele.Items.Clear();
                kursSecListele.Items.Add(new ListItem("Kurs Bulunamadı.", "0"));
            }
        }
    }
    protected void guncelleBTN_Click(object sender, EventArgs e)
    {
        baglanti kursGuncelle = new baglanti();
        if (kursGuncelle.komutCalistir("update ogrenciler set kursId='" + kursSecListele.SelectedValue + "' , adSoyad='" + adSoyad.Text + "' , yas='" + yas.Text + "' , cinsiyet='" + cinsiyetRADIO.SelectedValue + "' , tc='" + tc.Text + "' , sinif='" + siniflar.SelectedValue + "' , tel='" + tel.Text + "' , ePosta='" + ePosta.Text + "' , adres='" + adres.InnerText + "' where id='" + secimID.Text + "'") == "1")
        {
            bilgiTXT.Text = "Kayıt Güncellendi.";
            bilgiIMG.Visible = true;
            adSoyad.Text = "";
            yas.Text = "";
            tc.Text = "";
            tel.Text = "";
            ePosta.Text = "";
            cinsiyetRADIO.SelectedIndex = 0;
            adres.InnerText = String.Empty;
            kursSecListele.SelectedIndex = 0;
            siniflar.SelectedIndex = 0;

            seciliyiGucelle.Visible = false;
            secimID.Text = String.Empty;

            if (tabloSelect.SelectedValue == "1")
            {
                kontrolTXT.Text = "1";
                GridView_ogrenci.Visible = true;

                if (sorgulaTXT.Text == String.Empty)
                {
                    sqlSorgu.Text = String.Empty;
                }
                else
                {
                    sqlSorgu.Text = " where tc like '%" + sorgulaTXT.Text + "%' or adSoyad like '%" + sorgulaTXT.Text + "%'";
                    sorgulaTXT.Text = String.Empty;
                }

                baglanti Listele = new baglanti();
                Listele.verileriGetir("select * from ogrenciler" + sqlSorgu.Text);
                if (Listele.SQLTablo.Rows.Count > 0)
                {
                    GridView_ogrenci.DataSource = Listele.SQLTablo;
                    GridView_ogrenci.DataBind();
                }
            }
            else
            {
                bilgiTXT.Text = "İşlem Başarısız. Lütfen Daha Sonra Tekrar Deneyiniz.";
                bilgiIMG.Visible = true;
            }
        }
    }
    protected void GridView_ogretmen_SelectedIndexChanged(object sender, EventArgs e)
    {
        ogretmenGuncelle.Visible = true;
        silBTN.Visible = true;

        int selectedRowIndex = GridView_ogretmen.SelectedIndex;
        GridViewRow row = GridView_ogretmen.Rows[selectedRowIndex];

        int satir2ID = Convert.ToInt32(row.Cells[1].Text);

        baglanti ogretmanListele = new baglanti();
        ogretmanListele.verileriGetir("select * from ogretmenler where id='" + satir2ID.ToString() + "'");
        if (ogretmanListele.SQLTablo.Rows.Count > 0)
        {
            secim2ID.Text = ogretmanListele.SQLTablo.Rows[0][0].ToString();
            alaniTXT.Text = ogretmanListele.SQLTablo.Rows[0][1].ToString();
            ogretmenAdiTXT.Text = ogretmanListele.SQLTablo.Rows[0][2].ToString();
            ogretmenYasTXT.Text = ogretmanListele.SQLTablo.Rows[0][3].ToString();
            ogretmenSicilNoTXT.Text = ogretmanListele.SQLTablo.Rows[0][4].ToString();
            ogretmenTelTXT.Text = ogretmanListele.SQLTablo.Rows[0][5].ToString();
            ogretmenEPostaTXT.Text = ogretmanListele.SQLTablo.Rows[0][6].ToString();
            ogretmenAdresTXT.InnerText = ogretmanListele.SQLTablo.Rows[0][7].ToString();
        }
    }
    protected void ogretmenGuncelleBTN_Click(object sender, EventArgs e)
    {
        baglanti kursGuncelle = new baglanti();
        if (kursGuncelle.komutCalistir("update ogretmenler set alan='" + alaniTXT.Text + "' , adSoyad='" + ogretmenAdiTXT.Text + "' , yas='" + ogretmenYasTXT.Text + "' , sicilNo='" + ogretmenSicilNoTXT.Text + "' , tel='" + ogretmenTelTXT.Text + "' , ePosta='" + ogretmenEPostaTXT.Text + "' , adres='" + ogretmenAdresTXT.InnerText + "' where id='" + secim2ID.Text + "'") == "1")
        {
            bilgiTXT.Text = "Kayıt Güncellendi.";
            bilgiIMG.Visible = true;
            alaniTXT.Text = "";
            ogretmenAdiTXT.Text = "";
            ogretmenYasTXT.Text = "";
            ogretmenTelTXT.Text = "";
            ogretmenEPostaTXT.Text = "";
            ogretmenAdresTXT.InnerText = String.Empty;

            ogretmenGuncelle.Visible = false;
            secim2ID.Text = String.Empty;

            if (tabloSelect.SelectedValue == "2")
            {
                kontrolTXT.Text = "2";
                GridView_ogretmen.Visible = true;

                if (sorgulaTXT.Text == String.Empty)
                {
                    sqlSorgu.Text = String.Empty;
                }
                else
                {
                    sqlSorgu.Text = " where sicilNo like '%" + sorgulaTXT.Text + "%' or adSoyad like '%" + sorgulaTXT.Text + "%'";
                    sorgulaTXT.Text = String.Empty;
                }

                baglanti Listele = new baglanti();
                Listele.verileriGetir("select * from ogretmenler" + sqlSorgu.Text);
                if (Listele.SQLTablo.Rows.Count > 0)
                {
                    GridView_ogretmen.DataSource = Listele.SQLTablo;
                    GridView_ogretmen.DataBind();
                }
            }
            else
            {
                bilgiTXT.Text = "İşlem Başarısız. Lütfen Daha Sonra Tekrar Deneyiniz.";
                bilgiIMG.Visible = true;
            }
        }

    }
    protected void silBTN_Click(object sender, EventArgs e)
    {
        if (kontrolTXT.Text == "1")
        {
            string silinecekler = "";
            foreach (GridViewRow satirbilgi in GridView_ogrenci.Rows)
            {
                CheckBox chk = (CheckBox)satirbilgi.FindControl("ogrenciSecim");
                if (chk != null & chk.Checked)
                {
                    silinecekler += "id=" + satirbilgi.Cells[1].Text + " or ";
                }
            }
            if (silinecekler != "")
            {
                baglanti ogrenciSil = new baglanti();
                if (ogrenciSil.komutCalistir("delete from ogrenciler where " + silinecekler.Remove(silinecekler.Length - 4, 4)) == "1")
                {
                    bilgiTXT.Text = "Seçili Kayıtlar Silindi.";
                    bilgiIMG.Visible = true;

                    GridView_ogrenci.DataSource = null;
                    GridView_ogrenci.DataBind();

                    baglanti Listele = new baglanti();
                    Listele.verileriGetir("select * from ogrenciler");
                    if (Listele.SQLTablo.Rows.Count > 0)
                    {
                        GridView_ogrenci.DataSource = Listele.SQLTablo;
                        GridView_ogrenci.DataBind();
                    }
                }
                else
                {
                    bilgiTXT.Text = "İşlem Başarısız. Lütfen Daha Sonra Tekrar Deneyiniz.";
                    bilgiIMG.Visible = true;
                }
            }
            else 
            {
                bilgiTXT.Text = "Önce Silmek İstediğiniz Kayıtları Seçin.";
                bilgiIMG.Visible = true;
            }
        }
        else if (kontrolTXT.Text == "2")
        {
            string silinecekler = "";
            foreach (GridViewRow satirbilgi in GridView_ogretmen.Rows)
            {
                CheckBox chk = (CheckBox)satirbilgi.FindControl("ogretmenSecim");
                if (chk != null & chk.Checked)
                {
                    silinecekler += "id=" + satirbilgi.Cells[1].Text + " or ";
                }
            }
            baglanti ogretmenSil = new baglanti();
            if (ogretmenSil.komutCalistir("delete from ogretmenler where " + silinecekler.Remove(silinecekler.Length - 4, 4)) == "1")
            {
                bilgiTXT.Text = "Seçili Kayıtlar Silindi.";
                bilgiIMG.Visible = true;

                GridView_ogretmen.DataSource = null;
                GridView_ogretmen.DataBind();

                baglanti Listele = new baglanti();
                Listele.verileriGetir("select * from ogretmenler");
                if (Listele.SQLTablo.Rows.Count > 0)
                {
                    GridView_ogretmen.DataSource = Listele.SQLTablo;
                    GridView_ogretmen.DataBind();
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