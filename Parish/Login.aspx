<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel runat="server" DefaultButton="LinkButtonOK">
        <div class="grid-container fluid">
            <div class="grid-x">
                <table class="small-12 small-offset-0 large-10 large-offset-1">
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
                <div class="small-12 small-offset-0 large-10 large-offset-1">
                    <asp:LinkButton ID="LinkButtonOK" runat="server" CssClass="cssButton" OnClick="LinkButtonOK_Click">OK</asp:LinkButton>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
