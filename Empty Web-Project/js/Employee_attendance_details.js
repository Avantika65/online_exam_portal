window.onload = bind_month;
function bind_month() {
            Calender_details.bind_attendace_data(valuenumber);
}

function valuenumber(result) {
    var frmvalue = document.getElementById('Div4').innerHTML = result;
}