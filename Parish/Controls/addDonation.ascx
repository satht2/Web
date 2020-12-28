<%@ Control Language="C#" AutoEventWireup="true" CodeFile="addDonation.ascx.cs" Inherits="Controls_addDonation" %>

<div>
    <table align="center" class="content_border">
        <tr>
            <td colspan="4">
                <h2>Add Donation</h2>
                <asp:Label ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">Donation Type:
            </td>
            <td>
                <asp:DropDownList ID="ddDonationType" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td style="width: 130px;">Amount:
            </td>
            <td>
                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
            </td>
            <td>
                <div align="center" style="padding-top: 10px;">
                    <asp:Button CssClass="cssButton" ID="bSave" runat="server" Text="Save" OnClick="bSave_Click" />
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <h2>Donation</h2>
                <asp:GridView Width="100%" ID="grdDonations" runat="server"
                    AutoGenerateColumns="false"
                    AlternatingRowStyle-BackColor="#E9ECF1"
                    HeaderStyle-BackColor="white"
                    Font-Names="Arial"
                    RowStyle-HorizontalAlign="Center"
                    RowStyle-Height="22"
                    HeaderStyle-Height="25"
                    FooterStyle-HorizontalAlign="Center"
                    FooterStyle-Font-Bold="true"
                    FooterStyle-ForeColor="#555555"
                    ShowFooter="true">
                    <Columns>
                        <asp:TemplateField HeaderText="Donation Date">
                            <ItemTemplate><%#Eval("CreatedDate")%></ItemTemplate>
                            <%--<FooterTemplate>
                                <div><asp:Label Text="Total" runat="server" /></div>
                            </FooterTemplate>--%>
                        </asp:TemplateField>                        
                        <asp:BoundField DataField="DonationType" HeaderText="Donation Type" />
                        <asp:BoundField DataField="AddedBy" HeaderText="Created By" />
                        <asp:TemplateField HeaderText="Amount">
                            <ItemTemplate><%#Eval("Deposit", "{0:C}")%></ItemTemplate>
                            <%--<FooterTemplate>                                
                                <div><asp:Label ID="lblTotal" Text='<%#Eval("Total")%>' runat="server" /></div>
                            </FooterTemplate>--%>
                        </asp:TemplateField> 
                        <asp:BoundField DataField="Deposit" HeaderText="Amount" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Right" />
                    </Columns>
                    <EmptyDataTemplate>
                        <div>No records found.</div>
                    </EmptyDataTemplate>
                </asp:GridView>
                <br />
            </td>
        </tr>
    </table>
</div>
