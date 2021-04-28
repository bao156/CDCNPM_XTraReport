<%@ Page Language="C#" MasterPageFile="Admin.aspx" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebForm.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
       

        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Java5ConnectionString2 %>" SelectCommand="SELECT * FROM [database_name]"></asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <%
            var todo_list=getListTable();
            Response.Write("<ul>");
            foreach(var item in todo_list)
            {
                Response.Write("<li>"+item+"</li><br/>");
            }
            Response.Write("</ul>");
            %>
    </form>
</body>
</html>
