<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="controls_header" %>



<div class="headerTopBg">

<div class="headerTop">
	<div id="welcome">Welcome<a href="login.aspx" title="Login">login/Sign up</a> or +19265879123.</div>

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
        <a><span id="cart-total"><asp:Label ID="lblcart" runat="server" Text="0 item(s)"></asp:Label> </span></a></div>
      	<div class="content">
            <div class="mini-cart-info">

            <asp:Repeater ID="rptcart" runat="server">
            <ItemTemplate>
            <table>
                    <tr>
              <td class="image">
              
              <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("ImageFilenameOverride") %>'
         AlternateText='<%# Eval("Name") %>' Width="80" Height="80" />
         
                </td>
              <td class="name"><a href="#"><%# Eval("Name") %></a>
               <%-- <div>
                                - <small>Select Blue</small><br />
                              </div>--%></td>
              <td class="quantity">x&nbsp;1</td>
              <td class="total">$<%# Eval("ProductPrice")%></td>
              <td class="remove"><img src="images/remove-small.png" alt="Remove" title="Remove" onClick="javascript:void(0);" /></td>
            </tr>
                    
                          </table>
            </ItemTemplate>
            </asp:Repeater>

          
        </div>
      <%--  <div class="mini-cart-total">
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
        </div>--%>
        <div class="checkout">
        <a class="button" href="cart.aspx"><span>View Cart</span></a> 
        <a class="button" href="checkout.aspx"><span>Checkout</span></a></div>
        </div>
    </div>
	<!--Cart Part End-->
  	<div class="clear"></div>
</div>

<div class="headerBG">

<div id="headerMain">
<div id="header">
    <div id="logo">
    <a href="http://www.iabazaar.com/"><img src="images/logo2.png" title="iabazaar - Indian Brand Super Store" alt="iabazaar - Indian Brand Super Store" /></a>
    </div>
    
 	<div class="links">
 	<a class="home" href="http://www.iabazaar.com/">Home</a>
    <a href="Wishlist.aspx">Wish List</a>
    <a href="MyAccount.aspx">My Account</a>
    <a href="cart.aspx">Shopping Cart</a>
    <a href="checkout.aspx">Checkout</a>
	</div>
  
  	<div id="search">
    	<div >
          <asp:ImageButton ID="Button1"  CssClass="button-search"
            style=" width:16px; height:20px; border:none;"
            runat="server" ImageUrl="../images/btn-search.png" onclick="Button1_Click" /></div>

            <input type="text" name="filter_name" id="filter_name" runat="server" value="Search" onClick="this.value = '';" onKeyDown="this.style.color = '#333';" />

	</div>
</div>
<div class="clear"></div>
</div>


<!--Nav Part Start-->
<nav>
<div class="menu-main">
<div id="menu">
  <ul>
  	<li><a href="http://www.iabazaar.com/" title="Home"><span class='home_icon'></span></a></li>
      
         <li><a href="#" title="Bollywood">Bollywood</a>
            <div style="width:180px;">
                <ul>
                <li><a href="cc-afreen-originally-luxury-97"  >Afreen Originally Luxury</a></li>
                <li><a href="cc-kaia-white-feathers-98"  >KAIA White Feathers</a></li>
                <li><a href="cc-khwaab-99">KHWAAB</a></li>
                <li><a href="cc-khwaab-rama-100">Reisa By RF</a></li>
                <li><a href="cc-om-tex-301-101">OM TEX 301</a></li>
                <li><a href="cc-rose-fashion-102">ROSE Fashion</a></li>                
               <li><a href="cc-braahtii-by-huma-nassr-62">Bollywood Kurti</a></li>
                </ul>
     		 </div>
          </li>
        
        <li><a href="#" title="Summer Collection">Summer Collection</a>
        <div style=" width:690px;">
                <ul>
