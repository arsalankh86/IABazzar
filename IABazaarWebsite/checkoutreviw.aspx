<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkoutreviw.aspx.cs" Inherits="checkoutreview" %>\

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
    <form runat="server">
    
    <div class="mainWrapper">
        <!--Header Part Start-->
        <header>
<%--<uc1:header ID="header1" runat="server" />--%>
</header>
        <!--Header Part End-->
        <div class="wrapper">
            <div id="container">
                <div id="content">
                    <div class="breadcrumb">
                        <a href="Default.aspx" title="Home">Home</a> &raquo; <a href="cart.aspx" title="Shopping Cart">
                            Shopping Cart</a> &raquo; <a href="checkout.aspx" title="Checkout">Checkout</a>
                    </div>
                    <h1>
                        <span>Checkout</span></h1>
                    <div class="checkout">
                        <div id="checkout">
      <div class="checkout-heading">Order Information</div>
      <div class="checkout-content"></div>
   <asp:Repeater ID="dtlcart" runat="server">
                    <HeaderTemplate>
      <table class="list">
    <thead>
      <tr>
        <td class="left">Product Name</td>
        <td class="left">Model</td>
        <td class="right">Quantity</td>
        <td class="right">Price</td>
        <td class="right">Total</td>
                
              </tr>
    </thead>
    </HeaderTemplate>        
    <ItemTemplate>
    <tbody>
            <tr>
        <td class="left"><%# Eval("Name")%> </td>
        <td class="left">Product 14</td>
        <td class="right"><%# Eval("Quantity") %></td>
        <td class="right">$<%# Eval("ProductPrice")%></td>
        <td class="right">$<%# Eval("CartTotal")%></td>
        
      </tr>

                </tbody>
                </ItemTemplate>
                <FooterTemplate>
                </table>
                
                </FooterTemplate>

    

  </asp:Repeater>
<table align="right">
  
            <tr>
        <td colspan="3"></td>
        <td class="right"><b>Sub-Total:</b></td>
        <td class="right">$<asp:Label ID="lblsubtotal" runat="server" Text="[Subtotal]"></asp:Label></td>
                <td></td>
              </tr>
            <tr>
        <td colspan="3"></td>
        <td class="right"><b>Flat Shipping Rate:</b></td>
        <td class="right">$<asp:Label ID="lblShipping" runat="server" Text="[Shipping]"></asp:Label></td>
                <td></td>
              </tr>
            <tr>
        <td colspan="3"></td>
        <td class="right"><b>Total:</b></td>
        <td class="right">$<asp:Label ID="lbltotal" runat="server" Text="[Total]"></asp:Label></td>
                <td></td>
              </tr>
  </table>

    </div>
                    </div>
                </div>
                <div class="clear">
                <div class="buttons">
                    <div class="right">
                    <asp:ImageButton ID="btnContinue" runat="server" Text="Continue" ImageUrl="~/Images/btn_xpressCheckout.png"
                            onclick="btnContinue_Click" />
                    </div>
                </div>
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
