
$(document).ready(function () {
	debugger;
	$("#btnSearch").on('click', function () {
		if ($("#frm-roundtrip")[0].checkValidity() == false) {
			e.preventDefault();
		}
		else{
			debugger;
			OnLoadGetDataList();
	}

	});
	$("#ObtnSearch").on('click', function () {
		if($("#frm-oneway")[0].checkValidity()==false){
			e.preventDefault();
		}
		else{
			OnLoadGetDataList();
	}
	});
	$("#MbtnSearch").on('click', function () {
		debugger;
		if($('#MBdep2').val().length == 0 || $('#MBdep2').val() == undefined)
		{
			$('#MBdep2').val("xxx");
		}
		if ($('#MBarr2').val().length == 0 || $('#MBarr2').val() == undefined)
		{
			$('#MBarr2').val("xxx");
		}
		if ($('#DepDt2').val().length == 0 || $('#DepDt2').val() == undefined)
		{
			$('#DepDt2').val("01/01/2099");
		}

		if ($('#MBdep3').val().length == 0 || $('#MBdep3').val() == undefined) {
			$('#MBdep3').val("xxx");
		}
		if ($('#MBarr3').val().length == 0 || $('#MBarr3').val() == undefined) {
			$('#MBarr3').val("xxx");
		}
		if ($('#DepDt3').val().length == 0 || $('#DepDt3').val() == undefined) {
			$('#DepDt3').val("02/02/2099");
		}
		if($("#frm-multicity")[0].checkValidity()==false){
			e.preventDefault();
		}
		else{
			OnLoadGetDataList();
		}

	});
	$(document).on('click', '#tab-1, #tab-2, #tab-3', function () {
		var triptype = $(this).attr('data-val');
		$('#selectedtype').val(triptype);
	});
	var remove_button = $(".btn-remove-field"); //Fields wrapper
	var max_fields = 5; //maximum input boxes allowed
	var add_button = $(".add_more_field_button"); //Add button ID
	var x = 1; //initlal text box count

	$(add_button).click(function (e) { //on add input button click
		e.preventDefault();
		if (x < max_fields) { //max input box allowed
			x++; //text box increment
			$("#search-field-section-" + x).show();
		}
	});
	$(remove_button).click(function (e) { //on add input button click
		e.preventDefault();
		$("#search-field-section-" + x).hide();x--;
	});
});

