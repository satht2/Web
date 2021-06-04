<%@ Control Language="C#" AutoEventWireup="true" CodeFile="addDependent.ascx.cs" Inherits="Controls_addDependent" %>

<script>
    $(document).ready(function () {
        $("#<%= txtDOB.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            maxDate: "+0M + 0D"
        });
    });

</script>
<div>
    <table align="center" class="content_border">
        <tr>
            <td colspan="4">
                <h2>Add Dependents</h2>
                <asp:Label ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">Dependent Relationship:
            </td>
            <td>
                <asp:DropDownList ID="ddDependentType" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td style="width: 150px;">First Name:
            </td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 130px;">Last Name:
            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td>Date Of Birth(dd/mm/yyyy):
            </td>
            <td>
                <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Sex:
            </td>
            <td>
                <asp:DropDownList ID="ddSex" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td colspan="2" style="float: right; padding-right: 20px;">
                <div align="center" style="padding-top: 10px;">
                    <asp:Button CssClass="cssButton" ID="bSave" runat="server" Text="Save" OnClick="bSave_Click" />
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <h2>Dependents</h2>
                <asp:GridView Width="100%" ID="grdDependents" runat="server"
                    AutoGenerateColumns="false"
                    AlternatingRowStyle-BackColor="#E9ECF1"
                    HeaderStyle-BackColor="white"
                    Font-Names="Arial"
                    RowStyle-HorizontalAlign="Left"
                    RowStyle-Height="22"
                    HeaderStyle-Height="25"
                    FooterStyle-HorizontalAlign="Center"
                    FooterStyle-Font-Bold="true"
                    FooterStyle-ForeColor="#555555"
                    ShowFooter="true"
                    CellPadding="5">
                    <Columns>
                        <asp:BoundField DataField="DependentType" HeaderText="Dependent Relationship" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                        <asp:BoundField DataField="DOB" HeaderText="Date Of Birth" />
                        <asp:BoundField DataField="Sex" HeaderText="Sex" />
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
