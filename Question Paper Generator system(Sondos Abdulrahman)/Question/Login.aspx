<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="body" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
    
    <br />
   <table width="50%">
   <tr>
   <td align="center" colspan="3">
       <asp:Label ID="Label1" runat="server" CssClass="heading" Text="User Login"></asp:Label>
   </td>
   </tr>
   <tr>
   <td align="right" width="30%" style="vertical-align:top;">
       <asp:Label ID="Label2" runat="server" CssClass="lable" Text="User Id: "></asp:Label>
   </td>
   <td width="50%" align="left">
       <asp:TextBox ID="TextBox1" runat="server" CssClass="txt" ValidationGroup="Name" ontextchanged="TextBox1_TextChanged" 
           ></asp:TextBox>
   </td>
   <td align="left" style="vertical-align:top;">
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
           ErrorMessage="User Id" ForeColor="Red" ControlToValidate="TextBox1" ValidationGroup="Name"></asp:RequiredFieldValidator>
   </td>
   </tr>
   <tr>
   <td align="right">
       <asp:Label ID="Label3" runat="server" CssClass="lable" Text="Password:"></asp:Label>
   </td>
   <td align="left">
       <asp:TextBox ID="TextBox2" runat="server" CssClass="txt" ValidationGroup="Name"></asp:TextBox>
   </td>
   <td align="left" style="vertical-align:top;">
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
           ControlToValidate="TextBox2" ErrorMessage="Enter Password" ForeColor="Red" ValidationGroup="Name"></asp:RequiredFieldValidator>
   </td>
   </tr>
   <tr><td></td></tr>
   <tr>
   <td colspan="3">
       
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
       <asp:Button ID="Button2" runat="server" CssClass="button" Text="Log In" 
           ValidationGroup="Name" OnClick="Button2_Click" />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Button ID="Button3" runat="server" CssClass="button" Text="Cancel" OnClick="Button3_Click" />
       
   </td>
 
   </tr>
   <tr>
   <td colspan="3" align="center">
       &nbsp;</td>
   </tr>
   </table>
    
    </div>
</asp:Content>