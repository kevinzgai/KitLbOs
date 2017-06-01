<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Kit.Web.KlableroleBase.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		Lid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Lname
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLname" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Lcontent
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLcontent" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Lcontentsate
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLcontentsate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Llabletypeid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLlabletypeid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Llabletypename
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLlabletypename" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LlableImg
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLlableImg" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		循环规则表id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLlableloopid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LProductid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLProductid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Ltime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLtime" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




