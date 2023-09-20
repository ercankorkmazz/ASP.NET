using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_egitmen_soru : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "2")
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session[Request.Url.Authority + "soruID"] == null)
            Response.Redirect("~/inc/egitmen/test.aspx");

        int soruID = Convert.ToInt32(Session[Request.Url.Authority + "soruID"].ToString());
        string soruTuru = Session[Request.Url.Authority + "soruTuru"].ToString();
        if (soruTuru == "1")
        {
            coktanSecmeli.Visible = true;
            boslukDolsurma.Visible = false;
            dogruYanlis.Visible = false;
        }
        else if (soruTuru == "2")
        {
            coktanSecmeli.Visible = false;
            boslukDolsurma.Visible = true;
            dogruYanlis.Visible = false;
        }
        else if (soruTuru == "3")
        {
            coktanSecmeli.Visible = false;
            boslukDolsurma.Visible = false;
            dogruYanlis.Visible = true;
        }
        if (Page.IsPostBack == false)
        {
            if (soruTuru == "1")
            {
                baglanti soruGetir = new baglanti();
                int yardimci = 0;
                soruGetir.verileriGetir("select soru,yanit from sorular where id=" + soruID);
                if (soruGetir.SQLTablo.Rows.Count > 0)
                {
                    coktanSecSoru.InnerText = soruGetir.SQLTablo.Rows[0][0].ToString();
                    coktanSecmeliCevaplar.SelectedIndex = Convert.ToInt32(soruGetir.SQLTablo.Rows[0][1]) - 1;
                    yardimci = 1;
                }

                if (yardimci == 1)
                {
                    baglanti cevapGetir = new baglanti();
                    cevapGetir.verileriGetir("select yanitNo,yanit from cevaplar where soruID='" + soruID + "' order by yanitNo");
                    if (cevapGetir.SQLTablo.Rows.Count > 0)
                    {
                        for (int i = 0; i <= 4; i++)
                        {
                            if (cevapGetir.SQLTablo.Rows[i][0].ToString() == "1")
                                secenek1.Text = cevapGetir.SQLTablo.Rows[i][1].ToString();
                            else if (cevapGetir.SQLTablo.Rows[i][0].ToString() == "2")
                                secenek2.Text = cevapGetir.SQLTablo.Rows[i][1].ToString();
                            else if (cevapGetir.SQLTablo.Rows[i][0].ToString() == "3")
                                secenek3.Text = cevapGetir.SQLTablo.Rows[i][1].ToString();
                            else if (cevapGetir.SQLTablo.Rows[i][0].ToString() == "4")
                                secenek4.Text = cevapGetir.SQLTablo.Rows[i][1].ToString();
                            else if (cevapGetir.SQLTablo.Rows[i][0].ToString() == "5")
                                secenek5.Text = cevapGetir.SQLTablo.Rows[i][1].ToString();
                        }
                    }
                }
            }
            else if (soruTuru == "2")
            {
                baglanti soruGetir = new baglanti();
                soruGetir.verileriGetir("select soru,cevap from sorular where id=" + soruID);
                if (soruGetir.SQLTablo.Rows.Count > 0)
                {
                    boslukDoldurmaSorusu.InnerText = soruGetir.SQLTablo.Rows[0][0].ToString();
                    boslukDoldurCevabi.Text = soruGetir.SQLTablo.Rows[0][1].ToString();
                }
            }
            else if (soruTuru == "3")
            {
                baglanti soruGetir = new baglanti();
                soruGetir.verileriGetir("select soru,yanit from sorular where id=" + soruID);
                if (soruGetir.SQLTablo.Rows.Count > 0)
                {
                    dogruYanlisSorusu.InnerText = soruGetir.SQLTablo.Rows[0][0].ToString();
                    if (soruGetir.SQLTablo.Rows[0][1].ToString() == "1")
                        dogruYanlisCevap.SelectedIndex = 0;
                    else if (soruGetir.SQLTablo.Rows[0][1].ToString() == "2")
                        dogruYanlisCevap.SelectedIndex = 1;
                }
            }
        }
    }
    protected void geriDon_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inc/egitmen/test.aspx");
    }
    protected void coktanSecKaydetBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        int soruID = Convert.ToInt32(Session[Request.Url.Authority + "soruID"].ToString());

        baglanti soruGuncelle = new baglanti();
        int yardimci = 0;
        if (soruGuncelle.komutCalistir("update sorular set soru='" + coktanSecSoru.InnerText + "', yanit='" + coktanSecmeliCevaplar.SelectedValue + "' where id=" + soruID) == "1")
        {
            yardimci = 1;
        }
        if (yardimci == 1)
        {
            baglanti cevap1Guncelle = new baglanti();
                cevap1Guncelle.komutCalistir("update cevaplar set yanit='" + secenek1.Text + "' where yanitNo='1' and soruID=" + soruID);
            baglanti cevap2Guncelle = new baglanti();
                cevap2Guncelle.komutCalistir("update cevaplar set yanit='" + secenek2.Text + "' where yanitNo='2' and soruID=" + soruID);
            baglanti cevap3Guncelle = new baglanti();
                cevap3Guncelle.komutCalistir("update cevaplar set yanit='" + secenek3.Text + "' where yanitNo='3' and soruID=" + soruID);
            baglanti cevap4Guncelle = new baglanti();
                cevap4Guncelle.komutCalistir("update cevaplar set yanit='" + secenek4.Text + "' where yanitNo='4' and soruID=" + soruID);
            baglanti cevap5Guncelle = new baglanti();
                cevap5Guncelle.komutCalistir("update cevaplar set yanit='" + secenek5.Text + "' where yanitNo='5' and soruID=" + soruID);

            mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
    }
    protected void dogruYanlisKaydet_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        int soruID = Convert.ToInt32(Session[Request.Url.Authority + "soruID"].ToString());

        baglanti soruGuncelle = new baglanti();
        if (soruGuncelle.komutCalistir("update sorular set soru='" + dogruYanlisSorusu.InnerText + "', yanit='" + dogruYanlisCevap.SelectedValue + "' where id=" + soruID) == "1")
        {
            mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
    }
    protected void boslukDoldurBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        int soruID = Convert.ToInt32(Session[Request.Url.Authority + "soruID"].ToString());

        baglanti soruGuncelle = new baglanti();
        if (soruGuncelle.komutCalistir("update sorular set soru='" + boslukDoldurmaSorusu.InnerText + "', cevap='" + boslukDoldurCevabi.Text + "' where id=" + soruID) == "1")
        {
            mainMesaj.Text = mesaj.goster("1", "Güncelleme Yapıldı");
        }
        else
            mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
    }
}