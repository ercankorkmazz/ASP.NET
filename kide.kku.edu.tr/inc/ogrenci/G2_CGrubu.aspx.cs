using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class G2_CGrubu : System.Web.UI.Page
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
        int videoID = 2047;
        if (Session[Request.Url.Authority + "G2_CGrubuVideoID"] != null)
            videoID = Convert.ToInt32(Session[Request.Url.Authority + "G2_CGrubuVideoID"]);

        akranvideogetir vi = new akranvideogetir();
        rptDigerVideolar.DataSource = vi.akranVideoListeleVideoID(videoID);
        rptDigerVideolar.DataBind();

    }
    protected void rptvideolar_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (e.CommandName == "yorumButonlari")
        {
            TextBox yorum = (TextBox)e.Item.FindControl("yorumTXT");
            int ogrenciID = Convert.ToInt32(e.CommandArgument.ToString());
            int ogrID = Convert.ToInt32(Session[Request.Url.Authority + "ogrenciID"]);

            if (yorum.Text != "")
            {
                baglanti yorumEkle = new baglanti();
                if (yorumEkle.komutCalistir("insert into yorumlar (ogrID,egitmenID,videoID,yorum,kontrol,ogrenciID) values ('" + ogrID + "', '0', '0', '" + yorum.Text + "', '3', '" + ogrenciID + "')") == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "Yorum eklendi.");
                    yorum.Text = "";

                    int videoID = 2047;
                    if (Session[Request.Url.Authority + "G2_CGrubuVideoID"] != null)
                        videoID = Convert.ToInt32(Session[Request.Url.Authority + "G2_CGrubuVideoID"]);

                    akranvideogetir vi = new akranvideogetir();
                    rptDigerVideolar.DataSource = vi.akranVideoListeleVideoID(videoID);
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
                if(yorumBilgileri.SQLTablo.Rows[0][1].ToString() == "3" && yorumBilgileri.SQLTablo.Rows[0][0].ToString() == ogrId.ToString())
                {
                    baglanti yorumEkle = new baglanti();
                    if (yorumEkle.komutCalistir("delete from yorumlar where id=" + yorumID) == "1")
                    {
                        mainMesaj.Text = mesaj.goster("1", "Yorum silindi.");

                        int videoID = 2042;
                        if (Session[Request.Url.Authority + "G2_CGrubuVideoID"] != null)
                            videoID = Convert.ToInt32(Session[Request.Url.Authority + "G2_CGrubuVideoID"]);

                        akranvideogetir vi = new akranvideogetir();
                        rptDigerVideolar.DataSource = vi.akranVideoListeleVideoID(videoID);
                        rptDigerVideolar.DataBind();
                    }
                    else
                    {
                        mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                    }
                }
                else
                    mainMesaj.Text = mesaj.goster("2", "Sadece kendi yorumlarınızı silebilirsiniz.");
            }
        }
    }
    protected void rptvideolar_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rp = (Repeater)e.Item.FindControl("RepeaterYorumlar");

        yorumIslemleri yi = new yorumIslemleri();
        rp.DataSource = yi.yorumCekOgrenciID(4077);
        rp.DataBind();
        rp.Dispose();

        Repeater vb = (Repeater)e.Item.FindControl("rptVideoGitButonlari");

        akranvideoislemleri videoButonlari = new akranvideoislemleri();
        vb.DataSource = videoButonlari.digerVideoListeleOgrID(4077);
        vb.DataBind();
        vb.Dispose();
    }
    protected void rptVideoGitButonlari_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (e.CommandName == "videoGitButonlari")
        {
            Session[Request.Url.Authority + "G2_CGrubuVideoID"] = Convert.ToInt32(e.CommandArgument.ToString());
            akranvideogetir vi = new akranvideogetir();
            rptDigerVideolar.DataSource = vi.akranVideoListeleVideoID(Convert.ToInt32(Session[Request.Url.Authority + "G2_CGrubuVideoID"]));
            rptDigerVideolar.DataBind();
        }
    }
}