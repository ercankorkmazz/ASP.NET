using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Site_Master : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            sliderIslemleri sii = new sliderIslemleri();
            rptslider.DataSource = sii.resimGetir();
            rptslider.DataBind();

            siteAyarlari sa = new siteAyarlari();
            rptBilgiler.DataSource = sa.siteBilgileriniGetir();
            rptBilgiler.DataBind();
        }

        baglanti siteBilgileriGetir = new baglanti();
        siteBilgileriGetir.verileriGetir("select * from siteAyarlari where id='1'");
        if (siteBilgileriGetir.SQLTablo.Rows.Count > 0)
        {
            Page.Title = string.Format(siteBilgileriGetir.SQLTablo.Rows[0][1].ToString(), DateTime.Now);
            Page.MetaKeywords = siteBilgileriGetir.SQLTablo.Rows[0][2].ToString();
            Page.MetaDescription = siteBilgileriGetir.SQLTablo.Rows[0][3].ToString();
        }
    }
}
