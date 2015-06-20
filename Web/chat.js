var _ws;

function sendMessage() {
    _ws.send($("#message").val());
}

function registerName() {
    _ws.send("//registerName:" + $("#username").val());
}

$("document").ready(function() {
    _ws = new WebSocket("ws://localhost:8181");
    _ws.onopen = function() {
    };
    _ws.onclose = function() {
    };
    _ws.onmessage = function(message) {
        $(".messages").append(message.data + "<br />");
    };
});
