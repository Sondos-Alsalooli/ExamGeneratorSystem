<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Create.aspx.cs" Inherits="Create" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A"  namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
    <style>
.lab
{
    text-align:left;
    padding-left:200px;
    font-size:large;
    font-family:@MS PGothic;
}
.tx
{
   text-align:left;
   
}
</style>

</asp:Content>

<asp:Content ID="body" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
    
       <table width="80%">
       <tr><td colspan="2"><br /></td></tr>
       <tr><td colspan="2" align="center"><asp:Label ID="Label2" runat="server" 
               Font-Size="X-Large" Font-Underline="False" 
            Text="Get Question Paper" CssClass="heading"></asp:Label></td></tr>
       <tr><td colspan="2"><br /></td></tr>
       <tr>
                <td class="lab">
                    <asp:Label ID="Label8" runat="server" Text="Select Course  :-" 
                        CssClass="lable"></asp:Label>
                </td>
                <td class="tx">
                    <asp:DropDownList ID="DropDownList5" runat="server" Height="20px"
                        OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" Width="118px" 
                        CssClass="txt" DataSourceID="SqlDataSource1" DataTextField="Cource_Code" 
                        DataValueField="Cource_Code" AppendDataBoundItems="True">
                        <asp:ListItem>--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                </td>
            </tr>
    <tr><td colspan="2"><br /></td></tr>
    <tr><td></td><td class="tx">&nbsp;</td></tr>
      
       <tr><td class="lab"> <asp:Label ID="Label13" runat="server" 
               Text="Time For Exam  :-" CssClass="lable"></asp:Label></td><td class="tx">
               <asp:DropDownList ID="DropDownList7" runat="server" CssClass="txt" 
                   >
        <asp:ListItem>1/2 hour</asp:ListItem>
        <asp:ListItem>1 hour</asp:ListItem>
        <asp:ListItem>2 hour</asp:ListItem>
    </asp:DropDownList></td></tr>
       <tr><td colspan="2"><br /></td></tr>
       <tr><td class="lab"><asp:Label ID="Label4" runat="server" Text="Marks :-" 
               CssClass="lable"></asp:Label></td><td class="tx">
           <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="118px" 
     CssClass="txt ">
           
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>40</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
        </asp:DropDownList></td></tr>
        <tr><td colspan="2"><br /></td></tr>
        <tr><td class="lab"><asp:Label ID="Label5" runat="server" 
                Text="Chapter :-" CssClass="lable"></asp:Label></td><td class="tx">
                <asp:TextBox ID="TextBox8" runat="server" CssClass="txt"></asp:TextBox>
            </td></tr>
        <tr><td colspan="2"><br /></td></tr>
        <tr><td class="lab"><asp:Label ID="Label9" runat="server" 
            Text="Name Of Question Paper  :-" CssClass="lable"></asp:Label></td><td class="tx">  
            <asp:TextBox ID="TextBox2" runat="server" Width="77px" CssClass="txt "></asp:TextBox></td></tr>
    <tr><td colspan="2"><br /></td></tr>
    <tr><td class="lab"> 
        <asp:Label ID="Label17" runat="server" Text="Short Question" CssClass="lable"></asp:Label>
        </td><td class="tx">  
            <asp:TextBox ID="TextBox11" runat="server" CssClass="txt" 
                ></asp:TextBox>
        </td></tr>
    <tr><td colspan="2"><br /></td></tr>
    <tr><td class="lab"> <asp:Label ID="Label7" runat="server" 
            Text="Fill in the blanks :-" CssClass="lable"></asp:Label></td><td class="tx">
            <asp:TextBox ID="TextBox9" runat="server" CssClass="txt"></asp:TextBox>
        </td>
        <td align="left" style="vertical-align:top">
            &nbsp;</td></tr>
           <tr><td colspan="2"><br /></td></tr>
           <tr><td class="lab"><asp:Label ID="Label10" runat="server" 
                   Text="True or False  :-" CssClass="lable"></asp:Label></td><td class="tx"> 
                   <asp:TextBox ID="TextBox3" runat="server" Width="80px" CssClass="txt"></asp:TextBox></td>
               <td align="left" style="vertical-align:top;">
                       &nbsp;</td></tr>
               <tr><td colspan="2"><br /></td></tr>
               <tr><td class="lab"><asp:Label ID="Label11" runat="server" 
                       Text="Choose :-" CssClass="lable"></asp:Label></td><td class="tx"> 
                       <asp:TextBox ID="TextBox4" runat="server" Width="80px" CssClass="txt"></asp:TextBox></td>
                   <td style="vertical-align:top" align="left">
                           &nbsp;</td></tr>
       <tr><td colspan="2"></td></tr>
       <tr><td class="lab"> 
           <asp:Label ID="Label18" runat="server"  CssClass="lable" Text="Long Question"></asp:Label>
           </td><td class="tx">
               <asp:TextBox ID="TextBox10" runat="server" CssClass="txt"></asp:TextBox>
           </td></tr>
       <tr><td colspan="2"><br /></td></tr>
       <tr><td colspan="2" align="center" class="intabular">
           <asp:Button ID="Button2" 
               runat="server" Text="Download Exam Paper" 
            onclick="Button2_Click" Width="40%" Height="50px"  CssClass="button btn-secondary" />
           
           <asp:Button ID="Button1" 
               runat="server" Text="Download Answer Key" 
            onclick="Button1_Click" Width="40%" Height="50px" CssClass="button btn-secondary" /></td>

            </tr>
       </table>
    </div>     
       
   

    

    <br />
    <br />
    </asp:Content>