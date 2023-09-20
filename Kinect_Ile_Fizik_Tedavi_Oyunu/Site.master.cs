using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null)
            Response.Redirect("~/Giris.aspx");

        if (Session[Request.Url.Authority + "kullaniciTuru"].ToString() == "1")
        {
            yonetimMenu.Visible = true;
            hastaMenu.Visible = false;
        }
        else if (Session[Request.Url.Authority + "kullaniciTuru"].ToString() == "2")
        {
            hastaMenu.Visible = true;
            yonetimMenu.Visible = false;
        }

    }

    protected void oturumuKapatBTN_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Default.aspx");
    }

    protected void Anasayfabtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    protected void HastaKayitlaribtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inc/yonetim/Hastalar.aspx");
    }

    protected void KullaniciKayitlariBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inc/yonetim/Kullanicilar.aspx");
    }

    protected void HastaOturumKapatBTN_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Default.aspx");
    }

    protected void HastaKullaniciIslemleriBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inc/hasta/Kullanici.aspx");
    }

    protected void HastaSkorlarBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inc/hasta/Skorlar.aspx");
    }

    protected void HastaAnasayfaBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}
