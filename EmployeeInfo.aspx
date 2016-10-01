<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeInfo.aspx.cs" Inherits="EmployeeInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  
</head>
<body>
    <form id="form1" runat="server">
       
    <div>
     <table class="auto-style1">
           
            <tr>
                <td>
                    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPhone" runat="server" Text="Phone Number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
        <asp:Button ID="btnSumbit" runat="server" Text="Submit" OnClick="btnSumbit_Click" />

        &nbsp;
        
        <asp:GridView ID="gvEmpDetails" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvEmpDetails_RowDeleting" DataKeyNames="EmpId" OnRowCancelingEdit="gvEmpDetails_RowCancelingEdit" OnRowEditing="gvEmpDetails_RowEditing" OnRowUpdating="gvEmpDetails_RowUpdating">
            <Columns>
                <asp:BoundField DataField="EmpId" HeaderText="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="Mobile" HeaderText="Phone Number" />
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
