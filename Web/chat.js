var _ws;

$("document").ready(function() {
    $(".sendMessage").submit(function() {
        _ws.send($("#message").val());
        $("#message").val("");
        return false;
    });

    $(".registerName").submit(function() {
        _ws.send("//registerName:" + $("#username").val());
        $(".registerName").hide();
        $(".sendMessage").removeClass("hidden");
        $("#message").focus();
        return false;
    });

    _ws = new WebSocket("ws://localhost:8181");
    _ws.onopen = function() {
    };
    _ws.onclose = function() {
    };
    _ws.onmessage = function(message) {
        $(".messages").append(message.data + "<br />");
    };
});
