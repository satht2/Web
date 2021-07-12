<%@ Control Language="C#" AutoEventWireup="true" CodeFile="addCertificateOfConfirmation.ascx.cs" Inherits="Controls_addCertificateOfConfirmation" %>

<script>
    $(document).ready(function () {
        $("#<%= txtDOConfirmation.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            maxDate: "+0M + 0D",
            dateFormat: 'd-m-yy'
        });
        $("#<%= txtDOBaptism.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            maxDate: "+0M + 0D",
            dateFormat: 'd-m-yy'
        });
        $("#<%= txtDOGiven.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            maxDate: "+0M + 0D",
            dateFormat: 'd-m-yy'
        });
        $("#<%= txtDOB.ClientID %>").datepicker({
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
                <h2>Add Certificate of Confirmation</h2>
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
            <td style="width: 150px;">Parent Father Name:
            </td>
            <td>
                <asp:TextBox ID="txtParentFatherName" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td style="width: 130px;">Parent Mother Name:
            </td>
            <td>
                <asp:TextBox ID="txtParentMotherName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Date of Baptism(d-m-yy):
            </td>
            <td>
                <asp:TextBox ID="txtDOBaptism" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td>Date of Confirmation(d-m-yy):
            </td>
            <td>
                <asp:TextBox ID="txtDOConfirmation" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Place of Confirmation:
            </td>
            <td>
                <asp:TextBox ID="txtPlaceOfConfirmation" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td>Minister: His Lordship Rt. Rev. Dr.
            </td>
            <td>
                <asp:TextBox ID="txtMinister" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Given On Date(d-m-yy):
            </td>
            <td>
                <asp:TextBox ID="txtDOGiven" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td>Parish Priest:
            </td>
            <td>
                <asp:TextBox ID="txtParishPriest" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Active:
            </td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" Checked="true" />
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td>
                Date of Birth(d-m-yy):
            </td>
            <td>
                <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div align="center" style="padding-top: 10px;">
        <asp:Button CssClass="cssButton" ID="bSave" runat="server" Text="Save" OnClick="bSave_Click" />
    </div>
</div>
