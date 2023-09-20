using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class inc_yonetim_ogrKaydi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "1")
        {
            Response.Redirect("~/Default.aspx");
        }
        grupListele();
        sorguSonucu.Visible = false;
    }
    public void tabloListele(string grup)
    {
        baglanti sorgu = new baglanti();
        GridView_ogrenci.Visible = true;
        sorguSonucu.Visible = false;

        int kontrol = 1;
        sorgu.verileriGetir("select ogrenciler.grupID from ogrenciler" + grup);
        if (sorgu.SQLTablo.Rows.Count > 0)
            kontrol = 1;
        else
        {
            kontrol = 0;
            GridView_ogrenci.Visible = false;
            sorguSonucu.Visible = true;
            grupGuncelle.Visible = false;
            ogrenciSilBTN.Visible = false;
            grupGuncelleDropDownList.Visible = false;
        }

        if(kontrol==1)
        {
            grupGuncelle.Visible = true;
            ogrenciSilBTN.Visible = true;
            grupGuncelleDropDownList.Visible = true;

            baglanti Listele = new baglanti();
            Listele.verileriGetir("select ogrenciler.id, ogrenciler.adSoyad, ogrenciler.kullaniciID, kullanici.kadi, kullanici.sifre, kullanici.eposta, kullanici.telefon, gruplar.grupAdi, ogrenciler.grupID from kullanici INNER JOIN ogrenciler ON kullanici.id = ogrenciler.kullaniciID LEFT OUTER JOIN gruplar ON ogrenciler.grupID = gruplar.id" + grup + " order by id");
            if (Listele.SQLTablo.Rows.Count > 0)
            {
                GridView_ogrenci.DataSource = Listele.SQLTablo;
                GridView_ogrenci.DataBind();
                tabloDuzenle();
            }
        }
    }
    public void tabloDuzenle()
    {
        foreach (GridViewRow satirbilgi in GridView_ogrenci.Rows)
        {
            baglanti Listele = new baglanti();
            Listele.verileriGetir("select guncelleme from kullanici where id='" + satirbilgi.Cells[2].Text + "'");
            if (Listele.SQLTablo.Rows.Count > 0)
            {
                string durum = Listele.SQLTablo.Rows[0][0].ToString();
                if (durum == "1")
                    satirbilgi.Cells[8].Text = "Güncellendi";
            }
        }
    }
    public void grupListele()
    {
        baglanti gruplariGetir = new baglanti();
        gruplariGetir.verileriGetir("select * from gruplar");
        if (gruplariGetir.SQLTablo.Rows.Count > 0)
        {
            if (gruplarDropDownList.Items.Count == 0)
            {
                gruplarDropDownList.Items.Add(new ListItem("Grup Seçiniz", "0"));

                for (int i = 0; i <= gruplariGetir.SQLTablo.Rows.Count - 1; i++)
                {
                    gruplarDropDownList.Items.Add(new ListItem(gruplariGetir.SQLTablo.Rows[i][1].ToString(), gruplariGetir.SQLTablo.Rows[i][0].ToString()));
                }

                gruplarListeleDropDownList.Items.Add(new ListItem("Tüm Öğrenciler", "0"));

                for (int i = 0; i <= gruplariGetir.SQLTablo.Rows.Count - 1; i++)
                {
                    gruplarListeleDropDownList.Items.Add(new ListItem(gruplariGetir.SQLTablo.Rows[i][1].ToString(), gruplariGetir.SQLTablo.Rows[i][0].ToString()));
                }

                grupGuncelleDropDownList.Items.Add(new ListItem("Grup Seçiniz", "0"));

                for (int i = 0; i <= gruplariGetir.SQLTablo.Rows.Count - 1; i++)
                {
                    grupGuncelleDropDownList.Items.Add(new ListItem(gruplariGetir.SQLTablo.Rows[i][1].ToString(), gruplariGetir.SQLTablo.Rows[i][0].ToString()));
                }
            }
            if (grupAdiGuncelleDropDownList.Items.Count == 0)
            {
                grupAdiGuncelleDropDownList.Items.Add(new ListItem("Grup Seçiniz", "0"));

                for (int i = 0; i <= gruplariGetir.SQLTablo.Rows.Count - 1; i++)
                {
                    grupAdiGuncelleDropDownList.Items.Add(new ListItem(gruplariGetir.SQLTablo.Rows[i][1].ToString(), gruplariGetir.SQLTablo.Rows[i][0].ToString()));
                }
            }
        }
        else
        {
            gruplarDropDownList.Items.Clear();
            gruplarListeleDropDownList.Items.Clear();
            grupGuncelleDropDownList.Items.Clear();
            grupAdiGuncelleDropDownList.Items.Clear();
            gruplarDropDownList.Items.Add(new ListItem("Grup ekleyiniz.", "0"));
            gruplarListeleDropDownList.Items.Add(new ListItem("Tüm Öğrenciler", "0"));
            grupGuncelleDropDownList.Items.Add(new ListItem("Grup ekleyiniz.", "0"));
            grupAdiGuncelleDropDownList.Items.Add(new ListItem("Grup ekleyiniz.", "0"));
        }
    }
    protected void grupSecBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (grupAdiGuncelleDropDownList.SelectedIndex == 0)
        {
            grupID.Value = String.Empty;
            grupAdiTXT.Text = String.Empty;
            mainMesaj.Text = mesaj.goster("2", "Grup seçiniz!");
        }
        else
        {
            baglanti grupBilgileriniGetir = new baglanti();
            grupBilgileriniGetir.verileriGetir("select * from gruplar where id='" + grupAdiGuncelleDropDownList.SelectedValue + "'");
            if (grupBilgileriniGetir.SQLTablo.Rows.Count > 0)
            {
                grupID.Value = grupBilgileriniGetir.SQLTablo.Rows[0][0].ToString();
                grupAdiTXT.Text = grupBilgileriniGetir.SQLTablo.Rows[0][1].ToString();
                mainMesaj.Text = mesaj.goster("1", "&#8220;" + grupAdiTXT.Text + "&#8221; seçildi. Seçili grubu silebilir ya da adını güncelleyebilirsiniz.");
            }
        }
    }
    protected void grupSilBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (grupID.Value != String.Empty)
        {
            baglanti grupSil = new baglanti();
            int yardimci = 0;
            if (grupSil.komutCalistir("delete from gruplar where id='" + grupID.Value + "'") == "1")
            {
                yardimci = 1;
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız.");

            if (yardimci == 1)
            {
                yardimci = 0;
                baglanti ogrenciGetir = new baglanti();
                ogrenciGetir.verileriGetir("select ogrenciler.id from ogrenciler where grupID='" + grupID.Value + "'");
                if (ogrenciGetir.SQLTablo.Rows.Count > 0)
                {
                    yardimci = 1;
                }
                else
                {
                    mainMesaj.Text = mesaj.goster("1", "Seçili grup silindi!");
                    tabloListele(string.Empty);
                    grupAdiTXT.Text = String.Empty;
                    grupID.Value = String.Empty;
                    gruplarDropDownList.Items.Clear();
                    gruplarListeleDropDownList.Items.Clear();
                    grupGuncelleDropDownList.Items.Clear();
                    grupAdiGuncelleDropDownList.Items.Clear();
                    grupListele();
                }
            }
            if (yardimci == 1)
            {
                baglanti ogrenciGuncelle = new baglanti();
                if (ogrenciGuncelle.komutCalistir("update ogrenciler set grupID='0' where grupID='" + grupID.Value + "'") == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "Seçili grup silindi!");
                    tabloListele(string.Empty);
                    grupAdiTXT.Text = String.Empty;
                    grupID.Value = String.Empty;
                    gruplarDropDownList.Items.Clear();
                    gruplarListeleDropDownList.Items.Clear();
                    grupGuncelleDropDownList.Items.Clear();
                    grupAdiGuncelleDropDownList.Items.Clear();
                    grupListele();
                }
                else
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
        }
        else
            mainMesaj.Text = mesaj.goster("2", "Grup seçiniz!");
    }
    protected void grupGuncelleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (grupID.Value != String.Empty)
        {
            if (grupAdiTXT.Text != String.Empty)
            {
                baglanti kursGuncelle = new baglanti();

                String grupAdi = grupAdiTXT.Text;
                if (grupAdiTXT.Text.Length >= 100)
                    grupAdi = grupAdi.Remove(99).ToString();

                if (kursGuncelle.komutCalistir("update gruplar set grupAdi='" + grupAdi + "' where id='" + grupID.Value + "'") == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "Grup adı güncellendi.");
                    grupAdiTXT.Text = string.Empty;
                    grupID.Value = String.Empty;
                    gruplarDropDownList.Items.Clear();
                    gruplarListeleDropDownList.Items.Clear();
                    grupGuncelleDropDownList.Items.Clear();
                    grupAdiGuncelleDropDownList.Items.Clear();
                    grupListele();
                }
                else
                {
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "Grup adı yazınız!");
                grupID.Value = String.Empty;
                grupAdiTXT.Text = String.Empty;
            }
        }
        else
            mainMesaj.Text = mesaj.goster("2", "Grup seçiniz!");
    }
    protected void grupEkleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (yeniGrupTXT.Text != "")
        {
            baglanti grupEkle = new baglanti();

            String grupAdi = yeniGrupTXT.Text;
            if (yeniGrupTXT.Text.Length >= 100)
                grupAdi = grupAdi.Remove(99).ToString();
            
            if (grupEkle.komutCalistir("insert into gruplar (grupAdi) values ('" + grupAdi + "')") == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Kayıt Başarılı");
                yeniGrupTXT.Text = "";
                gruplarDropDownList.Items.Clear();
                gruplarListeleDropDownList.Items.Clear();
                grupGuncelleDropDownList.Items.Clear();
                grupAdiGuncelleDropDownList.Items.Clear();
                grupListele();
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
        }
        else
        {
            mainMesaj.Text = mesaj.goster("2", "Yeni grup adını yazınız!");
        }
    }
    protected void ogrEkleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (ogrenciAdiTXT.Text != "")
        {
            if(gruplarDropDownList.SelectedIndex != 0)
            {
                baglanti kullaniciEkle = new baglanti();

                Random rastgele = new Random();
                string sifre = "";
                string kadi = "Öğrenci";
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
                int yardimci = 0;
                if (kullaniciEkle.komutCalistir("insert into kullanici (kadi,sifre,kontrol) values ('" + kadi + "','" + sifre + "','3')") == "1")
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
                    baglanti kullaniciIDGetir = new baglanti();
                    kullaniciIDGetir.verileriGetir("select TOP 1 * from kullanici order by id desc");
                    if (kullaniciIDGetir.SQLTablo.Rows.Count > 0)
                    {
                        kullaniciID = kullaniciIDGetir.SQLTablo.Rows[0][0].ToString();
                    }

                    String ogrenciAdi = ogrenciAdiTXT.Text;
                    if (ogrenciAdiTXT.Text.Length >= 30)
                        ogrenciAdi = ogrenciAdi.Remove(29).ToString();

                    yardimci = 0;
                    baglanti ogrenciEkle = new baglanti();
                    if (ogrenciEkle.komutCalistir("insert into ogrenciler (kullaniciID,adSoyad,grupID) values ('" + kullaniciID + "','" + ogrenciAdi + "','" + gruplarDropDownList.SelectedValue + "')") == "1")
                    {
                        yardimci = 1;
                    }
                    else
                    {
                        mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                    }
                    if (yardimci == 1)
                    {
                        string ogrenciID = "";
                        baglanti ogrenciBilgisi = new baglanti();
                        ogrenciBilgisi.verileriGetir("select TOP 1 * from ogrenciler order by id desc");
                        if (ogrenciBilgisi.SQLTablo.Rows.Count > 0)
                        {
                            kadi = "Öğrenci" + ogrenciBilgisi.SQLTablo.Rows[0][0].ToString();
                        }
                        baglanti kullaniciGuncelle = new baglanti();
                        if (kullaniciGuncelle.komutCalistir("update kullanici set kadi='" + kadi + "' where id='" + kullaniciID + "'") == "1")
                        {
                            mainMesaj.Text = mesaj.goster("1", "Kayıt Başarılı");
                            gruplarDropDownList.SelectedIndex = 0;
                            ogrenciAdiTXT.Text = string.Empty;
                            tabloListele(string.Empty);
                            karsilama.Visible = false;
                        }
                        else
                        {
                            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                        }
                    }
                }
            }
            else
                mainMesaj.Text = mesaj.goster("2", "Grup seçiniz!");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "Öğrenci adını yazınız!");
    }
    protected void GridView_ogrenci_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex = GridView_ogrenci.SelectedIndex;
        GridViewRow row = GridView_ogrenci.Rows[selectedRowIndex];
        int ogrID = Convert.ToInt32(row.Cells[1].Text);

        Session[Request.Url.Authority + "ogrID"] = ogrID;
        Response.Redirect("~/inc/yonetim/ogrenci.aspx");
    }
    protected void grubaGoreListeleBTN_Click(object sender, EventArgs e)
    {
        karsilama.Visible = false;
        if (gruplarListeleDropDownList.SelectedIndex == 0)
            tabloListele(string.Empty);
        else
            tabloListele(" where grupID = '" + gruplarListeleDropDownList.SelectedValue + "'");
    }
    protected void grupGuncelle_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        string idler = "";
        foreach (GridViewRow satirbilgi in GridView_ogrenci.Rows)
        {
            CheckBox secimKutusu = (CheckBox)satirbilgi.FindControl("secim");
            if (secimKutusu != null && secimKutusu.Checked)
            {
                idler += "id=" + satirbilgi.Cells[1].Text + " or ";
            }
        }
        
        if (idler != "")
        {
            if (grupGuncelleDropDownList.SelectedIndex != 0)
            {
                baglanti ogrenciGrubunuGuncelle = new baglanti();
                if (ogrenciGrubunuGuncelle.komutCalistir("update ogrenciler set grupID='" + grupGuncelleDropDownList.SelectedValue + "' where " + idler.Remove(idler.Length - 4, 4)) == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "Seçili öğrencilerin grubu güncellendi.");
                    if (gruplarListeleDropDownList.SelectedIndex != 0)
                        tabloListele(" where grupID = '" + gruplarListeleDropDownList.SelectedValue + "'");
                    else
                        tabloListele(string.Empty);
                }
                else
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
            else
                mainMesaj.Text = mesaj.goster("2", "Grup seçiniz!");
        }
    }
    protected void ogrenciSilBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        string idler = "";
        string ogrIDler = "";
        string yorumIDler = "";
        foreach (GridViewRow satirbilgi in GridView_ogrenci.Rows)
        {
            CheckBox secimKutusu = (CheckBox)satirbilgi.FindControl("secim");
            if (secimKutusu != null && secimKutusu.Checked)
            {
                /*ogrenciSil.verileriGetir("select ogrenciler.kullaniciID from ogrenciler where id=" + satirbilgi.Cells[1].Text);
                if (ogrenciSil.SQLTablo.Rows.Count > 0)
                {
                    if (ogrenciSil.komutCalistir("delete from kullanici where id=" + ogrenciSil.SQLTablo.Rows[0][0].ToString()) == "1")
                    {
                        if (ogrenciSil.komutCalistir("delete from kullanici where id=" + ogrenciSil.SQLTablo.Rows[0][0].ToString()) == "1")
                        {
                            
                        }
                    }
                }*/
                baglanti Listele = new baglanti();
                int kontrol = 0;
                Listele.verileriGetir("select id,video from ogrencivideo where ogrID='" + satirbilgi.Cells[1].Text + "'");
                if (Listele.SQLTablo.Rows.Count > 0)
                {
                    for (int i = 0; i <= Listele.SQLTablo.Rows.Count - 1; i++)
                    {
                        File.Delete(Server.MapPath("~/video/" + Listele.SQLTablo.Rows[i][1]));
                        yorumIDler += "videoID=" + Listele.SQLTablo.Rows[i][0] + " or ";
                    }
                    kontrol = 1;
                }
                if (kontrol == 1)
                {
                    kontrol = 0;
                    baglanti ogrenciVideoSil = new baglanti();
                    if (ogrenciVideoSil.komutCalistir("delete from ogrencivideo where ogrID='" + satirbilgi.Cells[1].Text + "'") == "1")
                    {
                        kontrol = 1;
                    }
                }
                if (kontrol == 1)
                {
                    kontrol = 0;
                    baglanti ogrenciYorulariSil = new baglanti();
                    if (ogrenciYorulariSil.komutCalistir("delete from yorumlar where ogrID='" + satirbilgi.Cells[1].Text + "'") == "1")
                    {
                        idler += "id=" + satirbilgi.Cells[2].Text + " or ";
                        ogrIDler += "id=" + satirbilgi.Cells[1].Text + " or ";
                    }
                }
                else
                {
                    idler += "id=" + satirbilgi.Cells[2].Text + " or ";
                    ogrIDler += "id=" + satirbilgi.Cells[1].Text + " or ";
                }
            }
        }

        if (yorumIDler != "")
        {
            baglanti videoIDyeGoreYorumSil = new baglanti();
            videoIDyeGoreYorumSil.komutCalistir("delete from yorumlar where " + yorumIDler.Remove(yorumIDler.Length - 4, 4));
        }
        if (idler != "")
        {
            int kontrol = 0;
            baglanti ogrenciSil = new baglanti();
            if (ogrenciSil.komutCalistir("delete from ogrenciler where " + ogrIDler.Remove(ogrIDler.Length - 4, 4)) == "1")
            {
                kontrol = 1;
            }
            if (kontrol == 1)
            {
                baglanti kullaniciSil = new baglanti();
                if (kullaniciSil.komutCalistir("delete from kullanici where " + idler.Remove(idler.Length - 4, 4)) == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "Seçili öğrenciler silindi.");
                    if (gruplarListeleDropDownList.SelectedIndex != 0)
                        tabloListele(" where grupID = '" + gruplarListeleDropDownList.SelectedValue + "'");
                    else
                        tabloListele(string.Empty);
                }
                else
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız.");
        }
    }
}