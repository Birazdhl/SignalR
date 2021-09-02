"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/SignalRClientHub").build();


connection.start();

connection.on("BookRespectiveTickets", function (id) {
    $(id).removeClass('onHoldBooking');
    $(id).removeClass('seatNumber');
    $(id).addClass('bookSeatNumber');

});

connection.on("ResetAllTickets", function (id) {
    $('.seats').removeClass();
    $("#main").children('div').addClass("seats");
    $("#main").children('div').addClass("seatNumber");

});

