<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="_13_DisconnectedDataAccess.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnGetDataFromDB" runat="server" Text="Get Data From DataBase" OnClick="btnGetDataFromDB_Click" />
            <asp:Button ID="btnUpdateDataIntoDatabase" runat="server" Text="Update Data Into Database" OnClick="btnUpdateDataIntoDatabase_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowEditing="gvStudents_RowEditing" OnRowUpdating="gvStudents_RowUpdating" OnRowCancelingEdit="gvStudents_RowCancelingEdit" OnRowDeleting="gvStudents_RowDeleting">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender"></asp:BoundField>
                    <asp:BoundField DataField="TotalMarks" HeaderText="TotalMarks" SortExpression="TotalMarks"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnGetRowsState" runat="server" Text="Get Rows State" OnClick="btnGetRowsState_Click" />
            <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" OnClick="btnSaveChanges_Click" />
            <asp:Button ID="btnUndoChanges" runat="server" Text="Undo Changes" OnClick="btnUndoChanges_Click" />
            <br />
            <asp:Label ID="lblStateMessage" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
