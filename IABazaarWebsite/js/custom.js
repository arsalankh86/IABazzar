// JavaScript Document

/*===============================================================
		Template Name: Anycart
		Version: 1.0
		Description: Responsive and clean template for retail shop
		Theme URI: http://www.curvepixell.com/web/anycart
		Development: Stevemun
		Author URI: http://themeforest.net/user/stevemun7
		Tags: Anycrt, retail, curvepixell
===============================================================*/


//Flex Slider
$(window).load(function() {
	$('.flexslider').flexslider();
});




if($.cookie("css")){
	$("link.theme").attr("href",$.cookie("css"));
}




$(document).ready(function(){


	// Menu Animation
    $('#menu ul li').hover(
        function() {
            $(this).addClass("active");
            $(this).find('div').stop(false, true).slideDown();
        },
        function() {
            $(this).removeClass("active");        
            $(this).find('div').stop(false, true).slideUp('fast');
        }
    );
	
						   
						   
	//Define Variable
	var ftrMenu = $(".mobileFpart .column h3");
	
	
	$('.ab').hover(function(){
	$(this).prev('a').toggleClass('active');
	});
	
	
	
	
	//Mobile Footer Menu
	ftrMenu.click(function () {
	  $(this).next('.mobileFpart .column ul').slideToggle('slow');
	});
	
	
	
	
	$(".ab>ul>li:last-child a").css("border-bottom","none");
	$("#menu>ul>li:last-child").css("border-right","none");
	
	
	
	$(".customcarousel>li>div").mouseenter(function(){
		$(this).find(".abs").fadeIn("fast");
	});
	
	$(".customcarousel>li>div").mouseleave(function(){
		$(this).find(".abs").fadeOut("fast");
	});
	
	
	
	
	
	//Background changer
	
	
	$('.toggle').toggle(function(){$('.clbox').animate({left:'+=145'},458,'swing',function(){});},function(){$('.clbox').animate({left:'-=145'},458,'swing',function(){});});
	
	
	$('.patterns a').live('click',function(e){
		e.preventDefault();var pattern=$(this).attr('href');
		$(this).parents('ul').find('li').removeClass('active');
		$(this).parent().addClass('active');
		$('body').css('background-image','url(images/pattern/'+pattern+'.png)');
		$('body').css('background-repeat','repeat');
	});
	
	$('.patterns li:nth-child(5n+5)').css('margin-right','0px');
	
	
	
	
	
	
	//Opacity animation on hover
	if ($.browser.msie && ($.browser.version == 8 || $.browser.version == 7 || $.browser.version == 6)) {

		} else {
		 
			$(".box-product > div").hover(function() {
				$(this).siblings().stop().animate({ opacity: .65 }, 300)}, function () {
					$(this).siblings().stop().animate({ opacity: 1 }, 300)}
			);

			$(".product-list > div").hover(function() { 
				$(this).siblings().stop().animate({ opacity: .65 }, 500)}, function () {
					$(this).siblings().stop().animate({ opacity: 1 }, 300) }
			);
			
			$(".product-grid > div").hover(function() { 
				$(this).siblings().stop().animate({ opacity: .65 }, 500)}, function () {
					$(this).siblings().stop().animate({ opacity: 1 }, 300) }
			);

			$(".es-carousel > ul > li").hover(function() { 
				$(this).siblings().stop().animate({ opacity: .65 }, 500)}, function () {
					$(this).siblings().stop().animate({ opacity: 1 }, 300) }
			);

			$(".image-additional > a").hover(function() { 
				$(this).siblings().stop().animate({ opacity: .65 }, 500)}, function () {
					$(this).siblings().stop().animate({ opacity: 1 }, 300) }
			);
			
			
			$(".smlThumb > li").hover(function() { 
				$(this).siblings().stop().animate({ opacity: .65 }, 500)}, function () {
					$(this).siblings().stop().animate({ opacity: 1 }, 300) }
			);
			
		}
	
	
	
	
	// Tooltip
	$('.tooltip').tooltipster({ position:'bottom'});
	
	
	
	//plus mines button in qty
	$(".qtyBtn").click(function(){
		if($(this).hasClass("plus")){
			var qty = $("#qty").val();
			qty++;
			$("#qty").val(qty);
		}else{
			var qty = $("#qty").val();
			qty--;
			if(qty>0){
				$("#qty").val(qty);
			}
		}
	});	
	
	
	/*Alert Boxes*/
	$(".alert_box").each( function(){
   		$(this).append('<div class="close"></div>');
	});
	$("body").on('click', '.alert_box', function() {
			$(this).fadeOut();
	});
	
	
	/*Progress Bars*/
  	$(".progress_bar").each(function(index) {
    	$(this).find('span').animate({
    		width: $(this).attr("data-percentage")+"%",
  		}, 650 );
  		if($(this).attr("data-title")){
  			$(this).find('span').append($(this).attr("data-title")+"&nbsp;&nbsp;&nbsp;");
  		}
	});
	
	
	/*Tabs*/
	$('#tabs a').tabs();

	
	
});
