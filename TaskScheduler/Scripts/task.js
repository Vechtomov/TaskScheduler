$(document).ready(function () {

    $("#sortable").sortable(
        {
            cancel: '.task',
            cursor: 'pointer'
        }
    );
    $("#sortable").disableSelection();

    $(".createTask").click(function () {
        $('#createDatetimePicker').data("DateTimePicker").minDate($('#createDatetimePicker').data("DateTimePicker").date());

        $("#createModal").modal('show');
    });

    $('#createDatetimePicker').datetimepicker({
        locale: 'ru'
    });

    $('#editDatetimePicker').datetimepicker({
        locale: 'ru'
    });


    // Редактирование задачи
    $('body').delegate(".taskEdit", 'click', function () {
        var taskId = +$(this).data('taskid');

        var id = "task" + taskId;
        var name = $("#" + id + " .taskName p").text().trim();
        var description = $("#" + id + " .taskDescription p").text().trim();
        var date = $("#" + id + " .taskDate").text().trim();
        var time = $("#" + id + " .taskTime").text().trim();
        var status = $("#" + id + " .taskStatus p").text().trim();

        $('#editDatetimePicker').data("DateTimePicker").minDate($('#editDatetimePicker').data("DateTimePicker").date());

        $("#editId").val(taskId);
        $("#editName").val(name);
        $("#editDescription").val(description);
        $("#editDatetimePicker").val(date + " " + time);
        $("#editStatus").val(status);

        $("#editModal").modal('show');
    });


    // Удаление задачи
    $('body').delegate(".taskDelete", 'click',function () {
        var id = +$(this).data('taskid');

        $("#deleteModal").modal('show');

        $("#deleteModal .modal-footer .btn-primary").click(function () {
            $.ajax({
                url: "/Task/Delete",
                data: {
                    taskId: id
                },
                type: 'POST',
                complete: function (data) {
                    alert("Запрос отправлен.");
                    $("#deleteModal").prop("disabled", true);
                },
                success: function (data) {
                    $("#deleteModal").prop("disabled", false);
                    $("#deleteModal").modal('hide');

                    if(data == "Success")
                        location.reload();
                }
            });
        });
    });
});

function OnCreateSuccess(data) {
    $("#createModal .btn-primary").prop("disabled", false);
    $("#createModal").modal('hide');

    if (data == 'Success') {
        location.reload();
    }
}

function OnEditSuccess(data) {
    $("#editModal .btn-primary").prop("disabled", false);
    $("#editModal").modal('hide');

    if (data == 'Success') {
        location.reload();
    }
}

function OnCreateComplete() {
    alert("Запрос отправлен.");
    $("#createModal .btn-primary").prop("disabled", true);
}

function OnEditComplete() {
    alert("Запрос отправлен.");
    $("#editModal .btn-primary").prop("disabled", true);
}