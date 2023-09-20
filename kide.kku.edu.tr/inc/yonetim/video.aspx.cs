using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_yonetim_video : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "1")
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session[Request.Url.Authority + "videoID"] != null)
        {
            baglanti sorgu = new baglanti();
            sorgu.verileriGetir("select id from ogrencivideo where id='" + Session[Request.Url.Authority + "videoID"] + "'");
            if (sorgu.SQLTablo.Rows.Count < 1)
                Response.Redirect("~/inc/yonetim/ogrenci.aspx");

            baglanti ogrAdiSorgula = new baglanti();
            ogrAdiSorgula.verileriGetir("select adSoyad from ogrenciler where id='" + Session[Request.Url.Authority + "ogrID"] + "'");
            if (ogrAdiSorgula.SQLTablo.Rows.Count > 0)
                ogrAdiTXT.Text = ogrAdiSorgula.SQLTablo.Rows[0][0].ToString();

            yorumIslemleri vi = new yorumIslemleri();
            rptYorumlar.DataSource = vi.yorumCekOgrenciID(Convert.ToInt32(Session[Request.Url.Authority + "ogrID"]));
            rptYorumlar.DataBind();
        }
        else
            Response.Redirect("~/inc/yonetim/ogrenci.aspx");
    }
    protected void geriDon_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inc/yonetim/ogrenci.aspx");
    }
    protected void rptyorumlar_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (e.CommandName == "yorumSilButonlari")
        {
            int yorumID = Convert.ToInt32(e.CommandArgument.ToString());

            baglanti yorumSil = new baglanti();
            if (yorumSil.komutCalistir("delete from yorumlar where id=" + yorumID) == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Yorum silindi.");

                yorumIslemleri vi = new yorumIslemleri();
                rptYorumlar.DataSource = vi.yorumCekOgrenciID(Convert.ToInt32(Session[Request.Url.Authority + "ogrID"]));
                rptYorumlar.DataBind();
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
        }
    }
}