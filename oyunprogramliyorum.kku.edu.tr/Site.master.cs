using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        baglanti baslikGetir = new baglanti();
        baslikGetir.verileriGetir("select title,bannerText from sayfalar where id='1'");
        if (baslikGetir.SQLTablo.Rows.Count > 0)
        {
            Page.Title = string.Format(baslikGetir.SQLTablo.Rows[0][0].ToString(), DateTime.Now);
            baslikTXT.Text = baslikGetir.SQLTablo.Rows[0][1].ToString();
        }
    }
}
