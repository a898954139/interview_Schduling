var routeURL = location.protocol + "//" + location.host;
$(document).ready(function () {
    $("#appointmentDate").kendoDateTimePicker({
        value: new Date(),
        dateinput: false
    });
    InitializeCalendar();
});

function InitializeCalendar() {
    try {

        var calendarEl = document.getElementById('calendar');
        if (calendarEl != null) {
            var calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev, next, today',
                    center: 'title',
                    right: 'dayGridMonth, timeGridWeek, timeGridDay'
                },
                selectable: true,
                editable: false,
                select: function (event) {
                    onShowModal(event, null);
                }
            });
            calendar.render();
        }

    }
    catch (e) {
        alert(e);
    }
}

function onShowModal(event, isEventDetail) {
    $("#appointmentInput").modal("show");
}

function onCloseModal(event) {
    $("#appointmentInput").modal("hide");
}

function onSubmitForm() {
    if (checkValidation()) {
        var requestData = {
            Id: parseInt($("#id").val()),
            Title: $("#title").val(),
            Discription: $("#discription").val(),
            StartDate: $("#appointmentDate").val(),
            Duriation: $("#duriation").val(),
            DoctorId: $("#doctorId").val(),
            PatientId: $("#patientId").val(),
        };

        $.ajax({
            url: routeURL + '/api/Appointment/CalendarData',
            method: 'POST',
            data: JSON.stringify(requestData),
            contentType: 'application/json',
            success: function (response) {
                if (response.status == 1) {
                    $.notify(response.message, "success");
                    oncloseModal();
                }
                else {
                    $.notify(response.message, "error")
                }
            },
            error: function (xhr) {
                $.notify("Error", "error")
            }
        });
    }
}

function checkValidation() {
    //var isValid = true;
    //if title is undefined or title is empty string
    //set isValid to false
    //if ($("#title").val() === undefined || $("#title").val() === "") {
    //    isValid = false;
    //    $("#title").addClass('error');
    //} else {
    //    $("#title").removeClass('error');
    //}
    //if ($("#appointmentDate").val() === undefined || $("#appointmentDate").val() === "") {
    //    isValid = false;
    //    $("#appointmentDate").addClass('error');
    //} else {
    //    $("#appointmentDate").removeClass('error');
    //}
    //return isValid;

    if ($("#title").val() === undefined || $("#title").val() === "") {
        $("#title").addClass('error');
        return false;
    }
    $("#title").removeClass('error');
    if ($("#appointmentDate").val() === undefined || $("#appointmentDate").val() === "") {
        $("#appointmentDate").addClass('error');
        return false;
    } $("#appointmentDate").removeClass('error');
    return true;
}