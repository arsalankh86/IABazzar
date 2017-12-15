<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<%@ Register src="controls/header.ascx" tagname="header" tagprefix="uc1" %>

<%@ Register src="controls/footer.ascx" tagname="footer" tagprefix="uc2" %>

<%@ Register src="controls/socials.ascx" tagname="socials" tagprefix="uc3" %>

<!DOCTYPE HTML>
<html>
<head>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="HandheldFriendly" content="True" />
<meta name="MobileOptimized" content="320" />
<meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1" />
<meta name="description" content="Anycart Responsive Retail Template" />

<title>Buy Indian Pakistani Salwar Kameez Online</title>
<link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico" />

<link rel="stylesheet" type="text/css" href="css/stylesheet.css" media="screen" />
<!--<link href='http://fonts.googleapis.com/css?family=Carme' rel='stylesheet' type='text/css' />-->

<script src="js/jquery/jquery-1.8.2.min.js"></script>
<script src="js/jquery/ui/jquery-ui-1.8.16.custom.min.js"></script>
<script src="js/jquery/ui/external/jquery.cookie.js"></script>
<script src="js/common.js"></script>
<script src="js/html5.js"></script>
<script src="js/jquery.tooltipster.min.js"></script>
<script src="js/custom.js"></script>

<link rel="stylesheet" type="text/css" href="css/facebook.css" />

<!--[if IE 7]>
<link rel="stylesheet" type="text/css" href="css/ie7.css" />
<![endif]-->

<!--[if lt IE 7]>
<link rel="stylesheet" type="text/css" href="css/ie6.css" />
<script src="js/DD_belatedPNG_0.0.8a-min.js"></script>
<script type="text/javascript">
DD_belatedPNG.fix('#logo img');
</script>
<![endif]-->

</head>

<body>
<form runat="server">

<div class="clbox">
	&nbsp;<h2>Colors</h2>
	<ul id="changer">
        <li><a href="http://curvepixell.com/web/anycart" class="col-1"></a></li>
        <li><a href="brown/index.html" class="col-2"></a></li>
        <li><a href="red/index.html" class="col-3"></a></li>
        <li><a href="blue/index.html" class="col-4"></a></li>
        <li><a href="magenta/index.html" class="col-5"></a></li>
    </ul>
    
    
    <h2>Patterns</h2>
    <ul class="patterns">
        <li><a href="mainbg.html"><img alt="" src="images/pattern/mainbg.png"></a></li>
        <li><a href="mainbg2.html"><img alt="" src="images/pattern/mainbg2.png"></a></li>
        <li><a href="mainbg3.html"><img alt="" src="images/pattern/mainbg3.png"></a></li>
        <li><a href="mainbg4.html"><img alt="" src="images/pattern/mainbg4.png"></a></li>
        <li><a href="mainbg5.html"><img alt="" src="images/pattern/mainbg5.png"></a></li>
        <li><a href="mainbg6.html"><img alt="" src="images/pattern/mainbg6.png"></a></li>
        <li><a href="mainbg7.html"><img alt="" src="images/pattern/mainbg7.png"></a></li>
        <li><a href="mainbg8.html"><img alt="" src="images/pattern/mainbg8.png"></a></li>
        <li><a href="mainbg9.html"><img alt="" src="images/pattern/mainbg9.png"></a></li>
        <li><a href="mainbg10.html"><img alt="" src="images/pattern/mainbg10.png"></a></li>
        <li><a href="mainbg11.html"><img alt="" src="images/pattern/mainbg11.png"></a></li>
        <li><a href="mainbg12.html"><img alt="" src="images/pattern/mainbg12.png"></a></li>
        <li><a href="mainbg13.html"><img alt="" src="images/pattern/mainbg13.png"></a></li>
        <li><a href="mainbg14.html"><img alt="" src="images/pattern/mainbg14.png"></a></li>
        <li><a href="mainbg15.html"><img alt="" src="images/pattern/mainbg15.png"></a></li>
    </ul>    
</div>


<div class="mainWrapper">


