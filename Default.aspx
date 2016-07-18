<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="P_NW._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  

    <asp:Panel ID="Panel1" runat="server" Height="177px" style="margin-bottom: 12px">
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <%-- gridview只能放在panel或form --%>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </asp:Panel>


</asp:Content>
