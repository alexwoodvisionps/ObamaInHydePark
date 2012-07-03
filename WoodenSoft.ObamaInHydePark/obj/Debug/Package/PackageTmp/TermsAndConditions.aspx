<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TermsAndConditions.aspx.cs" Inherits="WoodenSoft.ObamaInHydePark.TermsAndConditions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Terms And Conditions</h2>
    <div>
        <asp:TextBox runat="server" ID="txtTerms" ReadOnly="True" Width="400" Height="400" TextMode="MultiLine"></asp:TextBox>
    </div>
</asp:Content>
