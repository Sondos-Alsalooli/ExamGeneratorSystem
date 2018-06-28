<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ManageUser.aspx.cs" Inherits="Register" %>

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
                        Text="Manage User" CssClass="heading"></asp:Label>
                </td>
            </tr>
               <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="Label1" runat="server" Font-Size="Large" Font-Underline="False"
                        Text="Admin" CssClass="heading"></asp:Label>
                </td>
            </tr>
       
            <tr>
                <td colspan="2" align="center">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:conn %>" 
                        DeleteCommand="DELETE FROM [Admin1] WHERE [ID] = @ID" 
                        InsertCommand="INSERT INTO [Admin1] ([ID], [Name], [Password]) VALUES (@ID, @Name, @Password)" 
                        SelectCommand="SELECT * FROM [Admin1]" 
                        
                        UpdateCommand="UPDATE [Admin1] SET [Name] = @Name, [Password] = @Password WHERE [ID] = @ID">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                            <asp:Parameter Name="Name" Type="String" />
                            <asp:Parameter Name="Password" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Name" Type="String" />
                            <asp:Parameter Name="Password" Type="String" />
                            <asp:Parameter Name="ID" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="ID" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                                SortExpression="ID" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Password" HeaderText="Password" 
                                SortExpression="Password" />
                        </Columns>
                    </asp:GridView>
                    <br />
                </td>
            </tr>
           
               <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="Label3" runat="server" Font-Size="Large" Font-Underline="False"
                        Text="Teacher" CssClass="heading"></asp:Label>
                </td>
            </tr>
             <tr>
                <td colspan="2" align="center">
                
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:conn %>" 
                        DeleteCommand="DELETE FROM [Teacher] WHERE [ID] = @ID" 
                        InsertCommand="INSERT INTO [Teacher] ([ID], [Name], [Password], [Department]) VALUES (@ID, @Name, @Password, @Department)" 
                        SelectCommand="SELECT * FROM [Teacher]" 
                        UpdateCommand="UPDATE [Teacher] SET [Name] = @Name, [Password] = @Password, [Department] = @Department WHERE [ID] = @ID">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                            <asp:Parameter Name="Name" Type="String" />
                            <asp:Parameter Name="Password" Type="String" />
                            <asp:Parameter Name="Department" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Name" Type="String" />
                            <asp:Parameter Name="Password" Type="String" />
                            <asp:Parameter Name="Department" Type="String" />
                            <asp:Parameter Name="ID" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="ID" DataSourceID="SqlDataSource2">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                                SortExpression="ID" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Password" HeaderText="Password" 
                                SortExpression="Password" />
                            <asp:BoundField DataField="Department" HeaderText="Department" 
                                SortExpression="Department" />
                        </Columns>
                    </asp:GridView>
                
                </td>
            </tr>
           
        </table>
    </div>
</asp:Content>
