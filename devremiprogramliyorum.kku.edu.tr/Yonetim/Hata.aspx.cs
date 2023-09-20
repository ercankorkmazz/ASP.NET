using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_Hata : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Abandon();
    }
    protected void girisYapBTN_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Yonetim/Login.aspx");
    }
}