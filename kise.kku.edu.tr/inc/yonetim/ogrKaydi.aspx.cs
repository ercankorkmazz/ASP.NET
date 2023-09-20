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
        sorguSonucu.Visible = false;
    }
    public void tabloListele()
    {
        baglanti sorgu = new baglanti();
        GridView_ogrenci.Visible = true;
        sorguSonucu.Visible = false;

        int kontrol = 1;
        sorgu.verileriGetir("select UserID from UserTable where UserType='3'");
        if (sorgu.SQLTablo.Rows.Count > 0)
            kontrol = 1;
        else
        {
            kontrol = 0;
            GridView_ogrenci.Visible = false;
            sorguSonucu.Visible = true;
            ogrenciSilBTN.Visible = false;
            listeleBTN.Visible = false;
        }

        if(kontrol==1)
        {
            ogrenciSilBTN.Visible = true;
            listeleBTN.Visible = false;

            baglanti Listele = new baglanti();
            Listele.verileriGetir("select UserID, UserName, Name, Surname, Email, PhoneNumber, IDNumber from UserTable where UserType='3'");
            if (Listele.SQLTablo.Rows.Count > 0)
            {
                GridView_ogrenci.DataSource = Listele.SQLTablo;
                GridView_ogrenci.DataBind();
            }
        }
    }
    protected void GridView_ogrenci_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex = GridView_ogrenci.SelectedIndex;
        GridViewRow row = GridView_ogrenci.Rows[selectedRowIndex];
        int ogrID = Convert.ToInt32(row.Cells[1].Text);

        Session[Request.Url.Authority + "ogrID"] = ogrID;
        Response.Redirect("~/inc/yonetim/ogrenci.aspx");
    }
    protected void ogrenciSilBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        string idler = "";
        foreach (GridViewRow satirbilgi in GridView_ogrenci.Rows)
        {
            CheckBox secimKutusu = (CheckBox)satirbilgi.FindControl("secim");
            if (secimKutusu != null && secimKutusu.Checked)
                idler += "UserID=" + satirbilgi.Cells[1].Text + " or ";
        }

        if (idler != "")
        {
            baglanti kullaniciSil = new baglanti();
            if (kullaniciSil.komutCalistir("delete from UserTable where " + idler.Remove(idler.Length - 4, 4)) == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Seçili öğrenciler silindi.");
                tabloListele();
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
    }
    protected void listeleBTN_Click(object sender, EventArgs e)
    {
        tabloListele();
    }
}