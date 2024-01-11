"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/indexHub").build();

// Run function when told to by the SignalR hub.
connection.on("RefreshDatabaseView", function () {
    // Refresh the page.
    Location.reload();
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});