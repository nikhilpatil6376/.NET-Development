<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="_12_SqlCommandBuilder.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div "font-family:Arial">
            <table border="1">
                <tr>
                    <td>
                        Student ID

                    </td>
                    <td>
                        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                        <asp:Button ID="btnGetStudent" runat="server" Text="Load" OnClick="btnGetStudent_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Gender
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGender" runat="server">
                            <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        TotaMarks

                    </td>
                    <td>
                        <asp:TextBox ID="txtTotalMarks" runat="server"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        <asp:Label ID="lblStatus" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
            </table>

            <br />
            <table border="1">
                <tr>
                    <td>
                        <b>Insert</b>
                    </td>
                    <td>
                        <asp:Label ID="lblInsert" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Update</b>
                    </td>
                    <td>
                        <asp:Label ID="lblUpdate" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Delate</b>
                    </td>
                    <td>
                        <asp:Label ID="lblDelate" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
