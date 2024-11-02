
$(function () {
    'use strict';
    $('#RBdep1,  #RBarr1, #OBdep1, #OBarr1, #MBdep1, #MBarr1, #MBdep2, #MBarr2, #MBdep3, #MBarr3, #hotelDestination').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '../../air/Quotes/GetAirlines/', //==='/Quotes/GetAirport/', 
                data: "{ 'prefix': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    debugger;
                    response($.map(data, function (item) {
                        return item;
                    }))
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        select: function (e, i) {
            //==  $("#hfCustomer").val(i.item.val);
        },
        minLength: 3,
        delay: 0
    });

    $('#AirlineText,#OAirlineText,#MAirlineText').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '../../air/Quotes/GetAirlines/', //==='/Quotes/GetAirlines/', 
                data: "{ 'prefix': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    debugger;
                    response($.map(data, function (item) {
                        debugger;
                        return item;
                    }))
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                },
                
            });
        },
        select: function (e, i) {
            $('#Airline').val(i.item.val);
            $('#OAirline').val(i.item.val);
            $('#MAirline').val(i.item.val);
        },
        minLength: 2,
        delay: 0
    });

});



