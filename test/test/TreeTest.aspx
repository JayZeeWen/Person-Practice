<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreeTest.aspx.cs" Inherits="test.TreeTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<script src="js/jquery-1.9.1.min.js"></script>
<body>
    <form id="form1" runat="server">
        <div id="tree1" runat="server">
        </div>
        <asp:TreeView  runat="server" ID="TreeView1"></asp:TreeView>
    </form>
    <link href="js/jquery.treeview/jquery.treeview.css" rel="stylesheet" />
    <script src="js/jquery.treeview/jquery.treeview.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            //TUILayout("form");
            new OpenTree();

            $("#<%=tree1.ClientID %> ul:first").treeview({
                collapsed: true, unique: true
            });

        });

        $("#<%=tree1.ClientID %> ul a").click(function () {
            window.parent.openWin($(this));
        })

        var OpenTree = function () {
            var id = location.href.split("#");
            var a = $("#tree1 a[ids='" + id[1] + "']");
            if (a.length == 1 && id.length > 1) {
                a.addClass("cur").click();
                if (a.attr("pid") != "" && a.attr("pid") != "0") {
                    a.parents("li").addClass("open");
                }
            }
        }


    </script>
</body>
</html>
