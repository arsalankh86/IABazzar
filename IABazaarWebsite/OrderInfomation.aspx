<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderInfomation.aspx.cs" Inherits="OrderInfomation" %>

<%@ Register src="controls/header.ascx" tagname="header" tagprefix="uc1" %>

<%@ Register src="controls/footer.ascx" tagname="footer" tagprefix="uc2" %>

<%@ Register src="controls/socials.ascx" tagname="socials" tagprefix="uc3" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="HandheldFriendly" content="True" />
<meta name="MobileOptimized" content="320" />
<meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1" />
<meta name="description" content="Anycart Responsive Retail Template" />

<title>Iabazaar</title>
<link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico" />

<link rel="stylesheet" type="text/css" href="css/stylesheet.css" media="screen" />
<link href='http://fonts.googleapis.com/css?family=Carme' rel='stylesheet' type='text/css' />

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

<form id="form1" runat="server">
<div class="clbox">
	<a class="toggle">Toggle</a>
    
	<h2>Colors</h2>
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
            <li><a href="MyAccount.aspx" title="My Account">My Account</a></li>
            <li><a href="#" title="Edit Account">Edit Account</a></li>
      		<li><a href="password.html" title="Password">Password</a></li>
            <li><a href="Wishlist.aspx" title="Wish List">Wish List</a></li>
      		<li><a href="OrderInfomation.aspx" title="Order History">Order History</a></li>
      		<li><a href="#" title="Downloads">Downloads</a></li>
      		<li><a href="returns.html" title="Returns">Returns</a></li>
     		<li><a href="transactions.html" title="Transactions">Transactions</a></li>
      		<li><a href="#" title="Newsletter">Newsletter</a></li>
            <li><a href="login.aspx" title="Logout">Logout</a></li>
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
         &raquo; <a href="OrderInfomation.aspx" title="Order History">Order History</a>
         &raquo; <a href="orderinformation.html" title="Order Information">Order Information</a>
      </div>
  
  <h1><span>Order Information</span></h1>
    <table class="list">
    <thead>
      <tr>
        <td class="left">Order <span>Information</span></td>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td class="left">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
          </td>
      </tr>
    </tbody>
  </table>
    <div class="buttons">
    <div class="right"><a href="orderhistory.html" class="button">Continue</a></div>
  </div>
  </div>
<div class="clear"></div>


</div>
</div>







<!--Footer Part Start-->
<footer>

<div class="backTop" id="backTop"><a title="Back to Top" href="javascript:void(0)" class="backtotop">Top</a></div>




<div class="clear"></div>
<div id="footerTop">
<div class="line-bottom">
<%--<div id="customHome" class="container_12"><div id="about_us_footer"
	class="grid_3">
<h2>About Anycart</h2>
<img class="about_us_image" alt="small logo" src="images/smalllogo.jpg"/><p>      Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing.</p>
</div>
 

<!--  TWITTER --> 

<div id="twitter_footer" class="grid_3">
	<h2>Latest Tweets</h2>
    
	<div id="twitter_update_list">
	<script type="text/javascript" src="../../../twitter.com/javascripts/blogger.js"></script> 
	</div>
    
    
    <a class="twitter-timeline" href="https://twitter.com/curvepixell" data-chrome="noheader nofooter noborders noscrollbar transparent" data-theme="light" data-tweet-limit="2" data-related="twitterapi,twitter" data-aria-polite="assertive" data-widget-id="349820723327541248">Tweets by @curvepixell</a>
<script>    !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
    
</div>

 
















<div id="contact_footer"
	class="grid_3">
<h2>Contact Us</h2>
<ul>
<li>
	<!-- TELEPHONE 1 -->
	<ul id="tel" class="contact_column">
		<li id="footer_telephone">+91 7377646107</li>


		<!-- TELEPHONE 2 -->
				<li id="footer_telephone2">+11 8832 456 456</li>
			</ul>
	
	<!-- FAX  -->
		<ul id="fax" class="contact_column">
		<li id="footer_fax">+11 0832 456 789</li>
	</ul>
	
	<!-- EMAIL 1 -->
		<ul id="mail" class="contact_column">
		<li id="footer_email">curvepixell@gmail.com</li>



		<!-- EMAIL 2 -->
				<li id="footer_email2">stevemun7@gmail.com</li>
			</ul>
	
	<!-- SKYPE -->
		<ul id="skype" class="contact_column">
		<li id="footer_skype">curvepixell</li>
	</ul>
	</li>
