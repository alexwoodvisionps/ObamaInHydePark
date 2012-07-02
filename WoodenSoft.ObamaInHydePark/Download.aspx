<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Download.aspx.cs" Inherits="WoodenSoft.ObamaInHydePark.Download" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function validateEmail(email) { 
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        }
        $(document).ready(function () {
            $('#btn').click(function () {
                var email = $('#<%=txtEmail.ClientID %>').val();
                if (email == undefined || email == null || email == "" || email.toString().indexOf("@") == -1) {
                    alert("Email Is Required!");
                    return false;
                }
                if (!validateEmail(email)) {
                    alert("Email Is Not A Valid Email!");
                }
                $.ajax({ url: '/SaveEmail.aspx?email=' + $('#<%=txtEmail.ClientID %>').val(), async: false, success: function (data) {
                    //                    $.fancybox({
                    //                        'width': '75%',
                    //                        'height': '75%',
                    //                        'autoScale': false,
                    //                        'transitionIn': 'none',
                    //                        'transitionOut': 'none',
                    //                        'type': 'iframe'
                    //                    });
                    window.open("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&notify_url=http://obamainhydepark.com/PayPalCallback.aspx&hosted_button_id=LKBA6LDFF3X36", "Paypal");
                }

                });
                return false;
            });

        });

    </script>
    Buy The Audio/Visual Walking Tour Via Paypal!
    And have an exclusive link sent to your Email
    <div>
      Enter Your Email:  <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
    </div>
    <!-- Put Pay Pal Button Here-->
     <input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_buynowCC_LG.gif" border="0" name="btn" id="btn" alt="PayPal - The safer, easier way to pay online!" />
        <img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1" />
</asp:Content>
