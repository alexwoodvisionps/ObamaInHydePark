<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WoodenSoft.ObamaInHydePark.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/pages/homepage.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#slides').slides({
                preload: true,
                preloadImage: 'img/loading.gif',
                play: 5000,
                pause: 2500,
                hoverPause: true,
                animationStart: function (current) {
                    $('.caption').animate({
                        bottom: -35
                    }, 100);
                    if (window.console && console.log) {
                        // example return of current slide number
                        console.log('animationStart on slide: ', current);
                    };
                },
                animationComplete: function (current) {
                    $('.caption').animate({
                        bottom: 0
                    }, 200);
                    if (window.console && console.log) {
                        // example return of current slide number
                        console.log('animationComplete on slide: ', current);
                    };
                },
                slidesLoaded: function () {
                    $('.caption').animate({
                        bottom: 0
                    }, 200);
                }
            });
                });
//        $(function () {

//            $('#masthead-carousel').carousel({ interval: 1000,loop: true });

//        });
	</script>
		<div>
		<div id="container" style="height: 300">
		
			<div id="slides">
				<div class="slides_container">
					<asp:Literal runat="server" ID="litCarousel"></asp:Literal>
				</div> <!-- /carousel-inner -->
				
			</div> <!-- /masthead-carousel -->
			
		</div> <!-- /container -->
	
	</div> <!-- /masthead -->
	<div id="welcome" class="grid-12">
		<h1>Welcome to the Obama in Hyde Park Downloadable Tour</h1>
	</div>
    
    <div>
        <asp:Literal runat="server" ID="litMessage"></asp:Literal>
    </div>
    <div>
        <iframe src="http://www.facebook.com/plugins/like.php?href=http%3A%2F%2Fexample.com%2Fpage%2Fto%2Flike&amp;send=false&amp;layout=standard&amp;width=450&amp;show_faces=false&amp;action=like&amp;colorscheme=light&amp;height=35" scrolling="no" frameborder="0" style="border:none; overflow:hidden; width:450px; height:35px;" allowTransparency="true"></iframe>
    </div>
    <div>
        Disclaimer: This site requires Java Script To Run Sucessfully!
    </div>
    <div style="text-align: left">
      			
			<hr class="row-divider" />
			
			
			<div class="row divider about-container">
				
				<div class="grid-3">				
					<h2><span class="slash">//</span> Our Story</h2>
                    <p>How This Works </p>
                    <p>
Purchase the tour via credit card or Paypal and you will receive a link via email.  Once clicked, the tour will begin
to download onto your desktop, laptop, or mobile device.  Just click play and enjoy! </p>				
			    </div> <!-- /grid-3 -->
			
			<div class="grid-4">
				<div class="about-item">
									
					<h3>About Us</h3>
					
					<p><asp:Literal runat="server" ID="litAboutUs"></asp:Literal></p>
					
					<p><a href="/About.aspx">Read More »</a></p>						
					
				</div> <!-- /about -->
			</div> <!-- /grid-4 -->
			
			<div class="grid-5">				
				<h3>Benefits of Our Tour</h3>
			
				<div class="choose-item">
					
					<h3>
						<i style="color:red">*</i>
						Self Guided							
					</h3>
					
					<p>Unlike traditional tours, this tour can be done at your own pace. No waiting in lines, or booking appointments.</p>
				</div> <!-- /choose-item -->
			
				<div class="choose-item">
					<h3>
						<i style="color:red">*</i>
						Authentic					
					</h3>
					
					<p>This tour is written and produced by a lifelong Chicagoan who worked on the campaign.  Countless interviews, research, and personal experience has gone into this tour.  </p>
				</div> <!-- /choose-item -->
				
				<div class="choose-item">
					
					<h3>
						<i style="color:red">*</i>
						Cost Savings							
					</h3>
					
					<p>A quarter of the price of the lowest available guided tour.  For a family of four that adds up to quite the savings!</p>
				</div> <!-- /choose-item -->
				
				<div class="choose-item">
					
					<h3>
						 <i style="color:red">*</i>
						Mac and Pc Compliant						
					</h3>
					
					<p>This tour is both Windows and Apple compliant.</p>
				</div> <!-- /choose-item -->
				

				
			</div> <!-- /grid-5 -->
				
			</div> <!-- /row -->
			
		</div> <!-- /container -->
		
</asp:Content>
