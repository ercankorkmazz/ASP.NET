﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["oturum"] != null)
        {
            oturumuKapatBTN.Visible = true;
            kullaniciAyarlariBTN.Visible = true;
        }
    }
    protected void kullaniciAyarlariBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inc/kullaniciAyarlari.aspx");
    }
    protected void oturumuKapatBTN_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Default.aspx");
    }
}
