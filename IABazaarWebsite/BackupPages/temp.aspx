<%@ Page Language="C#" AutoEventWireup="true" CodeFile="temp.aspx.cs" Inherits="temp" %>

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
<link rel="stylesheet" type="text/css" href="css/carousel.css" media="screen" />

<link rel="stylesheet" href="slider/css/style.css" type="text/css" media="all" />

<script src="slider/js/jquery-1.6.2.min.js" type="text/javascript" charset="utf-8"></script>
	<script src="slider/js/jquery.jcarousel.min.js" type="text/javascript" charset="utf-8"></script>
<script src="slider/js/jquery-func.js" type="text/javascript" charset="utf-8"></script>
        	

<script src="js/jquery/jquery-1.8.2.min.js"></script>
<script src="js/jquery/ui/jquery-ui-1.8.16.custom.min.js"></script>
<script src="js/jquery/ui/external/jquery.cookie.js"></script>
<script src="js/common.js"></script>
<script src="js/jquery.cycle.js"></script>
<script src="js/jquery.flexslider-min.js"></script>
<script src="js/jquery/jquery.cycle.js"></script>
<script src="js/jquery/jquery.jcarousel.min.js"></script>
<script src="js/html5.js"></script>
<script src="js/jquery.tooltipster.min.js"></script>
<script src="js/custom.js"></script>

<link rel="stylesheet" type="text/css" href="css/facebook.css" />

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
    <form id="form1" runat="server">
   
<div class="mainWrapper">


<!--Header Part Start-->
<header>
<div class="headerTopBg">

<div class="headerTop">
	<div id="welcome">Welcome<a href="login.html" title="Login">login/Sign up</a> or <a href="register.html" title="Create An Account">Call now</a>.</div>

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
              <td class="remove"><img src="images/remove-small.png" alt="Remove" title="Remove" onClick="javascript:void(0);" /></td>
            </tr>
                    <tr>
              <td class="image"><a href="#"><img src="images/products/ringTwo-80x80.jpg" alt="MacBook Air" title="MacBook Air" /></a>
                </td>
              <td class="name"><a href="#">MacBook Air</a>
                <div>
                              </div></td>
              <td class="quantity">x&nbsp;1</td>
              <td class="total">$1,000.00</td>
              <td class="remove"><img src="images/remove-small.png" alt="Remove" title="Remove" onClick="javascript:void(0);" /></td>
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
    <a href="index-2.html"><!--<img src="images/logo2.png" title="Anycart - Responsive Retail Template" alt="Anycart - Responsive Retail Template" />--></a>
    </div>
    
    <!-- home menu start -->
 	
  <!-- home mune end -->
  	<br />
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
        <li><a href="product.html" title="Men">Wedding</a>
            <div>
                <ul>
                <li><span style="    background: none repeat scroll 0 center rgba(0, 0, 0, 0);    border-bottom: 0 solid #CCCCCC;    color: #999999;    font-size: 12px;    font-weight: bold;    margin: 0;   padding-left:10px;"><u>Sarees</u></span></li>
                
                <li><span style="    background: none repeat scroll 0 center rgba(0, 0, 0, 0);    border-bottom: 0 solid #CCCCCC;    color: #999999;    font-size: 12px;    font-weight: bold;    margin: 0;   padding-left:10px;">Bridal</span></li>
                
                <li><span style="    background: none repeat scroll 0 center rgba(0, 0, 0, 0);    border-bottom: 0 solid #CCCCCC;    color: #999999;    font-size: 12px;    font-weight: bold;    margin: 0;   padding-left:10px;">Sangeet</span></li>
                <li><a href="product.html" title="Jeans">Sangeet</a></li>
                <li><a href="product.html" title="Jeans">Mehendi</a></li>
                <li><a href="product.html" title="Jeans">Engagement</a></li>
                <li><a href="product.html" title="Jeans">Wedding</a></li>
                <li><a href="product.html" title="Jeans">Kids Wear</a></li>
                <li><a href="product.html" title="Jeans">Jeans</a></li>
                </ul>
                <ul>
                <li><a href="product.html" title="Jacket">Jacket</a></li>
                <li><a href="product.html" title="Jeans">Jeans</a></li>
                <li><a href="product.html" title="Jeans">Jeans</a></li>
                <li><a href="product.html" title="Jeans">Jeans</a></li>
                <li><a href="product.html" title="Jeans">Jeans</a></li>
                <li><a href="product.html" title="Jeans">Jeans</a></li>
                <li><a href="product.html" title="Jeans">Jeans</a></li>
                <li><a href="product.html" title="Jeans">Jeans</a></li>
                </ul>
				<span class="catImg"><img src="images/festive-menu-Bridal.png" alt="product two" /></span>
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
                <span class="catImg"><img src="images/products/womenJacketThree-200x200.jpg" alt="women jacket three" /></span>
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
  <select id="menu-phone-select" onChange="location = this.value">
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
			<a class="ico-fb" onClick="window.open('http://www.facebook.com/');" title="Follow iabazaar on Facebook"></a>
			</li>
            
            <li>                	
			<a class="ico-twit" onClick="window.open('http://twitter.com/');" title="Follow iabazaar on Twitter"></a>
            </li>
                                
            
            </ul>
		</div>			
        
  <!-- Start slider -->      

