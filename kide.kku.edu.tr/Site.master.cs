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
            Response.Redirect("~/giris.aspx");

        mesajTXT.Text = "";

        if (Session[Request.Url.Authority + "kullaniciTuru"].ToString() == "1")
        {
            anasayfaBTN.Visible = true;
            ogrAnasayfBTN.Visible = false;
            MenuYonetim.Visible = true;
            MenuEgitmen.Visible = false;
            MenuOgrenci.Visible = false;
        }
        else if (Session[Request.Url.Authority + "kullaniciTuru"].ToString() == "2")
        {
            anasayfaBTN.Visible = true;
            ogrAnasayfBTN.Visible = false;
            MenuYonetim.Visible = false;
            MenuEgitmen.Visible = true;
            MenuOgrenci.Visible = false;
        }
        else if (Session[Request.Url.Authority + "kullaniciTuru"].ToString() == "3")
        {
            anasayfaBTN.Visible = false;
            ogrAnasayfBTN.Visible = true;
            MenuYonetim.Visible = false;
            MenuEgitmen.Visible = false;
            MenuOgrenci.Visible = true;
        }
        else
        {
            anasayfaBTN.Visible = false;
            ogrAnasayfBTN.Visible = false;
            MenuYonetim.Visible = false;
            MenuEgitmen.Visible = false;
            MenuOgrenci.Visible = false;
        }
    }
    protected void oturumuKapatBTN_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Default.aspx");
    }
    protected void ayarlarBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inc/ayar/ayarlar.aspx");
    }
}
