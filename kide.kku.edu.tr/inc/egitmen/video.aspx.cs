using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_ogrenci_video : System.Web.UI.Page
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

        akranvideogetir vi = new akranvideogetir();
        rptDigerVideolar.DataSource = vi.akranVideoListeleVideoID(Convert.ToInt32(Request.QueryString["video"]));
        rptDigerVideolar.DataBind();

    }
    protected void rptvideolar_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (e.CommandName == "yorumButonlari")
        {
            TextBox yorum = (TextBox)e.Item.FindControl("yorumTXT");
            int videoID = Convert.ToInt32(e.CommandArgument.ToString());
            int egitmenID = Convert.ToInt32(Session[Request.Url.Authority + "oturum"].ToString());

            if (yorum.Text != "")
            {
                baglanti yorumEkle = new baglanti();
                if (yorumEkle.komutCalistir("insert into yorumlar (ogrID,egitmenID,videoID,yorum,kontrol,ogrenciID) values ('0', '" + egitmenID.ToString() + "', '" + videoID + "', '" + yorum.Text + "', '2', '" + Convert.ToInt32(Session[Request.Url.Authority + "egitmenOgrID"]) + "')") == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "Yorum eklendi.");
                    yorum.Text = "";

                    akranvideogetir vi = new akranvideogetir();
                    rptDigerVideolar.DataSource = vi.akranVideoListeleVideoID(Convert.ToInt32(Request.QueryString["video"]));
                    rptDigerVideolar.DataBind();
                }
                else
                {
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "Yorum yazınız.");
            }
        }
    }
    protected void rptyorumlar_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (e.CommandName == "yorumSilButonlari")
        {
            int yorumID = Convert.ToInt32(e.CommandArgument.ToString());
            int ogrId = Convert.ToInt32(Session[Request.Url.Authority + "ogrenciID"]);

            baglanti yorumBilgileri = new baglanti();
            yorumBilgileri.verileriGetir("select ogrID,kontrol from yorumlar where id='" + yorumID + "'");
            if (yorumBilgileri.SQLTablo.Rows.Count > 0)
            {
                    baglanti yorumEkle = new baglanti();
                    if (yorumEkle.komutCalistir("delete from yorumlar where id=" + yorumID) == "1")
                    {
                        mainMesaj.Text = mesaj.goster("1", "Yorum silindi.");

                        akranvideogetir vi = new akranvideogetir();
                        rptDigerVideolar.DataSource = vi.akranVideoListeleVideoID(Convert.ToInt32(Request.QueryString["video"]));
                        rptDigerVideolar.DataBind();
                    }
                    else
                    {
                        mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                    }
            }
        }
    }
    protected void rptvideolar_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rp = (Repeater)e.Item.FindControl("RepeaterYorumlar");

        yorumIslemleri yi = new yorumIslemleri();
        rp.DataSource = yi.yorumCekOgrenciID(Convert.ToInt32(Session[Request.Url.Authority + "egitmenOgrID"]));
        rp.DataBind();
        rp.Dispose();
    }
}