<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Salwar_kameez_Default" %>

<%@ Register src="../controls/header.ascx" tagname="header" tagprefix="uc1" %>

<%@ Register src="../controls/footer.ascx" tagname="footer" tagprefix="uc2" %>

<%@ Register src="../controls/socials.ascx" tagname="socials" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="HandheldFriendly" content="True" />
<meta name="MobileOptimized" content="320" />
<meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1" />
<meta name="description" content="Anycart Responsive Retail Template" />

<title>Iabazaar</title>
<link rel="shortcut icon" type="image/x-icon" href="../images/favicon.ico" />

<link rel="stylesheet" type="text/css" href="../css/stylesheet.css" media="screen" />
<!--<link href='http://fonts.googleapis.com/css?family=Carme' rel='stylesheet' type='text/css' />-->

<script src="js/jquery/jquery-1.8.2.min.js"></script>
<script src="js/jquery/ui/jquery-ui-1.8.16.custom.min.js"></script>
<script src="js/jquery/ui/external/jquery.cookie.js"></script>
<script src="js/common.js"></script>
<script src="js/html5.js"></script>
<script src="js/jquery.tooltipster.min.js"></script>
<script src="js/custom.js"></script>

<link rel="stylesheet" type="text/css" href="../css/facebook.css" />

<!--[if IE 7]>
<link rel="stylesheet" type="text/css" href="../css/ie7.css" />
<![endif]-->

<!--[if lt IE 7]>
<link rel="stylesheet" type="text/css" href="../css/ie6.css" />
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
        <li><a href="mainbg.html"><img alt="" src="../images/pattern/mainbg.png"></a></li>
        <li><a href="mainbg2.html"><img alt="" src="../images/pattern/mainbg2.png"></a></li>
        <li><a href="mainbg3.html"><img alt="" src="../images/pattern/mainbg3.png"></a></li>
        <li><a href="mainbg4.html"><img alt="" src="../images/pattern/mainbg4.png"></a></li>
        <li><a href="mainbg5.html"><img alt="" src="../images/pattern/mainbg5.png"></a></li>
        <li><a href="mainbg6.html"><img alt="" src="../images/pattern/mainbg6.png"></a></li>
        <li><a href="mainbg7.html"><img alt="" src="../images/pattern/mainbg7.png"></a></li>
        <li><a href="mainbg8.html"><img alt="" src="../images/pattern/mainbg8.png"></a></li>
        <li><a href="mainbg9.html"><img alt="" src="../images/pattern/mainbg9.png"></a></li>
        <li><a href="mainbg10.html"><img alt="" src="../images/pattern/mainbg10.png"></a></li>
        <li><a href="mainbg11.html"><img alt="" src="../images/pattern/mainbg11.png"></a></li>
        <li><a href="mainbg12.html"><img alt="" src="../images/pattern/mainbg12.png"></a></li>
        <li><a href="mainbg13.html"><img alt="" src="../images/pattern/mainbg13.png"></a></li>
        <li><a href="mainbg14.html"><img alt="" src="../images/pattern/mainbg14.png"></a></li>
        <li><a href="mainbg15.html"><img alt="" src="../images/pattern/mainbg15.png"></a></li>
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
    <script type="text/javascript" src="js/jquery.dcjqaccordion.js"></script> 

<div class="box">

	<div class="box-heading">Categories</div>

	<div class="box-content box-category">
    	<ul id="cat_accordion">
        <li class="cid20"><a class="havechild active" href="product.html">Men</a> <span class="expand"></span>
        	<ul>
            	<li class="cid27"><a class="nochild " href="product.html">Jacket</a></li>
                <li class="cid26"><a class="nochild " href="product.html">Jeans</a></li>
			</ul>
		</li>
        <li class="cid18"><a class="nochild " href="product.html">Shoes</a></li>
        <li class="cid57"><a class="nochild " href="product.html">Bags</a></li>
        <li class="cid25"><a class="havechild " href="product.html">Women</a> <span class="expand"></span>
        	<ul>
            	<li class="cid29"><a class="nochild " href="product.html">Jacket</a></li>
                <li class="cid28"><a class="nochild " href="product.html">Jeans</a></li>
                <li class="cid30"><a class="nochild " href="product.html">Shoes</a></li>
                <li class="cid31"><a class="nochild " href="product.html">Skirts</a></li>
                <li class="cid32"><a class="nochild " href="product.html">Sweats</a></li>
			</ul>
		</li>
        <li class="cid17"><a class="nochild " href="product.html">Clothing</a></li>
        <li class="cid24"><a class="nochild " href="product.html">Jewelry</a></li>
        <li class="cid33"><a class="nochild " href="product.html">Kids</a></li>
        </ul>
	</div>
	
</div>

<script type="text/javascript">
    $(document).ready(function () {
        $('#cat_accordion').dcAccordion({
            classExpand: 'cid20',
            menuClose: false,
            autoClose: true,
            saveState: false,
            disableLink: false,
            autoExpand: true
        });
    });
</script>
    <div class="box">
  <div class="box-heading"><span>Specials</span></div>
  <div class="box-content">
    <div class="box-product1">
            
            
            
            
            
            
            
          </div>
  </div>
