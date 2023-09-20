using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_ogrenci_ogrenmeAmacliVideolar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "3")
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Page.IsPostBack == false)
        {
            string TCNo = Session[Request.Url.Authority + "ogrenciTC"].ToString();

            baglanti say = new baglanti();
            say.verileriGetir("select PerformaneID from PerformanceTable where IDNumber = " + TCNo);
            if (say.SQLTablo.Rows.Count > 0)
            {
                sorguSonucu.Visible = false;
                ogrenciperformansislemleri opi = new ogrenciperformansislemleri();
                rptperformanslar.DataSource = opi.performansGetir(TCNo);
                rptperformanslar.DataBind();
                baslikTR.Visible = true;
            }
            else
            {
                sorguSonucu.Visible = true;
                baslikTR.Visible = false;
            }
        }
    }
}