<li><a href="cc-sana-safinaz-lawn-85"  > Sana Safinaz Lawn</a></li>
<li><a href="cc-zunn-kurti-collection-by-lsm-91"  > Zunn Kurti Collection By LSM</a></li>
 <li><a href="cc-suman-ayesha-de-chiffon-vol-2-2014-90"  >SUMAN AYESHA DE CHIFFON VOL -2 2014</a></li>
 <li><a href="cc-suman-ayesha-de-chiffon-vol-1-2014-89"  >SUMAN AYESHA DE CHIFFON VOL -1 2014</a></li>
 <li><a href="cc-strawberry-chiffon-collection-2014-88"  >Strawberry Chiffon Collection 2014</a></li>
 <li><a href="cc-sobia-nazir-lawn-collection-2014-87"  >Sobia Nazir Lawn Collection 2014</a></li>
  <li><a href="cc-shamraf-rtw-collection-2014-86"  > Shamraf RTW Collection 2014</a></li>
 <li><a href="cc-nsm-pret-collection-84"  > NSM Pret Collection</a></li>
 </ul>
 <ul>
 <%--<li><a href="cc-mahnoor-spring-collection-2014-vol-i-83"  > Mahnoor Spring Collection 2014 Vol. I</a></li>--%>
 <li><a href="cc-mahiymaan-signature-series-2014-by-al-zohaib-textile-82"  > Mahiymaan Signature Series 2014 by Al-Zohaib Textile</a></li>
 <li><a href="cc-gul-ahmed-summer-fancy-collection-vol-1-2014-81"  >Gul Ahmed Summer Fancy Collection Vol 1 2014</a></li>
  <li><a href="cc-gul-ahmed-summer-2014-vol-1-80"  > Gul Ahmed Summer 2014 Vol 1</a></li>
 <li><a href="cc-eshal-premium-lawn-collection-2014-vol-01-by-shayyan-textile-79"  > Eshal Premium Lawn Collection 2014 Vol 01</a></li>
 <li><a href="cc-elan-lawn-2014-78"  > Elan Lawn 2014  </a></li>
 <li><a href="cc-dicha-summer-smile-emb.-kurti-2014-77"  > Dicha Summer Smile Emb. Kurti 2014</a></li>
 <li><a href="cc-anum-classic-collection-vol-ii-103"  > Anum Classic Collection Vol II
</a></li>
                </ul>
     		 </div>
        </li>
        
        <li><a href="#" title="Salwar Kameez">Salwar Kameez</a>
        <div style=" width:770px;">

                 

         <ul>
              <li><a href="cc-aalishan-krinkle-lawn-2014-by-dawood-textiles-1"> Aalishan Krinkle Lawn</a></li>
<li><a href="cc-ali-xeeshan-by-shariq-10"  > Ali Xeeshan by Shariq On Sale</a></li>
<li><a href="cc-allure-limited-edition-premium-lawn-collection-2013-13"  > Allure by Alkaram - 2013 On Sale</a></li>
<li><a href="cc-aramish-exclusive-lawn-collection-by-bv-14"  > Aramish Exclusive Lawn On Sale</a></li>
<li><a href="cc-mahnoor-spring-collection-2014-vol-1-29"  > Mahnoor Spring Collection 2014 Vol. I</a></li>
<li><a href="cc-eshal-premium-lawn-collection-2014-vol-01-by-shayyan-textile-17"  > Eshal Premium Lawn</a></li>

<li><a href="cc-ha-textile-designer-series-lawn-summer-2014-23"  > HA Textile Lawn Prints</a></li>
<li><a href="cc-hajiba-de-chiffon-lawn-2014-by-dawood-textiles-24"  > Hajiba De Chiffon Lawn</a></li>
<li><a href="cc-haute-monde-collection-2013-by-sadia-25"  > Haute Monde By Sadia On Sale</a></li>
<li><a href="cc-royal-embroidered-linen-2013-by-ittehad-40"  > Ittehad Embroidered Linen Collection On Sale</a></li>



        </ul>

          <ul>
                 
<li><a href="cc-la-femme-exclusive-embroidered-winter-collection-2013-27"  > La Femme Emb Collection On Sale</a></li>
<li><a href="cc-libas-crinkle-lawn-vol-1-2014-by-shariq-28"  > Libas Crinkle Lawn Volume-1</a></li>
<li><a href="cc-mausummery-lawn-2014-30"  > Mausummery Lawn 2014</a></li>
<li><a href="cc-monsoon-festivana-vol-2.-2013-by-al---zohaib-textile-31"  > Monsoon Festivana Vol 2 On Sale</a></li>
<li><a href="cc-orient-linen-collection-32"  > Orient Linen Collection</a></li>
<li><a href="cc-popular-cambric-collection-2013-33"  > Popular Cambric Collection 2013</a></li>


<li><a href="cc-popular-classic-lawn-collection-2013-34"  > Popular Classic Lawn Collection 2013</a></li>
<li><a href="cc-popular-exclusive-lawn-collection-2013-35"  > Popular Exclusive Lawn Collection 2013</a></li>
<li><a href="cc-popular-lawn-collection-2013-36"  > Popular Lawn Collection 2013 On Sale</a></li>
<li><a href="cc-popular-linen-collection-2014-37"  > Popular Linen Collection 2014</a></li>



        </ul>

        <ul>
        <li><a href="cc-sahil-mid-summer-collection-2013-by-shariq-41"  > Sahil Mid Summer 2013 On Sale</a></li>