jQuery(document).ready(function () {
	var dpmode = '';
	var startDate = new Date(); //=== '0';
	startDate.setDate(startDate.getDate() + parseInt(localStorage.getItem('RequestingClientInfo').split('|')[10]));
	var endDate = new Date(); //==='0';
	var numbrofmont =
		$("#RDepDt").click(function () {

		});
	dpmode = 'depart';
	$("#RDepDt").datepicker({
		minDate: new Date(startDate),
		dateFormat: "yy-mm-dd",
		changeMonth: true,
		numberOfMonths: parseInt(localStorage.getItem('RequestingClientInfo').split('|')[9]),
		beforeShow: function (input, calendar) {
			menuLocked = true;
			dpmode = 'depart';
		},
		beforeShowDay: function (date) {
			var date1 = $.datepicker.parseDate("yy-mm-dd", $("#RDepDt").val());
			var date2 = $.datepicker.parseDate("yy-mm-dd", $("#ArrDt").val());
			return [true, date1 && date2 && ((date.getTime() == date1.getTime()) || (date2 && date >= date1 && date <= date2)) ? "dp-highlight" : ""];
		},
		onClose: function (selectedDate) {
			startDate = selectedDate;
			var date = $(this).datepicker('getDate');
			if (date) {
				date.setDate(date.getDate() + 1);
			}
			$('#ArrDt').datepicker('option', 'minDate', date);
			$('#ArrDt').datepicker('show');
		}
	});
	$("#ArrDt").click(function () {
		dpmode = 'return';

	});
	$("#ArrDt").datepicker({
		dateFormat: "yy-mm-dd",
		minDate: new Date(startDate),
		setDate: new Date(startDate),
		changeMonth: true,
		numberOfMonths: parseInt(localStorage.getItem('RequestingClientInfo').split('|')[9]),
		beforeShow: function () {
			dpmode = 'return';
		},
		beforeShowDay: function (date) {
			var date1 = $.datepicker.parseDate("yy-mm-dd", $("#RDepDt").val());
			var date2 = $.datepicker.parseDate("yy-mm-dd", $("#ArrDt").val());
			return [true, date1 && date2 && ((date.getTime() == date1.getTime()) || (date2 && date >= date1 && date <= date2)) ? "dp-highlight" : ""];
		},
		onClose: function (selectedDate) {
			endDate = selectedDate;
		}
	});
	var nowTemp = new Date();
	var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate(), 0, 0, 0, 0);
	$("#ODepDt").click(function () {
		dpmode = '';
	});
	var checkinO = $('#ODepDt').datepicker({
		dateFormat: "yy-mm-dd",
		minDate: new Date(startDate),
		setDate: new Date(startDate),
		onRender: function (date) {
			return date.valueOf() < now.valueOf() ? 'disabled' : '';
		}
	}).on('changeDate', function (ev) {
		if (ev.date.valueOf() > checkout.date.valueOf()) {
			var newDate = new Date(ev.date)
			newDate.setDate(newDate.getDate() + 1);
			checkout.setValue(newDate);
		};
		checkinO.hide();
		//=== $('#ArrDt')[0].focus();
	})
		.on('show', function (ev) {
			if (ev.date.valueOf() > checkout.date.valueOf()) {
				var newDate = new Date(ev.date)
				newDate.setDate(newDate.getDate() + 1);
				checkout.setValue(newDate);
			};
		}).data('datepicker');

	$("#DepDt1").datepicker({
		dateFormat: "yy-mm-dd",
		minDate: new Date(startDate),
		onSelect: function (date) {
			var date2 = $('#DepDt1').datepicker('getDate');
			date2.setDate(date2.getDate() + 1);
			$('#DepDt2').datepicker('setDate', date2);
			//sets minDate to dt1 date + 1
			$('#DepDt2').datepicker('option', 'minDate', date2);
		}
	});

	$('#DepDt2').datepicker({
		dateFormat: "yy-mm-dd",
		onClose: function () {
			var dt1 = $('#DepDt1').datepicker('getDate');
			var dt2 = $('#DepDt2').datepicker('getDate');
			if (dt2 <= dt1) {
				var minDate = $('#DepDt2').datepicker('option', 'minDate');
				$('#DepDt2').datepicker('setDate', minDate);
			}
			$('#DepDt3').datepicker('option', 'minDate', dt2);
			$('#DepDt3').datepicker('setDate', dt2);
		}
	});
	$('#DepDt3').datepicker({
		dateFormat: "yy-mm-dd",
		minDate: $('#DepDt2').datepicker('getDate')
	});

	/*=== Hotel Car ===*/
	var checkinHotel = $('#checkIn').datepicker({
		onRender: function (date) {
			return date.valueOf() < now.valueOf() ? 'disabled' : '';
		}
	}).on('changeDate', function (ev) {
		if (ev.date.valueOf() > checkoutHotel.date.valueOf()) {
			var newDate = new Date(ev.date)
			newDate.setDate(newDate.getDate() + 1);
			checkoutHotel.setValue(newDate);
		}
		checkinHotel.hide();
		$('#checkOut')[0].focus();
	}).data('datepicker');
	var checkoutHotel = $('#checkOut').datepicker({
		onRender: function (date) {
			return date.valueOf() <= checkinHotel.date.valueOf() ? 'disabled' : '';
		}
	}).on('changeDate', function (ev) {
		checkoutHotel.hide();
	}).data('datepicker');

	var pickUp = $('#Pick-upDate').datepicker({
		onRender: function (date) {
			return date.valueOf() < now.valueOf() ? 'disabled' : '';
		}
	}).on('changeDate', function (ev) {
		if (ev.date.valueOf() > dropOff.date.valueOf()) {
			var newDate = new Date(ev.date)
			newDate.setDate(newDate.getDate() + 1);
			dropOff.setValue(newDate);
		}
		pickUp.hide();
		$('#Drop-OffDate')[0].focus();
	}).data('datepicker');
	var dropOff = $('#Drop-OffDate').datepicker({
		onRender: function (date) {
			return date.valueOf() <= pickUp.date.valueOf() ? 'disabled' : '';
		}
	}).on('changeDate', function (ev) {
		dropOff.hide();
	}).data('datepicker');
	/*=== End of Hotel Car ===*/
	$('#ui-datepicker-div').delegate('.ui-datepicker-calendar td', 'mouseover', function () {
		if ($(this).data('year') == undefined) {
			return;
		}
		if (dpmode == 'depart' && endDate == '0') {
			return;
		}
		if (dpmode == 'return' && startDate == '0') {
			return;
		}
		if (dpmode == '') {
			return;
		}
		var currentDate = $(this).data('year') + '-' + ($(this).data('month') + 1) + '-' + $('a', this).html();
		var defaultDate = currentDate;
		currentDate = $.datepicker.parseDate("yy-mm-dd", currentDate).getTime();
		if (dpmode == 'depart') {
			var StartDate = currentDate;
			var EndDate = $.datepicker.parseDate("yy-mm-dd", endDate == '' ? defaultDate : endDate).getTime();
		}
		else {
			var StartDate = $.datepicker.parseDate("yy-mm-dd", startDate == '' ? defaultDate : startDate).getTime();
			var EndDate = currentDate;
		};
		var count = '';
		$('#ui-datepicker-div td').each(function (index, el) {
			if ($(this).data('year') == undefined) {
				return;
			}
			var currentDate = $(this).data('year') + '-' + ($(this).data('month') + 1) + '-' + $('a', this).html();
			currentDate = $.datepicker.parseDate("yy-mm-dd", currentDate).getTime();
			if (currentDate >= StartDate && currentDate <= EndDate) {
				count++;
				if (count == 1) {
					$(this).css('cursor', 'pointer').attr('data-title', count + ' Day');
				}
				else {
					$(this).css('cursor', 'pointer').attr('data-title', count + ' Days');
				}
				$(this).addClass('dp-highlight')
			}
			else {
				$(this).removeClass('dp-highlight');
				$(this).removeAttr('data-title');
			};
		});
	});

});
$(document).ready(function () {
	selectWidth();
	/*===*/
	$(".search_widget").hide();
	$(".search_widget:first-child").show();
	$(".search_tab li:first-child").addClass("active");
	
	$('.search_tab li').click(function () {
		$('.search_tab li').removeClass("active");
		$(this).addClass("active");
		$(".search_widget").hide();
		var activeTab = $(this).find('a').attr("href");
		$(activeTab).show();
		return false;
	});

	$('.multicity_options').hide();
	$('input[name=radioval]').click(function () {
		if($(this).attr("value")=="R"){
            $('.one_way').fadeIn('fast');
			$('.multicity').fadeIn('fast');
			$('.multicity_options').fadeOut('fast');
        }
		if($(this).attr("value")=="O"){
			$('.one_way').fadeOut('fast');
			$('.multicity_options').fadeOut('fast');
			$('.multicity').fadeIn('fast');
		}
		
		if($(this).attr("value")=="M"){
            $('.multicity').fadeOut('fast');
			$('.one_way').fadeOut('fast');
			$('.multicity_options').fadeIn('fast');
        }
	});
	/*===*/
	
	jQuery(window).scroll(function () {
		jQuery("#DepDt,  #DepDt2, #DepDt3").blur();
	});
	/*===*/
	$("#room2, #room3, #room4, .deleteRoom").hide();
	$('.addRoom').click(function () {
		if($(this).hasClass("room1Opt")){
            $(this).removeClass("room1Opt");
			$(this).addClass("room2Opt");
			$('#room2').fadeIn('fast');
			$('.deleteRoom').fadeIn('fast');
			$('.deleteRoom').addClass("deleteRoom2");
        }
		else if($(this).hasClass("room2Opt")){
            $(this).removeClass("room2Opt");
			$(this).addClass("room3Opt");
			$('#room3').fadeIn('fast');
			$('.deleteRoom').addClass("deleteRoom3");
			$('.deleteRoom').removeClass("deleteRoom2");
        }
		else if($(this).hasClass("room3Opt")){
            $(this).removeClass("room3Opt");
			$(this).addClass("room4Opt");
			$('#room4').fadeIn('fast');
			$('.addRoom').hide();
			$('.deleteRoom').addClass("deleteRoom4");
			$('.deleteRoom').removeClass("deleteRoom3");
        }
	});
	$('.deleteRoom').click(function () {
		if($(this).hasClass("deleteRoom2")){
			$('#room2').fadeOut('fast');
			$('.deleteRoom').removeClass("deleteRoom2");
			$('.deleteRoom').hide();
			$('.addRoom').addClass("room1Opt");
			$('.addRoom').removeClass("room2Opt");
        }
		else if($(this).hasClass("deleteRoom3")){
            $('#room3').fadeOut('fast');
			$('.deleteRoom').addClass("deleteRoom2");
			$('.deleteRoom').removeClass("deleteRoom3");
			$('.addRoom').addClass("room2Opt");
			$('.addRoom').removeClass("room3Opt");
        }
		else if($(this).hasClass("deleteRoom4")){
            $('#room4').fadeOut('fast');
			$('.deleteRoom').addClass("deleteRoom3");
			$('.deleteRoom').removeClass("deleteRoom4");
			$('.addRoom').addClass("room3Opt");
			$('.addRoom').removeClass("room4Opt");
			$('.addRoom').show();
        }
	});

	$(".Drop-off-Location, .same-location").hide();
	$('.PickDropLocation').click(function () {
		if($(this).hasClass("active")){
			$(this).removeClass("active");
			$('.Drop-off-Location').fadeOut('fast');
			$('.same-location').hide();
			$('.different-location').fadeIn('fast');
			
        }
		else {
            $(this).addClass("active");
			$('.Drop-off-Location').fadeIn('fast');
			$('.different-location').hide();
			$('.same-location').fadeIn('fast');
        }
	});

	$(".CarOption, .less-options").hide();
	$('.car-options').click(function () {
		if($(this).hasClass("active")){
			$(this).removeClass("active");
			$('.CarOption').fadeOut('fast');
			$('.less-options').hide();
			$('.more-options').fadeIn('fast');
			
        }
		else {
            $(this).addClass("active");
			$('.CarOption').fadeIn('fast');
			$('.more-options').hide();
			$('.less-options').fadeIn('fast');
        }
	});
				
	$('[data-toggle="tooltip"]').tooltip();
    /*===*/
	var noOfMonths = parseInt(localStorage.getItem('RequestingClientInfo').split('|')[9] == null ? 3 :localStorage.getItem('RequestingClientInfo').split('|')[9]);
	$(window).resize(function () {
		selectWidth();
		var wd1 = $(window).width();
		if (wd1 < 768) {
			$('#RDepDt').datepicker('option', 'numberOfMonths', 1);
			$('#DepDt1').datepicker('option', 'numberOfMonths', 1);
			$('#DepDt2').datepicker('option', 'numberOfMonths', 1);
			$('#DepDt3').datepicker('option', 'numberOfMonths', 1);
			$('#ODepDt').datepicker('option', 'numberOfMonths', 1);
			$('#ArrDt').datepicker('option', 'numberOfMonths', 1);

		} else {
			$('#RDepDt').datepicker('option', 'numberOfMonths', noOfMonths);
			$('#DepDt1').datepicker('option', 'numberOfMonths', noOfMonths);
			$('#DepDt2').datepicker('option', 'numberOfMonths', noOfMonths);
			$('#DepDt3').datepicker('option', 'numberOfMonths', noOfMonths);
			$('#ODepDt').datepicker('option', 'numberOfMonths', noOfMonths);
			$('#ArrDt').datepicker('option', 'numberOfMonths', noOfMonths);
		}
	});
});

