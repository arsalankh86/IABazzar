<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" %>

 

<%@ Register src="controls/header.ascx" tagname="header" tagprefix="uc1" %>

<%@ Register src="controls/footer.ascx" tagname="footer" tagprefix="uc2" %>

<%@ Register src="controls/socials.ascx" tagname="socials" tagprefix="uc3" %>



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
    <form id="form1" runat="server">
         <input type="hidden" name="next" value="coupon" />

        <input type="hidden" name="next" value="reward" />
        <input type="hidden" name="next" value="voucher" />




<div class="mainWrapper">


<!--Header Part Start-->
<header>
<uc1:header ID="header1" runat="server" />
</header>
<!--Header Part End-->

<div class="wrapper">
<div id="notification"></div>
<div id="container">


 
<div id="content">

		<uc3:socials ID="socials1" runat="server" />			

<div class="breadcrumb">
        <a href="Default.aspx" title="Home">Home</a>
         &raquo; <a href="cart.aspx" title="Shopping Cart">Search Result</a>
      </div>
  
    <h1><span>Search Result       
    </span>

  </h1>
  
 
    <div class="cart-info">
        <asp:Label ID="lblerror" runat="server" Text="No Record Found" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>

        <div class="product-list">
    <asp:Repeater ID="rptSearchProduct" runat="server" OnItemCommand="ViewCart_ItemCommand" >
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
    <span class="price-old">$<%# Eval("promoamount")%></span> <span class="price-new">$<%# Eval("Profitpriceindollar") %></span><br /></div>
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
   <%--  Imran Search Work in cart-info div--%>


    </div>
 
  
  
  </div>
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
