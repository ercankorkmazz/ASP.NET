using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dersProgrami : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bilgiTXT.Text="";
        bilgiIMG.Visible = false;

        baglanti kursListele = new baglanti();
        kursListele.verileriGetir("select * from kurs");
        if (kursListele.SQLTablo.Rows.Count > 0)
        {
            if (kursSecListele.Items.Count == 0)
            {
                kursSecListele.Items.Add(new ListItem("Kurs Seçiniz", "0"));

                for (int i = 0; i <= kursListele.SQLTablo.Rows.Count - 1; i++)
                {
                    kursSecListele.Items.Add(new ListItem(kursListele.SQLTablo.Rows[i][1].ToString(), kursListele.SQLTablo.Rows[i][0].ToString()));
                }
            }
        }
        else
        {
            kursSecListele.Items.Clear();
            kursSecListele.Items.Add(new ListItem("Kurs Bulunamadı.", "0"));
        }
    }
    protected void dersSecBTN_Click(object sender, EventArgs e)
    {
        if (kursSecListele.SelectedValue != "0")
        {

            guncelle.Visible = true;
            kursSeciniz.Visible = false;
            GridView_dersProgram.Visible = true;

            pazartesiTXT.Text = "";
            saliTXT.Text = "";
            carsambaTXT.Text = "";
            persembeTXT.Text = "";
            cumaTXT.Text = "";
            cumartesiTXT.Text = "";
            pazarTXT.Text = "";

            baglanti programListele = new baglanti();
            programListele.verileriGetir("select * from programlar where kursId='" + kursSecListele.SelectedValue + "'");
            if (programListele.SQLTablo.Rows.Count > 0)
            {
                GridView_dersProgram.DataSource = programListele.SQLTablo;
                GridView_dersProgram.DataBind();
            }
        }
        else
        { 
            guncelle.Visible = false;
            GridView_dersProgram.Visible = false;
            kursSeciniz.Visible = true;
        }
    }
    protected void GridView_dersProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
       int selectedRowIndex = GridView_dersProgram.SelectedIndex;
        GridViewRow row = GridView_dersProgram.Rows[selectedRowIndex];
        int secimID = Convert.ToInt32(row.Cells[0].Text);

      baglanti DersListele = new baglanti();
      DersListele.verileriGetir("select * from programlar where id='" + secimID.ToString() + "'");
      if (DersListele.SQLTablo.Rows.Count > 0)
        {
            seciliID.Text = DersListele.SQLTablo.Rows[0][0].ToString();
            pazartesiTXT.Text = DersListele.SQLTablo.Rows[0][3].ToString();
            saliTXT.Text = DersListele.SQLTablo.Rows[0][4].ToString();
            carsambaTXT.Text = DersListele.SQLTablo.Rows[0][5].ToString();
            cumaTXT.Text = DersListele.SQLTablo.Rows[0][6].ToString();
            persembeTXT.Text = DersListele.SQLTablo.Rows[0][7].ToString();
            cumartesiTXT.Text = DersListele.SQLTablo.Rows[0][8].ToString();
            pazarTXT.Text = DersListele.SQLTablo.Rows[0][9].ToString();
        }
    }
    protected void GuncelleBTN_Click(object sender, EventArgs e)
    {
        if (seciliID.Text != "")
        {
            baglanti programGuncelle = new baglanti();
            if (programGuncelle.komutCalistir("update programlar set g1='" + pazartesiTXT.Text + "' , g2='" + saliTXT.Text + "' , g3='" + carsambaTXT.Text + "' , g4='" + persembeTXT.Text + "' , g5='" + cumaTXT.Text + "' , g6='" + cumartesiTXT.Text + "' , g7='" + pazarTXT.Text + "' where id='" + seciliID.Text + "'") == "1")
            {
                bilgiTXT.Text = "Program Güncellendi.";
                bilgiIMG.Visible = true;

                seciliID.Text = "";

                if (kursSecListele.SelectedValue != "0")
                {
                    baglanti programListele = new baglanti();
                    programListele.verileriGetir("select * from programlar where kursId='" + kursSecListele.SelectedValue + "'");
                    if (programListele.SQLTablo.Rows.Count > 0)
                    {
                        GridView_dersProgram.DataSource = programListele.SQLTablo;
                        GridView_dersProgram.DataBind();
                    }
                }

                pazartesiTXT.Text = "";
                saliTXT.Text = "";
                carsambaTXT.Text = "";
                persembeTXT.Text = "";
                cumaTXT.Text = "";
                cumartesiTXT.Text = "";
                pazarTXT.Text = "";
            }
            else
            {
                bilgiTXT.Text = "İşlem başarısız.";
                bilgiIMG.Visible = true;
            }
        }
        else
        {
            bilgiTXT.Text = "Saat Seçiniz";
            bilgiIMG.Visible = true;
        }
    }
}
