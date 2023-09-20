using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ogretmenKayit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bilgiIMG.Visible = false;
        bilgiTXT.Text = "";
    }
    protected void ogretmenKaydetBTN_Click(object sender, EventArgs e)
    {
        baglanti ogretmenKaydet = new baglanti();
        if (ogretmenKaydet.komutCalistir("insert into ogretmenler (alan, adSoyad, yas, sicilNo, tel, ePosta, adres) values ('" + alanTXT.Text + "','" + adSoyadTXT.Text + "','" + yasTXT.Text + "','" + sicilNoTXT.Text + "','" + telTXT.Text + "','" + ePostaTXT.Text + "','" + adresTXT.InnerText + "')") == "1")
        {
            bilgiTXT.Text = "Kayıt başarılı.";
            bilgiIMG.Visible = true;

            alanTXT.Text = ""; 
            adSoyadTXT.Text = ""; 
            yasTXT.Text = ""; 
            sicilNoTXT.Text = ""; 
            telTXT.Text = ""; 
            ePostaTXT.Text = "";
            adresTXT.InnerText = "";
        }
        else
        {
            bilgiTXT.Text = "İşlem başarısız. İstenilen bilgileri doğru girdiğinizden emin olunuz.";
            bilgiIMG.Visible = true;
        }
    }
}
