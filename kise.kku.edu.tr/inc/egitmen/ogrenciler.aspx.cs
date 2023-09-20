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
        sorguSonucu.Visible = false;
    }
    public void tabloListele()
    {
        baglanti sorgu = new baglanti();
        GridView_ogrenci.Visible = true;
        sorguSonucu.Visible = false;
        listeleBTN.Visible = true;

        int kontrol = 1;
        sorgu.verileriGetir("select UserID from UserTable where UserType='3'");
        if (sorgu.SQLTablo.Rows.Count > 0)
        {
            kontrol = 1;
            listeleBTN.Visible = false;
            GridView_ogrenci.Visible = true;
            sorguSonucu.Visible = false;
        }
        else
        {
            kontrol = 0;
            GridView_ogrenci.Visible = false;
            sorguSonucu.Visible = true;
        }

        if (kontrol == 1)
        {
            baglanti Listele = new baglanti();
            Listele.verileriGetir("select UserID, Name, Surname, Email, PhoneNumber, IDNumber from UserTable where UserType='3'");
            if (Listele.SQLTablo.Rows.Count > 0)
            {
                GridView_ogrenci.DataSource = Listele.SQLTablo;
                GridView_ogrenci.DataBind();
            }
        }
    }
    protected void listeleBTN_Click(object sender, EventArgs e)
    {
        tabloListele();
    }
    protected void GridView_ogrenci_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex = GridView_ogrenci.SelectedIndex;
        GridViewRow row = GridView_ogrenci.Rows[selectedRowIndex];
        int ogrID = Convert.ToInt32(row.Cells[0].Text);

        Session[Request.Url.Authority + "ogrID"] = ogrID;
        Response.Redirect("~/inc/egitmen/ogrenci.aspx");
    }
}