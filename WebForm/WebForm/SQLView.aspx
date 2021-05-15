<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.Master" AutoEventWireup="true" CodeBehind="SQLView.aspx.cs" Inherits="WebForm.SQLView" %>

<%@ MasterType VirtualPath="~/AdminLayout.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SheetContent" runat="server">
    <asp:HiddenField ID="getHidden2" ClientIDMode="Static" runat="server" />
    <style>
        .button-get {
            border: none;
            color: white;
            padding: 20px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            border: none;
            cursor: pointer;
            background-color: #4CAF50;
            border-radius: 8px;
            margin-left: 1000px;
            margin-bottom: 50px;
        }
    </style>

    <h1 style="text-align: center">SQL VIEW</h1>
    <asp:LinkButton OnClick="btnPrint_Click" runat="server" OnClientClick="changeContent()" CssClass="button-get">Make Report</asp:LinkButton>

    <asp:TextBox Style="border: gray 8px solid" ID="Box2" runat="server" TextMode="MultiLine" Font-Size="X-Large" Height="800px" Width="1200px" onchange="textChange(this)"></asp:TextBox>
    <script type="text/javascript">
        function textChange(txt) {
            document.getElementById('<%=getHidden2.ClientID%>').value = txt.value;
        }
    </script>
</asp:Content>
