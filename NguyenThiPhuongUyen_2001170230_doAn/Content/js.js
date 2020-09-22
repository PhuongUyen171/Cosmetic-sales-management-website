jQuery.noConflict(); 
(function(jQuery) {	
	jQuery(document).ready(function(){		
		jQuery("ul").each(function()
		{
			jQuery(this).find("li:last").addClass("end");
			
		});
		
		 var hover_image='';
		jQuery('.product_list_image').hover(function(){			
			clearTimeout(hover_image);
			var order_num=1;
			var image_id=jQuery(this).attr('id');
			jQuery(this).children('img').each(function(){
				jQuery(this).addClass('image_number_'+order_num);
				order_num++;
			});
			
			var number_image=1;	
			clearTimeout(hover_image);
			hover_image = setInterval(function(){				
				if(order_num>number_image){
					jQuery('#'+image_id).children('img').fadeOut(500);					
					number_image++;
					if(number_image==order_num){
						number_image=1;
					}
					jQuery('#'+image_id).children('img.image_number_'+number_image).fadeIn(500);
				}
			}, 2000);
		},function(){
			clearTimeout(hover_image);
			var image_id=jQuery(this).attr('id');
			jQuery('#'+image_id).children('img.image_number_1').fadeIn(500);
		});
		
		jQuery('ul.product_size_list>li>a').click(function(){
			jQuery('#hidden_product_id').val(jQuery(this).attr('rel'));
		});
		
		jQuery('ul.inputboxattrib>li>a').click(function(){
			jQuery('#'+jQuery(this).attr('rel')).val(jQuery(this).attr('id'));
			jQuery(this).parent('li').parent('ul').children('.product_attribute_list').removeClass('product_active_attribute');
			jQuery(this).parent('li').addClass('product_active_attribute');
		});
		
		jQuery('li.li_tab>a').click(function(){
			jQuery('li.li_tab').removeClass('tab_header_active');
			jQuery(this).parent('li').addClass('tab_header_active');
			jQuery('.product_tab_content').removeClass('product_tab_content_active');
			jQuery('div#'+jQuery(this).attr('rel')).addClass('product_tab_content_active');
		});
		
	});			
}) (jQuery);
