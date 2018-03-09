$(document).ready(function () {
    $("#sortable").sortable(
        {
            cancel: '.task',
            cursor: 'pointer'
        }
    );
    $("#sortable").disableSelection();

    $(".createTask").click(function () {
        $("#createModal").modal('show');
    });

    $('#editDatetimePicker').datetimepicker({
        locale: 'ru'
    });

    $('body').delegate(".taskEdit", 'click', function () {
        var taskId = +$(this).data('taskid');

        var id = "task" + taskId;
        var name = $("#" + id + " .taskName p").text().trim();
        var description = $("#" + id + " .taskDescription p").text().trim();
        var date = $("#" + id + " .taskDate").text().trim();
        var time = $("#" + id + " .taskTime").text().trim();

        $("#editId").val(taskId);
        $("#editName").val(name);
        $("#editDescription").val(description);
        $("#editDatetimePicker").val(date + " " + time);

        $("#editModal").modal('show');

        //$("#editModal .modal-footer .btn-primary").click(function () {
            

        //    $.ajax({
        //        url: "/Task/Edit",
        //        data: {
        //            taskId: id
        //        },
        //        type: 'POST',
        //        success: function (data) {

        //            $("#deleteModal").modal('hide');

        //            if (data == "Success")
        //                location.reload();
        //        }
        //    });
        //});
    });

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
                success: function (data) {

                    $("#deleteModal").modal('hide');

                    if(data == "Success")
                        location.reload();
                }
            });
        });
    });
});

function OnCreateSuccess(data) {
    $("#createModal").modal('hide');

    if (data == 'Success') {
        location.reload();
    }
}

function OnEditSuccess(data) {
    $("#editModal").modal('hide');

    if (data == 'Success') {
        location.reload();
    }
}