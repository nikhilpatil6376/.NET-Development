﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="_05_SqlInjectionPrevention.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox  >
            <asp:Button ID="Button2" runat="server" Text="Get Product" OnClick="Button1_Click" />
             <br />
             <br />
             <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
