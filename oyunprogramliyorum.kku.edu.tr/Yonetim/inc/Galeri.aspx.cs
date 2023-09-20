using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_inc_Galeri : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            tabloListele();
        }
    }
    public void tabloListele()
    {
        baglanti sorgu = new baglanti();
        int kontrol = 1;
        sorgu.verileriGetir("select id from galeri");
        if (sorgu.SQLTablo.Rows.Count > 0)
            kontrol = 1;
        else
        {
            kontrol = 0;
            GridView_resimler.Visible = false;
            sorguSonucu.Visible = true;
            silBTN.Visible = false;
            ResimKutusu.ImageUrl = "../../img/galeri/onizleme.jpg";
        }

        if (kontrol == 1)
        {
            GridView_resimler.Visible = true;
            sorguSonucu.Visible = false;
            silBTN.Visible = true;

            baglanti Listele = new baglanti();
            Listele.verileriGetir("select * from galeri");
            if (Listele.SQLTablo.Rows.Count > 0)
            {
                GridView_resimler.DataSource = Listele.SQLTablo;
                GridView_resimler.DataBind();
            }
        }
    }
    protected void kaydetBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

            HttpPostedFile yuklenecekDosya = fluDosya.PostedFile;
            if (yuklenecekDosya.FileName.ToString() != "")
            {
                    if (yuklenecekDosya != null)
                    {
                        string dosyauzantisi = Path.GetExtension(yuklenecekDosya.FileName);
                        if (dosyauzantisi.ToLower() == ".jpg" || dosyauzantisi.ToLower() == ".jpeg" || dosyauzantisi.ToLower() == ".png")
                        {
                            //FileInfo dosyaBilgisi = new FileInfo(yuklenecekDosya.FileName);
                            DateTime dosyaAdi = DateTime.Now;
                            string dosya = dosyaAdi.ToString() + dosyauzantisi.ToString();
                            dosya = dosya.Replace(':', '-');
                            dosya = dosya.Replace(' ', '-');

                            string yuklemeYeri = Server.MapPath("~/img/galeri/" + dosya);
                            fluDosya.SaveAs(yuklemeYeri);

                            //string videoName = dosyaBilgisi.Name.ToString();
                            baglanti videoEkle = new baglanti();
                            if (videoEkle.komutCalistir("insert into galeri (img) values ('" + dosya + "')") == "1")
                            {
                                mainMesaj.Text = mesaj.goster("1", "Resim Yüklendi");
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
                mainMesaj.Text = mesaj.goster("2", "Dosya seçiniz!");
    }
    protected void silBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        string idler = "";
        foreach (GridViewRow satirbilgi in GridView_resimler.Rows)
        {
            CheckBox secimKutusu = (CheckBox)satirbilgi.FindControl("secim");
            if (secimKutusu != null && secimKutusu.Checked)
            {
                File.Delete(Server.MapPath("~/img/galeri/" + satirbilgi.Cells[2].Text));
                idler += "id=" + satirbilgi.Cells[1].Text + " or ";
            }
        }

        if (idler != "")
        {
            baglanti ogrenciSil = new baglanti();
            if (ogrenciSil.komutCalistir("delete from galeri where " + idler.Remove(idler.Length - 4, 4)) == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Seçili resimler silindi.");
                tabloListele();
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
    }
    protected void GridView_resimler_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex = GridView_resimler.SelectedIndex;
        GridViewRow row = GridView_resimler.Rows[selectedRowIndex];
        string resim = row.Cells[2].Text;

        ResimKutusu.ImageUrl = "../../img/galeri/" + resim;
    }
}