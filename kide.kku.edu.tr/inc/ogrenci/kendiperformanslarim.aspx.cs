using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_ogrenci_kendiPerf : System.Web.UI.Page
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

        ogrencivideoislemleri vi = new ogrencivideoislemleri();
        rptvideolar.DataSource = vi.VideoListele(Convert.ToInt32(Session[Request.Url.Authority + "ogrenciID"]));
        rptvideolar.DataBind();

        baglanti say = new baglanti();
        say.verileriGetir("Select id From ogrencivideo where ogrID=" + Convert.ToInt32(Session[Request.Url.Authority + "ogrenciID"]));
        if (say.SQLTablo.Rows.Count > 0)
            sorguSonucuSorular.Visible = false;
        else
            sorguSonucuSorular.Visible = true;
    }
    protected void rptvideolar_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (e.CommandName == "yorumButonlari")
        {
            TextBox yorum = (TextBox)e.Item.FindControl("yorumTXT");
            int videoID = Convert.ToInt32(e.CommandArgument.ToString());
            int ogrID = Convert.ToInt32(Session[Request.Url.Authority + "ogrenciID"]);

            if (yorum.Text != "")
            {
                baglanti yorumEkle = new baglanti();
                if (yorumEkle.komutCalistir("insert into yorumlar (ogrID,egitmenID,videoID,yorum,kontrol) values ('" + ogrID + "', '0', '" + videoID + "', '" + yorum.Text + "', '3')") == "1")
                {
                    mainMesaj.Text = mesaj.goster("1", "Yorum eklendi.");
                    yorum.Text = "";

                    ogrencivideoislemleri vi = new ogrencivideoislemleri();
                    rptvideolar.DataSource = vi.VideoListele(Convert.ToInt32(Session[Request.Url.Authority + "ogrenciID"]));
                    rptvideolar.DataBind();
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

                        ogrencivideoislemleri vi = new ogrencivideoislemleri();
                        rptvideolar.DataSource = vi.VideoListele(Convert.ToInt32(Session[Request.Url.Authority + "ogrenciID"]));
                        rptvideolar.DataBind();
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
        /*Repeater rp = (Repeater)e.Item.FindControl("RepeaterYorumlar");

        yorumIslemleri yi = new yorumIslemleri();
        rp.DataSource = yi.yorumCekVideoID(Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "id").ToString()));
        rp.DataBind();
        rp.Dispose();*/
    }
}