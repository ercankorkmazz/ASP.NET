﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ekip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        sayfaIslemleri si = new sayfaIslemleri();
        rptsayfa.DataSource = si.sayfaBilgileriGetir();
        rptsayfa.DataBind();
    }
}