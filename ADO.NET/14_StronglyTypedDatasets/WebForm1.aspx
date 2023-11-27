<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_14_StronglyTypedDatasets.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:Arial">
            <asp:TextBox ID="TextBox" runat="server"></asp:TextBox>
            <asp:Button ID="Button" runat="server" Text="Button" OnClick="Button_Click" />
            <asp:GridView ID="GridView" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
