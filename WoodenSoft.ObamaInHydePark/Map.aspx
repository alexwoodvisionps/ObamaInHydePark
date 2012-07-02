<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="WoodenSoft.ObamaInHydePark.Map" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <script type="text/javascript">
        $(document).ready(function () {
            $('.googlemap').each(function (index) {
                alert('hello');
                $(this).attr('src', $(this).attr('src'));
                alert('hello2');
            });
        });
    </script>--%>
    <asp:Panel runat="server" ID="pnlMap"></asp:Panel>
</asp:Content>
