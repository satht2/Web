<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel runat="server" DefaultButton="LinkButtonOK">
        <div class="grid-container fluid login_background">
            <div class="grid-x">
                <div class="large-12 small-12">
                    <div class="login_card grid-container">
                        <div class="grid-x">
                            <div class="small-6 large-6">
                                <img class="login_image" src="./Images/Church.jpg">
                            </div>
                            <div class="small-6 large-6 login_section">
                                
                                <table class="login_table">
                                    <tr>
                                        <td>
                                            <h2>Sign in to the database</h2>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBoxUserName" CssClass="login_textbox" placeholder="Username" runat="server" label="hi"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBoxPassword" CssClass="login_textbox" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="LinkButtonOK" runat="server" CssClass="login_button" OnClick="LinkButtonOK_Click">Sign In</asp:LinkButton>
                                        </td>
                                        
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
