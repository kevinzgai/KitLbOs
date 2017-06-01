<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="Kit.Web.Ksystemset.Add" Title="增加页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
        <tr>
            <td height="25" width="30%" align="right">
                Stype
                ：</td>
            <td height="25" width="*" align="left">
                <asp:TextBox id="txtStype" runat="server" Width="200px"></asp:TextBox>
            </td></tr>
        <tr>
            <td height="25" width="30%" align="right">
                Sname
                ：</td>
            <td height="25" width="*" align="left">
                <asp:TextBox id="txtSname" runat="server" Width="200px"></asp:TextBox>
            </td></tr>
        <tr>
            <td height="25" width="30%" align="right">
                Svalue
                ：</td>
            <td height="25" width="*" align="left">
                <asp:TextBox id="txtSvalue" runat="server" Width="200px"></asp:TextBox>
            </td></tr>
        <tr>
            <td height="25" width="30%" align="right">
                Skey1
                ：</td>
            <td height="25" width="*" align="left">
                <asp:TextBox id="txtSkey1" runat="server" Width="200px"></asp:TextBox>
            </td></tr>
        <tr>
            <td height="25" width="30%" align="right">
                Skey2
                ：</td>
            <td height="25" width="*" align="left">
                <asp:TextBox id="txtSkey2" runat="server" Width="200px"></asp:TextBox>
            </td></tr>
    </table>
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnSave_Click">添加</asp:LinkButton>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
