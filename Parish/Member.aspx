﻿<%@ Page Title="" Language="C#" EnableViewState="true" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="Member" %>

<%@ Register Src="~/Controls/addMember.ascx" TagPrefix="uc1" TagName="addMember" %>
<%@ Register Src="~/Controls/addDonation.ascx" TagPrefix="uc1" TagName="addDonation" %>
<%@ Register Src="~/Controls/addDependent.ascx" TagPrefix="uc1" TagName="addDependent" %>
<%@ Register Src="~/Controls/addCertificateOfBaptism.ascx" TagPrefix="uc1" TagName="addCertificateOfBaptism" %>
<%@ Register Src="~/Controls/addCertificateOfConfirmation.ascx" TagPrefix="uc1" TagName="addCertificateOfConfirmation" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divMembers" visible="true" runat="server">
        <table align="center" class="content_border">
            <tr>
                <td>
                    <h2>Members</h2>
                    <div style="padding-left: 20px;">
                        <asp:Label ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
                    </div>
                </td>
                <td style="float: right">
                    <asp:Button ID="btnAddMember" runat="server" CssClass="cssButton" Text="Add Member" OnClick="btnAddMember_Click" />
                </td>
            </tr>
            <tr>
                <td width="100px">Search Member:
                </td>
                <td align="left">
                    <%--                    <asp:DropDownList ID="ddClient" runat="server" AutoPostBack="true" OnSelectedIndexChanged="GetMember_Selected">
                    </asp:DropDownList>--%>
                    <asp:TextBox ID="txtSearch" OnTextChanged="Search" AutoPostBack="true" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView Width="100%" ID="grdMembers" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                        OnPageIndexChanging="grdMembers_OnPaging" DataKeyName="MemberID" PageSize="2">
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
                                    <asp:LinkButton ID="lnkSelect" runat="server" CommandArgument='<%#  
                                         Eval("MemberID")%>'
                                        Text="Select" OnCommand="lnkSelect_Command"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div id="divSelectedMemberAction" visible="false" runat="server">
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
    <div id="divSelectedMember" visible="false" runat="server">
        <br />
        <table align="center" class="content_border">

            <tr>
                <td colspan="4">
                    <asp:GridView Width="100%" ID="grdSelectedMember" runat="server" AutoGenerateColumns="false"
                        DataKeyName="MemberID">
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
                    <asp:GridView Width="100%" ID="grdDependents" runat="server"
                        AutoGenerateColumns="false"
                        AlternatingRowStyle-BackColor="#E9ECF1"
                        HeaderStyle-BackColor="white"
                        Font-Names="Arial"
                        RowStyle-HorizontalAlign="Center"
                        RowStyle-Height="22"
                        HeaderStyle-Height="25"
                        FooterStyle-HorizontalAlign="Center"
                        FooterStyle-Font-Bold="true"
                        FooterStyle-ForeColor="#555555"
                        ShowFooter="true">
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
                    <asp:GridView Width="100%" ID="grdDonations" runat="server"
                        AutoGenerateColumns="false"
                        AlternatingRowStyle-BackColor="#E9ECF1"
                        HeaderStyle-BackColor="white"
                        Font-Names="Arial"
                        RowStyle-HorizontalAlign="Center"
                        RowStyle-Height="22"
                        HeaderStyle-Height="25"
                        FooterStyle-HorizontalAlign="Center"
                        FooterStyle-Font-Bold="true"
                        FooterStyle-ForeColor="#555555"
                        ShowFooter="true">
                        <Columns>
                            <asp:TemplateField HeaderText="Donation Date">
                                <ItemTemplate><%#Eval("CreatedDate")%></ItemTemplate>
                                <%--<FooterTemplate>
                                <div><asp:Label Text="Total" runat="server" /></div>
                            </FooterTemplate>--%>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DonationType" HeaderText="Donation Type" />
                            <asp:BoundField DataField="AddedBy" HeaderText="Created By" />
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate><%#Eval("Deposit", "{0:C}")%></ItemTemplate>
                                <%--<FooterTemplate>                                
                                <div><asp:Label ID="lblTotal" Text='<%#Eval("Total")%>' runat="server" /></div>
                            </FooterTemplate>--%>
                            </asp:TemplateField>
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
                    <asp:GridView Width="100%" ID="grdCertificates" runat="server"
                        AutoGenerateColumns="false"
                        AlternatingRowStyle-BackColor="#E9ECF1"
                        HeaderStyle-BackColor="white"
                        Font-Names="Arial"
                        RowStyle-HorizontalAlign="Center"
                        RowStyle-Height="22"
                        HeaderStyle-Height="25"
                        FooterStyle-HorizontalAlign="Center"
                        FooterStyle-Font-Bold="true"
                        FooterStyle-ForeColor="#555555"
                        ShowFooter="true">
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
    <div id="divBaptism" runat="server" visible="false">
        <uc1:addCertificateOfBaptism runat="server" ID="addCertificateOfBaptism" />
    </div>
    <div id="divConfirmation" runat="server" visible="false">
        <uc1:addCertificateOfConfirmation runat="server" ID="addCertificateOfConfirmation" />
    </div>
    <div id="divDeath" runat="server" visible="false"></div>
    <div id="divMarriage" runat="server" visible="false"></div>
    <div id="divDonation" runat="server" visible="false">
        <uc1:addDonation runat="server" ID="addDonation" />
    </div>
    <div id="divDependent" runat="server" visible="false">
        <uc1:addDependent runat="server" ID="addDependent" />
    </div>
    <div id="divClientinfo" runat="server" visible="false">
        <uc1:addMember runat="server" ID="addMember" />
    </div>
</asp:Content>