<div class="flexslider">
  <ul class="slides">
    <li><img src="images/slider/slider-image-111.jpg" alt="Banner One"  /></li>
	<li><img src="images/slider/slider-image-13.jpg" alt="Banner Three" /></li>
    <li><img src="images/slider/slider-image-1111.jpg" alt="Banner Two" /></li>
  </ul>
</div>

<!--End slider -->
<div class="box">
  <div class="box-heading"><span>Featured</span></div>
  <div class="box-content">
  	<ul id="carouselfeature" class="elastislide-list customcarousel">	
    	<li>
      	<div>
      	<div class="inner">
        <div class="image"><a href="#"><img src="images/products/womenRingOne-165x165.jpg" alt="Golden ring one" title="Golden ring one" /></a>
        </div>
        <div class="name"><a href="#">Golden ring one</a></div>
       	<div class="price">$199.99</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="specialPromo"></div>
        <div class="image"><a href="#"><img src="images/products/productTwo-165x165.jpg" alt="iPod Classic" title="iPod Classic" /></a>
        </div>
        <div class="name"><a href="#">iPod Classic</a></div>
       	<div class="price">$100.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>
        
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="image"><a href="#"><img src="images/products/womenSandalThree-165x165.jpg" alt="HP LP3065" title="HP LP3065" /></a>
        </div>
        <div class="name"><a href="#">HP LP3065</a></div>
       	<div class="price">$107.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>
      
        
        
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="image"><a href="#"><img src="images/products/womenBagOne-165x165.jpg" alt="Women bag one" title="Women bag one" /></a>
        </div>
        <div class="name"><a href="#">Women bag one</a></div>
       	<div class="price">$1,000.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>    
      
      
 		
        
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="specialPromo"></div>
        <div class="image"><a href="#"><img src="images/products/productSeven-165x165.jpg" alt="MacBook Pro" title="MacBook Pro" /></a>
        </div>
        <div class="name"><a href="#">MacBook Pro</a></div>
       	<div class="price">$2,000.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>
        
        
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="image"><a href="#"><img src="images/products/ringTwo-165x165.jpg" alt="MacBook Air" title="MacBook Air" /></a>
        </div>
        <div class="name"><a href="#">MacBook Air</a></div>
       	<div class="price">$1,000.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>
        
        
        
        
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="image"><a href="#"><img src="images/products/productSeven-165x165.jpg" alt="Men jacket one" title="Men jacket one" /></a>
        </div>
        <div class="name"><a href="#">Men jacket one</a></div>
       	<div class="price">$500.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>           
      	
        
        
        
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="specialPromo"></div>
        <div class="image"><a href="#"><img src="images/products/womenSandalOne-165x165.jpg" alt="Women sandal one" title="Women sandal one" /></a>
        </div>
        <div class="name"><a href="#">Women sandal one</a></div>
       	<div class="price">$100.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>
        
        
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="image"><a href="#"><img src="images/products/productTwo-165x165.jpg" alt="Men Jacket Two" title="Men Jacket Two" /></a>
        </div>
        <div class="name"><a href="#">Men Jacket Two</a></div>
       	<div class="price">$100.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>
        
        
        
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="specialPromo"></div>
        <div class="image"><a href="#"><img src="images/products/womenJacketTwo-165x165.jpg" alt="Women jacket one" title="Women jacket one" /></a>
        </div>
        <div class="name"><a href="#">Women jacket one</a></div>
       	<div class="price">$101.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>
      
      
      </ul>
    
  </div>
</div>





<script type="text/javascript" src="js/jquery.elastislide.js"></script>
<script type="text/javascript">
    $('#carouselfeature').elastislide();
</script>
<div id="banner0" class="banner">
	<div><img src="images/slider/middlebanner-962x125.jpg" alt="HP Banner" title="HP Banner" /></div>
