using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Galeri : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            galeriIslemleri sii = new galeriIslemleri();
            rptgaleri.DataSource = sii.resimGetir();
            rptgaleri.DataBind();
        }
    }
}