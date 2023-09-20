using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Seviye : System.Web.UI.Page
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
                SeviyeNoTXT.Text = bilgiGetir.SQLTablo.Rows[0][0].ToString();
            }

            SeviyeNoTXT.Text = Request.QueryString["seviye"].ToString() + ". SEVİYE";
            hareketListele();

            EgzersizIslemleri vi = new EgzersizIslemleri();
            RPTEgzersizProgrami.DataSource = vi.EgzersizGetir(Convert.ToInt32(Request.QueryString["hasta"].ToString()), Convert.ToInt32(Request.QueryString["seviye"].ToString()));
            RPTEgzersizProgrami.DataBind();
        }
    }

    protected void RPTEgzersizProgrami_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (e.CommandName == "silButonlari")
        {
            int silinecekID = Convert.ToInt32(e.CommandArgument.ToString());

            baglanti hareketSil = new baglanti();
            if (hareketSil.komutCalistir("delete from egzersizProgramlari where id=" + silinecekID) == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Hareket Kaldırıldı");
                hareketListele();

                EgzersizIslemleri vi = new EgzersizIslemleri();
                RPTEgzersizProgrami.DataSource = vi.EgzersizGetir(Convert.ToInt32(Request.QueryString["hasta"].ToString()), Convert.ToInt32(Request.QueryString["seviye"].ToString()));
                RPTEgzersizProgrami.DataBind();
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
        }
    }
    public void hareketListele()
    {
        baglanti hareketleriGetir = new baglanti();

        hareketleriGetir.verileriGetir("select hareketID, hareketADI from hareketler");
        if (hareketleriGetir.SQLTablo.Rows.Count > 0)
        {
            if (hareketlerDROP.Items.Count == 0)
            {
                hareketlerDROP.Items.Add(new ListItem("Hareket Seçiniz", "-1"));

                for (int i = 0; i <= hareketleriGetir.SQLTablo.Rows.Count - 1; i++)
                {
                    hareketlerDROP.Items.Add(new ListItem(hareketleriGetir.SQLTablo.Rows[i][1].ToString(), hareketleriGetir.SQLTablo.Rows[i][0].ToString()));
                }
            }
        }
        else
        {
            hareketlerDROP.Items.Clear();
            hareketlerDROP.Items.Add(new ListItem("Hareket Seçiniz", "-1"));
        }
    }

    protected void geriDonBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inc/yonetim/Seviyeler.aspx?hasta=" + Request.QueryString["hasta"].ToString());
    }

    protected void HareketEkleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (hareketlerDROP.SelectedValue != "-1" && tekrarTXT.Text != "" && beklemeTXT.Text != "" && aciklamaTXT.Text != "")
        {
            baglanti HareketEkle = new baglanti();
            if (HareketEkle.komutCalistir("insert into egzersizProgramlari (hastaID, asamaNO, hareketID, beklemeSuresi, hareketTekrari, aciklamalar) values ('" + Request.QueryString["hasta"].ToString() + "', '" + Request.QueryString["seviye"].ToString() + "', '" + hareketlerDROP.SelectedValue +  "', '" + beklemeTXT.Text + "', '" + tekrarTXT.Text + "', '" + aciklamaTXT.Text + "')") == "1")
            {
                hareketlerDROP.SelectedIndex = 0;
                beklemeTXT.Text = "";
                tekrarTXT.Text = "";
                aciklamaTXT.Text = "";

                hareketListele();

            EgzersizIslemleri vi = new EgzersizIslemleri();
            RPTEgzersizProgrami.DataSource = vi.EgzersizGetir(Convert.ToInt32(Request.QueryString["hasta"].ToString()), Convert.ToInt32(Request.QueryString["seviye"].ToString()));
            RPTEgzersizProgrami.DataBind();

                mainMesaj.Text = mesaj.goster("1", "Hareket kaydı eklendi.");
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
            }
        }
        else
        {
            mainMesaj.Text = mesaj.goster("2", "Tüm alanları doldurunuz.");
        }
    }
}