$(document).ready(function(){
	$(".multiButtonAdd").click(function () {
		debugger;
		if($('#MBarr1').val() != '')
		{
			$('#MBdep2').val($('#MBarr1').val().trim());
		}
		if($('#MBarr2').val() != '')
		{
			$('#MBdep3').val($('#MBarr2').val().trim());
			$('#MBarr3').val('');
		}
		if($(this).parentsUntil(".multiOneActive")){
			$(".multiClass").children().find(".deleteRoom").show();
		}
		var firstTrue = $(".multicity_options").children(".multiOne").hasClass("multiOneActive");
		if(firstTrue === false){
		$(".multicity_options").children(".multiOne").addClass("multiOneActive");
			$(".multiButtonDel").removeClass("removeDelButton");
		$(".multiButtonAdd").removeClass("removeAddButton");
		}
		else{
			$(".multicity_options").children(".multiTwo").addClass("multiOneActive");
			$(".multiButtonAdd").addClass("removeAddButton");
			$(".multiButtonDel").removeClass("removeDelButton");
		}
	});
	$(".multiButtonDel").click(function () {
		if( $(".multicity_options").children(".multiTwo").hasClass("multiOneActive")){
			$(".multicity_options").children(".multiTwo").removeClass("multiOneActive");
			$(".multiButtonAdd").removeClass("removeAddButton");
			$(".multiButtonDel").removeClass("removeDelButton");
		}
		else{
			$(".multicity_options").children(".multiOne").removeClass("multiOneActive");
			$(".multiButtonDel").addClass("removeDelButton");
			$(".multiButtonAdd").removeClass("removeAddButton");
		}
	});

});

