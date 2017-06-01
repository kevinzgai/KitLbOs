<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Kit.Web.Alllog.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		Aid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Uid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Atype
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAtype" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Acontent
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAcontent" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Atime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAtime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Astate
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAstate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Spare1
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSpare1" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Spare2
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSpare2" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Spare3
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSpare3" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




