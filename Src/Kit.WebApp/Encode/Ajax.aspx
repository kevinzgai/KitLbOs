<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ajax.aspx.cs" Inherits="Ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

</head>
<body>
    <form id="form1" name="form1" runat="server">
        <div>
            <textarea name="StrInput" style="border:1px solid Gray; border-radius:5px; width:70%; min-height:300px"></textarea>
            <select>
                <option value="0">加密</option>
                <option value="1">解密</option>
            </select>
            <br />
            <input type="text" value="login" id="login"/>
            <input type="button" id="Submit" value="Submit" />
        </div>
    </form>
    <i></i>
</body>
</html>
<script src="jquery.js" type="text/javascript"></script>
<script>
    $(function () {
        var strtext = null;
        $("#Submit").bind("click", function () {
            strtext = $("textarea[name='StrInput']").val();

            $.ajax({
                url: 'Default.aspx',
                type: 'get',
                cache: false,
                data: "aaa=" + $("textarea[name='StrInput']").val() + "&c=" + $("select").val()+"&login="+$("#login").val(),
                processData: false,
                contentType: false
            }).done(function (res) {
                alert(res);
                $("i").append(res)+"<br/>";
            }).fail(function (res) { });
        });
    });
</script>
