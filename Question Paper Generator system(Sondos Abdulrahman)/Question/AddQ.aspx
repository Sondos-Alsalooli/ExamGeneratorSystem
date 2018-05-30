<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddQ.aspx.cs" Inherits="AddQ" %>

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
        .style1
        {
            text-align: left;
            padding-left:unset;
            font-size: large;
            font-family: @MS PGothic;
            height: 45px;
        }
        .style2
        {
            text-align: left;
            height: 45px;
        }
        .style3
        {
            text-align: left;
            padding-left: 200px;
            font-size: large;
            font-family: @MS PGothic;
            height: 54px;
        }
        .style4
        {
            text-align: left;
            height: 54px;
        }
        .style5
        {
            text-align: left;
            padding-left: 200px;
            font-size: large;
            font-family: @MS PGothic;
            height: 60px;
        }
        .style6
        {
            text-align: left;
            height: 60px;
        }
    </style>

</asp:Content>
<asp:Content ID="body" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
         <table width="80%">
         <tr><td colspan="2"><br /></td></tr>
         <tr><td colspan="2" align="center"> <asp:Label ID="Label2" runat="server" 
                 Font-Size="X-Large" Font-Underline="False" 
            Text="Add Question" CssClass="heading"></asp:Label></td></tr>
            <tr><td colspan="2"><br /></td></tr>
            <tr><td class="style1"> <asp:Label ID="Label3" runat="server" Text="Question Id " 
                    CssClass="lable"></asp:Label></td><td class="style2"><asp:TextBox ID="TextBox1" 
                        runat="server" ReadOnly="True" CssClass="txt"></asp:TextBox></td></tr>
            <tr><td colspan="2"><br /></td></tr>
            <tr><td class="lab"><asp:Label ID="Label4" runat="server" Text="Your Question" 
                    CssClass="lable"></asp:Label></td><td class="tx"> <asp:TextBox ID="TextBox2" 
                        runat="server" Height="39px" TextMode="MultiLine" CssClass="txt"></asp:TextBox></td></tr>
            <tr><td colspan="2"><br /></td></tr>
            <tr><td class="lab">
                <asp:Label ID="Label5" runat="server" 
                    Text="Select Course :- " CssClass="lable"></asp:Label></td><td class="tx">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="txt" 
                        AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged"  
                        
                    >
           <asp:ListItem>--Select--</asp:ListItem>
        </asp:DropDownList>
              
                </td></tr>
        <tr><td colspan="2"><br /></td></tr>
        <tr><td class="lab"> <asp:Label ID="Label6" runat="server" Text="Chapter" 
                CssClass="lable"></asp:Label></td><td class="tx">
                <asp:DropDownList ID="DropDownList5" runat="server" CssClass="txt">
             <asp:ListItem>Selected</asp:ListItem>
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
        </asp:DropDownList></td></tr>
          <tr><td colspan="2"><br /></td></tr>
          <tr><td class="lab"><asp:Label ID="Label8" runat="server" Text="Type" 
                  CssClass="lable"></asp:Label></td><td class="tx">
                  <asp:DropDownList ID="DropDownList4" runat="server" CssClass="txt" 
                      >
            <asp:ListItem>short</asp:ListItem>
            <asp:ListItem>long</asp:ListItem>
            <asp:ListItem>fill</asp:ListItem>
            <asp:ListItem>choose</asp:ListItem>
            <asp:ListItem>TorF</asp:ListItem>
        </asp:DropDownList></td></tr>
          <tr><td colspan="2"><br /></td></tr>
          <tr><td class="style5"> <asp:Label ID="Label7" runat="server" Text="Mark" 
                  CssClass="lable"></asp:Label></td><td class="style6">
                  <asp:DropDownList ID="DropDownList6" runat="server" CssClass="txt" >
             <asp:ListItem>0.5</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
              </asp:DropDownList>
              </td></tr>
             <tr>
                 <td class="style3"> 
                     <asp:Label ID="Label10" runat="server" Text="CLO" 
                  CssClass="lable"></asp:Label></td><td class="style4">
                    <asp:DropDownList ID="DropDownList7" runat="server" CssClass="txt" 
                         DataSourceID="SqlDataSource3" DataTextField="CLO_Code" DataValueField="CLO_Code" 
                        
                    >
           <asp:ListItem>--Select--</asp:ListItem>
        </asp:DropDownList>
              
                     <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:conn %>" 
                         
                         SelectCommand="SELECT [CLO_Code] FROM [CLO] WHERE ([Course_Code] = @Course_Code)">
                         <SelectParameters>
                             <asp:ControlParameter ControlID="DropDownList1" Name="Course_Code" 
                                 PropertyName="SelectedValue" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                 </td>
             </tr>
          <tr><td colspan="2"><br /></td></tr>
          <tr><td class="lab"> <asp:Label ID="Label9" runat="server" Text="Answer" 
                  CssClass="lable"></asp:Label></td><td class="tx"><asp:TextBox ID="TextBox4" 
                      runat="server" CssClass="txt"></asp:TextBox></td></tr>
          <tr><td colspan="2"><br /></td></tr>
           <tr><td colspan="2" class="intabular" align="center" width="50%">
               <asp:Button ID="Button2" runat="server" Text="Add Question" onclick="Button2_Click" 
                   Height="50px" Width="20%" CssClass="button" /></td></tr>
           <tr><td colspan="2"><br /></td></tr>
         </table>   
       

        
            
    </div>
</asp:Content>