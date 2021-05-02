<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.master" AutoEventWireup="true" CodeBehind="AdminTableDesignView.aspx.cs" Inherits="WebForm.AdminTableDesignView" %>

<asp:Content ID="Content2" ContentPlaceHolderID="SheetContent" runat="server">
    <!DOCTYPE html>
<html>
<head>
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
</head>
<body>
     <asp:PlaceHolder ID="PlaceHolder2" runat="server">
         
     </asp:PlaceHolder>
  <%-- <div>
              <table style="width:20% ; border:5px solid gray">
              <tr>
                <th style="color:gray">Table name</th>
              </tr>
              <tr>
                <td><a href="#" style="text-decoration:none;color:blueviolet">Jill</a></td>
              </tr>
              <tr>
                <td><a href="#" style="text-decoration:none;color:blueviolet">Jill</a></td>
              </tr>
                  <tr>
                <td><a href="#">Jill</a></td>
              </tr>
                  <tr>
                <td><a href="#">Jill</a></td>
              </tr>
            </table>
    </div>--%>
    <hr class="rounded" style="margin-top:300px">
      <asp:PlaceHolder ID="PlaceHolder1" runat="server">
         
     </asp:PlaceHolder>

</body>
</html>
</asp:Content>
