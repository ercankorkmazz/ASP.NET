using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_inc_SiteAyarlari : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            baglanti bilgiGetir = new baglanti();
            bilgiGetir.verileriGetir("select * from siteAyarlari where id='1'");
            if (bilgiGetir.SQLTablo.Rows.Count > 0)
            {
                titleTXT.Text = bilgiGetir.SQLTablo.Rows[0][1].ToString();
                anahtarKelimelerTXT.Text = bilgiGetir.SQLTablo.Rows[0][2].ToString();
                aciklamaTXT.Text = bilgiGetir.SQLTablo.Rows[0][3].ToString();
                hakkimizdaTXT.InnerText = bilgiGetir.SQLTablo.Rows[0][4].ToString();
                adresTXT.Text = bilgiGetir.SQLTablo.Rows[0][5].ToString();
                telefonTXT.Text = bilgiGetir.SQLTablo.Rows[0][6].ToString();
                ePostaTXT.Text = bilgiGetir.SQLTablo.Rows[0][7].ToString();
                facebookTXT.Text = bilgiGetir.SQLTablo.Rows[0][8].ToString();
                twitterTXT.Text = bilgiGetir.SQLTablo.Rows[0][9].ToString();
                flickrTXT.Text = bilgiGetir.SQLTablo.Rows[0][10].ToString();
                googleTXT.Text = bilgiGetir.SQLTablo.Rows[0][11].ToString();
                dribbbleTXT.Text = bilgiGetir.SQLTablo.Rows[0][12].ToString();
            }
        }
    }
    protected void kaydetBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        baglanti sayfaGuncelle = new baglanti();
        if (sayfaGuncelle.komutCalistir("update siteAyarlari set title='" + titleTXT.Text + "', anahtarKelimeler='" + anahtarKelimelerTXT.Text + "', aciklama='" + aciklamaTXT.Text + "', bizKimiz='" + hakkimizdaTXT.InnerText + "', adres='" + adresTXT.Text + "', telefon='" + telefonTXT.Text + "', ePosta='" + ePostaTXT.Text + "', facebookLink='" + facebookTXT.Text + "', twitterLink='" + twitterTXT.Text + "', flickrLink='" + flickrTXT.Text + "', googleLink='" + googleTXT.Text + "', dribbbleLink='" + dribbbleTXT.Text + "' where id='1'") == "1")
        {
            mainMesaj.Text = mesaj.goster("1", "Güncellene Yapıldı");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
    }
}