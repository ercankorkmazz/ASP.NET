using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_egitmen_ogrVideolari : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "2")
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session[Request.Url.Authority + "egitmenOgrID"] == null)
            Response.Redirect("~/inc/egitmen/ogrenciler.aspx");

        if (Session[Request.Url.Authority + "egitmenOgrID"] != null)
        {
            baglanti ogrAdiSorgula = new baglanti();
            ogrAdiSorgula.verileriGetir("select adSoyad from ogrenciler where id='" + Session[Request.Url.Authority + "egitmenOgrID"] + "'");
            
            if (ogrAdiSorgula.SQLTablo.Rows.Count > 0)
                ogrAdiTXT.Text = ogrAdiSorgula.SQLTablo.Rows[0][0].ToString();

            egitmeneOgrVideolariGetir vi = new egitmeneOgrVideolariGetir();
            rptDigerVideolar.DataSource = vi.ogrVideoListele(Session[Request.Url.Authority + "egitmenOgrID"].ToString());
            rptDigerVideolar.DataBind();
        }
        else
            Response.Redirect("~/inc/egitmen/ogrenci.aspx");

    }
    protected void geriDon_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inc/egitmen/ogrenciler.aspx");
    }
    protected void rptvideolar_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "yorumButonlari")
        {
            string videoID = e.CommandArgument.ToString();
            Response.Redirect("~/inc/egitmen/video.aspx?video=" + videoID);
        }
    }
}