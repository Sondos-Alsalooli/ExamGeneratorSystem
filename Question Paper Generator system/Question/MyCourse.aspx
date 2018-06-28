<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MyCourse.aspx.cs" Inherits="ShowQ" %>

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
                <td colspan="2">
                    <asp:Label ID="Label2" runat="server" Text="My Course" Font-Size="X-Large" 
                        Font-Underline="False" CssClass="heading"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="lab">
                <h3>
                    <asp:Label ID="Label8" runat="server" Text="Select_Course:-" 
                        CssClass="lable" ></asp:Label> </h3>
                </td>
                <td class="tx">
                    <asp:DropDownList ID="DropDownList5"  class="form-control" runat="server" AutoPostBack="True" Height="20px"
                        Width="118px" 
                        CssClass="txt">
                        <asp:ListItem>--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                </td>
           </tr>
           <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Show" Height="50px"
                        Width="30%" CssClass="button" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:GridView ID="GridView1" runat="server"  Width="80%">
                        
                    </asp:GridView>
                </td>
            </tr>
          
              <tr>
               <td colspan="2" align="center"><h3>
                    <asp:Label ID="Label3" runat="server" Text="Course_Soecfication:-" CssClass="lable" 
                        Visible="False"></asp:Label></h3>
              </td>
            </tr>
            <tr>
            <td></td>
            <td align="left">
                &nbsp;</td>
            </tr>
            <tr>
          
            <td colspan="2" align="center">

             <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="Name" HeaderText="File Name"/>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="DownloadFile"
                    CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
                &nbsp;</td>
            </tr>

            <tr>     
                <td colspan="2" align="center">
                  <h3>   <asp:Label ID="Label1" runat="server" Text="Course_Report:-" CssClass="lable" 
                        Visible="False"></asp:Label></h3>
                
             
                <td CssClass="button"">
                 <asp:FileUpload ID="FileUpload1" runat="server" Visible="False" />
                 </td>
                 <tr>
                 <td></td>
                   <td>
<asp:Button ID="Button1" CssClass="button" runat="server" Text="Upload"

OnClick="btnUpload_Click1" Visible="False" />

<br />
  </td>
  </tr>
<asp:Label ID="lblMessage" runat="server" Text=""

Font-Names = "Arial"></asp:Label>
                </td>

  </td>
<asp:Label ID="Label6" runat="server" Text=""

Font-Names = "Arial"></asp:Label>
                </td>
            </tr>
            <tr>
            <td></td>
         
            </tr>
            <tr>
           
            <td colspan="2" align="center">

            <asp:GridView ID="GridView3" runat="server"    AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="Name" HeaderText="File Name"/>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="DownloadFile2"
                    CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
                &nbsp;</td>
            </tr>


        </table>
    </div>
</asp:Content>
