<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Privacy_Policy.aspx.cs" Inherits="Privacy_Policy" %>

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

<div id="column-left">
    <div class="box">
  <div class="box-heading"><span>Information</span></div>
  <div class="box-content">
  <div class="box-category">
    <ul>
            <li><a href="About_Us.aspx" title="About Us">About Us</a></li>
            <li><a href="Delivery_Information.aspx" title="Delivery Information">Delivery Information</a></li>
            <li><a href="Privacy_Policy.aspx" title="Privacy Policy">Privacy Policy</a></li>
            <li><a href="Terms_Condition.aspx" title="Terms &amp; Conditions">Terms &amp; Conditions</a></li>
            <li><a href="Contactus.aspx" title="Contact Us">Contact Us</a></li>
      <li><a href="Site_Map.aspx" title="Site Map">Site Map</a></li>
    </ul>
    </div>
  </div>
</div>
  </div>
 
<div id="content">

		<div class="social">
        	<ul>
            <li>
			<a class="ico-fb" onClick="window.open('http://www.facebook.com/');" title="Follow Anycart Theme on Facebook"></a>
			</li>
            
            <li>                	
			<a class="ico-twit" onClick="window.open('http://twitter.com/');" title="Follow Anycart Theme on Twitter"></a>
            </li>
                                
            <li>                	
			<a class="ico-pint" onClick="window.open('http://pinterest.com/');" title="Follow Anycart Theme on Pinterest"></a>
            </li>
            </ul>
		</div>			
  
  <div class="breadcrumb">
        <a href="index-2.html" title="Home">Home</a>
         &raquo; <a href="policy.html" title="Privacy Policy">Privacy Policy</a>
      </div>
  
  <h1><span>Privacy Policy</span></h1>
  <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>
  
  <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec vehicula, augue dapibus tempus dignissim, turpis erat imperdiet urna, sed posuere lorem sapien eget neque. Cras pretium, magna sit amet sagittis feugiat, elit ipsum tempus dui, vitae rutrum nulla ante vitae diam. Nunc eu dui nec odio volutpat pretium faucibus nec erat. Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
  <div class="buttons">
    <div class="right"><a href="index-2.html" class="button">Continue</a></div>
  </div>
  </div>
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
