﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="Kit.Web.KlableroleBase.Add" Title="增加页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
                
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		Lname
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLname" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Lcontent
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLcontent" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Lcontentsate
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLcontentsate" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Llabletypeid
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLlabletypeid" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Llabletypename
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLlabletypename" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LlableImg
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLlableImg" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		循环规则表id
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLlableloopid" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LProductid
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLProductid" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Ltime
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtLtime" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
</table>
<script src="/js/calendar1.js" type="text/javascript"></script>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
