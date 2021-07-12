<%@ Control Language="C#" AutoEventWireup="true" CodeFile="addMember.ascx.cs" Inherits="Controls_addMember" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="msgBox" Namespace="BunnyBear" TagPrefix="cc1" %>

<script>
    $(document).ready(function () {
        $("#<%= txtDOB.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
            maxDate: "+0M + 0D",
            yearRange: "-100Y : +1Y"

        });
        $("#<%= txtFreeToMarry.ClientID %>").datepicker({
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
                <h2>Add Member</h2>
                <cc1:msgBox ID="MsgBox1" runat="server" />
                <asp:Label ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">Family Book Number:
            </td>
            <td>
                <asp:TextBox ID="txtFamilyBookNumber" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td>Church:
            </td>
            <td>
                <asp:DropDownList ID="ddChurch" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">Name:
            </td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td style="width: 130px;"><%--Last Name:--%>
            </td>
            <td>
                <asp:TextBox ID="txtLastName" Visible="false" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Address:
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td>City:
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Postal Code:
            </td>
            <td>
                <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td>Home Phone:
            </td>
            <td>
                <asp:TextBox ID="txtHomePhone" runat="server"></asp:TextBox>
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
            <td>Cell Phone:
            </td>
            <td>
                <asp:TextBox ID="txtCellPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Email:
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td>Date Of Birth(mm/dd/yyyy):
            </td>
            <td>
                <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                <%-- Text='<%=time() %>' <input type="text" id="datepicker" name="datepicker">
                
                <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                <asp:Image ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png" runat="server" />
                <asp:CalendarExtender ID="calDOB" runat="server" TargetControlID="txtDOB" Format="MM/dd/yyyy"
                    PopupButtonID="Image1" FirstDayOfWeek="Default">
                </asp:CalendarExtender>--%>
            </td>
        </tr>
        <tr>
            <td>Marital Status:
            </td>
            <td>
                <asp:DropDownList ID="ddMaritalStatus" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td>Preferred method of Contact:
            </td>
            <td>
                <asp:TextBox ID="txtPreContact" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Free to Marry(mm/dd/yyyy):
            </td>
            <td>
                <asp:TextBox ID="txtFreeToMarry" runat="server"></asp:TextBox>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td style="width: 130px;">Active:
            </td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" Checked="true" />
            </td>
        </tr>
        <tr>
            <td colspan="2">Upload member photo (file extension: jpeg, png and gif) :
                <br />
                <asp:FileUpload ID="fileMemberPhoto" runat="server" /><br />
                <%--<asp:Button ID="btnUpload" OnClick="btnUpload_Click" runat="server" Text="Upload file" />--%>
            </td>
            <td style="width: 30px;">&nbsp;
            </td>
            <td colspan="2">
                <asp:Image ID="Image1" runat="server" Width="100px" />
            </td>
        </tr>
    </table>

    <table align="center" class="content_border">
        <tr>
            <td colspan="4">
                <h2>Notes</h2>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:TextBox TextMode="MultiLine" Width="700px" Height="100px" ID="txtNotes" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div align="center" style="padding-top: 10px;">
        <asp:Button CssClass="cssButton" ID="bSave" runat="server" Text="Save" OnClick="bSave_Click" />
    </div>
</div>
