<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ManageCourse.aspx.cs" Inherits="ManageCourse" %>

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
                    <asp:Label ID="Label2" runat="server" Text="Manage Courses" Font-Size="X-Large" 
                        Font-Underline="False" CssClass="heading"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
           <tr>
                <td class="lab">
                    <asp:Label ID="Label8" runat="server" Text="Select Course  :-" 
                        CssClass="lable" ></asp:Label>
                
                <td class="tx" align="center">
                    <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" Height="20px"
                        Width="118px" 
                        CssClass="txt">
                        <asp:ListItem>--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                </td>
                </td>
           
         
           
                <td colspan="2">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Manage Course" Height="50px"
                        Width="85%" CssClass="button" />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>

                <td colspan="2" align="center">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Course_Code" 
                        DataSourceID="SqlDataSource2">
                        <AlternatingRowStyle  />
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            <asp:BoundField DataField="Course_Code" HeaderText="Course_Code" 
                                ReadOnly="True" SortExpression="Course_Code" />
                            <asp:BoundField DataField="Course_Title" HeaderText="Course_Title" 
                                SortExpression="Course_Title" />
                            <asp:BoundField DataField="Level" HeaderText="Level" SortExpression="Level" />
                            <asp:BoundField DataField="Teacher_ID" HeaderText="Teacher_ID" 
                                SortExpression="Teacher_ID" />
                        </Columns>
                        
                    </asp:GridView>

                </td>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:conn %>" 
                    DeleteCommand="DELETE FROM [Course] WHERE [Course_Code] = @Course_Code" 
                    InsertCommand="INSERT INTO [Course] ([Course_Code], [Course_Title], [Level], [Teacher_ID]) VALUES (@Course_Code, @Course_Title, @Level, @Teacher_ID)" 
                    SelectCommand="SELECT [Course_Code], [Course_Title], [Level], [Teacher_ID] FROM [Course] WHERE ([Course_Code] = @Course_Code)" 
                    
                    
                    UpdateCommand="UPDATE [Course] SET [Course_Title] = @Course_Title, [Level] = @Level, [Teacher_ID] = @Teacher_ID WHERE [Course_Code] = @Course_Code">
                    <DeleteParameters>
                        <asp:Parameter Name="Course_Code" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Course_Code" Type="String" />
                        <asp:Parameter Name="Course_Title" Type="String" />
                        <asp:Parameter Name="Level" Type="Int32" />
                        <asp:Parameter Name="Teacher_ID" Type="Int32" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList5" Name="Course_Code" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Course_Title" Type="String" />
                        <asp:Parameter Name="Level" Type="Int32" />
                        <asp:Parameter Name="Teacher_ID" Type="Int32" />
                        <asp:Parameter Name="Course_Code" Type="String" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
              <tr>
                <td colspan="2" align="center">
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="SqlDataSource3">
                        <Columns>
                            <asp:BoundField DataField="CLO_Code" HeaderText="CLO_Code" 
                                SortExpression="CLO_Code" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:conn %>" 
                        SelectCommand="SELECT [CLO_Code] FROM [CLO] WHERE ([Course_Code] = @Course_Code)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList5" Name="Course_Code" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                </td>
            </tr>
              <tr>
                <td>
                    <br />
                </td>
            </tr>
          <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="Label9" runat="server" Text="Add CLO" Visible="False"></asp:Label>
                 
             
                    
                    <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                    
                    <br />
                </td>
                   <td>
                    
             
                    
                       <asp:Button ID="Button3" runat="server" Text="Add CLO" OnClick="Button3_Click"  Height="50px"
                         CssClass="button" Visible="False" />
                    
             
                    
                    <br />
                </td>
            </tr>
          
             
            <tr>
                <td>
                    <br />
                </td>
            </tr>
        
          
            <tr>        
                <td class="lab">
                    <asp:Label ID="Label1" runat="server" Text="Course_Specfication:-" CssClass="lable" 
                        Visible="False"></asp:Label>
                
              
                <td CssClass="button"">
                 <asp:FileUpload ID="FileUpload2" runat="server" Visible="False" />
                   <td>
<asp:Button ID="Button1" CssClass="button" runat="server" Text="Upload"

OnClick="btnUpload_Click1" Visible="False" />

<br />
  </td>
  </td>
  
  <td>
<asp:Label ID="lblMessage" runat="server" Text=""

Font-Names = "Arial"></asp:Label>
                </td>

  </td>
  <td>
<asp:Label ID="Label6" runat="server" Text=""

Font-Names = "Arial"></asp:Label>
                </td>
            </tr>
            <tr>
            <td></td>
            <td align="left">
                &nbsp;</td>
            </tr>
             <tr>
            <td></td>
            <td align="left">

         <asp:GridView ID="GridView2" runat="server"  AutoGenerateColumns="false">
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
                <td class="lab">
                    
                    <asp:Label ID="Label3" runat="server" Text="Course Report" Visible="False"></asp:Label>

                </td>
                <td CssClass="button"">
                 <asp:FileUpload ID="FileUpload1" runat="server" Visible="False" />
                   <td>
<asp:Button ID="btnUpload" CssClass="button" runat="server" Text="Upload"

OnClick="btnUpload_Click" Visible="False" />

<br />
  </td>
<asp:Label ID="Label4" runat="server" Text=""

Font-Names = "Arial"></asp:Label>
                      </td>
            </tr>
            <tr>
            <td></td>
            <td align="left">
                &nbsp;</td>
            </tr>
             <tr>
            <td></td>
            <td align="left">

            <asp:GridView ID="GridView3" runat="server"  AutoGenerateColumns="false">
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
