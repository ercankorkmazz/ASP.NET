using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_ogrenci_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }
        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "3")
        {
            Response.Redirect("~/Default.aspx");
        }
        if(Session[Request.Url.Authority + "testCozID"] == null)
            Response.Redirect("~/inc/ogrenci/testler.aspx");

        baglanti testBilgileri = new baglanti();
        testBilgileri.verileriGetir("select testadi from testler where id='" + Session[Request.Url.Authority + "testCozID"].ToString() + "'");
        if (testBilgileri.SQLTablo.Rows.Count > 0)
            baslik.Text = testBilgileri.SQLTablo.Rows[0][0].ToString();

        dogruYanlisSorulariGetir dy = new dogruYanlisSorulariGetir();
        rptDogruYanlis.DataSource = dy.dogruYanlisListele(Convert.ToInt32(Session[Request.Url.Authority + "testCozID"]));
        rptDogruYanlis.DataBind();

        boslukDoldurmaSorusuGetir bd = new boslukDoldurmaSorusuGetir();
        rptBoslukDoldur.DataSource = bd.boslukDoldurmaListele(Convert.ToInt32(Session[Request.Url.Authority + "testCozID"]));
        rptBoslukDoldur.DataBind();

        coktanSecmeliSorulariGetir cs = new coktanSecmeliSorulariGetir();
        rptCoktanSecmeli.DataSource = cs.coktanSecmeliListele(Convert.ToInt32(Session[Request.Url.Authority + "testCozID"]));
        rptCoktanSecmeli.DataBind();
    }
    protected void rptCoktanSecmeli_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rp = (Repeater)e.Item.FindControl("RepeaterCevaplar");

        coktanSecmeliCevaplari csc = new coktanSecmeliCevaplari();
        rp.DataSource = csc.cevaplariListele(Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "id").ToString()));
        rp.DataBind();
        rp.Dispose();
    }
}