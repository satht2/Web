<%@ Control Language="C#" AutoEventWireup="true" CodeFile="addMemberPhoto.ascx.cs" Inherits="Controls_addMemberPhoto" %>

<h2>Add Member Photo</h2>
            <asp:Label ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
<table id="tPhoto" runat="server">
    <tr>
        <td>Upload member photo:<br />
            (file extension: jpeg, png and gif)
        </td>
        <td>
            <asp:FileUpload ID="fileMemberPhoto" runat="server" /><br />
            <asp:Button ID="btnUpload" OnClick="btnUpload_Click" runat="server" Text="Upload file" />
        </td>
        <td style="width: 30px;">&nbsp;
        </td>
        <td colspan="2">
            <asp:Image ID="Image1" runat="server" />
        </td>
    </tr>
</table>
