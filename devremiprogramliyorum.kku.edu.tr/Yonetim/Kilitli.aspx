<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Kilitli.aspx.cs" Inherits="Yonetim_Kilitli" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="iso-8859-9">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Dashboard">
    <meta name="keyword" content="Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">

    <title>Y&ouml;netim Paneli - Kilitli</title>
    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet">
    <link href="css/style-responsive.css" rel="stylesheet">
    <script src="js/jquery-2.0.3.min.js" type="text/javascript"></script>
    <script src="js/notifIt.js" type="text/javascript"></script>
    <link href="css/notifIt.css" type="text/css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body onload="getTime()">
    <form id="form1" runat="server">
        <asp:Literal runat="server" ID="mesajTXT" />
        <div class="container">
	  		<div id="showtime"></div>
	  			<div class="col-lg-4 col-lg-offset-4">
	  				<div class="lock-screen">
		  				<h2><a data-toggle="modal" href="#myModal"><i class="fa fa-lock"></i></a></h2>
		  				<p>Kilidi Aç</p>
		  				
				          <!-- Modal -->
				          <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal" class="modal fade">
				              <div class="modal-dialog">
				                  <div class="modal-content">
				                      <div class="modal-header">
				                          <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
				                          <h4 class="modal-title">Tekrar Hoşgeldiniz</h4>
				                      </div>
				                      <div class="modal-body">
				                          <p class="centered"><img class="img-circle" width="80" src="img/ui-sam.jpg"></p>
                                          <p><asp:Label ID="adSoyadTXT" runat="server" Text="Label"></asp:Label></p>
                                          <asp:TextBox ID="sifreTXT" runat="server" placeholder="Şifre" class="form-control placeholder-no-fix" TextMode="Password"></asp:TextBox>
				
				                      </div>
				                      <div class="modal-footer centered">
				                          <button data-dismiss="modal" class="btn btn-theme04" type="button">İptal</button>
                                          <asp:Button ID="girisBTN" class="btn btn-theme03" runat="server" Text="Giriş" OnClick="girisBTN_Click" />
				                      </div>
				                  </div>
				              </div>
				          </div>
	  				</div><! --/lock-screen -->
	  			</div>
	  	</div>

    <script src="js/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/jquery.backstretch.min.js"></script>
    <script>
        $.backstretch("img/login-bg.jpg", { speed: 500 });
    </script>

    <script>
        function getTime() {
            var today = new Date();
            var h = today.getHours();
            var m = today.getMinutes();
            var s = today.getSeconds();
            // add a zero in front of numbers<10
            m = checkTime(m);
            s = checkTime(s);
            document.getElementById('showtime').innerHTML = h + ":" + m + ":" + s;
            t = setTimeout(function () { getTime() }, 500);
        }

        function checkTime(i) {
            if (i < 10) {
                i = "0" + i;
            }
            return i;
        }
    </script>
    </form>
</body>
</html>
