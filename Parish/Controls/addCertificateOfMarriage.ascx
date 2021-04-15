<%@ Control Language="C#" AutoEventWireup="true" CodeFile="addCertificateOfMarriage.ascx.cs" Inherits="Controls_addCertificateOfMarriage" %>

<script>
    $(document).ready(function () {
        $("#<%= txtDOMarriage.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            maxDate: "+0M + 0D",
            dateFormat: 'd-m-yy'
        });
        $("#<%= txtDOGivenOnDate.ClientID %>").datepicker({
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
                <h2>Add Certificate of Marriage</h2>
                <asp:Label ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">Name of Bridegroom:
            </td>
            <td>
                <asp:TextBox ID="txtNameOfGroom" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td>Name of Bride:
            </td>
            <td>
                <asp:TextBox ID="txtNameOfBride" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">Bridegroom's Father Name:
            </td>
            <td>
                <asp:TextBox ID="txtGroomFatherName" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td style="width: 130px;">Bridegroom's Mother Name:
            </td>
            <td>
                <asp:TextBox ID="txtGroomMotherName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">Bride's Father Name:
            </td>
            <td>
                <asp:TextBox ID="txtBrideFatherName" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td style="width: 130px;">Bride's Mother Name:
            </td>
            <td>
                <asp:TextBox ID="txtBrideMotherName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Witness 1:
            </td>
            <td>
                <asp:TextBox ID="txtWitness1" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td>Witness 2:
            </td>
            <td>
                <asp:TextBox ID="txtWitness2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Date of Marriage(d-m-yy):
            </td>
            <td>
                <asp:TextBox ID="txtDOMarriage" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td>Signed: Rev. Fr.
            </td>
            <td>
                <asp:TextBox ID="txtSigned" runat="server"></asp:TextBox>
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
            <td>Given at:
            </td>
            <td>
                <asp:TextBox ID="txtGivenPlace" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Given On Date(mm/dd/yyyy):
            </td>
            <td>
                <asp:TextBox ID="txtDOGivenOnDate" runat="server"></asp:TextBox>
            </td>

            <td style="width: 30px;">&nbsp;
            </td>
            <td>Active:
            </td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" Checked="true" />
            </td>
        </tr>
    </table>
    <div align="center" style="padding-top: 10px;">
        <asp:Button CssClass="cssButton" ID="bSave" runat="server" Text="Save" OnClick="bSave_Click" />
    </div>
</div>
