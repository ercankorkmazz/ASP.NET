<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Iletisim.aspx.cs" Inherits="_Iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Terms of use -->
	<div class="contact main-grid-border">
		<div class="container">
			<h2 class="head text-center">İLETİŞİM FORMU</h2>
			<section id="hire">    
				<div id="filldetails">
					  <div class="field name-box">
                          <input id="adSoyadTXT" type="text" placeholder="ADINIZI VE SOYADINIZI YAZINIZ." runat="server" />
						  <label for="name">ADINIZ *</label>
					      <span class="ss-icon" style="font-size:17px; margin-top:7px;">ADINIZ</span>
					  </div>
					  
					  <div class="field email-box">
							<input type="text" id="ePostaTXT" placeholder="ILETISIM@GMAIL.COM" runat="server" />
							<label for="email">E-POSTA *</label>
							<span class="ss-icon" style="font-size:17px; margin-top:7px;">E-POSTA</span>
					  </div>
					  
					  <div class="field phonenum-box">
							<input type="text" id="konuTXT" placeholder="KONU YAZINIZ." runat="server" />
							<label for="email">KONU *</label>
							<span class="ss-icon" style="font-size:17px; margin-top:7px;">KONU</span>
					  </div>

					  <div class="field msg-box">
							<textarea id="mesajTXT" placeholder="MESAJINIZI BU ALANA YAZINIZ." style="height:200px;" runat="server" /></textarea>
							<label for="msg">MESAJINIZ *</label>
							<span class="ss-icon" style="font-size:17px; margin-top:7px;">MESAJINIZ</span>
					  </div>
                    <div style="width:100%; text-align:right;">
                        <asp:Button ID="gonderBTN" CssClass="button" runat="server" Text="Gönder" OnClick="gonderBTN_Click" />
                    </div>
		        <div class="clear"></div>
		    </div>

        </section>
			<script>
			    $('textarea').blur(function () {
			        $('#hire textarea').each(function () {
			            $this = $(this);
			            if (this.value != '') {
			                $this.addClass('focused');
			                $('textarea + label + span').css({ 'opacity': 1 });
			            } else {
			                $this.removeClass('focused');
			                $('textarea + label + span').css({ 'opacity': 0 });
			            }
			        });
			    });
			    $('#hire .field:first-child input').blur(function () {
			        $('#hire .field:first-child input').each(function () {
			            $this = $(this);
			            if (this.value != '') {
			                $this.addClass('focused');
			                $('.field:first-child input + label + span').css({ 'opacity': 1 });
			            } else {
			                $this.removeClass('focused');
			                $('.field:first-child input + label + span').css({ 'opacity': 0 });
			            }
			        });
			    });
			    $('#hire .field:nth-child(2) input').blur(function () {
			        $('#hire .field:nth-child(2) input').each(function () {
			            $this = $(this);
			            if (this.value != '') {
			                $this.addClass('focused');
			                $('.field:nth-child(2) input + label + span').css({ 'opacity': 1 });
			            } else {
			                $this.removeClass('focused');
			                $('.field:nth-child(2) input + label + span').css({ 'opacity': 0 });
			            }
			        });
			    });
			    $('#hire .field:nth-child(3) input').blur(function () {
			        $('#hire .field:nth-child(3) input').each(function () {
			            $this = $(this);
			            if (this.value != '') {
			                $this.addClass('focused');
			                $('.field:nth-child(3) input + label + span').css({ 'opacity': 1 });
			            } else {
			                $this.removeClass('focused');
			                $('.field:nth-child(3) input + label + span').css({ 'opacity': 0 });
			            }
			        });
			    });
			    $('#hire .field:nth-child(4) input').blur(function () {
			        $('#hire .field:nth-child(4) input').each(function () {
			            $this = $(this);
			            if (this.value != '') {
			                $this.addClass('focused');
			                $('.field:nth-child(4) input + label + span').css({ 'opacity': 1 });
			            } else {
			                $this.removeClass('focused');
			                $('.field:nth-child(4) input + label + span').css({ 'opacity': 0 });
			            }
			        });
			    });
		</script>    
    </div>	
</div>
<!-- // Terms of use -->
</asp:Content>

