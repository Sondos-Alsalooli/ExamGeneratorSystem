<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AddUser.aspx.cs" Inherits="Register" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
    <style>
        .lab
        {
            text-align: left;
            padding-left: 200px;
            font-size: large;
            font-family: @MS PGothic;
        }
        .tx
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="body" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
        <table width="80%">
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Font-Underline="False"
                        Text="Add User" CssClass="heading"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="lab">
                    <asp:Label ID="Label5" runat="server" Text="Type of User  :-" CssClass="lable"></asp:Label>
                </td>
                <td class="tx">
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        CssClass="dropdownRequestList txt" AutoPostBack="True">
                         <asp:ListItem>Teacher</asp:ListItem>
                         <asp:ListItem>Admin</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter type of user"
                        ForeColor="Red" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="lab">
                    <asp:Label ID="Label3" runat="server" Text="User ID :-" CssClass="lable"></asp:Label>
                </td>
                <td class="tx">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="txt"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Id"
                        ForeColor="Red" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="lab">
                    <asp:Label ID="Label4" runat="server" Text="User Name  :-" CssClass="lable"></asp:Label>
                </td>
                <td class="tx">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="txt"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td></td>
            <td align="left">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ErrorMessage="Enter Name"  ValidationExpression="[a-zA-z]*$" 
                    ForeColor="Red" ControlToValidate="TextBox2"></asp:RegularExpressionValidator>
            </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="lab">
                    <asp:Label ID="Label9" runat="server" Text="Department  :-" CssClass="lable" 
                        Visible="True"></asp:Label>
                </td>
                <td class="tx">
                    <asp:TextBox ID="TextBox7" runat="server" CssClass="txt"></asp:TextBox>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:conn %>" 
                        SelectCommand="SELECT [Department] FROM [Teacher]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="lab">
                    <asp:Label ID="Label7" runat="server" Text="Password  :-" CssClass="lable"></asp:Label>
                </td>
                <td class="tx">
                    <asp:TextBox ID="TextBox5" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td></td>
            <td align="left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Enter Password" ControlToValidate="TextBox5" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="lab">
                    <asp:Label ID="Label8" runat="server" Text="Confirm Password  :-" CssClass="lable"></asp:Label>
                </td>
                <td class="tx">
                    <asp:TextBox ID="TextBox6" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td></td>
            <td align="left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Enter Confirm Password" ControlToValidate="TextBox6" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button3" runat="server" CssClass="button" OnClick="Button3_Click"
                        Text="Add User" Height="50px" Width="20%" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
