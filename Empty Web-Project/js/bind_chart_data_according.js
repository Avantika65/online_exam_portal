$(document).ready(function () {
    $("#today_academic").click(function () {
        var json_data = JSON.stringify({ 'from_date': '1900-01-01', 'to_date': '1900-01-01', 'daytype': 'today' });
        alert(json_data);
        $.ajax({
            type: "POST",
            url: "http://localhost:1067/E-SIM_NGI/Faculty/FacultyDashboard.aspx/bind_chart2",
            data: json_data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (responseData) {
                $("#count1").fadeIn(300);
                alert(responseData);
            }
        });
        alert("Ok");
    });

    $("#lstsevenday").click(function () {
        var json_data = JSON.stringify({ 'from_date': '1900-01-01', 'to_date': '1900-01-01', 'daytype': 'today' });
        alert(json_data);
        $.ajax({
            type: "POST",
            url: "Faculty/FacultyDashboard.aspx/bind_chart1",
            data: json_data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (responseData) {
            alert(responseData);
                $("#count1").fadeIn(300);
            }
        });
        alert("Ok");
    });

    $("#lstmonth").click(function () {
        var json_data = JSON.stringify({ 'from_date': '1900-01-01', 'to_date': '1900-01-01', 'daytype': 'today' });
        alert(json_data);
        $.ajax({
            type: "POST",
            url: "Faculty/FacultyDashboard.aspx/bind_chart1",
            data: json_data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (responseData) {
                $("#count1").fadeIn(300);
                alert(responseData);
            }
        });
        alert("Ok");
    });

});


  