<li><a href="cc-grand-sale-2014-19"  > GRAND SALE - 2014</a></li>
<li><a href="cc-silk-asia-fancy-dresses-42"  > Silk Asia 2014</a></li>
<li><a href="cc-silky-line-collection-2012-by-qasimi-industries-43"  > Silky Line Collection On Sale</a></li>

<li><a href="cc-subhata-linen-designer-collection-2014-by-shariq-45"  > Subhata Linen On Sale</a></li>
<li><a href="cc-subhata-summer-collection-2014-by-shariq-textiles-46"  > Subhata Summer Collection</a></li>

<li><a href="cc-tradition-collection-2013-by-z.s-textile-49"  > Tradition Collection 2013 On Sale</a></li>
<li><a href="cc-vs-textile-mills-summer-2014-52"  > VS Textile Mills Summer 2014</a></li>
<li><a href="cc-zaheer-abbas-lawn-2013-by-shariq-54"  > Zaheer Abbas Lawn On Sale</a></li>
<li><a href="cc-zunn-winter-collection-2013-by-lsm-fabrics-55"  > ZUNN Winter by LSM On Sale </a></li>


        
        </ul>



      <%--          <ul>
               <li><a href="cc-aalishan-krinkle-lawn-2014-by-dawood-textiles-1"> Aalishan Krinkle Lawn</a></li>
             
             <li><a href="cc-ali-xeeshan-by-shariq-10"  > Ali Xeeshan by Shariq On Sale</a></li>
             <li><a href="cc-allure-limited-edition-premium-lawn-collection-2013-13"  > Allure by Alkaram - 2013 On Sale</a></li>
             <li><a href="cc-aramish-exclusive-lawn-collection-by-bv-14"  > Aramish Exclusive Lawn On Sale</a></li>
             <li><a href="cc-Crescent Faraz Manan Luxury Collection 2013-14"  > Crescent Luxury Collection On Sale</a></li>
             <li><a href="cc-eshal-premium-lawn-collection-2014-vol-01-by-shayyan-textile-17"  > Eshal Premium Lawn</a></li>
             <li><a href="cc-faiza-samee-collection-2012-by-al-karam-18"  > Faiza Samee On Sale</a></li>
             <li><a href="cc-ha-textile-designer-series-lawn-summer-2014-23"  > HA Textile Lawn Prints</a></li>
             <li><a href="cc-hajiba-de-chiffon-lawn-2014-by-dawood-textiles-24"  > Hajiba De Chiffon Lawn</a></li>
             <li><a href="cc-haute-monde-collection-2013-by-sadia-25"  > Haute Monde By Sadia On Sale</a></li>
             <li><a href="cc-royal-embroidered-linen-2013-by-ittehad-40"  > Ittehad Embroidered Linen Collection On Sale</a></li>
             <li><a href="cc-khaddar-fall-winter-collection-2013-by-shariq-26"  > Khadder Winter By Shariq On Sale</a></li>
             <li><a href="cc-la-femme-exclusive-embroidered-winter-collection-2013-27"  > La Femme Emb Collection On Sale</a></li>
             
             <li><a href="cc-libas-crinkle-lawn-vol-1-2014-by-shariq-28"  > Libas Crinkle Lawn Volume-1</a></li>
             <li><a href="cc-mausummery-lawn-2014-30"  > Mausummery Lawn 2014</a></li>
             <li><a href="cc-monsoon-festivana-vol-2.-2013-by-al---zohaib-textile-31"  > Monsoon Festivana Vol 2 On Sale</a></li>
             <li><a href="cc-orient-linen-collection-32"  > Orient Linen Collection</a></li>
             <li><a href="cc-popular-cambric-collection-2013-33"  > Popular Cambric Collection 2013</a></li>
             <li><a href="cc-popular-classic-lawn-collection-2013-34"  > Popular Classic Lawn Collection 2013</a></li>
             <li><a href="cc-popular-exclusive-lawn-collection-2013-35"  > Popular Exclusive Lawn Collection 2013</a></li>
             <li><a href="cc-popular-lawn-collection-2013-36"  > Popular Lawn Collection 2013 On Sale</a></li>
             <li><a href="cc-popular-linen-collection-2014-37"  > Popular Linen Collection 2014</a></li>
             <li><a href="cc-rabeea-designer-embroidered-linen-collection-2013-38"  > Rabeea Embroidered Linen 2013 On Sale</a></li>
             <li><a href="cc-reeva-designer-embroidered-collection-2013-by-shariq-39"  > Reeva Collection On Sale</a></li>
             <li><a href="cc-sahil-mid-summer-collection-2013-by-shariq-41"  > Sahil Mid Summer 2013 On Sale</a></li>
            
             <li><a href="cc-grand-sale-2014-19"  > GRAND SALE - 2014</a></li>
             <li><a href="cc-silk-asia-fancy-dresses-42"  > Silk Asia 2014</a></li>
             <li><a href="cc-silky-line-collection-2012-by-qasimi-industries-43"  > Silky Line Collection On Sale</a></li>
             <li><a href="cc-strawberry-chiffon-collection-2014-44"  > Strawberry Chiffon 2014</a></li>
             <li><a href="cc-subhata-linen-designer-collection-2014-by-shariq-45"  > Subhata Linen On Sale</a></li>
             <li><a href="cc-subhata-summer-collection-2014-by-shariq-textiles-46"  > Subhata Summer Collection</a></li>
             <li><a href="cc-suman-ayesha-de-chiffon-vol--2-2014-48"  > Suman Ayesha Chiffon Lawn - V2</a></li>
             <li><a href="cc-tradition-collection-2013-by-z.s-textile-49"  > Tradition Collection 2013 On Sale</a></li>
             <li><a href="cc-vs-textile-mills-summer-2014-52"  > VS Textile Mills Summer 2014</a></li>
             <li><a href="cc-zaheer-abbas-lawn-2013-by-shariq-54"  > Zaheer Abbas Lawn On Sale</a></li>
             <li><a href="cc-zunn-winter-collection-2013-by-lsm-fabrics-55"  > ZUNN Winter by LSM On Sale </a></li>
 </ul>--%>
             <%--<li><a href="product.html"  > La Femme Winter 2013</a></li>--%>
             <%--<li><a href="cc-ali-xeeshan-by-shariq-10"  > Afreen By Lala</a></li>--%>
             <%--<li><a href="product.html"  > Feminine Embroidered Lawn 2014</a></li>--%>
             <%--<li><a href="product.html"  > Komal Chiffon Collection 2014</a></li>--%>
             <%--<li><a href="product.html"  > Komal Kurties 2014 By LSM</a></li>--%>
             <%--<li><a href="product.html"  > Komal Sticherry Lawn 2014</a></li>--%>
             <%--<li><a href="product.html"  > Mashaal Khaadi Collection</a></li>--%>
             <%--<li><a href="product.html"  > Rabea Embroidered Lawn 2014</a></li>--%>
             
               
     		 </div>
        </li>
         <li><a href="#" title="Brand">Brand</a>
        <div style="width:600px;">
                <ul>
              <li><a href="cc-al-karam-festival-collection-2013-2"  > Al Karam Festival Collection 2013 On Sale</a></li>
 <li><a href="cc-al-karam-mid-summer-collection-2013-3"  > Al Karam MidSummer 2013</a></li>
 
 <li><a href="cc-al-karam-winter-digital-collection-2013-5"  > Al Karam Winter Digital Collection 2013</a></li>
 <%--<li><a href="product.html"  > Al Karam Winter Hues 2013 Vol-1</a></li>--%>
 
 <%--<li><a href="product.html"  > Al Karam Winter Hues 2013 Vol-3 On Sale</a></li>--%>
 <li><a href="cc-alkaram-spring-summer-collection-2013-vol-01-11"  > Alkaram Lawn Collection 2013 Vol-1</a></li>
 <li><a href="cc-alkaram-spring-summer-collection-2013-vol-02-12"  > Alkaram Lawn Collection 2013 Vol-2</a></li>

 <li><a href="cc-deepak-perwani-collection-2013-by-orient-textile-mills-16"  > Deepak Perwani On Sale</a></li>
 <li><a href="cc-faiza-samee-collection-2012-by-al-karam-18"  > Faiza Samee On Sale</a></li>
 <li><a href="cc-khaddar-fall-winter-collection-2013-by-shariq-26"  > Khadder Winter By Shariq On Sale</a></li>
 <li><a href="cc-rabeea-designer-embroidered-linen-collection-2013-38"  > Rabeea Embroidered Linen 2013 On Sale</a></li>
