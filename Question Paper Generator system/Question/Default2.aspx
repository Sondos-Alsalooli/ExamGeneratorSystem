<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
<center>
<table width="80%">
<tr><td colspan="2"><br /></td></tr>
<tr><td colspan="2" align="center"><asp:Label ID="Label2" runat="server" 
        Font-Size="X-Large" Font-Underline="False" 
        Text="Login" CssClass="heading"></asp:Label></td></tr>
        <tr><td colspan="2"><br /></td></tr>
        <tr><td align="right">
            <asp:ImageButton ID="ImageButton1" 
        runat="server" ImageUrl="~/images/AdminLogin.jpg" 
        PostBackUrl="~/Default.aspx" Width="40%" onclick="ImageButton1_Click" /></td><td align="left"> 
                <asp:ImageButton ID="ImageButton2" runat="server" 
        ImageUrl="~/images/UserLogin.jpg" PostBackUrl="~/Login.aspx" Width="40%" /></td></tr>
        <tr><td colspan="2"><br /></td></tr>
</table>
 </center>

</div>
</asp:Content>