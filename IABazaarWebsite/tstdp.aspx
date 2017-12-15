<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tstdp.aspx.cs" Inherits="tstdp" %>

<!DOCTYPE HTML>
<html>
<head>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="HandheldFriendly" content="True" />
<meta name="MobileOptimized" content="320" />
<meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1" />
<meta name="description" content="Anycart Responsive Retail Template" />

<title>Iabazaar</title>
<link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico" />

<link rel="stylesheet" type="text/css" href="css/stylesheet.css" media="screen" />
<!--<link href='http://fonts.googleapis.com/css?family=Carme' rel='stylesheet' type='text/css' />-->
<link rel="stylesheet" type="text/css" href="css/carousel.css" media="screen" />

<script src="js/jquery/jquery-1.8.2.min.js"></script>
<script src="js/jquery/ui/jquery-ui-1.8.16.custom.min.js"></script>
<script src="js/jquery/ui/external/jquery.cookie.js"></script>
<script src="js/jquery/tabs.js"></script>
<script src="js/common.js"></script>
<script src="js/jquery/jquery.cycle.js"></script>
<script src="js/jquery/jquery.jcarousel.min.js"></script>
<script src="js/html5.js"></script>
<script src="js/jquery.tooltipster.min.js"></script>
<script src="js/custom.js"></script>

<link rel="stylesheet" type="text/css" href="css/facebook.css" />
<link rel="stylesheet" type="text/css" href="js/jackbox/css/jackbox.min.css" />

<!--[if lt IE 9]><link href="js/jackbox/css/jackbox-ie8.css" rel="stylesheet" type="text/css" /><![endif]-->
<!--[if gt IE 8]><link href="js/jackbox/css/jackbox-ie9.css" rel="stylesheet" type="text/css" /><![endif]-->

<link rel="stylesheet" type="text/css" href="css/elastislide.css" />
<script src="js/modernizr.custom.17475.js"></script>

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
  	<li><a href="Default.aspx" title="Home"><span class='home_icon'></span></a></li>
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
         &raquo; <a href="product.html" title="Men">Men</a>
         &raquo; <a href="#" title="Canon EOS 5D">Canon EOS 5D</a>
	</div>
  
  
  
  
	<div class="product-info">
    
    
    <div class="span6">
        <ul class="thumbnails row">
			
            <li class="span4">
            <a href="images/products/productSeven-500x500.jpg" title="Canon EOS 5D" class="cloud-zoom jackbox thumbnail" data-group="images" id='zoom1' rel="adjustX: 10, adjustY:-4, tint:'#000000',tintOpacity:0.2, zoomWidth:365, zoomHight: 275, position:'inside', showTitle:false">
            <img src="images/products/productSeven-500x500.jpg" title="Canon EOS 5D" alt="Canon EOS 5D" id="image" />
            </a>
            </li>
                        
            
            <li class="zfr"><a href="images/products/productSeven-500x500.jpg" title="Canon EOS 5D" class="linkText jackbox tooltip" data-group="images">zoom</a></li>
            
            
            
            
            
            <li class="imgadli">
            <div class="image-additional">
                <div id="carousel94">
                  <ul class="jcarousel-skin-opencart">
                                            <li>
                        <a href="images/products/productTwo-500x500.jpg" title="Canon EOS 5D" class="cloud-zoom-gallery jackbox thumbnail" data-group="images" rel="useZoom: 'zoom1', smallImage: 'images/products/productTwo-500x500.jpg'">
                        <img src="images/products/productTwo-57x57.jpg" width="51" height="51" title="Canon EOS 5D" alt="Canon EOS 5D" />
                        </a>
                        </li>
						
                        <li>
                        <a href="images/products/productSeven-500x500.jpg" title="Canon EOS 5D" class="cloud-zoom-gallery jackbox thumbnail" data-group="images" rel="useZoom: 'zoom1', smallImage: 'images/products/productSeven-500x500.jpg'">
                        <img src="images/products/productSeven-57x57.jpg" width="51" height="51" title="Canon EOS 5D" alt="Canon EOS 5D" />
                        </a>
                        </li>
						
                        
                        <li>
                        <a href="images/products/womenJacketThree-500x500.jpg" title="Canon EOS 5D" class="cloud-zoom-gallery jackbox thumbnail" data-group="images" rel="useZoom: 'zoom1', smallImage: 'images/products/womenJacketThree-500x500.jpg'">
                        <img src="images/products/womenJacketThree-57x57.jpg" width="51" height="51" title="Canon EOS 5D" alt="Canon EOS 5D" />
                        </a>
                        </li>
                                            
                                            
						<li>
                        <a href="images/products/womenJacketTwo-500x500.jpg" title="Canon EOS 5D" class="cloud-zoom-gallery jackbox thumbnail" data-group="images" rel="useZoom: 'zoom1', smallImage: 'images/products/womenJacketTwo-500x500.jpg'">
                        <img src="images/products/womenJacketTwo-57x57.jpg" width="51" height="51" title="Canon EOS 5D" alt="Canon EOS 5D" />
                        </a>
                        </li>
                          
                          
                          
						<li>
                        <a href="images/products/productEight-500x500.jpg" title="Canon EOS 5D" class="cloud-zoom-gallery jackbox thumbnail" data-group="images" rel="useZoom: 'zoom1', smallImage: 'images/products/productEight-500x500.jpg'">
                        <img src="images/products/productEight-57x57.jpg" width="51" height="51" title="Canon EOS 5D" alt="Canon EOS 5D" />
                        </a>
                        </li>
				</ul>
                </div>
            </div>
            </li> 
            
            <script type="text/javascript"><!--
                $('#carousel94 ul').jcarousel({
                    vertical: false,
                    visible: 3,
                    /*wrap:'circular',*/
                    scroll: 1
                });
            //--></script>
	</ul>
