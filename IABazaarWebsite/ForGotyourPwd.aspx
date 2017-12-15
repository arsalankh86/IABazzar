<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForGotyourPwd.aspx.cs" Inherits="ForGotyourPwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

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
<div class="headerTopBg">

<div class="headerTop">
	<div id="welcome">Welcome visitor you can <a href="login.html" title="Login">login</a> or <a href="register.html" title="Create An Account">create an account</a>.</div>

    <!--Currency Part Start-->  
    <script type="text/javascript">
        $(document).ready(function () {
            co_w = $('#c_options').width();
            $('#c_switcher').css('width', (co_w + 15) + 'px');
            $('#c_switcher').hover(function () {
                $('#c_options').slideDown(200);
            }, function () {
                $('#c_options').slideUp(200);
            });
        });		
    </script>  
    
    <form action="#" method="post" enctype="multipart/form-data">
      <div id="currency">
            <div id="c_switcher">
                <span class="c_selected">US Dollar</span>
                <div id="c_options" style="display: none;">
                <a onclick="javascript:void(0);">Euro</a>
                <a onclick="javascript:void(0);">Pound Sterling</a>
                <a onclick="javascript:void(0);">US Dollar</a>
                </div>
            </div>
    <input type="hidden" name="currency_code" value="" />
    <input type="hidden" name="redirect" value="#" />          
    </div>
    </form>
    <!--Currency Part End-->    


    <!--Language Part Start-->  
    <script type="text/javascript">
        $(document).ready(function () {
            l_w = $('#l_options').width();
            $('#l_switcher').css('width', (l_w + 18) + 'px');
            $('#l_switcher').hover(function () {
                $('#l_options').slideDown(200);
            }, function () {
                $('#l_options').slideUp(200);
            });
        });		
    </script>  
    
    <form action="#" method="post" enctype="multipart/form-data">
      <div id="language">
            <div id="l_switcher">
            <span class="l_selected"> <img src="images/gb.png" alt="English" /> English</span>
            <div id="l_options" style="display: none;">
            <a style="background: url('images/gb.png') 5px 50% no-repeat;" onclick="$('input[name=\'language_code\']').attr('value', 'en').submit(); $(this).parent().parent().parent().parent().submit();">English</a>
            <a style="background: url('images/fi.png') 5px 50% no-repeat;" onclick="$('input[name=\'language_code\']').attr('value', 'fi').submit(); $(this).parent().parent().parent().parent().submit();">Finnish</a>
            </div>
            </div>
    <input type="hidden" name="language_code" value="" />
    <input type="hidden" name="redirect" value="" />          
    </div>
    </form>
    <!--Language Part End-->


    <!--Cart Part Start-->
	<div id="cart">
      <div class="heading">
        <!--<h4>Shopping Cart</h4>-->
        <a><span id="cart-total">2 item(s) - $1,080.00</span></a></div>
      	<div class="content">
            <div class="mini-cart-info">
          <table>
                    <tr>
              <td class="image"><a href="#"><img src="images/products/productSeven-80x80.jpg" alt="Canon EOS 5D" title="Canon EOS 5D" /></a>
                </td>
              <td class="name"><a href="#">Canon EOS 5D</a>
                <div>
                                - <small>Select Blue</small><br />
                              </div></td>
              <td class="quantity">x&nbsp;1</td>
              <td class="total">$80.00</td>
              <td class="remove"><img src="images/remove-small.png" alt="Remove" title="Remove" onclick="javascript:void(0);" /></td>
            </tr>
                    <tr>
              <td class="image"><a href="#"><img src="images/products/ringTwo-80x80.jpg" alt="MacBook Air" title="MacBook Air" /></a>
                </td>
              <td class="name"><a href="#">MacBook Air</a>
                <div>
                              </div></td>
              <td class="quantity">x&nbsp;1</td>
              <td class="total">$1,000.00</td>
              <td class="remove"><img src="images/remove-small.png" alt="Remove" title="Remove" onclick="javascript:void(0);" /></td>
            </tr>
                          </table>
        </div>
        <div class="mini-cart-total">
          <table>
                    <tr>
              <td class="fr"><b>Sub-Total:</b></td>
              <td class="fr">$1,080.00</td>
            </tr>
                    <tr>
              <td class="fr"><b>Total:</b></td>
              <td class="fr">$1,080.00</td>
            </tr>
                  </table>
        </div>
        <div class="checkout">
        <a class="button" href="cart.html"><span>View Cart</span></a> 
        <a class="button" href="checkout.html"><span>Checkout</span></a></div>
        </div>
    </div>
	<!--Cart Part End-->
  	<div class="clear"></div>
</div>

<div class="headerBG">

<div id="headerMain">
<div id="header">
    <div id="logo">
    <a href="index-2.html"><img src="images/logo2.png" title="Anycart - Responsive Retail Template" alt="Anycart - Responsive Retail Template" /></a>
    </div>
    
 	<div class="links">
 	<a class="home" href="index-2.html">Home</a>
    <a href="wishlist.html">Wish List (3)</a>
    <a href="myaccount.html">My Account</a>
    <a href="cart.html">Shopping Cart</a>
    <a href="checkout.html">Checkout</a>
	</div>
  
  	<div id="search">
    	<div class="button-search"></div>
        <input type="text" name="filter_name" value="Search" onClick="this.value = '';" onKeyDown="this.style.color = '#333';" />
	</div>
