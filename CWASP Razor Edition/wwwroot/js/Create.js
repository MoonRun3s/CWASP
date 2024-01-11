"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/indexHub").build();

document.getElementById("createButton").addEventListener("click", function (event) {
    // Tell the SignalR hub to invoke the "RefreshDatabaseView" function.
    connection.invoke("UpdateDatabaseView").catch(function (err) {
        return console.error(err.toString());
    });

    console.log("SignalR detected an event.");
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});