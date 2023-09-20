using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProjeGoruntule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        projeListele();
    }
    public void projeListele()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);

        baglanti bilgileriGetir = new baglanti();
        bilgileriGetir.verileriGetir("select * from projeler where id='" + id.ToString() + "'");
        if (bilgileriGetir.SQLTablo.Rows.Count > 0)
        {
            baslikTXT.Text = bilgileriGetir.SQLTablo.Rows[0][2].ToString();
            projeHakkindaTXT.Text = bilgileriGetir.SQLTablo.Rows[0][4].ToString();
            projeEkibiTXT.Text = bilgileriGetir.SQLTablo.Rows[0][5].ToString();
            yayinlarTXT.Text = bilgileriGetir.SQLTablo.Rows[0][6].ToString();
            duyurularTXT.Text = bilgileriGetir.SQLTablo.Rows[0][7].ToString();
        }
    }
}