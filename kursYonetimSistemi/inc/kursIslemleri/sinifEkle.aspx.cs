using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sinifEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bilgiIMG.Visible = false;
        bilgiTXT.Text = "";
    }
    protected void sinifEkleBTN_Click(object sender, EventArgs e)
    {
        baglanti sinifKaydet = new baglanti();
        if (sinifKaydet.komutCalistir("insert into siniflar (sinifAdi) values ('" + sinifTXT.Text + "')") == "1")
        {
            bilgiTXT.Text = "Sınıf Eklendi.";
            bilgiIMG.Visible = true;
            sinifTXT.Text = "";
        }
        else
        {
            bilgiTXT.Text = "İşlem Başarısız. Lütfen Daha Sonra Tekrar Deneyiniz.";
            bilgiIMG.Visible = true;
        }
    }
}
