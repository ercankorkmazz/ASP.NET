using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_ogrenmeAmacliVideolar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "2")
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Page.IsPostBack == false)
        {
            egiticivideoislemleri vi = new egiticivideoislemleri();
            rptvideolar.DataSource = vi.videoGetirEgitmenId(Convert.ToInt32(Session[Request.Url.Authority + "oturum"]));
            rptvideolar.DataBind();
        }
    }
    protected void videoKaydetBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        int egitmenID = Convert.ToInt32(Session[Request.Url.Authority + "oturum"]);
        string bilgi = bilgiTXT.Text;
        string videoURL = videoURLTXT.Text;

        if (videoURL.Trim() != "")
        {
            if (videoURL.Substring(0, 8) == "<iframe " && videoURL.Substring((videoURL.Length-10),10).Trim() == "></iframe>")
            {
                baglanti videoEkle = new baglanti();
                if (videoEkle.komutCalistir("insert into egiticivideolar (egitmenID,bilgi,video) values ('" + egitmenID + "', '" + bilgi + "', '" + videoURL + "')") == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "Kayıt Başarılı");
                    bilgiTXT.Text = "";
                    videoURLTXT.Text = "";

                    egiticivideoislemleri vi = new egiticivideoislemleri();
                    rptvideolar.DataSource = vi.videoGetirEgitmenId(Convert.ToInt32(Session[Request.Url.Authority + "oturum"]));
                    rptvideolar.DataBind();
                }
                else
                {
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "Geçerli bir video yerleştirme kodu yazınız.");
            }
        }
        else
        {
            mainMesaj.Text = mesaj.goster("2", "Video yerleştirme kodunu yazınız.");
        }
    }
    protected void rptvideolar_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (e.CommandName == "videoSilButonlari")
        {
            int silinecekID = Convert.ToInt32(e.CommandArgument.ToString());
            
            baglanti videoSil = new baglanti();
            if (videoSil.komutCalistir("delete from egiticivideolar where id=" + silinecekID) == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Video Silindi");

                egiticivideoislemleri vi = new egiticivideoislemleri();
                rptvideolar.DataSource = vi.videoGetirEgitmenId(Convert.ToInt32(Session[Request.Url.Authority + "oturum"]));
                rptvideolar.DataBind();
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
        }
    }
}