</div>
<script type="text/javascript"><!--
    $(document).ready(function () {
        $('#banner0 div:first-child').css('display', 'block');
    });

    var banner = function () {
        $('#banner0').cycle({
            before: function (current, next) {
                $(next).parent().height($(next).outerHeight());
            }
        });
    }

    setTimeout(banner, 2000);
//--></script>

<div class="clear"></div>

<div class="products-slider">
							<div class="slider-holder">
								<ul>
								    <li>
								    	<a class="product" title="Product 9">
										<img src="css/images/product-101.jpg" alt="Product Image 10" width="204" height="165" />
											<span class="order model">Model Name</span>
										<span class="order">catalog number: <span class="number">347</span></span>
											<span class="order"><span class="buy-text">Buy Now</span><span class="price"><span class="dollar">$</span>14<span class="sub-text">.99</span></span></span>
										</a>
								    </li>
								    <li>
								    	<a class="product" title="Product 10">
										<img src="css/images/product-111.jpg" alt="Product Image 10" width="204" height="156" />
											<span class="order model">Model Name</span>
										<span class="order">catalog number: <span class="number">537</span></span>
											<span class="order"><span class="buy-text">Buy Now</span><span class="price"><span class="dollar">$</span>24<span class="sub-text">.99</span></span></span>
										</a>
								    </li>
								    <li>
								    	<a class="product" title="Product 11">
										<img src="css/images/product-121.jpg" alt="Product Image 11" width="204" height="160" />
											<span class="order model">Model Name</span>
											<span class="order">catalog number: <span class="number">710</span></span>
											<span class="order"><span class="buy-text">Buy Now</span><span class="price"><span class="dollar">$</span>4<span class="sub-text">.99</span></span></span>
										</a>
								    </li>
								    <li>
								    	<a class="product" title="Product 12">
										<img src="css/images/product-9.jpg" alt="Product Image 11" width="204" height="160"  />
											<span class="order model">Model Name</span>
											<span class="order">catalog number: <span class="number">32</span></span>
											<span class="order"><span class="buy-text">Buy Now</span><span class="price"><span class="dollar">$</span>7<span class="sub-text">.99</span></span></span>
										</a>
								    </li>
								     <li>
								    	<a class="product" title="Product 9">
										<img src="css/images/product-11.jpg" alt="Product Image 11" width="204" height="160"  />
											<span class="order model">Model Name</span>
										<span class="order">catalog number: <span class="number">347</span></span>
											<span class="order"><span class="buy-text">Buy Now</span><span class="price"><span class="dollar">$</span>14<span class="sub-text">.99</span></span></span>
										</a>
								    </li>
								    <li>
								    	<a class="product" title="Product 10">
										<img src="css/images/product-10.jpg" alt="Product Image 11" width="204" height="160"  />
											<span class="order model">Model Name</span>
										<span class="order">catalog number: <span class="number">537</span></span>
											<span class="order"><span class="buy-text">Buy Now</span><span class="price"><span class="dollar">$</span>24<span class="sub-text">.99</span></span></span>
										</a>
								    </li>
								    <li>
								    	<a class="product" title="Product 11">
										<img src="css/images/product-11.jpg" alt="Product Image 11" width="204" height="160"  />
											<span class="order model">Model Name</span>
											<span class="order">catalog number: <span class="number">710</span></span>
											<span class="order"><span class="buy-text">Buy Now</span><span class="price"><span class="dollar">$</span>4<span class="sub-text">.99</span></span></span>
										</a>
								    </li>
								    <li>
								    	<a class="product" title="Product 12">
											<img src="css/images/product-121.jpg" alt="Product Image 12" width="204" height="160" />
											<span class="order model">Model Name</span>
											<span class="order">catalog number: <span class="number">32</span></span>
											<span class="order"><span class="buy-text">Buy Now</span><span class="price"><span class="dollar">$</span>7<span class="sub-text">.99</span></span></span>
										</a>
								    </li>
								</ul>
							</div>
							<div class="nav">
								<a href="#" class="prev" title="Previous">Prev</a>
								<a href="#" class="next" title="Next">Next</a>
								<div class="cl">&nbsp;</div>
							</div>
						</div>
        <div class="clear"></div>                
                        
