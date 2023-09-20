<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Hata.aspx.cs" Inherits="Yonetim_Hata" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="iso-8859-9">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Dashboard">
    <meta name="keyword" content="Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">

    <title>Y&ouml;netim Paneli - Hata Sayfası</title>
    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" runat="server">
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
<body>
    <form id="form1" runat="server">
        <div id="login-page">
	  	<div class="container">
	  	
		      <div class="form-login">
		        <div class="login-wrap">
                    <h1 style="text-align:center;">Hata 404 !</h1><br />
                    <p style="text-align:center;">Sistemde istenmeyen bir hata ile karşılaştık. Lütfen daha sonra tekrar deneyiniz.</p>
                    <asp:Button ID="girisYapBTN" class="btn btn-theme btn-block" runat="server" Text="GİRİŞ YAP" OnClick="girisYapBTN_Click" />
		
		        </div>
		          <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal" class="modal fade">
		              <div class="modal-dialog">
		                  <div class="modal-content">
		                      <div class="modal-header">
		                          <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
		                          <h4 class="modal-title">Şifrenizi mi unuttunuz?</h4>
		                      </div>
		                      <div class="modal-body">
		                          <p>Sisteme kayıtlı E-Posta adresinizi doğrulayınız. Kullanıcı bilgileriniz mail olarak gönderilecektir.</p>
                                  <asp:TextBox ID="ePostaTXT" placeholder="E-Posta" class="form-control placeholder-no-fix" runat="server"></asp:TextBox>
		                      </div>
		                      <div class="modal-footer">

		                          <button data-dismiss="modal" class="btn btn-default" type="button">İptal</button>
                                  <asp:Button ID="mailGonderBTN" class="btn btn-theme" runat="server" Text="Gönder" />
		                      </div>
		                  </div>
		              </div>
		          </div>
		
		      </div>	  	
	  	
	  	</div>
	  </div>

    <script src="js/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/jquery.backstretch.min.js"></script>
    <script>
        $.backstretch("img/login-bg.jpg", { speed: 500 });
    </script>
    </form>
</body>
</html>
