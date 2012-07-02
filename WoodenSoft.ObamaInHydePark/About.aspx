<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WoodenSoft.ObamaInHydePark.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>About Obama In Hyde Park</h2>
    <div>
        <asp:TextBox runat="server" TextMode="MultiLine" ID="txtAbout" ReadOnly="True" Width="400" Height="400"></asp:TextBox>
    </div>
</asp:Content>