<li><a href="cc-reeva-designer-embroidered-collection-2013-by-shariq-39"  > Reeva Collection On Sale</a></li>
 </ul>
 <ul>
 <li><a href="cc-faraz-manan-crescent-lawn-2014-74"  > FARAZ MANAN Crescent Lawn 2014</a></li>
 <li><a href="cc-gulahmed-spring-summer-collection-2013-22"  > Gul Ahmed 2013 On Sale</a></li>
 <li><a href="cc-gul-ahmed-new-season-2013-20"  > Gul Ahmed New Season 2013 On Sale</a></li>
 <li><a href="cc-gul-ahmed-summer-style-2013-21"  > Gul Ahmed Summer Style 2013 On Sale</a></li>
 <li><a href="cc-umar-sayeed-collection-2013-by-al-karam-50"  > Umar Sayeed Collection 2013 On Sale</a></li>
 <li><a href="cc-umar-sayeed-festival-2013-by-al-karam-51"  > Umar Sayeed Festival 2013</a></li>
 <li><a href="cc-suman-ayesha-de-chiffon-vol--2-2014-48"  > Suman Ayesha Chiffon Lawn - V2</a></li>
 <li><a href="cc-strawberry-chiffon-collection-2014-44"  > Strawberry Chiffon 2014</a></li>
 <li><a href="cc-suman-ayesha-de-chiffon-vol--2-2014-48"  > Suman Ayesha Chiffon Lawn - V2</a></li>

                </ul>
                
     		 </div>
          
        </li>
        <li><a href="#" title="Designer Stiched Fabric">Designer Stiched Fabric</a>
        <div>
                <ul>
                 <li><a href="cc-kurties-by-fashion-café-68"  >Kurties By Fashion Cafe</a></li>
 <li><a href="cc-parahan-red-tree-dresses-66"  >Parahan Designer Collection</a></li>
  <li><a href="cc-alkaram-shawls-2013-red-tree-61"  > Alkaram Shawls 2013</a></li>
 <li><a href="cc-alkaram-valentine-day-collection-red-tree-60"  > AlKaram Valentine Day Collection</a></li>
 <li><a href="cc-al-karam-the-joy-of-spring-2014-4"  > Al Karam The Joy of Spring 2014</a></li>
 <li><a href="cc-al-karam-winter-hues-2013-vol-2-7"  > Al Karam Winter Hues 2013 Vol-2 On Sale</a></li>
 <li><a href="cc-al-karam-winter-hues-2013-vol-3-8"  > Al Karam Winter Hues 2013 Vol-3</a></li>
