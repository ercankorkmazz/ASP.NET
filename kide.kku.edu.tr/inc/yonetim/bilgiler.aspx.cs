﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_yonetim_bilgiler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "1")
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Page.IsPostBack == false)
        {
            baglanti bilgiGetir = new baglanti();
            bilgiGetir.verileriGetir("select hakkinda,ekip,yayinlar,anasayfa from bilgiler where id='1'");
            if (bilgiGetir.SQLTablo.Rows.Count > 0)
            {
                hakkindaTXT.InnerText = bilgiGetir.SQLTablo.Rows[0][0].ToString();
                ekipTXT.InnerText = bilgiGetir.SQLTablo.Rows[0][1].ToString();
                yayinlarTXT.InnerText = bilgiGetir.SQLTablo.Rows[0][2].ToString();
                anasayfaTXT.InnerText = bilgiGetir.SQLTablo.Rows[0][3].ToString();
            }
        }
    }
    protected void anasayfaGuncelleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        baglanti bilgiGuncelle = new baglanti();
        if (bilgiGuncelle.komutCalistir("update bilgiler set anasayfa='" + anasayfaTXT.InnerText + "' where id='1'") == "1")
        {
            mainMesaj.Text = mesaj.goster("1", "Güncellene Yapıldı");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
    }
    protected void girisBilgileriGuncelleBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        baglanti ogrenciGuncelle = new baglanti();
        if (ogrenciGuncelle.komutCalistir("update bilgiler set hakkinda='" + hakkindaTXT.InnerText + "', ekip='" + ekipTXT.InnerText + "', yayinlar='" + yayinlarTXT.InnerText + "' where id='1'") == "1")
        {
            mainMesaj.Text = mesaj.goster("1", "Güncellene Yapıldı");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
    }
}