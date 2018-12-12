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
    }
}

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#blah').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$("#file").change(function () {
    readURL(this);
});