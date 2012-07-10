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
		<div>
		
			<div id="slides">
				<div class="slides_container">
					<asp:Literal runat="server" ID="litCarousel"></asp:Literal>
				</div> <!-- /carousel-inner -->
				
			</div> <!-- /masthead-carousel -->
			
		</div> <!-- /container -->
	
	</div> <!-- /masthead -->
	
    <h2>Welcome To Obama In Hyde Park</h2>
    <div>
        <asp:Literal runat="server" ID="litMessage"></asp:Literal>
    </div>
    <div>
        <iframe src="http://www.facebook.com/plugins/like.php?href=http%3A%2F%2Fexample.com%2Fpage%2Fto%2Flike&amp;send=false&amp;layout=standard&amp;width=450&amp;show_faces=false&amp;action=like&amp;colorscheme=light&amp;height=35" scrolling="no" frameborder="0" style="border:none; overflow:hidden; width:450px; height:35px;" allowTransparency="true"></iframe>
    </div>
    <div>
        Disclaimer: This site requires Java Script To Run Sucessfully!
    </div>
</asp:Content>
