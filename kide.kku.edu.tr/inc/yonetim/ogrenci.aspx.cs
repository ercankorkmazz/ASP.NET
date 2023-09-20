using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class inc_yonetim_ogrenci : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "1")
        {
            Response.Redirect("~/Default.aspx");
        }

        baglanti sorgu = new baglanti();
        sorgu.verileriGetir("select adSoyad from ogrenciler where id='" + Session[Request.Url.Authority + "ogrID"] + "'");
        if (sorgu.SQLTablo.Rows.Count > 0)
            ogrAdiTXT.Text = sorgu.SQLTablo.Rows[0][0].ToString();
        else
            Response.Redirect("~/inc/yonetim/ogrKaydi.aspx");

        listeleBTN.Visible = true;
        GridView_videolar.Visible = false;
        sorguSonucu.Visible = false;
        videoSilBTN.Visible = false;
    }
    protected void yukleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        HttpPostedFile yuklenecekDosya = fluDosya.PostedFile;
        if (yuklenecekDosya.FileName.ToString() != "")
        {
            if (videoBilgi.Text != String.Empty)
            {
                if (yuklenecekDosya != null)
                {
                    string dosyauzantisi = Path.GetExtension(yuklenecekDosya.FileName);
                    if (dosyauzantisi.ToLower() == ".mp4")
                    {
                        //FileInfo dosyaBilgisi = new FileInfo(yuklenecekDosya.FileName);
                        DateTime dosyaAdi = DateTime.Now;
                        string dosya = dosyaAdi.ToString() + dosyauzantisi.ToString();
                        dosya = dosya.Replace(':', '-'); 
                        dosya = dosya.Replace(' ', '-');
                        
                        string yuklemeYeri = Server.MapPath("~/video/" + dosya);
                        fluDosya.SaveAs(yuklemeYeri);

                        //string videoName = dosyaBilgisi.Name.ToString();
                        baglanti videoEkle = new baglanti();

                        String videoBilgisi = videoBilgi.Text;
                        if (videoBilgi.Text.Length >= 150)
                            videoBilgisi = videoBilgisi.Remove(149).ToString();
                        if (videoEkle.komutCalistir("insert into ogrencivideo (ogrID,bilgi,video) values ('" + Session[Request.Url.Authority + "ogrID"].ToString() + "', '" + videoBilgisi + "', '" + dosya + "')") == "1")
                        {
                            videoBilgi.Text = String.Empty;
                            mainMesaj.Text = mesaj.goster("1", "Video Yüklendi");
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
                mainMesaj.Text = mesaj.goster("2", "Video başlığı yazınız! Bu başlık öğrenci panelinde görünecek.");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "Dosya seçiniz!");
    }
    public void tabloListele()
    {
        baglanti sorgu = new baglanti();
        listeleBTN.Visible = false;
        int kontrol = 1;
        sorgu.verileriGetir("select id from ogrencivideo where ogrID='" + Session[Request.Url.Authority + "ogrID"] + "'");
        if (sorgu.SQLTablo.Rows.Count > 0)
            kontrol = 1;
        else
        {
            kontrol = 0;
            GridView_videolar.Visible = false;
            sorguSonucu.Visible = true;
            videoSilBTN.Visible = false;
        }

        if (kontrol == 1)
        {
            GridView_videolar.Visible = true;
            sorguSonucu.Visible = false;
            videoSilBTN.Visible = true;

            baglanti Listele = new baglanti();
            Listele.verileriGetir("select ogrencivideo.id, ogrencivideo.bilgi, ogrencivideo.video, ogrenciler.adSoyad from ogrenciler INNER JOIN ogrencivideo ON ogrenciler.id = ogrencivideo.ogrID where ogrencivideo.ogrID='" + Session[Request.Url.Authority + "ogrID"] + "' order by ogrencivideo.id");
            if (Listele.SQLTablo.Rows.Count > 0)
            {
                GridView_videolar.DataSource = Listele.SQLTablo;
                GridView_videolar.DataBind();
            }
        }
    }
    protected void listeleBTN_Click(object sender, EventArgs e)
    {
        tabloListele();
    }
    protected void videoSilBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        string idler = "";
        foreach (GridViewRow satirbilgi in GridView_videolar.Rows)
        {
            CheckBox secimKutusu = (CheckBox)satirbilgi.FindControl("secim");
            if (secimKutusu != null && secimKutusu.Checked)
            {
                File.Delete(Server.MapPath("~/video/" + satirbilgi.Cells[4].Text));
                idler += "id=" + satirbilgi.Cells[1].Text + " or ";

                baglanti yorumSil = new baglanti();
                yorumSil.komutCalistir("delete from yorumlar where videoID='" + satirbilgi.Cells[1].Text + "'");
            }
        }
        
        if (idler != "")
        {
            baglanti ogrenciSil = new baglanti();
            if (ogrenciSil.komutCalistir("delete from ogrencivideo where " + idler.Remove(idler.Length - 4, 4)) == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Seçili videolar silindi.");
                tabloListele();
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
    }
    protected void GridView_ogrenci_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex = GridView_videolar.SelectedIndex;
        GridViewRow row = GridView_videolar.Rows[selectedRowIndex];
        int id = Convert.ToInt32(row.Cells[1].Text);

        Session[Request.Url.Authority + "videoID"] = id;
        Response.Redirect("~/inc/yonetim/video.aspx");
    }
}