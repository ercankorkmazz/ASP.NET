using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_yonetim_Hastalar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "1")
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }

        if (Page.IsPostBack == false)
            bilgiTXT.Visible = true;
        else
            bilgiTXT.Visible = false;
    }

    protected void BtnListele_Click(object sender, EventArgs e)
    {
        hastaIslemleri vi = new hastaIslemleri();
        RPTHastalar.DataSource = vi.hastalariGetir(adSoyad.Text, tcNO.Text);
        RPTHastalar.DataBind();
    }

    protected void RPTHastalar_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;


        if (e.CommandName == "takipButonlari")
        {
            int takipEdilecekID = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("~/inc/yonetim/HastaTakibi.aspx?hasta=" + takipEdilecekID.ToString());
        }

        if (e.CommandName == "duzenleButonlari")
        {
            int duzenlenecekID = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("~/inc/yonetim/HastaDuzenle.aspx?hasta=" + duzenlenecekID.ToString());
        }

        if (e.CommandName == "silButonlari")
        {
            int silinecekID = Convert.ToInt32(e.CommandArgument.ToString());

            baglanti hastaSil = new baglanti();
            if (hastaSil.komutCalistir("delete from hastalar where id=" + silinecekID) == "1")
            {
                baglanti kullaniciSil = new baglanti();
                if (kullaniciSil.komutCalistir("delete from kullanicilar where hastaID=" + silinecekID) == "1")
                {
                    baglanti sayac = new baglanti();
                    sayac.verileriGetir("select id from egzersizProgramlari where hastaID='" + silinecekID + "'");
                    if (sayac.SQLTablo.Rows.Count != 0)
                    {
                        baglanti egzersizProgramiSil = new baglanti();
                        if (egzersizProgramiSil.komutCalistir("delete from egzersizProgramlari where hastaID='" + silinecekID + "'") == "1")
                        {
                            baglanti sayac_2 = new baglanti();
                            sayac_2.verileriGetir("select id from skorlar where hastaID='" + silinecekID + "'");
                            if (sayac_2.SQLTablo.Rows.Count != 0)
                            {
                                baglanti skorSil = new baglanti();
                                if (skorSil.komutCalistir("delete from skorlar where hastaID='" + silinecekID + "'") == "1")
                                {
                                    mainMesaj.Text = mesaj.goster("1", "Hasta Kaydı Silindi");

                                    hastaIslemleri vi = new hastaIslemleri();
                                    RPTHastalar.DataSource = vi.hastalariGetir(adSoyad.Text, tcNO.Text);
                                    RPTHastalar.DataBind();
                                }
                                else
                                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                            }
                            else
                            {
                                mainMesaj.Text = mesaj.goster("1", "Hasta Kaydı Silindi");

                                hastaIslemleri vi = new hastaIslemleri();
                                RPTHastalar.DataSource = vi.hastalariGetir(adSoyad.Text, tcNO.Text);
                                RPTHastalar.DataBind();
                            }
                        }
                        else
                            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                    }
                    else
                    {
                        baglanti sayac_2 = new baglanti();
                        sayac_2.verileriGetir("select id from skorlar where hastaID='" + silinecekID + "'");
                        if (sayac_2.SQLTablo.Rows.Count != 0)
                        {
                            baglanti skorSil = new baglanti();
                            if (skorSil.komutCalistir("delete from skorlar where hastaID='" + silinecekID + "'") == "1")
                            {
                                mainMesaj.Text = mesaj.goster("1", "Hasta Kaydı Silindi");

                                hastaIslemleri vi = new hastaIslemleri();
                                RPTHastalar.DataSource = vi.hastalariGetir(adSoyad.Text, tcNO.Text);
                                RPTHastalar.DataBind();
                            }
                            else
                                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                        }
                        else
                        {
                            mainMesaj.Text = mesaj.goster("1", "Hasta Kaydı Silindi");

                            hastaIslemleri vi = new hastaIslemleri();
                            RPTHastalar.DataSource = vi.hastalariGetir(adSoyad.Text, tcNO.Text);
                            RPTHastalar.DataBind();
                        }
                    }                    
                }
                else
                {
                    mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                }
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
        }
    }

    protected void BtnYeniKayit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inc/yonetim/YeniHasta.aspx");
    }
}