$(function () {
	$('.addAdults').click(function add() {
		debugger;
        var $rooms = $(".noOfAdults");
        var a = $rooms.val();
        if (a < 9) {
			a++;
            $(".subAdults").prop("disabled", !a);
            $rooms.val(a);
        }
        AdultInfantValidation();
    });
    $(".subAdults").prop("disabled", !$(".noOfAdults").val());
    $('.subAdults').click(function subst() {
        var $rooms = $(".noOfAdults");
        var b = $rooms.val();
        if (b > 1) {
			b--;
            $rooms.val(b);
        }
        else {
			$(".subAdults").prop("disabled", true);
        }
        AdultInfantValidation();
    });
    $('.addSeniors').click(function add() {
        var $rooms = $(".noOfSeniors");
        var a = $rooms.val();
        if (a < 9) {
			a++;
            $(".subSeniors").prop("disabled", !a);
            $rooms.val(a);
        }
    });
    $(".subSeniors").prop("disabled", !$(".noOfSeniors").val());
    $('.subSeniors').click(function subst() {
        var $rooms = $(".noOfSeniors");
        var b = $rooms.val();
        if (b >= 1) {
			b--;
            $rooms.val(b);
        }
        else {
			$(".subSeniors").prop("disabled", true);
        }
    });
    $('.addChildrens').click(function add() {
        var $rooms = $(".noOfChildrens");
        var $adultrooms = $(".noOfAdults");
        var a = $rooms.val();
        var b = $adultrooms.val();
        if (a < b) {
			a++;
            $(".subChildrens").prop("disabled", !a);
            $rooms.val(a);
        }
    });
    $(".subChildrens").prop("disabled", !$(".noOfChildrens").val());
    $('.subChildrens').click(function subst() {
        var $rooms = $(".noOfChildrens");
        var b = $rooms.val();
        if (b >= 1) {
			b--;
            $rooms.val(b);
        }
        else {
			$(".subChildrens").prop("disabled", true);
        }
    });
    $('.addInfants').click(function add() {
        var $rooms = $(".noOfInfants");
        var $adultrooms = $(".noOfAdults");
        var b = $adultrooms.val();
        var a = $rooms.val();
        if (a < b) {
			a++;
            $(".subInfants").prop("disabled", !a);
            $rooms.val(a);
        }
        AdultInfantValidation();
    });
    $(".subInfants").prop("disabled", !$(".noOfInfants").val());
    $('.subInfants').click(function subst() {
        var $rooms = $(".noOfInfants");
        var b = $rooms.val();
        if (b >= 1) {
			b--;
            $rooms.val(b);
        }
        else {
			$(".subInfants").prop("disabled", true);
        }
        AdultInfantValidation();
    });
});
function AdultInfantValidation() {
	try {
		if ($('.noOfAdults').val() < $(".noOfInfants").val()) {
			ConfirmBootBox("Successfully", "Number of infants cannot be more than number of adults, incase you want to accompany more infants, please call agency.", 'App_Warning', initialCallbackYes, initialCallbackNo);
			return false;
		}
		return true;
	}
	catch (e) {
		var error = e;
		error = e;
	}
}
$(function () {
	debugger;
	var seltext = $('#hdnAirlineText').val();;
	var airlineval = $('#hdnAirlineVal').val();

	$('#AirlineText').val(seltext);
	$('#OAirlineText').val(seltext);
	$('#MAirlineText').val(seltext);

	$("#AirlineText,#OAirlineText,#MAirlineText").change(function () {
		debugger;
		/*===
		seltext = $('option:selected', this).text();
		var selval = $('option:selected', this).val();
		
		
		$('#Airline').val(selval);
		$('#OAirline').val(selval);
		$('#MAirline').val(selval);
		===*/
	});

});
function selectWidth() {
	$(".select_option").find("select").css('width', '');
	$(".select_option").each(function () {
		var selWidth = $(this).width();
		$(this).find("select").css('width', (selWidth - 1));
	});
}