<!--Header Part Start-->
<header>
<uc1:header ID="header1" runat="server" />
</header>
<!--Header Part End-->

<div class="wrapper">
<div id="notification"></div>
<div id="container">

<div id="column-left">
    <div class="box">
  <div class="box-heading"><span>Account</span></div>
  <div class="box-content">
  <div class="box-category">
    <ul>
		<li><a href="login.aspx" title="Login">Login</a></li>
      	<li><a href="register.aspx" title="Register">Register</a></li>
      	<%--<li><a href="ForGotyourPwd.aspx" title="Forgotten Password">Forgotten Password</a></li>--%>
        <li><a href="MyAccount.aspx" title="My Account">My Account</a></li>
        <li><a href="Wishlist.aspx" title="Wish List">Wish List</a></li>
      	<li><a href="OrderInfomation.aspx" title="Order History">Order History</a></li>
      <%--	<li><a href="#" title="Downloads">Downloads</a></li>
      	<li><a href="returns.html" title="Returns">Returns</a></li>
      	<li><a href="transactions.html" title="Transactions">Transactions</a></li>
      	<li><a href="#" title="Newsletter">Newsletter</a></li>--%>
	</ul>
    </div>

  </div>
</div>
  </div>
 
<div id="content">


<uc3:socials ID="socials1" runat="server" />

					

<div class="breadcrumb">
        <a href="Default.aspx" title="Home">Home</a>
         &raquo; <a href="MyAccount.aspx" title="Account">Account</a>
         &raquo; <a href="login.aspx" title="Login">Login</a>
      </div>
  
  <div class="login-content">
    <div class="left">
      <div class="content">
        <h2>Register Account</h2>
        <p>By creating an account you will be able to shop faster, be up to date on an order's status, and keep track of the orders you have previously made.</p>
        <a href="register.aspx" class="button">Registration</a><br />
                <br />
            <h2>Guest Checkout</h2>
            <asp:Button ID="btnlogin0" runat="server" Text="CONTINUE AS A GUEST" value="Login" 
                class="button" onclick="CONTINUE_Click" Width="170px" CausesValidation="false" />
                         
        </div>
    </div>

   

    <div class="right">
      <h2>Returning Customer</h2>
       
        <div class="content">
          <p>I am a returning customer</p>
          <b>E-Mail Address:</b><br />
          <input type="text" name="email" id="email" value="" runat="server" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                  ControlToValidate="email" ErrorMessage="Please Enter Email-Address" 
                  ForeColor="Red">*</asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                  ControlToValidate="email" ErrorMessage="Email-id is Not vaild" 
                  ForeColor="Red" 
                  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Email-id is Not vaild</asp:RegularExpressionValidator>
         <br />
          <br />
          <b>Password:</b><br />
          <input type="password" name="password" id="password" value="" runat="server" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                  ControlToValidate="password" ErrorMessage="Please Enter Password" 
                  ForeColor="Red">*</asp:RequiredFieldValidator>
          <br />
          <%--<a href="Forgotten_Password.aspx" title="Forgotten Password">Forgotten Password</a><br />--%>
          <br />
            <asp:Button ID="btnlogin" runat="server" Text="Login" value="Login" 
                class="button" onclick="btnlogin_Click" />
          
                  </div>
       
    </div>
  </div>
  </div>
<script type="text/javascript"><!--
    $('#login input').keydown(function (e) {
        if (e.keyCode == 13) {
            $('#login').submit();
        }
    });
//--></script> 
<div class="clear"></div>


</div>
</div>







<!--Footer Part Start-->
<footer>
<uc2:footer ID="footer1" runat="server" />
</footer>
<!--Footer Part End-->

</div>
</form>
<!--Scroll back to top-->
<script>
    $(function () {
        $(window).scroll(function () {
            if ($(this).scrollTop() > 100) {
                $('#backTop').fadeIn();
            } else {
                $('#backTop').fadeOut();
            }
        });
    });
    jQuery('.backtotop').click(function () {
        jQuery('html, body').animate({ scrollTop: 0 }, 'slow');
    });

</script>
<!--end of Scroll back to top-->
 

</body>


</html>
