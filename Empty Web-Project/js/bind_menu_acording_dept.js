$(document).ready(function () {
    $('#spn_academin').click(function () {
        $('#for_Hr').css('display', 'none');
        $('#for_logistic').css('display', 'none');
        $('#for_academic').css('display', 'block');
    });
});

$(document).ready(function () {
    $('#spn_hr').click(function () {
        $('#for_Hr').css('display', 'block');
        $('#for_logistic').css('display', 'none');
        $('#for_academic').css('display', 'none');
    });
});

$(document).ready(function () {
    $('#spn_logistic').click(function () {
        $('#for_Hr').css('display', 'none');
        $('#for_logistic').css('display', 'block');
        $('#for_academic').css('display', 'none');
    });
});