<li><a href="cc-element-women-bottoms-63"  > Element Women Bottoms</a></li>
 <li><a href="cc-element-women-tops-64"  >Element Women Tops</a></li>
 <li><a href="cc-kausar-outfits-65"  >Kausar Outfits</a></li>

 <%--<li><a href="product.html"  >Parahan RTW Dresses</a></li>--%>
 <%--<li><a href="product.html"  >Party Wear By Themz</a></li>--%>
 <%--<li><a href="product.html"  >Red Tree Kurties On Sale</a></li>--%>
 <%--<li><a href="product.html"  >Red Tree Winter Kurties On Sale</a></li>--%>
 <%--<li><a href="product.html"  >Vibration Kurties</a></li>--%>
 <%--<li><a href="product.html"  >Vibration RTW Collection</a></li>--%>

                </ul>
     		 </div>
        </li>
      
       
          <li><a href="#" title="Designer">Designer</a> 
          <div style="width:250px;">
        <ul>
        <li><a href="cc-asim-jofa-semi-formal-wear-75"  > Asim Jofa Semi Formal</a></li>
             <li><a href="cc-asim-jofa-western-wear-76"  > Asim Jofa Western</a></li>
             <li><a href="cc-nsm-pret-collection-84"  >  NSM Pret Collection</a></li>
        </ul>
        </div>         
		</li>

        
     
      </ul>
</div>
</div>
</nav>
<!--Nav Part End-->

<!-- PHONE::Start -->
<div id="menu-phone" class="shown-phone" style="display: none;">
  <div id="menu-phone-button">Menu</div>
  <select id="menu-phone-select" onChange="location = this.value">
 
  		<option value="cc-anum-classic-collection-vol-ii-103">Anum Classic Collection Vol II</option>
        <option value="cc-sana-safinaz-lawn-85">Sana Safinaz Lawn</option>
        <option value="cc-strawberry-chiffon-collection-2014-88">Strawberry Chiffon Collection 2014</option>
        <option value="cc-nsm-pret-collection-84"> NSM Pret Collection</option>
        <option value="cc-afreen-originally-luxury-97">Afreen Originally Luxury</option>
        <option value="cc-kaia-white-feathers-98">KAIA White Feathers</option>
        <option value="cc-rose-fashion-102">ROSE Fashion</option>
        <option value="cc-om-tex-301-101">OM TEX 301</option>
        <option value="cc-braahtii-by-huma-nassr-62">Bollywood Kurti</option>
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