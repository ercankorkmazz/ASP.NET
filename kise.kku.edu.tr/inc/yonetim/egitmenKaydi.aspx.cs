using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_yonetim_egitmenKaydi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "1")
        {
            Response.Redirect("~/Default.aspx");
        }
        listeleBTN.Visible = true;
        GridView_egitmen.Visible = false;
        sorguSonucu.Visible = false;
        egitmenSilBTN.Visible = false;
    }
    public void tabloListele()
    {
        baglanti sorgu = new baglanti();
        listeleBTN.Visible = false;
        int kontrol = 1;
        sorgu.verileriGetir("select UserID from UserTable where UserType='2'");
        if (sorgu.SQLTablo.Rows.Count > 0)
            kontrol = 1;
        else
        {
            kontrol = 0;
            GridView_egitmen.Visible = false;
            sorguSonucu.Visible = true;
            egitmenSilBTN.Visible = false;
        }

        if (kontrol == 1)
        {
            GridView_egitmen.Visible = true;
            sorguSonucu.Visible = false;
            egitmenSilBTN.Visible = true;

            baglanti Listele = new baglanti();
            Listele.verileriGetir("select UserID,UserName,Email,PhoneNumber,Name,Surname from UserTable where UserType='2' order by UserID");
            if (Listele.SQLTablo.Rows.Count > 0)
            {
                GridView_egitmen.DataSource = Listele.SQLTablo;
                GridView_egitmen.DataBind();
            }
        }
    }
    protected void egitmenSilBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        string idler = "";
        foreach (GridViewRow satirbilgi in GridView_egitmen.Rows)
        {
            CheckBox secimKutusu = (CheckBox)satirbilgi.FindControl("secim");
            if (secimKutusu != null && secimKutusu.Checked)
            {                
                idler += "UserID=" + satirbilgi.Cells[1].Text + " or ";
            }
        }
        if(idler != String.Empty)
        {
            baglanti egitmenSil = new baglanti();
            if (egitmenSil.komutCalistir("delete from UserTable where " + idler.Remove(idler.Length - 4, 4)) == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Seçili eğitmenler silindi.");
                tabloListele();
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
    }
    protected void listeleBTN_Click(object sender, EventArgs e)
    {
        tabloListele();
    }
}