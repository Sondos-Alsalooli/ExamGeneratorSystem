<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ShowQ.aspx.cs" Inherits="ShowQ" %>

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
                    <asp:Label ID="Label2" runat="server" Text="Show Questions" Font-Size="X-Large" 
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
                    <asp:Label ID="Label8" runat="server" Text="Select Course :-" 
                        CssClass="lable" ></asp:Label>
                </td>
                <td class="tx">
                    <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" Height="20px"
                        OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" Width="118px" 
                        CssClass="txt" >
                        <asp:ListItem>--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
           <!-- <tr>
                <td class="lab">
                    <asp:Label ID="Label4" runat="server" Text="Chapter :-" CssClass="lable"></asp:Label>
                </td>
                <td class="tx">
                    <asp:DropDownList ID="DropDownList2" runat="server"
                        Height="20px" Width="118px" CssClass="txt">
                        <asp:ListItem>--Select--</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr> -->
           
            <!-- <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" 
                        Text="Show" Height="50px"
                        Width="20%" CssClass="button" />
                </td>
            </tr> -->
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:conn %>" 
                        DeleteCommand="DELETE FROM [QuestionBank] WHERE [Question_ID] = @Question_ID" 
                        InsertCommand="INSERT INTO [QuestionBank] ([Question], [Mark], [Question_Type], [Answer], [Cource_Code], [Chapter], [CLO]) VALUES (@Question, @Mark, @Question_Type, @Answer, @Cource_Code, @Chapter, @CLO)" 
                        SelectCommand="SELECT * FROM [QuestionBank] WHERE ([Cource_Code] = @Cource_Code)" 
                        UpdateCommand="UPDATE [QuestionBank] SET [Question] = @Question, [Mark] = @Mark, [Question_Type] = @Question_Type, [Answer] = @Answer, [Cource_Code] = @Cource_Code, [Chapter] = @Chapter, [CLO] = @CLO WHERE [Question_ID] = @Question_ID">
                        <DeleteParameters>
                            <asp:Parameter Name="Question_ID" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Question" Type="String" />
                            <asp:Parameter Name="Mark" Type="Double" />
                            <asp:Parameter Name="Question_Type" Type="String" />
                            <asp:Parameter Name="Answer" Type="String" />
                            <asp:Parameter Name="Cource_Code" Type="String" />
                            <asp:Parameter Name="Chapter" Type="Int32" />
                            <asp:Parameter Name="CLO" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList5" Name="Cource_Code" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Question" Type="String" />
                            <asp:Parameter Name="Mark" Type="Double" />
                            <asp:Parameter Name="Question_Type" Type="String" />
                            <asp:Parameter Name="Answer" Type="String" />
                            <asp:Parameter Name="Cource_Code" Type="String" />
                            <asp:Parameter Name="Chapter" Type="Int32" />
                            <asp:Parameter Name="CLO" Type="String" />
                            <asp:Parameter Name="Question_ID" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        Width="80%" AutoGenerateColumns="False" DataKeyNames="Question_ID" 
                        DataSourceID="SqlDataSource2">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            <asp:BoundField DataField="Question_ID" HeaderText="Question_ID" 
                                InsertVisible="False" ReadOnly="True" SortExpression="Question_ID" />
                            <asp:BoundField DataField="Question" HeaderText="Question" 
                                SortExpression="Question" />
                            <asp:BoundField DataField="Mark" HeaderText="Mark" SortExpression="Mark" />
                            <asp:BoundField DataField="Question_Type" HeaderText="Question_Type" 
                                SortExpression="Question_Type" />
                            <asp:BoundField DataField="Answer" HeaderText="Answer" 
                                SortExpression="Answer" />
                            <asp:BoundField DataField="Cource_Code" HeaderText="Cource_Code" 
                                SortExpression="Cource_Code" />
                            <asp:BoundField DataField="Chapter" HeaderText="Chapter" 
                                SortExpression="Chapter" />
                            <asp:BoundField DataField="CLO" HeaderText="CLO" SortExpression="CLO" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