function GetCurrentTime() {
	var today = new Date(),
	h = checkTime(today.getHours()),
	m = checkTime(today.getMinutes()),
	s = checkTime(today.getSeconds());
	return h + ":" + m + ":" + s;
}
function checkTime(i) {
	return (i < 10) ? "0" + i : i;
}

function OnLoadGetDataList() {
	try {
		debugger;
		var RequestDomain = localStorage.getItem('RequestingClientInfo').split('|')[2];
		var selectiontype = $("#selectedtype").val();
		var dataonly = ($('#'+selectiontype+'directOnly').is(':checked')==true?"ON":"OFF");
		if (selectiontype == "R") {
		dataonly = ($('#directOnly').is(':checked') == true ? "ON" : "OFF");
		}

		if($('#DepDt3').val()==undefined){
		$('#DepDt3').val("");
		}
		if($('#DepDt2').val()==undefined){
		$('#DepDt2').val("");
		}
		if($('#DepDt1').val()==undefined){
		$('#DepDt1').val("");
		}
		$("#BookingType,#OBookingType,#MBookingType").val("A");
		$("#SearchType,#OSearchType,#MSearchType").val(selectiontype);
		$("#DirectOnly,#ODirectOnly,#MDirectOnly").val(dataonly);
		$("#DomainName,#ODomainName,#MDomainName").val(RequestDomain);
		$("#DefaultCompanyId,#ODefaultCompanyId,#MDefaultCompanyId").val(localStorage.getItem('RequestingClientInfo') != null ? localStorage.getItem('RequestingClientInfo').split('|')[5] : 0);
		$("#CompanyTypeId,#OCompanyTypeId,#MCompanyTypeId").val(localStorage.getItem('RequestingClientInfo') != null ? localStorage.getItem('RequestingClientInfo').split('|')[3] : 0);
		$("#ClientRequestId,#OClientRequestId,#MClientRequestId").val(localStorage.getItem('RequestingClientInfo').split('|')[1]);
		$("#AuthToken,#OAuthToken,#MAuthToken").val(localStorage.getItem('RequestingClientInfo').split('|')[4]);
		$("#ReferrerUrl,#OReferrerUrl,#MReferrerUrl").val(window.location.href);
		$("#RequestingClientInfo,#ORequestingClientInfo,#MRequestingClientInfo").val(localStorage.getItem('RequestingClientInfo'));

	} catch (e) {
	var error = e;
	error = error;
	}
}
