using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inc_egitmen_testKaydi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Request.Url.Authority + "oturum"] == null || Session[Request.Url.Authority + "kullaniciTuru"].ToString() != "2")
        {
            Response.Redirect("~/Default.aspx");
        }
        sorguSonucu.Visible = false;
        GridView_testler.Visible = false;
        testSilBTN.Visible = false;
        if (Page.IsPostBack == false)
        {
            tabloListele();
            testListesiDuzenle();
        }
    }
    protected void GridView_testler_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex = GridView_testler.SelectedIndex;
        GridViewRow row = GridView_testler.Rows[selectedRowIndex];
        int testID = Convert.ToInt32(row.Cells[1].Text);

        Session[Request.Url.Authority + "testID"] = testID;
        Response.Redirect("~/inc/egitmen/test.aspx");
    }

    protected void testSilBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        string idler = "";
        string soruIDler = "";
        string yanitIDler = "";
        foreach (GridViewRow satirbilgi in GridView_testler.Rows)
        {
            CheckBox secimKutusu = (CheckBox)satirbilgi.FindControl("secim");
            if (secimKutusu != null && secimKutusu.Checked)
            {
                idler += "id=" + satirbilgi.Cells[1].Text + " or ";

                baglanti soruSay = new baglanti();
                soruSay.verileriGetir("select id,turu from sorular where testID=" + satirbilgi.Cells[1].Text);
                if (soruSay.SQLTablo.Rows.Count > 0)
                {
                    for(int i=0;i<soruSay.SQLTablo.Rows.Count;i++)
                    {
                        soruIDler += "id=" + soruSay.SQLTablo.Rows[i][0].ToString() + " or ";
                        if (soruSay.SQLTablo.Rows[i][1].ToString() == "1")
                        {
                            yanitIDler += "soruID=" + soruSay.SQLTablo.Rows[i][0].ToString() + " or ";
                        }
                    }
                    
                }
            }
        }

        if (yanitIDler != "")
        {
            baglanti yanitSil = new baglanti();
            yanitSil.komutCalistir("delete from cevaplar where " + yanitIDler.Remove(yanitIDler.Length - 4, 4));
        }

        if (soruIDler != "")
        {
            baglanti soruSil = new baglanti();
            soruSil.komutCalistir("delete from sorular where " + soruIDler.Remove(soruIDler.Length - 4, 4));
        }
        
        if (idler != "")
        {
            baglanti testSil = new baglanti();
            if (testSil.komutCalistir("delete from testler where " + idler.Remove(idler.Length - 4, 4)) == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Seçili testler silindi.");
            }
            else
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        }
        tabloListele();
        testListesiDuzenle();
    }
    protected void testKaydetBTN_Click(object sender, EventArgs e)
    {
        MessageBox mesaj = new MessageBox();
        Literal mainMesaj = this.Master.FindControl("mesajTXT") as Literal;

        if (testadiTXT.Text != "")
        {
            baglanti grupEkle = new baglanti();

            String testAdi = testadiTXT.Text;
            if (testadiTXT.Text.Length >= 100)
                testAdi = testAdi.Remove(99).ToString();
            int egitmenID = Convert.ToInt32(Session[Request.Url.Authority + "oturum"]);
            if (grupEkle.komutCalistir("insert into testler (egitmenID,testadi,kontrol) values ('" + egitmenID + "', '" + testAdi + "', '0')") == "1")
            {
                mainMesaj.Text = mesaj.goster("1", "Test oluşturuldu. Test içeriğini oluşturmak için aşağıdaki listeden ilgili teste gidiniz.");
                testadiTXT.Text = "";
                tabloListele();
                testListesiDuzenle();
            }
            else
            {
                mainMesaj.Text = mesaj.goster("2", "İşlem başarısız. Lütfen daha sonra tekrar deneyiniz.");
                tabloListele();
                testListesiDuzenle();
            }
        }
        else
        {
            mainMesaj.Text = mesaj.goster("2", "Test adını yazınız!");
            tabloListele();
            testListesiDuzenle();
        }
    }
    public void tabloListele()
    {
        baglanti sorgu = new baglanti();

        int kontrol = 1;
        sorgu.verileriGetir("select id from testler where egitmenID='" + Session[Request.Url.Authority + "oturum"] + "'");
        if (sorgu.SQLTablo.Rows.Count > 0)
            kontrol = 1;
        else
        {
            kontrol = 0;
            GridView_testler.Visible = false;
            sorguSonucu.Visible = true;
            testSilBTN.Visible = false;
        }

        if (kontrol == 1)
        {
            GridView_testler.Visible = true;
            sorguSonucu.Visible = false;
            testSilBTN.Visible = true;

            baglanti Listele = new baglanti();
            Listele.verileriGetir("select id,testadi,kontrol from testler where egitmenID='" + Session[Request.Url.Authority + "oturum"] + "' order by id");
            if (Listele.SQLTablo.Rows.Count > 0)
            {
                GridView_testler.DataSource = Listele.SQLTablo;
                GridView_testler.DataBind();
            }
        }
    }
    public void testListesiDuzenle()
    {
        foreach (GridViewRow satirbilgi in GridView_testler.Rows)
        {
            if (satirbilgi.Cells[3].Text == "0")
            {
                satirbilgi.Cells[3].Text = "Yayınlanmadı";
            }
            else if (satirbilgi.Cells[3].Text == "1")
            {
                satirbilgi.Cells[3].Text = "Yayınlandı";
            }
        }
    }
}