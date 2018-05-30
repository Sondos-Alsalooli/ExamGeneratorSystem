<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AddCourse.aspx.cs" Inherits="Register" %>

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
                        Text="Add Course" CssClass="heading"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="lab">
                    <asp:Label ID="Label3" runat="server" Text="Course_Code:-" CssClass="lable"></asp:Label>
                </td>
                <td class="tx">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="txt"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="lab">
                    <asp:Label ID="Label4" runat="server" Text="Course_Title:-" CssClass="lable"></asp:Label>
                </td>
                <td class="tx">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="txt"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td></td>
            <td align="left">
                &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="lab">
                    <asp:Label ID="Label5" runat="server" Text="Level :-" CssClass="lable"></asp:Label>
                </td>
                <td class="tx">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="txt">
                         <asp:ListItem>1</asp:ListItem>
                         <asp:ListItem>2</asp:ListItem>
                         <asp:ListItem>3</asp:ListItem>
                         <asp:ListItem>4</asp:ListItem>
                         <asp:ListItem>5</asp:ListItem>
                         <asp:ListItem>6</asp:ListItem>
                         <asp:ListItem>7</asp:ListItem>
                         <asp:ListItem>8</asp:ListItem>
                         <asp:ListItem>9</asp:ListItem>
                         <asp:ListItem>10</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="lab">
                    <asp:Label ID="Label9" runat="server" Text="Teacher_ID"></asp:Label>
                </td>
                <td class="tx">
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="txt"
                        DataSourceID="SqlDataSource1" DataTextField="ID" 
                        DataValueField="ID" 
                       >
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:conn %>" 
                        SelectCommand="SELECT [ID] FROM [Teacher]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
           
<br />

            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button3" runat="server" CssClass="button" OnClick="Button3_Click"
                        Text="Add Course" Height="50px" Width="20%" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
