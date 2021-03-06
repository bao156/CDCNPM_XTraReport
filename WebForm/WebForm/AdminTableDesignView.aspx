<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.master" AutoEventWireup="true" CodeBehind="AdminTableDesignView.aspx.cs" Inherits="WebForm.AdminTableDesignView" %>

<%@ MasterType VirtualPath="~/AdminLayout.Master" %>



<asp:Content ID="Content2" ContentPlaceHolderID="SheetContent" runat="server">
    <asp:HiddenField ID="getHidden2" ClientIDMode="Static" runat="server" />
    <style>
        table, td, th {
            border: 1px solid #ddd;
            text-align: left;
        }

        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            padding: 15px;
        }

        hr.rounded {
            border-top: 20px solid #bbb;
            border-radius: 5px;
        }
    </style>
    <script type="text/javascript">
        function getCriteria(txt)
        {
            document.getElementById('<%=getHidden2.ClientID%>').value += txt.id + txt.value + "_____";
        }
    </script>
    <div>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
    </div>


</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="TableContent" runat="server">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</asp:Content>



