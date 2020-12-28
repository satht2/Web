<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopNav.ascx.cs" Inherits="Controls_TopNav" %>

<div>
    <div>
        <asp:HyperLink ID="HyperLink2" CssClass="cssButton" NavigateUrl="~/home.aspx" runat="server">Home</asp:HyperLink>
        <asp:HyperLink ID="HyperLink1" CssClass="cssButton" NavigateUrl="~/Member.aspx"
            runat="server">Member</asp:HyperLink>
        <asp:HyperLink ID="HyperLink3" CssClass="cssButton" NavigateUrl="~/Church.aspx"
            runat="server">Church</asp:HyperLink>
        <%--<asp:HyperLink ID="HyperLink4" CssClass="cssButton" NavigateUrl="~/addClientNotes.aspx"
            runat="server">Client Notes</asp:HyperLink>
        <asp:HyperLink ID="HyperLink5" CssClass="cssButton" NavigateUrl="~/addClinicalSupervisor.aspx"
            runat="server">Add Clinical Supervisor</asp:HyperLink>
        <asp:HyperLink ID="HyperLink6" CssClass="cssButton" NavigateUrl="~/editClinicalSupervisor.aspx"
            runat="server">Edit Clinical Supervisor</asp:HyperLink>--%>
        <%--<asp:LinkButton ID="LinkButton2" CssClass="cssButton" runat="server">About Us</asp:LinkButton>--%>
        <%--<asp:LinkButton ID="LinkButton3" CssClass="cssButton" runat="server">Contact Us</asp:LinkButton>--%>
        <div style="float: right;">
            <asp:LinkButton ID="lkbSignOut" runat="server" OnClick="lkbSignOut_Click">Sign out</asp:LinkButton>
        </div>
    </div>
</div>