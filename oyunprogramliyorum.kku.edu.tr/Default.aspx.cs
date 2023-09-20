using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            sliderIslemleri sii = new sliderIslemleri();
            rptslider.DataSource = sii.resimGetir();
            rptslider.DataBind();

            sayfaIslemleri si = new sayfaIslemleri();
            rptsayfa.DataSource = si.sayfaBilgileriGetir();
            rptsayfa.DataBind();
        }
    }
}