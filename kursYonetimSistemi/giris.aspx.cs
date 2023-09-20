using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class giris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void uyelikKontroluBTN_Click(object sender, EventArgs e)
    {
        baglanti uyeler = new baglanti();
        uyeler.verileriGetir("select * from uyelik where kadi='" + kadiTXT.Text + "' and sifre='" + sifreTXT.Text + "'");
        if (uyeler.SQLTablo.Rows.Count > 0)
        {
            Session["oturum"] = uyeler.SQLTablo.Rows[0][0].ToString();
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            bilgiTXT.Text = "Kullanıcı adı ya da şifre hatalı.";
        }
    }
}