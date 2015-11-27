<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="test.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="js/json2.js"></script>
    <script src="js/jquery-1.9.1.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=RBHMUeEfNkiG73EE8LZbZgPf"></script>
    <!--加载鼠标绘制工具-->
    <script type="text/javascript" src="http://api.map.baidu.com/library/DrawingManager/1.4/src/DrawingManager_min.js"></script>
    <link rel="stylesheet" href="http://api.map.baidu.com/library/DrawingManager/1.4/src/DrawingManager_min.css" />
    <!--加载检索信息窗口-->
    <script type="text/javascript" src="http://api.map.baidu.com/library/SearchInfoWindow/1.4/src/SearchInfoWindow_min.js"></script>
    <link rel="stylesheet" href="http://api.map.baidu.com/library/SearchInfoWindow/1.4/src/SearchInfoWindow_min.css" />
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <table border="0" >
            <tr>
                <td>
                    <asp:DropDownList ID="buyList" runat="server" Width="120px">
                        <asp:ListItem Value="0" Text="  ---  请选择  ---  "></asp:ListItem>
                        <asp:ListItem Value="500166" Text="图书"></asp:ListItem>
                        <asp:ListItem Value="500168" Text="手机数码"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="subList" runat="server" Width="120px">
                        <asp:ListItem Value="0" Text="  ---  请选择  ---  "></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnServiceStart" Text=" Services Install" OnClick="btnServceStart_Click" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnServicesStop" Text="Services Unstall" OnClick="btnServicesStop_Click" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnStart" Text="Start Services" OnClick="btnStart_Click" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnStop" Text="Stop Services" OnClick="btnStop_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnPause" Text="Pause" OnClick="btnPause_Click" />
                </td>
            </tr>
        </table>
        <%--<div style="width: 100%; height: 700px;" id="mapView"></div>--%>
        <%--<button id="setPanoramaByLocation">按经纬度展示全景</button>--%>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#buyList").bind("keyup change", function (e) {
                e.preventDefault();
                // 首先初始化
                $("#subList").empty().append($("<option></option>").val("0").html("  ---  请选择  ---  "));
                if ($(this).val() != "0") {
                    sendData($(this).val());
                }
            });

            function sendData(sBuyID) {
                var loc = window.location.href;
                $.ajax({
                    type: "POST",
                    url: loc + "/GetSubList", // 调动后台页面方法
                    data: '{"sBuyID":"' + sBuyID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        // msg.d是数组，由后台数组ArrayList返回，因此可以遍历每个元素
                        $.each(msg.d, function () {
                            // this.Value和this.Text是后台返回数组ArrayList类型包含元素ListItem类型的属性
                            $("#subList").append($("<option></option").val(this.Value).html(this.Text));
                        });
                    },
                    error: function () {
                        alert("ajax请求发生错误");
                    }
                });
            }
        });
    </script>
</body>
</html>
