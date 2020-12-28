<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel runat="server" DefaultButton="LinkButtonOK">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td>User name
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div style="padding: 15px 0 5px 0; vertical-align: middle;">
                <asp:LinkButton ID="LinkButtonOK" runat="server" CssClass="cssButton" OnClick="LinkButtonOK_Click">OK</asp:LinkButton>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

