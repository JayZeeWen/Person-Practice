<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baiduMap.aspx.cs" Inherits="test.baiduMap" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
	<style type="text/css">
		body, html {width: 100%;height: 100%;margin:0;font-family:"微软雅黑";}
		#allmap{width:100%;height:500px;}
		p{margin-left:5px; font-size:14px;}
	</style>
	<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=RBHMUeEfNkiG73EE8LZbZgPf"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/library/TextIconOverlay/1.2/src/TextIconOverlay_min.js"></script>
	<script type="text/javascript" src="http://api.map.baidu.com/library/MarkerClusterer/1.2/src/MarkerClusterer_min.js"></script>
	<title>地图展示</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="allmap"></div>
        <p>缩放地图，查看点聚合效果</p>
        <%--输入省、直辖市或县名称：<input type="text" id="districtName" style="width:80px" value="重庆市">
<input type="button" onclick="getBoundary()" value="获取轮廓线">--%>
    </form>
</body>
</html>
<script type="text/javascript">
    // 百度地图API功能
    //var map = new BMap.Map("allmap");
    //map.centerAndZoom(new BMap.Point(116.404, 39.915), 4);
    //map.enableScrollWheelZoom();
    //var bdary = new BMap.Boundary();
    //var count = rs.boundaries.length; //行政区域的点有多少个
    //for (var i = 0; i < count; i++) {
    //    var ply = new BMap.Polygon(rs.boundaries[i], { strokeWeight: 2, strokeColor: "#ff0000" }); //建立多边形覆盖物
    //    map.addOverlay(ply);  //添加覆盖物
    //}
    //map.setViewport(points);

    //var MAX = 10;
    //var markers = [];
    //var pt = null;
    //var i = 0;
    //for (; i < MAX; i++) {
    //    pt = new BMap.Point(Math.random() * 40 + 85, Math.random() * 30 + 21);
    //    markers.push(new BMap.Marker(pt));
    //}
    //最简单的用法，生成一个marker数组，然后调用markerClusterer类即可。
    //var markerClusterer = new BMapLib.MarkerClusterer(map, { markers: markers });

    //var map = new BMap.Map("allmap");
    //map.centerAndZoom(new BMap.Point(116.403765, 39.914850), 5);
    //map.addControl(new BMap.NavigationControl({ type: BMAP_NAVIGATION_CONTROL_SMALL }));
    //map.enableScrollWheelZoom();

    //function getBoundary() {
    //    var bdary = new BMap.Boundary();
    //    var name = "深圳市";
    //    bdary.get(name, function (rs) {       //获取行政区域
    //        map.clearOverlays();        //清除地图覆盖物       
    //        var count = rs.boundaries.length; //行政区域的点有多少个
    //        for (var i = 0; i < count; i++) {
    //            var ply = new BMap.Polygon(rs.boundaries[i], { strokeWeight: 2, strokeColor: "#ff0000", enableClicking:"false",fillColor:"" }); //建立多边形覆盖物
    //            map.addOverlay(ply);  //添加覆盖物
    //            map.setViewport(ply.getPath());    //调整视野         
    //        }
    //    });
    //}
</script>

<script type="text/javascript">
    // 百度地图API功能
    var map = new BMap.Map("allmap");
    map.centerAndZoom(new BMap.Point(116.404, 39.915), 4);
    map.enableScrollWheelZoom();

    var MAX = 10;
    var markers = [];
    var pt = null;
    var i = 0;
    for (; i < MAX; i++) {
        pt = new BMap.Point(Math.random() * 40 + 85, Math.random() * 30 + 21);
        markers.push(new BMap.Marker(pt));
    }
    //最简单的用法，生成一个marker数组，然后调用markerClusterer类即可。
    var markerClusterer = new BMapLib.MarkerClusterer(map, { markers: markers });
</script>
