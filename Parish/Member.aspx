<%@ Page Title="" Language="C#" EnableViewState="true" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="Member" %>

<%@ Register Src="~/Controls/addMember.ascx" TagPrefix="uc1" TagName="addMember" %>
<%@ Register Src="~/Controls/addDonation.ascx" TagPrefix="uc1" TagName="addDonation" %>
<%@ Register Src="~/Controls/addDependent.ascx" TagPrefix="uc1" TagName="addDependent" %>
<%@ Register Src="~/Controls/addCertificateOfBaptism.ascx" TagPrefix="uc1" TagName="addCertificateOfBaptism" %>
<%@ Register Src="~/Controls/addCertificateOfConfirmation.ascx" TagPrefix="uc1" TagName="addCertificateOfConfirmation" %>
<%@ Register Src="~/Controls/addCertificateOfMarriage.ascx" TagPrefix="uc1" TagName="addCertificateOfMarriage" %>
<%@ Register Src="~/Controls/addCertificateOfDeath.ascx" TagPrefix="uc1" TagName="addCertificateOfDeath" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="grid-container fluid">
        <div class="grid-x">

            <div class="large-12 small-12">
                <div class="logo_box">
                    <div class="logo_image">
                        <img src="./Images/logo.png">
                    </div>
                </div>
            </div>

            <div id="divMembers" class="large-10 large-offset-1 small-10 small-offset-1 members_maintable" visible="true" runat="server">
                <table align="center" class="content_border">
                    <tr class="member_searchsection">
                        <td>
                            <asp:TextBox ID="txtSearch" CssClass="member_search" OnTextChanged="Search" placeholder="Search Member" AutoPostBack="true" runat="server"></asp:TextBox>
                            <div style="padding-left: 20px;">
                                <asp:Label ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
                            </div>
                        </td>
                        <td>
                            <asp:Button ID="btnAddMember" CssClass="member_addbtn" runat="server" Text="+ Add Member" OnClick="btnAddMember_Click" />
                        </td>
                    </tr>
                
                    <tr class="member_tablesection">
                        <td colspan="2">
                            <asp:GridView Width="100%" ID="grdMembers" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                OnPageIndexChanging="grdMembers_OnPaging" DataKeyName="MemberID" PageSize="50" RowStyle-HorizontalAlign="Left"
                                CellPadding="5" CssClass="members_table">
                                <Columns>
                                    <%--<asp:BoundField DataField="FamilyBookNumber" HeaderText="Family Book Number" />--%>
                                    <asp:TemplateField HeaderText="S. No">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkFamilyBookNumber" runat="server" CommandArgument='<%#Eval("MemberID")%>'
                                                Text='<%#Eval("FamilyBookNumber")%>' OnCommand="lnkSelect_Command"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="First Name">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkFirstName" runat="server" CommandArgument='<%#Eval("MemberID")%>'
                                                Text='<%#Eval("FirstName")%>' OnCommand="lnkSelect_Command"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="FirstName" HeaderText="First Name" />--%>
                                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                    <asp:BoundField DataField="HomePhone" HeaderText="Home Phone" />
                                    <asp:BoundField DataField="CellPhone" HeaderText="Cell Phone" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <asp:BoundField DataField="Active" HeaderText="Active" />
                                    <%--<asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSelect" runat="server" CommandArgument='<%#  
                                            Eval("MemberID")%>'
                                        Text="Select" OnCommand="lnkSelect_Command"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>



















        <div id="divSelectedMemberAction" class="small-12 large-10 large-offset-1" visible="false" runat="server">
            <h2>Member:
                    <asp:Label ID="lblmemberName" runat="server" Text=""></asp:Label></h2>
            <table align="center" class="content_border">
                <tr>
                    <td>
                        <asp:Button ID="btnDependent" runat="server" CssClass="cssButton" Text="Dependent" OnClick="btnDependent_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnDonation" runat="server" CssClass="cssButton" Text="Donation" OnClick="btnDonation_Click" />
                    </td>
                    <td style="padding-left: 20px;">
                        <table align="center" style="border: solid 3px #D9D9D9;">
                            <tr>
                                <td>Select Certificate Type:
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddCertificateType" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btnCertificate" runat="server" CssClass="cssButton" Text="Add Certificate" OnClick="btnCertificate_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" CssClass="cssButton" Text="Go Back" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="grid-x">
            <div id="divSelectedMember" class="small-12 large-10 large-offset-1" visible="false" runat="server">
                <br />
                <table align="center" class="content_border">

                    <tr>
                        <td colspan="4">
                            <asp:GridView Width="100%" ID="grdSelectedMember" runat="server" AutoGenerateColumns="false" DataKeyName="MemberID" RowStyle-HorizontalAlign="Left" CellPadding="5">
                                <Columns>
                                    <asp:BoundField DataField="FamilyBookNumber" HeaderText="Family Book Number" />
                                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                    <asp:BoundField DataField="HomePhone" HeaderText="Home Phone" />
                                    <asp:BoundField DataField="CellPhone" HeaderText="Cell Phone" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <asp:BoundField DataField="Active" HeaderText="Active" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#  
                                                 Eval("MemberID")%>'
                                                Text="Edit" OnCommand="lnkEdit_Command"></asp:LinkButton>
                                            <%--&nbsp;
                                            <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%#  
                                                 Eval("MemberID")%>'
                                            OnClientClick="return confirm('Do you want to delete?')"
                                            Text="Delete" OnClick="lnkRemove_Click"></asp:LinkButton>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <h2>Dependents</h2>
                            <asp:GridView Width="100%" ID="grdDependents" runat="server" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="#E9ECF1" HeaderStyle-BackColor="white" Font-Names="Arial" RowStyle-HorizontalAlign="Left" RowStyle-Height="22" HeaderStyle-Height="25" FooterStyle-HorizontalAlign="Center" FooterStyle-Font-Bold="true" FooterStyle-ForeColor="#555555" ShowFooter="true" CellPadding="5">
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
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <h2>Donation</h2>
                            <asp:GridView Width="100%" ID="grdDonations" runat="server" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="#E9ECF1" HeaderStyle-BackColor="white" Font-Names="Arial" RowStyle-HorizontalAlign="Left" RowStyle-Height="22" HeaderStyle-Height="25" FooterStyle-HorizontalAlign="Center" FooterStyle-Font-Bold="true" FooterStyle-ForeColor="#555555" ShowFooter="true" CellPadding="5">
                                <Columns>
                                    <asp:TemplateField HeaderText="Donation Date">
                                        <ItemTemplate><%#Eval("CreatedDate")%></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DonationType" HeaderText="Donation Type" />
                                    <asp:BoundField DataField="AddedBy" HeaderText="Created By" />
                                    <asp:BoundField DataField="Deposit" HeaderText="Amount" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Right" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <div>No records found.</div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <h2>Certificates</h2>
                            <asp:GridView Width="100%" ID="grdCertificates" runat="server" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="#E9ECF1" HeaderStyle-BackColor="white" Font-Names="Arial" RowStyle-HorizontalAlign="Left" RowStyle-Height="22" HeaderStyle-Height="25" FooterStyle-HorizontalAlign="Center" FooterStyle-Font-Bold="true" FooterStyle-ForeColor="#555555" ShowFooter="true" CellPadding="5">
                                <Columns>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate><%#Eval("Name")%></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CertificateType" HeaderText="Certificate Name" />
                                    <asp:BoundField DataField="ParentFather" HeaderText="Parent Father" />
                                    <asp:BoundField DataField="ParentMother" HeaderText="Parent Mother" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <div>No records found.</div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divBaptism" class="small-12 large-10 large-offset-1" runat="server" visible="false">
                <uc1:addCertificateOfBaptism runat="server" ID="addCertificateOfBaptism" />
            </div>
            <div id="divConfirmation" class="small-12 large-10 large-offset-1" runat="server" visible="false">
                <uc1:addCertificateOfConfirmation runat="server" ID="addCertificateOfConfirmation" />
            </div>
            <div id="divDeath" class="small-12 large-10 large-offset-1" runat="server" visible="false">
                <uc1:addCertificateOfDeath runat="server" ID="addCertificateOfDeath" />
            </div>
            <div id="divMarriage" class="small-12 large-10 large-offset-1" runat="server" visible="false">
                <uc1:addCertificateOfMarriage runat="server" ID="addCertificateOfMarriage" />
            </div>
            <div id="divDonation" class="small-12 large-10 large-offset-1" runat="server" visible="false">
                <uc1:addDonation runat="server" ID="addDonation" />
            </div>
            <div id="divDependent" class="small-12 large-10 large-offset-1" runat="server" visible="false">
                <uc1:addDependent runat="server" ID="addDependent" />
            </div>
            <div id="divClientinfo" class="small-12 large-10 large-offset-1" runat="server" visible="false">
                <uc1:addMember runat="server" ID="addMember" />
            </div>
        </div>
    </div>
</asp:Content>
