<%@ Control Language="C#" AutoEventWireup="true" CodeFile="addCertificateOfBaptism.ascx.cs" Inherits="Controls_addCertificateOfBaptism" %>

<script>
    $(document).ready(function () {
        $("#<%= txtDOB.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            maxDate: "+0M + 0D"
        });
        $("#<%= txtDOBaptism.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            maxDate: "+0M + 0D"
        });
        $("#<%= txtDOGiven.ClientID %>").datepicker({
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
                <h2>
                    Add Certificate of Baptism</h2>
                <asp:Label ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Name:
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">
                &nbsp;
            </td>
            <td>Sex:
            </td>
            <td>
                <asp:DropDownList ID="ddSex" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                Parent Father Name:
            </td>
            <td>
                <asp:TextBox ID="txtParentFatherName" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">
                &nbsp;
            </td>
            <td style="width: 130px;">
                Parent Mother Name:
            </td>
            <td>
                <asp:TextBox ID="txtParentMotherName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Date of Birth(mm/dd/yyyy):
            </td>
            <td>
                <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">
                &nbsp;
            </td>
            <td>
                Date of Baptism(mm/dd/yyyy):
            </td>
            <td>
                <asp:TextBox ID="txtDOBaptism" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Sponsor1:
            </td>
            <td>
                <asp:TextBox ID="txtSponsor1" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">
                &nbsp;
            </td>
            <td>
                Sponsor2:
            </td>
            <td>
                <asp:TextBox ID="txtSponsor2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Minister: Rev. Fr.
            </td>
            <td>
                <asp:TextBox ID="txtMinister" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">
                &nbsp;
            </td>
            <td>
                First Holy Communion:
            </td>
            <td>
                <asp:TextBox ID="txtFirstHolyCommunion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Confirmation:
            </td>
            <td>
                <asp:TextBox ID="txtConfirmation" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">
                &nbsp;
            </td>
            <td>
                Given On Date(mm/dd/yyyy):
            </td>
            <td>
                <asp:TextBox ID="txtDOGiven" runat="server"></asp:TextBox>
            </td>
        </tr>        
        <tr>
            <td>
                Parish Priest:
            </td>
            <td>
                <asp:TextBox ID="txtParishPriest" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">
                &nbsp;
            </td>
            <td>
                Active:
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
