$(document).ready(function () {
    setTimeout(function () {   //calls click event after a certain time
        dismissAlerts();
    }, 8000);
});

function dismissAlerts() {
    var alerts = $('[name="alert"]');
    console.log("ready!");
    for (var i = 0; i < alerts.length; i++) {
        var alert = alerts[i];
        alert.remove();
        // alert.hide('slow', function () {alert.remove(); });
    }
}