</div>
        
        



    
<div class="right">

<h1><span>Canon EOS 5D</span></h1>


  <div id="tabs" class="htabs">
  <a class="info" href="#tab-information">Information</a>
  <a href="#tab-description">Description</a>
  <a href="#tab-review">Reviews (1)</a>
  </div>
  
  <div id="tab-information" class="tab-content">
  <!--Price Start-->
  <div class="price">
  
  <div class="prDetailMain">
  <div class="prDetailMainLeft">
  <span class="textPrice">Price:</span>
  <span class="price-old">$100.00</span> <span class="cyan_price price-new"><span>$80.00</span></span>
  <br />
  <span class="price-tax">Ex Tax: $80.00</span><br />
  </div>
            
  <div class="prDetailMainRight"><div>
  
  <div class="qty">
  <span class="qtytxt">Qty :</strong>
  <a class="qtyBtn mines" href="javascript:void(0);">-</a>
  <input id="qty" type="text" class="w30" name="quantity" size="2" value="1" />      
  <a class="qtyBtn plus" href="javascript:void(0);">+</a>          
  <input type="hidden" name="product_id" size="2" value="30" />
  </div>
  <a id="button-cart" class="button" title="Add to Cart">Add to Cart</a>
  </div>
  </div>
  </div>
  </div>
  <!--Price End-->
    
  
  
	<div class="description">
    	<div class="prDetailMain">
        <div class="prDetailMainLeft">
    	<span>Brand:</span> <a href="brands.html">Canon</a><br />
		<span>Product Code:</span> Product 3<br />
        <span>Reward Points:</span> 0<br />
        <span>Availability:</span> In Stock			</div>  
            
            
        <div class="prDetailMainRight">
		<div class="cart">
        <div class="wishlistWrap">
        <a class="wish-list tooltip" title='Add to Wish List' onclick="addToWishList('30');"><span>Add to Wish List</span></a>
        </div>
                    
        <div class="compareWrap">  
        <a class="compare-icon tooltip" title="Add to Compare" onclick="addToCompare('30');"><span>Add to Compare</span>
        </a>
        </div>
                    
        </div>
              
              	
		
        
        <div class="review">
        	<div class="reviewWrap">
            <div class="writeWrap"><a class="tooltip" title="Write A Review" onclick="#">Write a review</a></div>
			<img src="images/stars-3.png" alt="1 reviews" />
            <a onclick="">1 reviews</a>
		</div>
		</div>
        </div>                     
        </div>
         
	</div>
        
     
     
     
     
     <div class="options">
     <h2 class="optheading">Available Options</h2>
     <br>
     <div class="clear"></div>
     <div id="option-226" class="option">
     <span class="required">*</span>
     <b>Select:</b><br />
     <select name="option[226]">
     <option value=""> --- Please Select --- </option>
     <option value="16">Blue</option>
     <option value="15">Red</option>
     <option value="14">Black</option>
	 </select>
     </div>
     <br />
	</div>
      
            
    
    
    
	
  


