<%@ Control Language="C#" AutoEventWireup="true" CodeFile="addCertificateOfDeath.ascx.cs" Inherits="Controls_addCertificateOfDeath" %>


<script>
    $(document).ready(function () {
        $("#<%= txtDODeath.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            maxDate: "+0M + 0D",
            dateFormat: 'd-m-yy'
        });
        $("#<%= txtDOBurial.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            maxDate: "+0M + 0D",
            dateFormat: 'd-m-yy'
        });
    });

</script>
<div>
    <table align="center" class="content_border">
        <tr>
            <td colspan="4">
                <h2>Add Certificate of Death</h2>
                <asp:Label ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">Name:
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td>Sex:
            </td>
            <td>
                <asp:DropDownList ID="ddSex" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">Age:
            </td>
            <td>
                <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td style="width: 130px;">Address:
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">Date of Death(d-m-yy):
            </td>
            <td>
                <asp:TextBox ID="txtDODeath" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td style="width: 130px;">Date of Burial(d-m-yy):
            </td>
            <td>
                <asp:TextBox ID="txtDOBurial" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Place of Burial:
            </td>
            <td>
                <asp:TextBox ID="txtPlaceOfBurial" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td>Date of Given(d-m-yy):
            </td>
            <td>
                <asp:TextBox ID="txtDOGiven" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Parish Priest:
            </td>
            <td>
                <asp:TextBox ID="txtParishPriest" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td>Deed:
            </td>
            <td>
                <asp:TextBox ID="txtDeed" runat="server"></asp:TextBox>
            </td>
        </tr>        
    </table>
    <div align="center" style="padding-top: 10px;">
        <asp:Button CssClass="cssButton" ID="bSave" runat="server" Text="Save" OnClick="bSave_Click" />
    </div>
</div>
