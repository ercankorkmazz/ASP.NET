using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_Yonetim : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null)
        {
            Response.Redirect("~/Yonetim/Login.aspx");
        }
        else if (Session[Request.Url.Authority + "oturum"] == "kilitli")
        {
            Response.Redirect("~/Yonetim/Kilitli.aspx");
        }
        adSoyadLabelTXT.Text = Session[Request.Url.Authority + "adSoyad"].ToString();
    }
    protected void kapatBTN_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Yonetim/Login.aspx");
    }
    protected void hakkindaBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Yonetim/inc/Hakkinda.aspx");
    }
    protected void ekipBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Yonetim/inc/Ekip.aspx");
    }
    protected void etkinlikHakkindaBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Yonetim/inc/etkinlikHakkinda.aspx");
    }
    protected void etkinlikKonusuBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Yonetim/inc/etkinlikKonusu.aspx");
    }
    protected void etkinlikTarihiYeriBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Yonetim/inc/etkinlikTarihiYeri.aspx");
    }
    protected void etkinlikProgramiBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Yonetim/inc/etkinlikProgrami.aspx");
    }
    protected void katilimciKriterleriBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Yonetim/inc/katilimciKriterleri.aspx");
    }
    protected void katilimFormuBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Yonetim/inc/katilimFormu.aspx");
    }
    protected void duyurularBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Yonetim/inc/duyurular.aspx");
    }
    protected void yayinlarBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Yonetim/inc/Yayinlar.aspx");
    }
    protected void mesajlarBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Yonetim/inc/Mesajlar.aspx");
    }
    protected void iletisimBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Yonetim/inc/Iletisim.aspx");
    }
    protected void ayarlarBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Yonetim/inc/Ayarlar.aspx");
    }
    protected void siteAyarlariBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Yonetim/inc/SiteAyarlari.aspx");
    }
    protected void kilitleBTN_Click(object sender, EventArgs e)
    {
        Session[Request.Url.Authority + "oturum"] = "kilitli";
        Response.Redirect("~/Yonetim/Kilitli.aspx");
    }
    protected void oturumuKapatBTN_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Yonetim/Login.aspx");
    }
    protected void galeriBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Yonetim/inc/Galeri.aspx");
    }
}