</ul>
</div>

<!--  FACEBOOK --> 
<div id="facebook_footer" class="grid_3">
    <h2>Facebook</h2>
    <div style="width:210px; height:244px; overflow:hidden;">
    <div id="facebook"  style="margin-left:-10px; margin-top:-10px;">
    <div id="fb-root"></div>
    <script>        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "../../../connect.facebook.net/en_US/all.js#xfbml=1";
            fjs.parentNode.insertBefore(js, fjs);
        } (document, 'script', 'facebook-jssdk'));</script>
    <div class="fb-like-box" data-href="http://www.facebook.com/540994729266040" data-width="240" data-connections="20" data-height="255" data-show-faces="true" data-stream="false" data-header="false" data-border-color="#fff"></div>
    </div>
    </div>
</div>

 
</div>--%>
<div class="clear"></div>
</div>
<div class="line-bottom1"></div>

</div>





<div id="footerMain">
<div id="footerm" class="mobileFpart">
  <div class="column">
    <h3>Information</h3>
    <ul>
            <li><a href="about.html">About Us</a></li>
            <li><a href="delivery.html">Delivery Information</a></li>
            <li><a href="policy.html">Privacy Policy</a></li>
            <li><a href="conditions.html">Terms &amp; Conditions</a></li>
          </ul>
  </div>
  <div class="column">
    <h3>Customer Service</h3>
    <ul>
      <li><a href="contact.html">Contact Us</a></li>
      <li><a href="returns.html">Returns</a></li>
      <li><a href="sitemap.html">Site Map</a></li>
    </ul>
  </div>
  <div class="column">
    <h3>Extras</h3>
    <ul>
      <li><a href="brands.html">Brands</a></li>
      <li><a href="voucher.html">Gift Vouchers</a></li>
      <li><a href="affiliates.html">Affiliates</a></li>
      <li><a href="specials.html">Specials</a></li>
    </ul>
  </div>
  <div class="column">
    <h3>My Account</h3>
    <ul>
      <li><a href="myaccount.html">My Account</a></li>
      <li><a href="orderhistory.html">Order History</a></li>
      <li><a href="wishlist.html">Wish List</a></li>
      <li><a href="newsletter.html">Newsletter</a></li>
    </ul>
  </div>
</div>

<div id="footer">
  <div class="column">
    <h3>Information</h3>
    <ul>
            <li><a href="about.html">About Us</a></li>
            <li><a href="delivery.html">Delivery Information</a></li>
            <li><a href="policy.html">Privacy Policy</a></li>
            <li><a href="conditions.html">Terms &amp; Conditions</a></li>
          </ul>
  </div>
  <div class="column">
    <h3>Customer Service</h3>
    <ul>
      <li><a href="contact.html">Contact Us</a></li>
      <li><a href="returns.html">Returns</a></li>
      <li><a href="sitemap.html">Site Map</a></li>
    </ul>
  </div>
  <div class="column">
    <h3>Extras</h3>
    <ul>
      <li><a href="brands.html">Brands</a></li>
      <li><a href="voucher.html">Gift Vouchers</a></li>
      <li><a href="affiliates.html">Affiliates</a></li>
      <li><a href="specials.html">Specials</a></li>
    </ul>
  </div>
  <div class="column">
    <h3>My Account</h3>
    <ul>
      <li><a href="myaccount.html">My Account</a></li>
      <li><a href="orderhistory.html">Order History</a></li>
      <li><a href="wishlist.html">Wish List</a></li>
      <li><a href="newsletter.html">Newsletter</a></li>
    </ul>
  </div>
</div>


<div class="powered-main">
    <div id="powered">
        <div class="fl">iabazaar &copy; 2013</div>
        Theme by <a href="http://www.curvepixell.com/" target="_blank" title="CURVEPIXELL">CURVEPIXELL</a>
    </div>
</div>

</div>
</footer>
<!--Footer Part End-->

</div>



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

</form>

</body>
</html>