<div id="tab-description" class="tab-content">
<p>Canon EOS 5D press material for the EOS 5D states that it 'defines (a) new D-SLR category', while we're not typically too concerned with marketing talk this particular statement is clearly pretty accurate. The EOS 5D is unlike any previous digital SLR in that it combines a full-frame (35 mm sized) high resolution sensor (12.8 megapixels) with a relatively compact body (slightly larger than the EOS 20D, although in your hand it feels noticeably 'chunkier'). The EOS 5D is aimed to slot in between the EOS 20D and the EOS-1D professional digital SLR's, an important difference when compared to the latter is that the EOS 5D doesn't have any environmental seals. While Canon don't specifically refer to the EOS 5D as a 'professional' digital SLR it will have obvious appeal to professionals who want a high quality digital SLR in a body lighter than the EOS-1D. It will also no doubt appeal to current EOS 20D owners (although lets hope they've not bought too many EF-S lenses...)</p>
<p>&nbsp;</p>
<h3>Features:</h3>
<p>Unrivaled display performance</p>
<ul>
	<li>30-inch (viewable) active-matrix liquid crystal display provides breathtaking image quality and vivid, richly saturated color.</li>
	<li>Support for 2560-by-1600 pixel resolution for display of high definition still and video imagery.</li>
	<li>Wide-format design for simultaneous display of two full pages of text and graphics.</li>
	<li>Industry standard DVI connector for direct attachment to Mac- and Windows-based desktops and notebooks</li>
	<li>Incredibly wide (170 degree) horizontal and vertical viewing angle for maximum visibility and color performance.</li>
	<li>Lightning-fast pixel response for full-motion digital video playback.</li>
	<li>Support for 16.7 million saturated colors, for use in all graphics-intensive applications.</li>
</ul>
<p>Simple setup and operation</p>
<ul>
	<li>Single cable with elegant breakout for connection to DVI, USB and FireWire ports</li>
	<li>Built-in two-port USB 2.0 hub for easy connection of desktop peripheral devices.</li>
	<li>Two FireWire 400 ports to support iSight and other desktop peripherals</li>
</ul>
<p>Sleek, elegant design</p>
<ul>
	<li>Huge virtual workspace, very small footprint.</li>
	<li>Narrow Bezel design to minimize visual impact of using dual displays</li>
	<li>Unique hinge design for effortless adjustment</li>
	<li>Support for VESA mounting solutions (Apple Cinema Display VESA Mount Adapter sold separately)</li>
</ul>
<h3>Technical specifications</h3>
<p><b>Screen size (diagonal viewable image size)</b></p>
<ul>
	<li>Apple Cinema HD Display: 30 inches (29.7-inch viewable)</li>
</ul>
<p>
	<b>Screen type</b></p>
<ul>
	<li>Thin film transistor (TFT) active-matrix liquid crystal display (AMLCD)</li>
</ul>
</div>

	
    
    
<div id="tab-review" class="tab-content">
    <div id="review" class="rev"></div>
    <h2 id="review-title">Write a review</h2>
    <b>Your Name:</b><br />
    <input type="text" name="name" value="" />
    <br />
    <br />
    <b>Your Review:</b>
    <textarea name="text" cols="40" rows="8" style="width: 96%;"></textarea>
    <span style="font-size: 11px;"><span style="color: #FF0000;">Note:</span> HTML is not translated!</span><br />
    <br />
    <b>Rating:</b> <span>Bad</span>&nbsp;
    <input type="radio" name="rating" value="1" />
    &nbsp;
    <input type="radio" name="rating" value="2" />
    &nbsp;
    <input type="radio" name="rating" value="3" />
    &nbsp;
    <input type="radio" name="rating" value="4" />
    &nbsp;
    <input type="radio" name="rating" value="5" />
    &nbsp; <span>Good</span><br />
    <br />
    <b>Enter the code in the box below:</b><br />
    <input type="text" name="captcha" value="" />
    <br />
    <img src="images/index.php.html" alt="" id="captcha" class="mt10" /><br />
    <br />
    <div class="buttons">
      <div class="right"><a id="button-review" class="button">Continue</a></div>
    </div>
  </div>
   
</div>
</div>

</div>

<script type="text/javascript"><!--
    $('.colorbox').colorbox({
        overlayClose: true,
        opacity: 0.5
    });
//--></script> 
<script type="text/javascript"><!--
    $('#button-cart').bind('click', function () {
        $.ajax({
            url: 'index.php?route=checkout/cart/add',
            type: 'post',
            data: $('.product-info input[type=\'text\'], .product-info input[type=\'hidden\'], .product-info input[type=\'radio\']:checked, .product-info input[type=\'checkbox\']:checked, .product-info select, .product-info textarea'),
            dataType: 'json',
            success: function (json) {
                $('.success, .warning, .attention, information, .error').remove();

                if (json['error']) {
                    if (json['error']['option']) {
                        for (i in json['error']['option']) {
                            $('#option-' + i).after('<span class="error">' + json['error']['option'][i] + '</span>');
                        }
                    }
                }

                if (json['success']) {
                    $('#notification').html('<div class="success" style="display: none;">' + json['success'] + '<img src="catalog/view/theme/default/image/close.png" alt="" class="close" /></div>');

                    $('.success').fadeIn('slow');

                    $('#cart-total').html(json['total']);

                    $('html, body').animate({ scrollTop: 0 }, 'slow');
                }
            }
        });
    });
//--></script>
<script type="text/javascript" src="js/jquery/ajaxupload.js"></script>
<script type="text/javascript"><!--
    $('#review .pagination a').live('click', function () {
        $('#review').slideUp('slow');

        $('#review').load(this.href);

        $('#review').slideDown('slow');

        return false;
    });

    $('#review').load('indexcd0a.html?route=product/product/review&amp;product_id=30');

    $('#button-review').bind('click', function () {
        $.ajax({
            url: 'index.php?route=product/product/write&product_id=30',
            type: 'post',
            dataType: 'json',
            data: 'name=' + encodeURIComponent($('input[name=\'name\']').val()) + '&text=' + encodeURIComponent($('textarea[name=\'text\']').val()) + '&rating=' + encodeURIComponent($('input[name=\'rating\']:checked').val() ? $('input[name=\'rating\']:checked').val() : '') + '&captcha=' + encodeURIComponent($('input[name=\'captcha\']').val()),
            beforeSend: function () {
                $('.success, .warning').remove();
                $('#button-review').attr('disabled', true);
                $('#review-title').after('<div class="attention"><img src="catalog/view/theme/default/image/loading.gif" alt="" /> Please Wait!</div>');
            },
            complete: function () {
                $('#button-review').attr('disabled', false);
                $('.attention').remove();
            },
            success: function (data) {
                if (data.error) {
                    $('#review-title').after('<div class="warning">' + data.error + '</div>');
                }

                if (data.success) {
                    $('#review-title').after('<div class="success">' + data.success + '</div>');

                    $('input[name=\'name\']').val('');
                    $('textarea[name=\'text\']').val('');
                    $('input[name=\'rating\']:checked').attr('checked', '');
                    $('input[name=\'captcha\']').val('');
                }
            }
        });
    });
//--></script> 
<script type="text/javascript"><!--
    $('#tabs a').tabs();
//--></script> 
<script type="text/javascript" src="js/jquery/ui/jquery-ui-timepicker-addon.js"></script> 
<script type="text/javascript"><!--
    if ($.browser.msie && $.browser.version == 6) {
        $('.date, .datetime, .time').bgIframe();
    }

    $('.date').datepicker({ dateFormat: 'yy-mm-dd' });
    $('.datetime').datetimepicker({
        dateFormat: 'yy-mm-dd',
        timeFormat: 'h:m'
    });
    $('.time').timepicker({ timeFormat: 'h:m' });


    //zoom on link click
    $(".cloud-zoom-gallery").click(function () {
        $('#zoom_image').attr('href', $(this).attr('href'));
    });
//--></script> 

<style>
ul.thumbnails {padding:0px; margin:0px; list-style:none; *zoom:1;}
.thumbnails > li {float: left; margin: 0 20px 25px 0px;}
.thumbnail { display:block; padding:0; line-height:1; border:1px solid #d7d7d7; border-radius:3px; -moz-border-radius:3px; -webkit-border-radius:3px; -o-border-radius:3px; -ms-border-radius:3px; }
a.thumbnail:hover { border-color:#a6a6a6; }
.thumbnail > img { display:block; max-width:100%; margin-left:auto; margin-right:auto; }
.thumbnail .caption { padding:9px; }
.smlThumb { width:auto; }
.span2 { width:80px; float:left; margin:0 24px 10px 0; }
.span4 { width:300px; }
.span6 { width:320px; float:left; }
.row {margin-left:0px; *zoom: 1; }
.zfr { float:right!important; margin:0 0 25px 0!important; }
.imgadli { margin:-30px 0 0px 0!important; }
.row:before,
.row:after { display:table; content:""; }
.row:after { clear:both; }

.cloud-zoom-big {border:none; overflow:hidden; margin:5px 0 0 -9px;}

.right { float:right; width:635px; }

#wrap { z-index:0!important; }
.mousetrap { cursor:move!important; }

#wrap > a:hover, .span2 a:hover { border:solid 1px #a6a6a6; }

h1 { display:none; visibility:hidden; }




@media screen and (min-width:0px) and (max-width:760px) {

.thumbnails > li.span4 { float:none; margin:0 auto; text-align:center; }
ul.thumbnails {padding:0px; margin:0px auto; list-style:none; *zoom:1;}
.thumbnails > li {float:none; margin:0 0 25px 0;}

.right { float:none; width:auto; }
.smlThumb { text-align:center; }
.span2 { width:80px; float:none; margin:5px 24px 10px 0; display:inline-block; }

}


</style>


<script type="text/javascript" src="js/cloud-zoom.1.0.2.min.js"></script>
<script type="text/javascript" src="js/jackbox/js/jackbox-packed.min.js"></script>
<script type="text/javascript" src="js/jackbox/js/jackbox.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        jQuery(".jackbox[data-group]").jackBox("init");
    });
</script>

<div class="clear"></div>


</div>
</div>







<!--Footer Part Start-->
<footer>

<div class="backTop" id="backTop"><a title="Back to Top" href="javascript:void(0)" class="backtotop">Top</a></div>




<div class="clear"></div>
<div id="footerTop">
<div class="line-bottom">
<div id="customHome" class="container_12"><div id="about_us_footer"
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

 
</div>
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
