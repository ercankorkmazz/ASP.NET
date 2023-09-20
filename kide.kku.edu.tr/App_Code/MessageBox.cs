using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Globalization;

public class MessageBox
{

    //MesajTipleri

    //    Error,
    //    Info,
    //    Warning,
    //    Success

    public MessageBox()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public String goster(string type, string metin)
    {
        if (type == "1")
            type = "info";
        else if (type == "2")
            type = "error";

        string s = "<script language='javascript'>notif({type: '" + type + "', msg: '" + metin + "', position: 'center', autohide: true, multiline: true});</script>";
        return s.ToString();
    }
    public String bilgi(string metin, int sure)
    {
        string s = "<script language='javascript'>notif({type: 'success', msg: '" + metin + "', position: 'center', autohide: true, multiline: true, time: '" + sure + "'});</script>";
        return s.ToString();
    }
}