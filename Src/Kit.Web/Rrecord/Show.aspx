<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Kit.Web.Rrecord.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		Rid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Pid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Lid
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		本次记录开始编号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRstartnumber" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Rendnumber
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRendnumber" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Rprintnum
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRprintnum" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Rdatetime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRdatetime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		生成标签用户id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUid" runat="server"></asp:Label>
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




