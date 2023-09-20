using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_egitmen_notlar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "2")
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Page.IsPostBack == false)
        {
            tabloListele();
        }
    }
    protected void kaydetBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        HttpPostedFile yuklenecekDosya = notDosyasi.PostedFile;
        if (yuklenecekDosya.FileName.ToString() != "")
        {
            if (baslikTXT.Text != String.Empty)
            {
                if (yuklenecekDosya != null)
                {
                    string dosyauzantisi = Path.GetExtension(yuklenecekDosya.FileName);
                    if (dosyauzantisi.ToLower() == ".pdf" || dosyauzantisi.ToLower() == ".doc" || dosyauzantisi.ToLower() == ".docx" || dosyauzantisi.ToLower() == ".xls" || dosyauzantisi.ToLower() == ".xlsx"
                         || dosyauzantisi.ToLower() == ".ppt" || dosyauzantisi.ToLower() == ".pptx" || dosyauzantisi.ToLower() == ".pps" || dosyauzantisi.ToLower() == ".ppsx" || dosyauzantisi.ToLower() == ".txt" || dosyauzantisi.ToLower() == ".rar")
                    {
                        //FileInfo dosyaBilgisi = new FileInfo(yuklenecekDosya.FileName);
                        DateTime dosyaAdi = DateTime.Now;
                        string dosya = dosyaAdi.ToString() + dosyauzantisi.ToString();
                        dosya = dosya.Replace(':', '-');
                        dosya = dosya.Replace(' ', '-');

                        string yuklemeYeri = Server.MapPath("~/dosya/" + dosya);
                        notDosyasi.SaveAs(yuklemeYeri);

                        //string videoName = dosyaBilgisi.Name.ToString();
                        baglanti dosyaEkle = new baglanti();

                        String dosyaBasligi = baslikTXT.Text;
                        if (baslikTXT.Text.Length >= 240)
                            dosyaBasligi = dosyaBasligi.Remove(239).ToString();
                        if (dosyaEkle.komutCalistir("insert into notlar (egitmenID,baslik,bilgi,dosya) values ('" + Session[Request.Url.Authority + "oturum"].ToString() + "', '" + dosyaBasligi + "', '" + bilgiTXT.InnerText + "', '" + dosya + "')") == "1")
                        {
                            baslikTXT.Text = String.Empty;
                            bilgiTXT.InnerText = String.Empty;
                            mainMesaj.Text = mesaj.goster("1", "Ders Notu Eklendi");
                            tabloListele();
                        }
                        else
                        {
                            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                        }
                    }
                    else
                        mainMesaj.Text = mesaj.goster("2", dosyauzantisi.ToLower() + " dosya türünü sisteme yükleyemezsiniz.");
                }
            }
            else
                mainMesaj.Text = mesaj.goster("2", "Ders notuna başlık yazınız.");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "Dosya seçiniz!");
    }

    public void tabloListele()
    {
        baglanti sorgu = new baglanti();
        int kontrol = 1;
        sorgu.verileriGetir("select id from notlar where egitmenID='" + Session[Request.Url.Authority + "oturum"] + "'");
        if (sorgu.SQLTablo.Rows.Count > 0)
            kontrol = 1;
        else
        {
            kontrol = 0;
            GridView_dosyalar.Visible = false;
            sorguSonucu.Visible = true;
            dosyaSilBTN.Visible = false;
        }

        if (kontrol == 1)
        {
            GridView_dosyalar.Visible = true;
            sorguSonucu.Visible = false;
            dosyaSilBTN.Visible = true;

            baglanti Listele = new baglanti();
            Listele.verileriGetir("select id,baslik,dosya from notlar where egitmenID='" + Session[Request.Url.Authority + "oturum"] + "' order by id desc");
            if (Listele.SQLTablo.Rows.Count > 0)
            {
                GridView_dosyalar.DataSource = Listele.SQLTablo;
                GridView_dosyalar.DataBind();
            }
        }
    }
    protected void dosyaSilBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        string idler = "";
        foreach (GridViewRow satirbilgi in GridView_dosyalar.Rows)
        {
            CheckBox secimKutusu = (CheckBox)satirbilgi.FindControl("secim");
            if (secimKutusu != null && secimKutusu.Checked)
            {
                File.Delete(Server.MapPath("~/dosya/" + satirbilgi.Cells[3].Text));
                idler += "id=" + satirbilgi.Cells[1].Text + " or ";
            }
        }

        if (idler != "")
        {
            baglanti ogrenciSil = new baglanti();
            if (ogrenciSil.komutCalistir("delete from notlar where " + idler.Remove(idler.Length - 4, 4)) == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Seçili ders notları silindi.");
                tabloListele();
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
    }
    protected void GridView_dosyalar_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex = GridView_dosyalar.SelectedIndex;
        GridViewRow row = GridView_dosyalar.Rows[selectedRowIndex];
        string dosya = row.Cells[3].Text;

        Response.Redirect("~/dosya/" + dosya);
    }
}