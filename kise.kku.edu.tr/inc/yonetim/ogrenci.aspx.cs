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
        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "1")
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Page.IsPostBack == false)
        {
            string TCNo = String.Empty;
            baglanti ogrGetir = new baglanti();
            ogrGetir.verileriGetir("select Name,Surname,IDNumber from UserTable where UserID='" + Session[Request.Url.Authority + "ogrID"].ToString() + "'");
            if (ogrGetir.SQLTablo.Rows.Count > 0)
            {
                TCNo = ogrGetir.SQLTablo.Rows[0][2].ToString();
                adSoyadTXT.Text = ogrGetir.SQLTablo.Rows[0][0].ToString() + " " + ogrGetir.SQLTablo.Rows[0][1].ToString();
            }

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