<div class="box">
  <div class="box-heading"><span>Latest</span></div>
  <div class="box-content">
  	<ul id="carousellatest" class="elastislide-list customcarousel">	
    	<li>
      	<div>
      	<div class="inner">
        <div class="image"><a href="#"><img src="images/products/womenRingOne-165x165.jpg" alt="Golden ring one" title="Golden ring one" /></a>
        </div>
        <div class="name"><a href="#">Golden ring one</a></div>
       	<div class="price">$199.99</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="specialPromo"></div>
        <div class="image"><a href="#"><img src="images/products/productTwo-165x165.jpg" alt="iPod Classic" title="iPod Classic" /></a>
        </div>
        <div class="name"><a href="#">iPod Classic</a></div>
       	<div class="price">$100.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>
        
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="image"><a href="#"><img src="images/products/womenSandalThree-165x165.jpg" alt="HP LP3065" title="HP LP3065" /></a>
        </div>
        <div class="name"><a href="#">HP LP3065</a></div>
       	<div class="price">$107.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>
      
        
        
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="image"><a href="#"><img src="images/products/womenBagOne-165x165.jpg" alt="Women bag one" title="Women bag one" /></a>
        </div>
        <div class="name"><a href="#">Women bag one</a></div>
       	<div class="price">$1,000.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>    
      
      
 		
        
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="specialPromo"></div>
        <div class="image"><a href="#"><img src="images/products/productSeven-165x165.jpg" alt="MacBook Pro" title="MacBook Pro" /></a>
        </div>
        <div class="name"><a href="#">MacBook Pro</a></div>
       	<div class="price">$2,000.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>
        
        
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="image"><a href="#"><img src="images/products/ringTwo-165x165.jpg" alt="MacBook Air" title="MacBook Air" /></a>
        </div>
        <div class="name"><a href="#">MacBook Air</a></div>
       	<div class="price">$1,000.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>
        
        
        
        
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="image"><a href="#"><img src="images/products/productSeven-165x165.jpg" alt="Men jacket one" title="Men jacket one" /></a>
        </div>
        <div class="name"><a href="#">Men jacket one</a></div>
       	<div class="price">$500.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>           
      	
        
        
        
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="specialPromo"></div>
        <div class="image"><a href="#"><img src="images/products/womenSandalOne-165x165.jpg" alt="Women sandal one" title="Women sandal one" /></a>
        </div>
        <div class="name"><a href="#">Women sandal one</a></div>
       	<div class="price">$100.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>
        
        
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="image"><a href="#"><img src="images/products/productTwo-165x165.jpg" alt="Men Jacket Two" title="Men Jacket Two" /></a>
        </div>
        <div class="name"><a href="#">Men Jacket Two</a></div>
       	<div class="price">$100.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>
        
        
        
        
        
        <li>
      	<div>
      	<div class="inner">
        <div class="specialPromo"></div>
        <div class="image"><a href="#"><img src="images/products/womenJacketTwo-165x165.jpg" alt="Women jacket one" title="Women jacket one" /></a>
        </div>
        <div class="name"><a href="#">Women jacket one</a></div>
       	<div class="price">$101.00</div>
        </div>
        
        <div class="abs">
        <div class="cart">
        <a class="button1" title="Add to Cart" href="#"><span>Add to Cart</span></a>
        <a class="btn-detail ml10" title="Detail" href="#"><span>Detail</span></a></div>        
        </div>
		</div>
      	</li>
      
      
      </ul>
    
  </div>
</div>


<script type="text/javascript" src="js/jquery.elastislide.js"></script>
<script type="text/javascript">
    $('#carousellatest').elastislide();
</script>

<!--<div id="carousel0">
  <ul class="jcarousel-skin-opencart">
        <li><a href="#"><img src="images/manufacture/komoder-100x100.jpg" alt="Komoder" title="Komoder" /></a></li>
        <li><a href="#"><img src="images/manufacture/checkout-100x100.jpg" alt="Checkout" title="Checkout" /></a></li>
        <li><a href="#"><img src="images/manufacture/booko-100x100.jpg" alt="Booko" title="Booko" /></a></li>
        <li><a href="#"><img src="images/manufacture/mistercutts-100x100.jpg" alt="Mister Cutts" title="Mister Cutts" /></a></li>
        <li><a href="#"><img src="images/manufacture/become-100x100.jpg" alt="Become" title="Become" /></a></li>
        <li><a href="#"><img src="images/manufacture/komoder-100x100.jpg" alt="Komoder" title="Komoder" /></a></li>
      </ul>
</div>-->

<!--<script type="text/javascript">
$('#carousel0 ul').jcarousel({
	vertical: false,
	visible: 5,
	scroll: 3});
</script>//-->

</div>
<div class="clear"></div>


</div>
</div>







<!--Footer Part Start-->
<footer>

<div class="backTop" id="backTop"><a title="Back to Top" href="javascript:void(0)" class="backtotop">Top</a></div>




<div class="clear"></div>
<!--start footerTop -->


<!-- end footertop -->





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
