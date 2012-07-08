<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="SiteManager.aspx.cs" Inherits="WoodenSoft.ObamaInHydePark.Admin.SiteManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    function ConfirmIt() {
        return confirm("Are you sure you want to delete the Map Location?");
    }
</script>
<div>
    <asp:Label ID="lblError" runat="server" Text="" />
</div>
<div>
    Settings Menu:
</div>
<div>
    Website Logo: <asp:Image ID="imgCurrentLogo" runat="server" /> <asp:FileUpload ID="fuCompanyLogo" runat="server" />
</div>
<div>
    Contact Phone: <asp:TextBox ID="txtPhone" runat="server" />
</div>
<div>
    Contact Email Address: <asp:TextBox ID="txtSiteMasterEmail" runat="server" />
</div>

<div>
    About Us Description: <asp:TextBox MaxLength="2000" runat="server" TextMode="MultiLine" ID="txtDescription" Width="300" Height="500" />
</div>
<div>
    Terms And Conditions: <asp:TextBox ID="txtTerms" runat="server" TextMode="MultiLine" MaxLength="7000" Width="300" Height="300" />
</div>
<div>
    Home Page Message: <asp:TextBox runat="server" ID="txtHomePageMessage" TextMode="MultiLine" Width="400" Height="400"></asp:TextBox>
</div>
<div>
    Company Address: <asp:TextBox MaxLength="500" ID="txtAddress" runat="server" TextMode="MultiLine" Width="200" Height="200" />
</div>
<div>
    iTunes Url: <asp:TextBox runat="server" ID="txtItunesUrl"></asp:TextBox>
</div>
<div>
    <asp:Button ID="btnSaveSettings" runat="server" Text="Save Settings" 
        onclick="btnSaveSettings_Click" />
</div>
<div>
    <div>
        Walking Tour Points For The Map
    </div>
    <div>
        <asp:GridView runat="server" ID="gvMapPoints" AutoGenerateColumns="True" AllowPaging="False" AllowSorting="False">
           <Columns>
               <asp:TemplateField runat="server">
                   <ItemTemplate>
                        <asp:Button Text="Delete" runat="server" ID="btnDelete" OnClick="DeleteMapPoint" CommandArgument='<%#Eval("Id") %>'/>
               </ItemTemplate>

            </asp:TemplateField>
           </Columns>
        </asp:GridView>

    </div>
    <div>
        Add Map Addresses
    </div>
    <div>
        <div>Name: <asp:TextBox runat="server" ID="txtMapPointName"></asp:TextBox></div>
        <div>Address: <asp:TextBox runat="server" ID="txtMapPointAddress"></asp:TextBox></div>
        <div>Stop Number (as a whole number): <asp:TextBox runat="server" ID="txtMapPointOrdinal"></asp:TextBox></div>
        <div><asp:Button runat="server" ID="btnSaveMapPoint" 
                Text="Save Walking Tour Address Stop" onclick="btnSaveMapPoint_Click"/></div>
    </div>
</div>
</asp:Content>
