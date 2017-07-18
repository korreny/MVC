
<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8" name="viewport" content="width=device-width" />
    <title>Home</title> 
    <link href="../../Content/css/Login.css" rel="stylesheet" />
</head>  
<body>  
    <div id="login">  
        <h1>Login</h1>  
        <form method="post" action="/Home/UserLogin">  
            <input type="text" required="required" placeholder="Account" name="account"></input>  
            <input type="password" required="required" placeholder="PassWord" name="password"></input>  
            <button class="but" type="submit">Login</button>  
        </form>  
    </div> <br/>
    <div>
            <%=ViewData ["info"]%>
    </div>
</body>  
</html>
