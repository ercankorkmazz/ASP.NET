using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null)
        {
            Response.Redirect("~/Yonetim/Login.aspx");
        }
        else if (Session[Request.Url.Authority + "oturum"] == "kilitli")
        {
            Response.Redirect("~/Yonetim/Kilitli.aspx");
        }
        if (Page.IsPostBack == false)
        {
            iletisimIslemleri ki = new iletisimIslemleri();
            rptMesajlar.DataSource = ki.mesajGetir();
            rptMesajlar.DataBind();
        }
    }
    protected void rptMesajlar_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (e.CommandName == "MesajSilBTN")
        {
            int mesajID = Convert.ToInt32(e.CommandArgument.ToString());

            baglanti sil = new baglanti();
            if (sil.komutCalistir("delete from iletisim where id='" + mesajID.ToString() + "'") == "1")
            {
                iletisimIslemleri ki = new iletisimIslemleri();
                rptMesajlar.DataSource = ki.mesajGetir();
                rptMesajlar.DataBind();
                mainMesaj.Text = mesaj.goster("1", "Silindi");
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
    }
}