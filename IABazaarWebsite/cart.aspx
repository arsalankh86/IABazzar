<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="cart" %>

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
         &raquo; <a href="cart.aspx" title="Shopping Cart">Shopping Cart</a>
      </div>
  
    <h1><span>Shopping Cart         
    </span>

  </h1>
  
 
    <div class="cart-info">
       <table>
       <thead>
          <tr>
            <td class="image">Image</td>
            <td class="name">Product Name</td>
            <td class="model">Model</td>
            <td class="quantity">Quantity</td>
            <td class="price">Unit Price</td>
            <td class="total">Total</td>
          </tr>
          </thead>
          <table>
        <tbody>

        <asp:Repeater ID="dtlcart" runat="server" OnItemCommand="ViewCart_ItemCommand">
        
        <ItemTemplate>
           <tr>
               
            <td class="image">
              <asp:ImageButton ID="Imgbtn" runat="server" ImageUrl='<%# Eval("ImageFilenameOverride") %>' CommandArgument='<%# Eval("ProductID") %>' CommandName="ImageRedirect"
                 AlternateText='<%# Eval("Name") %>' style="width:80px; height:80px" Width="80px" Height="80px" />

          <asp:HiddenField ID="hdncartid" runat="server" Value='<%# Eval("ShoppingCartRecID") %>' />
          </td>
            <td class="name"> 
                <asp:LinkButton ID="lnkbtn" runat="server" Text='<%# Eval("Name") %>'   CommandArgument='<%# Eval("ProductID") %>' CommandName="LinkRedirect" /> 
                            <div>
                                - <small>Size: <%# Eval("ChosenSize")%></small><br />
                              </div>
              </td>
            <td class="model">Product 3</td>
            <td class="quantity">
                <asp:TextBox ID="txtqty" runat="server" class="w30" size="1"  Text='<%# Eval("Quantity") %>' />
              &nbsp;
              <%--<asp:LinkButton ID="lnkupdate" runat="server" CommandArgument='<%# Eval("ShoppingCartRecID") %>' CommandName="LinkUpdate" >
              <img src="images/update.png" alt="Update" title="Update" /></asp:LinkButton>--%>
              &nbsp;<asp:LinkButton ID="lnkremove" runat="server" CommandArgument='<%# Eval("ShoppingCartRecID") %>' CommandName="LinkRemove" >
               <img src="images/remove.png" alt="Remove" title="Remove" /></asp:LinkButton></td>
            <td class="price">$<%# Eval("ProductPrice")%></td>
            <td class="total">$<%# Eval("CartTotal")%></td>
          </tr>
      </ItemTemplate>
      </asp:Repeater>

       </tbody>
      </table>

    </div>
 
  <div class="cart-total">
    <table id="total">
      <tr>
              <td class="right"><b>Sub-Total:</b></td>
              <td class="right">$<asp:Label ID="lblsubtotal" runat="server" Text="[Subtotal]"></asp:Label></td>
            </tr>
              <tr>
              <td class="right"><b>Shipping:</b></td>
              <td class="right">$<asp:Label ID="lblShipping" runat="server" Text="[Shipping]"></asp:Label></td>
            </tr>
                    <tr>
              <td class="right"><b>Total:</b></td>
              <td class="right">$<asp:Label ID="lbltotal" runat="server" Text="[Total]"></asp:Label></td>
            </tr>
         
          </table>
  </div>
  <div class="buttons">
    <div class="right">
        <asp:Button ID="btnchkout" runat="server" Text="Checkout" class="button" 
            onclick="btnchkout_Click" Width="200"  /></div>
    <div class="left"><a href="product.aspx" class="button" Width="200">Continue Shopping</a></div>
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