</div>
<div class="clear"></div>
</div>


<!--Nav Part Start-->
<nav>
<div class="menu-main">
<div id="menu">
  <ul>
  	<li><a href="index-2.html" title="Home"><span class='home_icon'></span></a></li>
        <li><a href="product.html" title="Men">Men</a>
            <div>
                <ul>
                <li><a href="product.html" title="Jacket">Jacket</a></li>
                <li><a href="product.html" title="Jeans">Jeans</a></li>
                </ul>
				<span class="catImg"><img src="images/products/productTwo-200x200.jpg" alt="product two" /></span>
			</div>
		</li>
        <li><a href="product.html" title="Shoes">Shoes</a></li>
        <li><a href="product.html" title="Bags">Bags</a></li>
        <li><a href="product.html" title="Women">Women</a>
            <div>
                <ul>
                <li><a href="product.html" title="Jacket">Jacket</a></li>
                <li><a href="product.html" title="Jeans">Jeans</a></li>
                <li><a href="product.html" title="Shoes">Shoes</a></li>
                <li><a href="product.html" title="Skirts">Skirts</a></li>
                <li><a href="product.html" title="Sweats">Sweats</a></li>
                </ul>
                <span class="catImg"><img src="images/products/womenJacketThree-200x200.jpg" alt="women jacket" /></span>
     		 </div>
          </li>
        <li><a href="product.html" title="Clothing">Clothing</a></li>
        <li><a href="product.html" title="Jewelry">Jewelry</a></li>
        <li><a href="product.html" title="Kids">Kids</a></li>
        <li><a href="shortcodes.html" title="Shortcodes">Shortcodes</a></li>
      </ul>
</div>
</div>
</nav>
<!--Nav Part End-->

<!-- PHONE::Start -->
<div id="menu-phone" class="shown-phone" style="display: none;">
  <div id="menu-phone-button">Menu</div>
  <select id="menu-phone-select" onchange="location = this.value">
  		<option value="index-2.html">Home</option>
        <option value="product.html">Men</option>
        <option value="product.html">Shoes</option>
        <option value="product.html">Bags</option>
        <option value="product.html">Women</option>
        <option value="product.html">Clothing</option>
        <option value="product.html">Jewelry</option>
        <option value="product.html">Kids</option>
        <option value="shortcodes.html">Shortcodes</option>
      </select>
</div>

<script type="text/javascript">
    // Bind the Phone menu dropdown
    $('#menu-phone-button').bind('click', function () {
        $("#menu-phone-select").css({ 'opacity': '1' });
    });
</script>
<!-- PHONE::End -->


</div>


</div>
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
      	<li><a href="ForGotyourPwd.aspx" title="Forgotten Password">Forgotten Password</a></li>
        <li><a href="MyAccount.aspx" title="My Account">My Account</a></li>
        <li><a href="Wishlist.aspx" title="Wish List">Wish List</a></li>
      	<li><a href="OrderInfomation.aspx" title="Order History">Order History</a></li>
      	<li><a href="#" title="Downloads">Downloads</a></li>
      	<li><a href="returns.html" title="Returns">Returns</a></li>
      	<li><a href="transactions.html" title="Transactions">Transactions</a></li>
      	<li><a href="#" title="Newsletter">Newsletter</a></li>
	</ul>
    </div>

  </div>
</div>
  </div>
 
<div id="content">

		<div class="social">
        	<ul>
            <li>
			<a class="ico-fb" onclick="window.open('http://www.facebook.com/');" title="Follow iabazaar on Facebook"></a>
			</li>
            
            <li>                	
			<a class="ico-twit" onclick="window.open('http://twitter.com/');" title="Follow iabazaar on Twitter"></a>
            </li>
                                
            <li>                	
			<a class="ico-pint" onclick="window.open('http://pinterest.com/');" title="Follow iabazaar on Pinterest"></a>
            </li>
            </ul>
		</div>			


<div class="breadcrumb">
        <a href="index-2.html" title="Home">Home</a>
         &raquo; <a href="myaccount.html" title="Account">Account</a>
         &raquo; <a href="password.html" title="Forgotten Password">Forgotten Password</a>
      </div>
  
  <h1><span>Forgot Your Password?</span></h1>
  <form action="#" method="post" enctype="multipart/form-data">
    <p>Enter the e-mail address associated with your account. Click submit to have your password e-mailed to you.</p>
    <h2>Your E-Mail Address</h2>
    <div class="content">
      <table class="form">
        <tr>
          <td>E-Mail Address:</td>
          <td><input type="text" name="email" value="" /></td>
        </tr>
      </table>
    </div>
    <div class="buttons">
      <div class="left"><a href="login.html" class="button">Back</a></div>
      <div class="right">
        <input type="submit" value="Continue" class="button" />
      </div>
    </div>
  </form>
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

</body>
</html>
