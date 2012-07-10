<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WoodenSoft.ObamaInHydePark.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/pages/contact.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Contact Us</h2>
    <div>Email: <asp:Label runat="server" ID="lblContactEmail"></asp:Label></div>
    <div>Phone: <asp:Label runat="server" ID="lblContactPhone"></asp:Label></div>
    <div>Address: <asp:Label runat="server" ID="lblAddress"></asp:Label></div>
</asp:Content>
