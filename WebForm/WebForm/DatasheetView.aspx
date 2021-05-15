<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.Master" AutoEventWireup="true" CodeBehind="DatasheetView.aspx.cs" Inherits="WebForm.DatasheetView" %>

<%@ MasterType VirtualPath="~/AdminLayout.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SheetContent" runat="server">
    <h1 style="text-align: center">DATASHEET VIEW FOR XTRAREPORT</h1>
    <asp:LinkButton class="button button3" Style="border: none; color: white; padding: 20px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px; margin: 4px 2px; cursor: pointer; background-color: #4CAF50; border-radius: 8px; margin-left: 1000px; margin-bottom: 50px;"
        OnClick="btnPrint_Click" runat="server">Make Report</asp:LinkButton>
     <div style="margin-left:-200px">
        <asp:PlaceHolder ID="TableHolder" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>
