using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_yonetim_HastaDuzenle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "1")
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }

        if (Page.IsPostBack == false)
        {
            baglanti bilgiGetir = new baglanti();

            bilgiGetir.verileriGetir("select * from hastalar where id='" + Request.QueryString["hasta"] + "'");
            if (bilgiGetir.SQLTablo.Rows.Count > 0)
            {
                tcNoTXT.Text = bilgiGetir.SQLTablo.Rows[0][1].ToString();
                adSoyadTXT.Text = bilgiGetir.SQLTablo.Rows[0][2].ToString();
                yasTXT.Text = bilgiGetir.SQLTablo.Rows[0][3].ToString();
                hastaDurumuTXT.Text = bilgiGetir.SQLTablo.Rows[0][4].ToString();
            }
        }
    }

    protected void guncelleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        baglanti HastaGuncelle = new baglanti();

        if (HastaGuncelle.komutCalistir("update hastalar set TC='" + tcNoTXT.Text + "', adSoyad='" + adSoyadTXT.Text + "', yas='" + yasTXT.Text + "', hastaninDurumu='" + hastaDurumuTXT.Text + "' where id='" + Request.QueryString["hasta"] + "'") == "1")
        {
            mainMesaj.Text = mesaj.goster("1", "Güncellene Yapıldı");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
    }

    protected void geriDonBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inc/yonetim/Hastalar.aspx");
    }
}