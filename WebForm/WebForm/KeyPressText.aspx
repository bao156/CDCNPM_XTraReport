<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KeyPressText.aspx.cs" Inherits="WebForm.KeyPressText" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
        <div>
            <input type="hidden" id="txtDistance" runat="server" />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnStart_Click">LinkButton</asp:LinkButton>
            <asp:TextBox ID="TextBox1" runat="server" onchange="tSpeedValue(this)"></asp:TextBox>
        </div>
    </form>
    <script type="text/javascript">
        function tSpeedValue(txt) {
            alert(txt.value);
            document.getElementById("txtDistance").value += txt.value + "___";
        }
    </script>
</body>
</html>