</div>
  </div>
 
<div id="content">

		<uc3:socials ID="socials1" runat="server" />			

<div class="breadcrumb">
        <a href="Default.aspx" title="Home">Home</a>
         &raquo; <asp:Label ID="lblbcatname" runat="server"
            Text=""></asp:Label> </a>
    </div>
  
  <h1><span>
      <asp:Label ID="lblcatname" runat="server" Text=""></asp:Label></span></h1>
    <div class="category-info">
        <div class="image"><img id="catimg" src="" alt="" runat="server"  /></div>
            <p>
                <asp:Label ID="lblcatdescription" runat="server" Text=""></asp:Label></p>
      </div>
      <h2>Salwar Kameez</h2>
  <div class="category-list">
        <ul>
            <li><a href="product.html">Jacket (1)</a></li>
            <li><a href="product.html">Jeans (0)</a></li>
          </ul>
      </div>
      
  
  <div class="product-filter">
    <div class="display">
    	<b></b> 
        <span>List</span>
        <a class="gridSelect" onclick="display('grid');">Grid</a>
	</div>
    
    
    
    
    <div class="product-compare"><a href="productcompare.html" id="compare-total">Product Compare (0)</a></div>
    
    
    <%--<div class="limit">Show:      <select onchange="location = this.value;">
                        <option value="15" selected="selected">15</option>
                                <option value="25">25</option>
                                <option value="50">50</option>
                                <option value="75">75</option>
                                <option value="100">100</option>
                      </select>
    </div>--%>
    <%--<div class="sort">Sort By:      <select onchange="location = this.value;">
                        <option value="Default" selected="selected">Default</option>
                                <option value="Name (A - Z)">Name (A - Z)</option>
                                <option value="Name (Z - A)">Name (Z - A)</option>
                                <option value="Price (Low &gt; High)">Price (Low &gt; High)</option>
                                <option value="Price (High &gt; Low">Price (High &gt; Low)</option>
                                <option value="Rating (Highest)">Rating (Highest)</option>
                                <option value="Rating (Lowest)">Rating (Lowest)</option>
                                <option value="Model (A - Z)">Model (A - Z)</option>
                                <option value="Model (Z - A)">Model (Z - A)</option>
                      </select>
    </div>--%>
  </div>
  
  
  
  <div class="product-list">
        
    
    
    
	</div>
  
  
  

</div>
<script type="text/javascript"><!--
    function display(view) {
        if (view == 'list') {
            $('.product-grid').attr('class', 'product-list');

            $('.product-list > div').each(function (index, element) {

                html = '<div class="inner">';
                html += '<div class="right">';
                html += '  <div class="price">' + $(element).find('.price').html() + '</div>';
                html += '  <div class="cart">' + $(element).find('.cart').html() + '</div>';
                html += '  <div class="wishlist">' + $(element).find('.wishlist').html() + '</div>';
                html += '  <div class="compare">' + $(element).find('.compare').html() + '</div>';
                html += '</div>';

                html += '<div class="left">';

                var image = $(element).find('.image').html();

                if (image != null) {
                    html += '<div class="image">' + image + '</div>';
                }

                /*var price = $(element).find('.price').html();
			
                if (price != null) {
                html += '<div class="price">' + price  + '</div>';
                }*/

                html += '  <div class="name">' + $(element).find('.name').html() + '</div>';
                html += '  <div class="description">' + $(element).find('.description').html() + '</div>';

                var rating = $(element).find('.rating').html();

                if (rating != null) {
                    html += '<div class="rating">' + rating + '</div>';
                }

                html += '</div>';
                html += '</div>';


                $(element).html(html);
            });

            $('.display').html('<b></b> <span class="list">List</span> <a class="gridSelect" onclick="display(\'grid\');" title="Grid View">Grid</a>');

            $.cookie('display', 'list');
        } else {
            $('.product-list').attr('class', 'product-grid category');

            $('.product-grid > div').each(function (index, element) {
                html = '<div class="inner">';

                var image = $(element).find('.image').html();


                if (image != null) {
                    html += '<div class="image">' + image + '</div>';
                }

                html += '<div class="name">' + $(element).find('.name').html() + '</div>';
                html += '<div class="description">' + $(element).find('.description').html() + '</div>';

                var price = $(element).find('.price').html();

                if (price != null) {
                    html += '<div class="price">' + price + '</div>';
                }

                var rating = $(element).find('.rating').html();

                if (rating != null) {
                    html += '<div class="rating">' + rating + '</div>';
                }

                html += '<div class="cart">' + $(element).find('.cart').html() + '</div>';
                html += '<div class="wishlist">' + $(element).find('.wishlist').html() + '</div>';
                html += '<div class="compare">' + $(element).find('.compare').html() + '</div>';

                html += '</div>';

                $(element).html(html);
            });

            $('.display').html('<b></b> <a class="listSelect" onclick="display(\'list\');" title="List View">List</a> <span class="grid">Grid</span>');

            $.cookie('display', 'grid');
        }
    }

    view = $.cookie('display');

    if (view) {
        display(view);
    } else {
        display('list');
    }
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
