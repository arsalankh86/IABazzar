<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Return.aspx.cs" Inherits="Return" %>

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
        <uc1:header ID="header1" runat="server" />

</header>
        <!--Header Part End-->

        <div id="container">

&nbsp;<div id="column-left">
    <div class="box">
  <div class="box-heading"><span>&nbsp;Account</span></div>
  <div class="box-content">
  <div class="box-category">
    <ul>
            <li><a href="myaccount.html" title="My Account">My Account</a></li>
            <li><a href="#" title="Edit Account">Edit Account</a></li>
      		<li><a href="password.html" title="Password">Password</a></li>
            <li><a href="wishlist.html" title="Wish List">Wish List</a></li>
      		<li><a href="orderhistory.html" title="Order History">Order History</a></li>
      		<li><a href="#" title="Downloads">Downloads</a></li>
      		<li><a href="returns.html" title="Returns">Returns</a></li>
     		<li><a href="transactions.html" title="Transactions">Transactions</a></li>
      		<li><a href="#" title="Newsletter">Newsletter</a></li>
            <li><a href="#" title="Logout">Logout</a></li>
          </ul>
    </div>
  </div>
</div>
  </div>
 
<div id="content">

					
<uc3:socials ID="socials1" runat="server" />

<div class="breadcrumb">
        <a href="index-2.html" title="Home">
        
        Home</a>
         &raquo; <a href="myaccount.html" title="My Account">Account</a>
         &raquo; <a href="returns.html" title="Product Returns">Product Returns</a>
      </div>
  
  <h1><span>Product Returns</span></h1>
  
  At iabazaar.com, we want you to be delighted every time you shop with us. You can always return items if they are defective or sent incorrect. Please know that you must 
    email us the complete written record of the reason for return or exchange within 24 hours of receiving the item. 
    You can return items within 24 hours of receving item. Custom, Oversize, or hazardous items cannot be returned. Items that have been used will not be accepted as returns or exchanges. Items which have any stains, emit, body odours or perfume scents, have any kind of marks, damages or water stains will not be accepted for returns or exchanges. There is no refund for shipping and handling charges. 

  
<div class="clear"></div>


</div>



          <!--Footer Part Start-->
        <footer>
<uc2:footer ID="footer1" runat="server" />
</footer>
        <!--Footer Part End-->


    </form>
</body>
</html>
