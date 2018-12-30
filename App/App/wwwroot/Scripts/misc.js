$(document).ready(function () {
    $("#myAnc").click(function () {
        alert("Handler for .click() called.");
    });

    $("#settingsId").click(function () {
        document.getElementById("div_1").innerHTML = 5000;
    });

    $("#settingsId3").click(function () {
        document.getElementById("div_1").innerHTML = 7000;
    });
});

function myFunction() {
    let d = new Date();
    document.getElementById("div_1").innerHTML = 1000;
    return true
}

function move() {
    var elem = document.getElementById("myBar");
    var msg = document.getElementById("progressbar");
    var width = 1;
    var id = setInterval(frame, 100);
    function frame() {
        if (width >= 100) {
            clearInterval(id);
        } else {
            width++;
            elem.style.width = width + '%';
            msg.innerHTML = width + '%';
        }
    }
}
