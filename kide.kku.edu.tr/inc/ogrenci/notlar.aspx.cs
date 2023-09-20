using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_ogrenci_notlar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "3")
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Page.IsPostBack == false)
        {
            dersNotuIslemleri vi = new dersNotuIslemleri();
            rptnotlar.DataSource = vi.dersNotuGetir();
            rptnotlar.DataBind();

            baglanti say = new baglanti();
            say.verileriGetir("Select id From notlar");
            if (say.SQLTablo.Rows.Count > 0)
                sorguSonucuSorular.Visible = false;
            else
                sorguSonucuSorular.Visible = true;
        }
    }
}