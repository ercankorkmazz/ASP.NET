using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Seviyeler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "1")
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }

        if (Page.IsPostBack == false)
        {
            baglanti bilgiGetir = new baglanti();

            bilgiGetir.verileriGetir("select adSoyad, asamaSayisi from hastalar where id='" + Request.QueryString["hasta"] + "'");
            if (bilgiGetir.SQLTablo.Rows.Count > 0)
            {
                hastaAdiTXT.Text = bilgiGetir.SQLTablo.Rows[0][0].ToString();
                SeviyelerDROP.SelectedIndex = Convert.ToInt32(bilgiGetir.SQLTablo.Rows[0][1].ToString());

                seviyeIslemleri si = new seviyeIslemleri();
                RPTSeviyeler.DataSource = si.seviyeGetir(Convert.ToInt32(Request.QueryString["hasta"]), Convert.ToInt32(bilgiGetir.SQLTablo.Rows[0][1].ToString()));
                RPTSeviyeler.DataBind();
            }
        }
    }

    protected void geriDonBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inc/yonetim/Hastalar.aspx");
    }

    protected void BtnListele_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (SeviyelerDROP.SelectedValue != "0")
        {
            baglanti SeviyeGuncelle = new baglanti();

            if (SeviyeGuncelle.komutCalistir("update hastalar set asamaSayisi='" + SeviyelerDROP.SelectedValue + "', asamaKontrolu='1' where id='" + Request.QueryString["hasta"] + "'") == "1")
            {
                baglanti sayac = new baglanti();
                sayac.verileriGetir("select id from egzersizProgramlari where hastaID='" + Request.QueryString["hasta"] + "'");
                if (sayac.SQLTablo.Rows.Count != 0)
                {
                    baglanti egzersizProgramiSil = new baglanti();
                    if (egzersizProgramiSil.komutCalistir("delete from egzersizProgramlari where hastaID='" + Request.QueryString["hasta"] + "'") == "1")
                    {
                        seviyeIslemleri si = new seviyeIslemleri();
                        RPTSeviyeler.DataSource = si.seviyeGetir(Convert.ToInt32(Request.QueryString["hasta"]), Convert.ToInt32(SeviyelerDROP.SelectedValue));
                        RPTSeviyeler.DataBind();

                        mainMesaj.Text = mesaj.goster("1", "Seviyeler Oluşturuldu");
                    }
                    else
                        mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
                else
                {
                    seviyeIslemleri si = new seviyeIslemleri();
                    RPTSeviyeler.DataSource = si.seviyeGetir(Convert.ToInt32(Request.QueryString["hasta"]), Convert.ToInt32(SeviyelerDROP.SelectedValue));
                    RPTSeviyeler.DataBind();

                    mainMesaj.Text = mesaj.goster("1", "Seviyeler Oluşturuldu");
                }
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "Seviye Belirleyiniz");
    }
}