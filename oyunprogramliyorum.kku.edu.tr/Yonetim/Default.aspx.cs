using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_Default : System.Web.UI.Page
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
    }
}