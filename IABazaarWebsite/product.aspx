<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="product"  EnableEventValidation="true" %>

<%@ Register src="controls/header.ascx" tagname="header" tagprefix="uc1" %>

<%@ Register src="controls/footer.ascx" tagname="footer" tagprefix="uc2" %>

<%@ Register src="controls/socials.ascx" tagname="socials" tagprefix="uc3" %>


<!DOCTYPE HTML>
<html>
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="HandheldFriendly" content="True" />
<meta name="MobileOptimized" content="320" />
<meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1" />
<meta name="description" runat="server" />


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


    <!-- Google Analytics -->
   <%-- <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-49609094-1', 'iabazaar.com');
        ga('send', 'pageview');

</script>--%>

<script>
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-50123633-1', 'iabazaar.com');
    ga('send', 'pageview');

</script>

<!-- End Google Analytics -->


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
        <li class="cid20"><a class="havechild active" href="cc-al-karam-mid-summer-collection-2013-3">Al Karam MidSummer 2014</a> <span class="expand"></span>
        	<%--<ul>
            	<li class="cid27"><a class="nochild " href="product.html">Jacket</a></li>
                <li class="cid26"><a class="nochild " href="product.html">Jeans</a></li>
			</ul>--%>
		</li>
        <li class="cid18"><a class="nochild " href="cc-al-karam-the-joy-of-spring-2014-4">Al Karam The Joy of Spring 2014</a></li>
        <li class="cid57"><a class="nochild " href="cc-ha-textile-designer-series-lawn-summer-2014-23">HA Textile Lawn Prints</a></li>
        <li class="cid25"><a class="havechild " href="cc-haute-monde-collection-2013-by-sadia-25">Haute Monde By Sadia </a>&nbsp;<span class="expand"></span><%--<ul>
            	<li class="cid29"><a class="nochild " href="product.html">Jacket</a></li>
                <li class="cid28"><a class="nochild " href="product.html">Jeans</a></li>
                <li class="cid30"><a class="nochild " href="product.html">Shoes</a></li>
                <li class="cid31"><a class="nochild " href="product.html">Skirts</a></li>
                <li class="cid32"><a class="nochild " href="product.html">Sweats</a></li>
			</ul>--%></li>
        <li class="cid17"><a class="nochild " href="cc-royal-embroidered-linen-2013-by-ittehad-40">Royal Embroidered Linen </a></li>
        <li class="cid24"><a class="nochild " href="cc-khaddar-fall-winter-collection-2013-by-shariq-26">Khadder Winter By Shariq </a></li>
        <li class="cid33"><a class="nochild " href="cc-gulahmed-spring-summer-collection-2013-22">Gul Ahmed 2013 </a></li>
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
            
          <asp:DataList ID="ViewCart" runat="server" Height="439px" Width="190px" OnItemCommand="ViewCart_ItemCommand">
                            <ItemTemplate>
                                        <div>
                                            <div class="image">
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("ProductID") %>' CommandName="Add" ImageUrl='<%# Eval("ImageFilenameOverride") %>'
                                                            AlternateText='<%# Eval("Name") %>' style="width:180px; height:250px" Width="180px" Height="250px"  />
                                            <div class="name">
                                                    <%# Eval("Name") %></div>
                                            <div class="price">
                                                <span class="price-old">$<%# String.Format("{0:f2}", Eval("promoamount"))%></span> <span class="price-new">$<%# String.Format("{0:f2}", Eval("Profitpriceindollar"))%></span><br /><%--<span class="price-tax">Ex Tax: $<%# Eval("Profitpriceindollar") %></span>--%></div>
                                                
                                                <div align="left">
                                                <asp:Button ID="btn" runat="server" CommandArgument='<%# Eval("ProductID") %>' CommandName="Add" class="button" Text="Add to Cart" />
                                                </div>
                                        </div>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:DataList>  
            
            
            
            
            
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
      <h2>Refine Search</h2>
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
        
    <asp:Repeater ID="rptViewCart" runat="server" OnItemCommand="ViewCart_ItemCommand" >
    
    <ItemTemplate>
    
    <div>
    <div class="image">
        <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("ProductID") %>' CommandName="Add" ImageUrl='<%# Eval("ImageFilenameOverride") %>' 
         AlternateText='<%# Eval("Name") %>' style="width:236px; height:236px" Width="236px" Height="236px" />
        
        </div>
    <div class="name"><%# Eval("Name") %></div>
    <div class="description">
	<%# Eval("Description")%>..</div>
    <div class="price">
    <span class="price-old">$<%# String.Format("{0:f2}", Eval("promoamount"))%></span> <span class="price-new">$<%# String.Format("{0:f2}", Eval("Profitpriceindollar")) %></span><br /></div>
    <div class="rating"><img src="images/stars-3.png" alt="Based on 1 reviews." /></div>
    <div class="cart">
        <asp:Button ID="btn" runat="server" CommandArgument='<%# Eval("ProductID") %>' CommandName="Add" class="button" Text="Add to Cart" />
    <%--<input type="button" value="Add to Cart" onclick="addToCart('30');" class="button" />--%>
    </div>
    <div class="wishlist"><a class="tooltip" title="Add To WishList" onclick="addToWishList('30');"></a></div>
    <div class="compare"><a class="tooltip" title="Add To Compare" onclick="addToCompare('30');"></a></div>
    </div>
    </ItemTemplate>
    </asp:Repeater>
    
    
	</div>
  
  
  
<div class="pagination"><div class="results">Showing 1 to 11 of 11 (1 Pages)11 of 11 (1 Pages)</div></div>
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
