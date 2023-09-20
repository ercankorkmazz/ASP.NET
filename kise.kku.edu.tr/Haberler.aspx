<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Haberler.aspx.cs" Inherits="giris" %>

<html>
<head id="Head1" runat="server">
    <meta charset="iso-8859-9">
    <title>Kinect ile Spor</title>
    <script src="js/jquery-2.0.3.min.js" type="text/javascript"></script>
    <script src="js/notifIt.js" type="text/javascript"></script>
    <script src="js/jquery-2.0.3.min.js" type="text/javascript"></script>
    <script src="js/notifIt.js" type="text/javascript"></script>
    <link href="~/css/notifIt.css" type="text/css" rel="stylesheet" />

    <style type="text/css">
		@import url(http://fonts.googleapis.com/css?family=Lato:100,300,400,700);
  		@import url(http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,400,300,600,700);
  		@import url(http://fonts.googleapis.com/css?family=Noto+Sans:400,700);
	</style>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/animate.min.css" rel="stylesheet"> 
	<link href="css/main.css" rel="stylesheet" />
</head><!--/head-->

<body>
    <form id="Form1" runat="server">

    <header id="header">
      <div class="container" style="padding-top:10px; width:100%;">
        <div class="navbar-header" style="margin:auto; padding-right:20px; width:100%;">
            <table border="0" style="margin:auto; width:1150px;">
            	<tr>
                	<td rowspan="3" style="vertical-align:top;"><img src="images/KKU_logo.png" /></td>
                    <td style="width:55px; padding:0; text-align:center;"><img src="images/logo_giris.png" alt="logo"></td>
                	<td rowspan="3" style="text-align:right; vertical-align:top;"><img src="images/TUBITAK_logo.png" /></td>
                </tr>
                <tr>
                    <td class="logoBaslik" style="font-size:20px; padding:5px; padding-bottom:0; text-align:center;">İLE</td>
                </tr>
                <tr>
                    <td class="logoBaslik" style="padding:0; text-align:center; width:500px;">
                        SANAL SPOR EĞİTİMİ
                        <div class="clearfix"></div>
                        <a href="Default.aspx"><img src="images/home_2.png" style="margin-top:10px;" alt="Anasayfa" /></a>
                    </td>
                </tr>
            </table>
        </div>
     </div>
    </header>
    
    <section id="services">
        <div class="container">
            <div class="Haberler_icerik">
                <br />
                <h2 style="text-align:center; margin:20px; font-size:30px;"><a href="https://www.haberler.com/dogru-egzersiz-icin-sanal-spor-platformu-9502974-haberi/" target="_blank">HABERLER.COM</a>, <a href="http://www.milliyet.com.tr/dogru-egzersiz-icin-sanal-spor-platformu-kirikkale-yerelhaber-1979516/" target="_blank">MİLLİYET.COM.TR</a>, <a href="http://www.memurlar.net/haber/661332/dogru-egzersiz-icin-sanal-spor-platformu-gelistirildi.html" target="_blank">MEMURLAR.NET</a> ve <a href="http://www.kirikkalehaber.info/haber/dogru-egzersiz-icin-sanal-spor-platformu-gelistirildi-3674411.html" target="_blank">KIRIKKALEHABER.INFO</a>&#39;da <br />Sanal Spor Platformu</h2>
                <img src="images/Haber_R1.jpg" style="width:40%; max-width:550px; float:left; margin-right:10px; border:3px solid #444; padding:2px;"/>
                <p style="margin-top:0; padding-top:0;"><span style="font-size:20px; font-weight:bold; margin:0; padding:0;">&#8220;<span>Kırıkkale Üniversitesinde geliştirilen &quot;3 boyutlu sanal spor platformu&quot;, egzersiz ve spor hareketlerinin ev ortamında doğru tekniklerle yapılabilmesine imkan sunacak.<span style="font-size:20px; font-weight:bold; margin:0; padding:0;">&#8221;</span></span></p>
                <p>Üniversite bünyesinde TÜBİTAK desteğiyle yürütülen proje kapsamında &quot;3 boyutlu sanal spor platformu&quot; geliştirildi. Bu çerçevede, spor salonuna gidemeyenlerin ev ortamında, sanal eğitmen eşliğinde doğru ve kontrollü egzersiz yapabilmelerinin sağlanması için özel kameralarla desteklenen sistem tasarlandı.<br />
                    <br />
                    Kırıkkale Üniversitesi Eğitim Fakültesi Bilgisayar ve Öğretim Teknolojileri Eğitimi Bölüm Başkanı Doç. Dr. Erman Yükseltürk, AA muhabirine, geliştirdikleri 3 boyutlu sanal spor yazılımı ve özel kameralar sayesinde, insanların birçok egzersiz ile spor ve özel amaçlı hareketleri kendi başına doğru tekniklerle yapabileceğini söyledi.</p>
                <p class="MsoNormal">
                    <span>Yükseltürk, proje kapsamında üniversite bünyesinde oluşturdukları özel laboratuvarda, hareket algılayıcı özellikli &quot;kinect&quot; kameralarla farklı egzersizlere ait hareket çekimlerini yaparak, bunları &quot;avatarlar&quot; kullanıp sanal ortama aktardıklarını bildirdi.<br />
                    <br />
                    &quot;Avatarlar&quot; ile spor ve egzersiz hareketlerini daha cazip hale getirip özendirdiklerini ifade eden Yükseltürk, bu sayede&nbsp;</span>Türkiye<span>&#39;de önemli bir çalışmayı başlattıklarını dile getirdi.<br />
                    <br />
                    TÜBİTAK destekli bu çalışmalarının 2015&#39;te başladığını bildiren Yükseltürk, şunları kaydetti:&nbsp;<br />
                    <br />
                    &quot;Spor Bilimleri Fakültesi ve Bilgisayar Mühendisliği Bölümü&#39;nden akademisyenlerle ortaklaşa yaptığımız bu çalışmada amacımız, düzenli egzersiz yapamayan ev hanımlarından yoğun iş temposundan dolayı spor salonuna gidemeyenlere, çocuklardan yetişkinlere kadar geniş bir yelpazede olan gruplara, sanal eğitmen eşliğinde, kontrollü olarak avatarlarla, sanal bir ortamda istedikleri yerden spor yapma imkanı sağlamaktır. Sistem üzerinden, hareketlerin doğru yapılıp yapılmadığını analiz edebiliyoruz. Anında geri bildirimler sağlıyoruz. Aynı zamanda geliştirilen sistemde, egzersizlerin performans analizini yaparak, ne kadar doğru ve ne sıklıkla yapıldığını sorgulama, spor hocalarına tekrar rapor etme olanaklarımız var.&quot;<br />
                    <br />
                    İnsanlara hem sporu sevdirmeyi hem de motivasyonlarını artırarak düzenli ve disiplinli şekilde egzersiz yaptırmayı hedeflediklerini vurgulayan Yükseltürk, &quot;Platformu, yapılan egzersizlerin kontrol edilip anında bilgisayar ekranında geri bildirim verilen, veri tabanına da kaydedilerek daha sonradan incelenebilen bir sistem haline getirmeye çalıştık. Bunu da başardık diyebiliriz.&quot; şeklinde konuştu.<br />
                    <br />
                    Sistemde eş zamanlı kullanımla ilgili testleri tamamladıklarını anlatan Yükseltürk, &quot;Şu anda istenildiği kadar kişinin kullanabileceği bir sistem haline getirdik. Egzersiz yapacak kişilerin sistemimizi kullanabilmesi için sadece bilgisayarlarına geliştirdiğimizi yazılımı indirmesi ve hareket algılayıcısı kinect kameralarını temin etmesi gerekecek.&quot; ifadelerini kullandı.<br />
                    <br />
                    Yükseltürk, projenin büyük bölümünün tamamlandığını, gelecek aylarda hazırlayacakları raporları&nbsp;</span>TÜBİTAK<span>&#39;a teslim edeceklerini sözlerine ekledi.</p>
                <h2 style="text-align:center; margin-top:20px; font-size:30px;"><a href="http://www.kku.edu.tr/Anasayfa/Haber/Index/383" target="_blank">KKU.EDU.TR</a>&#39;de Sanal Spor Platformu</h2>
                &nbsp;<p style="margin-top:0; padding-top:0;"><p style="font-size:20px; font-weight:bold; margin:0; padding:0;">&#8220;<span>Spor Yapmak Artık Daha Kolay<span style="font-size:20px; font-weight:bold; margin:0; padding:0;">&#8221;</span></span></p><p class="MsoNormal">
                <span>Üniversitemizde geliştirilen &quot;3 boyutlu sanal spor platformu&quot; ile egzersiz ve spor hareketleri ev ortamında sanal eğitmen eşliğinde doğru tekniklerle yapılabilecek.<o:p></o:p></span></p>
                <p class="MsoNormal">
                    <span>Üniversitemiz ve TÜBİTAK işbirliğiyle gerçekleştirilen proje hakkında bilgi veren Kırıkkale Üniversitesi Eğitim Fakültesi Bilgisayar ve Öğretim Teknolojileri Eğitimi Bölüm Başkanı Doç. Dr. Erman Yükseltürk, “Bu çalışmada amacımız, düzenli egzersiz yapamayanlara, yoğun iş temposundan dolayı spor salonuna gidemeyenlere, sanal eğitmen eşliğinde kontrollü olarak avatarlarla, sanal bir ortamda istedikleri yerden spor yapma imkanı sağlamaktır. Sistem üzerinden hareketlerin doğru yapılıp yapılmadığını analiz edebiliyoruz. Anında geri bildirimler sağlıyoruz. Aynı zamanda geliştirilen sistemde egzersizlerin performans analizini yaparak, ne kadar doğru ve ne sıklıkla yapıldığını sorgulama, spor hocalarına tekrar rapor etme olanaklarımız var&quot; dedi.<o:p></o:p></span></p>
                <p class="MsoNormal">
                    <span>Üniversitemiz Spor Bilimleri Fakültesi ve Bilgisayar Mühendisliği Bölümü&#39;nden akademisyenlerle ortaklaşa yapılan projenin insanlara sporu sevdirmeyi hedeflediğini belirten Doç. Dr. Yükseltürk, &quot;Platformu, yapılan egzersizlerin kontrol edilip anında bilgisayar ekranında geri bildirim verilen, veri tabanına da kaydedilerek daha sonradan incelenebilen bir sistem haline getirmeye çalıştık. Şu anda istenildiği kadar kişinin kullanabileceği bir sistem haline getirdik. Egzersiz yapacak kişilerin sistemimizi kullanabilmesi için sadece bilgisayarlarına geliştirdiğimiz yazılımı indirmesi ve hareket algılayıcısı kinect kameralarını temin etmesi gerekecek&quot; dedi.<o:p></o:p></span></p>
                <p class="MsoNormal">
                    <span>Doç. Dr. Yükseltürk projenin büyük bölümünün tamamlandığını, gelecek aylarda hazırlayacakları raporları TÜBİTAK’a&nbsp; teslim edeceklerini ifade etti.</span>
                </p>
            </div>
        </div>
    </section>
    <!--/#services-->


    <footer id="footer">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="copyright-text text-center">
                        <p style="color:#9a1717; text-align:center;">2016 &copy; Copyright by Ercan KORKMAZ </p>
                    </div>
                </div>
            </div>
        </div>
    </footer>
    <!--/#footer-->
    <script type="text/javascript" src="js/wow.min.js"></script>
    <script type="text/javascript" src="js/main.js"></script>                      
    </form>
</body>
</html>

