<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../../Content/css/doc/DocAPI.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.7.1.min.js"></script>
    <title>作业平台数据库说明文档</title>
    <script>
        $(
            function(){
                alert("OK");
            });
    </script>
</head>
<body>
    <form id="form1" runat="server">
       <!--顶部 开始-->
		<div class="top">
			<p>API Docs</p>
		</div>
		<!--顶部 结束-->

		<!--头部  开始-->
		<div class="head">
			<img src="../../Images/Doc/banner.jpg"/>
		</div>
		<!--头部  结束-->

		<!--内容  开始-->
		<div class="content">
			<div class="title">
				<p class="Atitle">DataBase API</p>
			</div>
 

			<table class="tablecreate">
				<tr class="trbox">
					<td colspan="2" class="trtitle">guser</td> 
                    <td colspan="2" class="trtitle">用户信息表</td>
				</tr>
				<tr class="trtitle">
					<td class="field">字段</td>
					<td class="type">类型</td>
                    <td class="name">名称</td>
                    <td class="remark">备注</td>
				</tr>
                <tr class="trcontent">
					<td class="field">字段</td>
					<td class="type">类型</td>
                    <td class="name">名称</td>
                    <td class="remark">备注</td>
				</tr>
			</table>

			

		</div>
		<!--内容  结束-->

		<!--底部  开始-->
		<!--<div class="foot"></div>-->
		<!--底部  结束--> 
    </form>
</body>
</html>