<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
   
   <!--<link href='http://fonts.googleapis.com/css?family=Carme' rel='stylesheet' type='text/css' />-->
   
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
            <div>
            <div class="image"><a href="#"><img src="images/products/productSeven-80x80.jpg" title="Canon EOS 5D" alt="Canon EOS 5D" /></a></div>
            <div class="name"><a href="#">Canon EOS 5D</a></div>
            <div class="price">
            <span class="price-old">$100.00</span> <span class="price-new">$80.00</span>
            </div>
            </div>
            
            
            <div>
            <div class="image"><a href="#"><img src="images/products/womenSandalOne-80x80.jpg" title="Women sandal one" alt="Women sandal one" /></a></div>
            <div class="name"><a href="#">Women sandal one</a></div>
            <div class="price">
            <span class="price-old">$100.00</span> <span class="price-new">$90.00</span>
            </div>
            </div>
            
            
            
          </div>
  </div>
</div>
  </div>
 
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
    </div>
  
  <h1><span>Men</span></h1>
    <div class="category-info">
        <div class="image"><img src="images/products/productTwo-80x80.jpg" alt="Men" /></div>
            <p>
	Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
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
    
    
    <div class="limit">Show:      <select onchange="location = this.value;">
                        <option value="15" selected="selected">15</option>
                                <option value="25">25</option>
                                <option value="50">50</option>
                                <option value="75">75</option>
                                <option value="100">100</option>
                      </select>
    </div>
    <div class="sort">Sort By:      <select onchange="location = this.value;">
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
    </div>
  </div>
  
  
  
  <div class="product-list">
        
    
    <div>
    <div class="image"><a href="#"><img src="images/products/productSeven-150x150.jpg" title="Canon EOS 5D" alt="Canon EOS 5D" /></a></div>
    <div class="name"><a href="#">Canon EOS 5D</a></div>
    <div class="description">
	Canon EOS 5D press material for the EOS 5D states that it 'defines (a) new D-SLR category', while..</div>
    <div class="price">
    <span class="price-old">$100.00</span> <span class="price-new">$80.00</span>
    <br />
    <span class="price-tax">Ex Tax: $80.00</span>
    </div>
    <div class="rating"><img src="images/stars-3.png" alt="Based on 1 reviews." /></div>
    <div class="cart">
    <input type="button" value="Add to Cart" onclick="addToCart('30');" class="button" />
    </div>
    <div class="wishlist"><a class="tooltip" title="Add To WishList" onclick="addToWishList('30');"></a></div>
    <div class="compare"><a class="tooltip" title="Add To Compare" onclick="addToCompare('30');"></a></div>
    </div>
    
    
    
    
    <div>
    <div class="image"><a href="#"><img src="images/products/womenSandalThree-150x150.jpg" title="HP LP3065" alt="HP LP3065" /></a></div>
    <div class="name"><a href="#">HP LP3065</a></div>
    <div class="description">
	HP LP3065 press material for the EOS 5D states that it 'defines (a) new D-SLR category', while we..</div>
    <div class="price">$100.00<br />
    <span class="price-tax">Ex Tax: $100.00</span>
    </div>
    <div class="rating"><img src="images/stars-5.png" alt="Based on 1 reviews." /></div>
    <div class="cart">
    <input type="button" value="Add to Cart" onclick="addToCart('30');" class="button" />
    </div>
    <div class="wishlist"><a class="tooltip" title="Add To WishList" onclick="addToWishList('30');"></a></div>
    <div class="compare"><a class="tooltip" title="Add To Compare" onclick="addToCompare('30');"></a></div>
    </div>
    
    
    
    
    
    
    
    <div>
    <div class="image"><a href="#"><img src="images/products/womenjacketFour-150x150.jpg" title="HTC Touch HD" alt="HTC Touch HD" /></a></div>
    <div class="name"><a href="#">HTC Touch HD</a></div>
    <div class="description">
	HTC Touch - in High Definition. Watch music videos and streaming content in awe-inspiring high de..</div>
    <div class="price">$100.00<br />
    <span class="price-tax">Ex Tax: $100.00</span>
    </div>
    <div class="rating"><img src="images/stars-1.png" alt="Based on 1 reviews." /></div>
    <div class="cart">
    <input type="button" value="Add to Cart" onclick="addToCart('30');" class="button" />
    </div>
    <div class="wishlist"><a class="tooltip" title="Add To WishList" onclick="addToWishList('30');"></a></div>
    <div class="compare"><a class="tooltip" title="Add To Compare" onclick="addToCompare('30');"></a></div>
    </div>
    
    
    
    
    
    
    <div>
    <div class="image"><a href="#"><img src="images/products/productTwo-150x150.jpg" title="iPod Classic" alt="iPod Classic" /></a></div>
    <div class="name"><a href="#">iPod Classic</a></div>
    <div class="description">
	More room to move. With 80GB or 160GB of storage and up to 40 hours of battery l..</div>
    <div class="price">$100.00<br />
    <span class="price-tax">Ex Tax: $100.00</span>
    </div>
    <div class="rating"><img src="images/stars-5.png" alt="Based on 1 reviews." /></div>
    <div class="cart">
    <input type="button" value="Add to Cart" onclick="addToCart('30');" class="button" />
    </div>
    <div class="wishlist"><a class="tooltip" title="Add To WishList" onclick="addToWishList('30');"></a></div>
    <div class="compare"><a class="tooltip" title="Add To Compare" onclick="addToCompare('30');"></a></div>
    </div>  
    
    
    
    
    
    
    
    
    <div>
    <div class="image"><a href="#"><img src="images/products/ringTwo-150x150.jpg" title="MacBook Air" alt="MacBook Air" /></a></div>
    <div class="name"><a href="#">MacBook Air</a></div>
    <div class="description">
	MacBook Air is ultrathin, ultraportable, and ultra unlike anything else. But you don’t lose inche..</div>
    <div class="price">$1,000.00<br />
    <span class="price-tax">Ex Tax: $1,000.00</span>
    </div>
    <div class="rating"><img src="images/stars-4.png" alt="Based on 1 reviews." /></div>
    <div class="cart">
    <input type="button" value="Add to Cart" onclick="addToCart('30');" class="button" />
    </div>
    <div class="wishlist"><a class="tooltip" title="Add To WishList" onclick="addToWishList('30');"></a></div>
    <div class="compare"><a class="tooltip" title="Add To Compare" onclick="addToCompare('30');"></a></div>
    </div> 
       
        
    
    
    
    
    <div>
    <div class="image"><a href="#"><img src="images/products/productSeven-150x150.jpg" title="Men jacket one" alt="Men jacket one" /></a></div>
    <div class="name"><a href="#">Men jacket one</a></div>
    <div class="description">
	Canon's press material for the EOS 5D states that it 'defines (a) new D-SLR category', while we'r..</div>
    <div class="price">$500.00<br />
    <span class="price-tax">Ex Tax: $500.00</span>
    </div>
    <div class="rating"><img src="images/stars-4.png" alt="Based on 1 reviews." /></div>
    <div class="cart">
    <input type="button" value="Add to Cart" onclick="addToCart('30');" class="button" />
    </div>
    <div class="wishlist"><a class="tooltip" title="Add To WishList" onclick="addToWishList('30');"></a></div>
    <div class="compare"><a class="tooltip" title="Add To Compare" onclick="addToCompare('30');"></a></div>
    </div>
    
    
    
    
    
    
    
    <div>
    <div class="image"><a href="#"><img src="images/products/womenBagTwo-150x150.jpg" title="Palm Treo Pro" alt="Palm Treo Pro" /></a></div>
    <div class="name"><a href="#">Palm Treo Pro</a></div>
    <div class="description">
	Redefine your workday with the Palm Treo Pro smartphone. Perfectly balanced, you can respond to b..</div>
    <div class="price">$279.00<br />
    <span class="price-tax">Ex Tax: $279.00</span>
    </div>
    <div class="rating"><img src="images/stars-2.png" alt="Based on 1 reviews." /></div>
    <div class="cart">
    <input type="button" value="Add to Cart" onclick="addToCart('30');" class="button" />
    </div>
    <div class="wishlist"><a class="tooltip" title="Add To WishList" onclick="addToWishList('30');"></a></div>
    <div class="compare"><a class="tooltip" title="Add To Compare" onclick="addToCompare('30');"></a></div>
    </div>
    
    
    
    
    
    
    
    <div>
    <div class="image"><a href="#"><img src="images/products/womenBagThree-150x150.jpg" title="Samsung SyncMaster 941BW" alt="Samsung SyncMaster 941BW" /></a></div>
    <div class="name"><a href="#">Samsung SyncMaster 941BW</a></div>
    <div class="description">
	Imagine the advantages of going big without slowing down. The big 19" 941BW monitor combines wide..</div>
    <div class="price">$200.00<br />
    <span class="price-tax">Ex Tax: $200.00</span>
    </div>
    <div class="rating"><img src="images/stars-1.png" alt="Based on 1 reviews." /></div>
    <div class="cart">
    <input type="button" value="Add to Cart" onclick="addToCart('30');" class="button" />
    </div>
    <div class="wishlist"><a class="tooltip" title="Add To WishList" onclick="addToWishList('30');"></a></div>
    <div class="compare"><a class="tooltip" title="Add To Compare" onclick="addToCompare('30');"></a></div>
    </div>
    
    
    
    
    
    
    
    
    <div>
    <div class="image"><a href="#"><img src="images/products/womenBagOne-150x150.jpg" title="Women bag one" alt="Women bag one" /></a></div>
    <div class="name"><a href="#">Women bag one</a></div>
    <div class="description">
	Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been t..</div>
    <div class="price">$1,000.00<br />
    <span class="price-tax">Ex Tax: $1,000.00</span>
    </div>
    <div class="rating"><img src="images/stars-3.png" alt="Based on 1 reviews." /></div>
    <div class="cart">
    <input type="button" value="Add to Cart" onclick="addToCart('30');" class="button" />
    </div>
    <div class="wishlist"><a class="tooltip" title="Add To WishList" onclick="addToWishList('30');"></a></div>
    <div class="compare"><a class="tooltip" title="Add To Compare" onclick="addToCompare('30');"></a></div>
    </div>
    
    
    
    
    
    
    
    
    
    <div>
    <div class="image"><a href="#"><img src="images/products/womenJacketTwo-150x150.jpg" title="Women jacket one" alt="Women jacket one" /></a></div>
    <div class="name"><a href="#">Women jacket one</a></div>
    <div class="description">
	Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been t..</div>
    <div class="price">$101.00<br />
    <span class="price-tax">Ex Tax: $101.00</span>
    </div>
    <div class="rating"><img src="images/stars-5.png" alt="Based on 1 reviews." /></div>
    <div class="cart">
    <input type="button" value="Add to Cart" onclick="addToCart('30');" class="button" />
    </div>
    <div class="wishlist"><a class="tooltip" title="Add To WishList" onclick="addToWishList('30');"></a></div>
    <div class="compare"><a class="tooltip" title="Add To Compare" onclick="addToCompare('30');"></a></div>
    </div>
    
    
    
    
    
    
    
    <div>
    <div class="image"><a href="#"><img src="images/products/womenSandalOne-150x150.jpg" title="Women sandal one" alt="Women sandal one" /></a></div>
    <div class="name"><a href="#">Women sandal one</a></div>
    <div class="description">
	Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been t..</div>
    <div class="price"><span class="price-old">$100.00</span> <span class="price-new">$90.00</span><br>
    <span class="price-tax">Ex Tax: $90.00</span>
    </div>
    <div class="rating"><img src="images/stars-2.png" alt="Based on 1 reviews." /></div>
    <div class="cart">
    <input type="button" value="Add to Cart" onclick="addToCart('30');" class="button" />
    </div>
    <div class="wishlist"><a class="tooltip" title="Add To WishList" onclick="addToWishList('30');"></a></div>
    <div class="compare"><a class="tooltip" title="Add To Compare" onclick="addToCompare('30');"></a></div>
    </div>
    
    
    
	</div>
  
  
  
<div class="pagination"><div class="results">Showing 1 to 11 of 11 (1 Pages)</div></div>
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
</asp:Content>

