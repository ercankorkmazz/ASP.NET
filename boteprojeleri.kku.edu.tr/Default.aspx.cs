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
            kategoriListele kl = new kategoriListele();
            rptKategoriler.DataSource = kl.kategorileriGetir();
            rptKategoriler.DataBind();
        }
    }
    protected void rptKategoriler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void rptKategoriler_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rp = (Repeater)e.Item.FindControl("RepeaterProjeler");

        projeListele yi = new projeListele();
        rp.DataSource = yi.projeleriGetir(Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "id").ToString()));
        rp.DataBind();
        rp.Dispose();
    }
}