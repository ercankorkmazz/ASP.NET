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
        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "2")
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
        {
            GridView_gruplar.Visible = true;
            kaydetBTN.Visible = true;
            kontrol = 1;
        }
        else
        {
            kontrol = 0;
            GridView_ogrenci.Visible = false;
            sorguSonucu.Visible = true;
            GridView_gruplar.Visible = false;
            kaydetBTN.Visible = false;
        }

        if (kontrol == 1)
        {
            baglanti Listele = new baglanti();
            Listele.verileriGetir("select ogrenciler.id, ogrenciler.adSoyad, kullanici.eposta, kullanici.telefon from kullanici INNER JOIN ogrenciler ON kullanici.id = ogrenciler.kullaniciID" + grup + " order by id");
            if (Listele.SQLTablo.Rows.Count > 0)
            {
                GridView_ogrenci.DataSource = Listele.SQLTablo;
                GridView_ogrenci.DataBind();
            }
            baglanti gruplarSecListele = new baglanti();
            gruplarSecListele.verileriGetir("select * from gruplar order by id");
            if (gruplarSecListele.SQLTablo.Rows.Count > 0)
            {
                GridView_gruplar.DataSource = gruplarSecListele.SQLTablo;
                GridView_gruplar.DataBind();
            }
            if (Session[Request.Url.Authority + "grupID"] != null)
            {
                if (Session[Request.Url.Authority + "grupID"] != "0")
                {
                    baglanti grupSorgula = new baglanti();
                    grupSorgula.verileriGetir("select grupAdi from gruplar where id='" + Session[Request.Url.Authority + "grupID"] + "'");
                    if (grupSorgula.SQLTablo.Rows.Count > 0)
                        grupAdiTXT.Text = grupSorgula.SQLTablo.Rows[0][0].ToString();
                }
            }
        }
    }

    public void grupChkSorgula()
    {
        baglanti gruplarSorgu = new baglanti();
        gruplarSorgu.verileriGetir("select gruplar from gruplar where id='" + Session[Request.Url.Authority + "grupID"] + "'");
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
    public void grupListele()
    {
        baglanti gruplariGetir = new baglanti();
        gruplariGetir.verileriGetir("select * from gruplar");
        if (gruplariGetir.SQLTablo.Rows.Count > 0)
        {
            if (gruplarListeleDropDownList.Items.Count == 0)
            {
                gruplarListeleDropDownList.Items.Add(new ListItem("Grup Seçiniz", "0"));

                for (int i = 0; i <= gruplariGetir.SQLTablo.Rows.Count - 1; i++)
                {
                    gruplarListeleDropDownList.Items.Add(new ListItem(gruplariGetir.SQLTablo.Rows[i][1].ToString(), gruplariGetir.SQLTablo.Rows[i][0].ToString()));
                }
            }
        }
        else
        {
            gruplarListeleDropDownList.Items.Clear();
            gruplarListeleDropDownList.Items.Add(new ListItem("Grup Seçiniz", "0"));
        }
    }
    protected void GridView_ogrenci_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex = GridView_ogrenci.SelectedIndex;
        GridViewRow row = GridView_ogrenci.Rows[selectedRowIndex];
        int ogrID = Convert.ToInt32(row.Cells[0].Text);

        baglanti videoSorgu = new baglanti();
        videoSorgu.verileriGetir("select * from ogrencivideo where ogrID='" + ogrID + "'");
        if (videoSorgu.SQLTablo.Rows.Count > 0)
        {
            Session[Request.Url.Authority + "egitmenOgrID"] = ogrID;
            Response.Redirect("~/inc/egitmen/ogrVideolari.aspx");
        }
        else
        {
            MessageBox mesaj = new MessageBox();
            Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

            mainMesaj.Text = mesaj.goster("2", "Öğrenciye ait ders kaydı bulunamadı.");
        }
    }
    protected void grubaGoreListeleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        karsilama.Visible = false;
        if (gruplarListeleDropDownList.SelectedIndex == 0)
        {
            mainMesaj.Text = mesaj.goster("2", "Grup Seçiniz");
            Session[Request.Url.Authority + "grupID"] = "0";
            grupAdiTXT.Text = "Yok";
            karsilama.Visible = true;
            GridView_ogrenci.Visible = false;
            GridView_gruplar.Visible = false;
            kaydetBTN.Visible = false;
        }
        else
        {
            tabloListele(" where grupID = '" + gruplarListeleDropDownList.SelectedValue + "'");
            Session[Request.Url.Authority + "grupID"] = gruplarListeleDropDownList.SelectedValue;
            grupChkSorgula();

            if (Session[Request.Url.Authority + "grupID"] != null)
            {
                if (Session[Request.Url.Authority + "grupID"] != "0")
                {
                    baglanti grupSorgula = new baglanti();
                    grupSorgula.verileriGetir("select grupAdi from gruplar where id='" + Session[Request.Url.Authority + "grupID"] + "'");
                    if (grupSorgula.SQLTablo.Rows.Count > 0)
                        grupAdiTXT.Text = grupSorgula.SQLTablo.Rows[0][0].ToString();
                }
                else
                    grupAdiTXT.Text = "Yok";
            }
            else
                grupAdiTXT.Text = "Yok";
        }
    }
    protected void bilgiBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        mainMesaj.Text = mesaj.bilgi("Seçili gruptaki öğrencilerin grup arkadaşlarının ve/veya diğer grup arkadaşlarının etkinlik videolarına ulaşması ile ilgili seçimi aşağıdaki tablodan yapabilirsiniz.", 7000);
    }
    protected void kaydetBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        string idler = "";
        foreach (GridViewRow satirbilgi in GridView_gruplar.Rows)
        {
            CheckBox secimKutusu = (CheckBox)satirbilgi.FindControl("secim");
            if (secimKutusu != null && secimKutusu.Checked)
            {
                idler += satirbilgi.Cells[1].Text + ".";
            }
        }

        if (idler != "")
        {
            baglanti gruplarGuncelle = new baglanti();
            if (gruplarGuncelle.komutCalistir("update gruplar set gruplar='" + idler.Remove(idler.Length - 1, 1) + "' where id='" + Session[Request.Url.Authority + "grupID"] + "'") == "1")
            {
                tabloListele(" where grupID = '" + Session[Request.Url.Authority + "grupID"] + "'");
                mainMesaj.Text = mesaj.goster("1", "Kayıt Başarılı");
            }
        }
        else
        {
            baglanti gruplarGuncelle = new baglanti();
            if (gruplarGuncelle.komutCalistir("update gruplar set gruplar='' where id='" + Session[Request.Url.Authority + "grupID"] + "'") == "1")
            {
                tabloListele(" where grupID = '" + Session[Request.Url.Authority + "grupID"] + "'");
                mainMesaj.Text = mesaj.goster("1", "Kayıt Başarılı");
            }
        }
        grupChkSorgula();
    }
}