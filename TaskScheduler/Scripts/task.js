$(document).ready(function () {
    InitSortable();

    InitDatetimePickers();

    InitHandlers();

    Timer(10000);
});


// Эти методы используются хелперами
function BeforeCreateSend() {
    $("#createModal .btn-primary").button('loading');
}

function BeforeEditSend() {
    $("#editModal .btn-primary").button('loading');
}

function OnCreateSuccess(data) {
    $("#createModal .btn-primary").button('reset');
    $("#createModal").modal('hide');

    if (data != "Success") {
        alert(data);
    } else {
        location.reload();
    }
}

function OnEditSuccess(data) {
    if (data != "Success") {
        alert(data);
    } else {
        location.reload();
    }
}

function OnCreateComplete() {
    $("#createModal .btn-primary").button('reset');
    $("#createModal").modal('hide');
}

function OnEditComplete() {
    $("#editModal .btn-primary").button('reset');
    $("#editModal").modal('hide');
}

// Таймер для проверки времени задач
function Timer(interval) {
    var timerId = setTimeout(function tick() {
        var ids = $('.task');
        var times = $('.task .taskTime');
        var dates = $('.task .taskDate');

        var date = new Array(dates.length);

        for (var i = 0; i < dates.length; i++) {
            var day = dates[i].innerText.substring(0, 2);
            var month = dates[i].innerText.substring(3, 5) - 1;
            var year = dates[i].innerText.substring(6);
            var hours = times[i].innerText.substring(0, 2);
            var minutes = times[i].innerText.substring(3);

            var date = new Date(year, month, day, hours, minutes);

            if ((date - new Date()) < 0) {
                var id = ids[i].id.substring(4);
                var status = $("#task" + id + " .taskStatus p").text().trim();

                if (status == 'Просрочена') {
                    continue;
                }

                TimeIsOverHandler(id);
            }
        }

        timerId = setTimeout(tick, interval);
    }, interval);
}

// Обработчик просроченной задачи
function TimeIsOverHandler(id) {
    $.ajax({
        url: "/Task/UpdateTask",
        type: "POST",
        data: {
            taskId: +id
        }
    }).done(function (data) {
        if (data == "Success") {

            location.reload();

            
        }
        else {
            alert(data);
        }
    }).fail(function () {
        alert("fail");
    });

    
}


// Сортируемый список
function InitSortable() {
    $("#sortable").sortable(
        {
            cancel: '.task',
            cursor: 'pointer'
        }
    );
    $("#sortable").disableSelection();
}

// DatetimePickers
function InitDatetimePickers() {
    $('#createDatetimePicker').datetimepicker({
        locale: 'ru'
    });

    $('#editDatetimePicker').datetimepicker({
        locale: 'ru'
    });
}

// Обработчики
function InitHandlers() {
    // Отрисовка задач
    //var ids = $(".task");
    //for (var i = 0; i < ids.length; i++) {
    //    var id = ids[i].id.substring(4);
    //    var status = $("#task" + id + " .taskStatus p").text().trim();

    //    if (status == 'Просрочена') {
    //        $("#task" + id).parent().addClass('overdue');
    //    }
    //}
    
    // Создание задачи
    $(".createTask").click(function () {
        $('#createDatetimePicker').data("DateTimePicker").minDate($('#createDatetimePicker').data("DateTimePicker").date());

        $("#createModal").modal('show');
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
    $('body').delegate(".taskDelete", 'click', function () {
        var id = +$(this).data('taskid');

        $("#deleteModal").modal('show');
        $("#deleteModal").on('shown.bs.modal', function () {
            $("#deleteModal .btn-primary").focus();
        });

        $("#deleteModal .btn-primary").click(function () {
            var btn = $(this);

            btn.button('loading');
            $.ajax({
                url: "/Task/Delete",
                data: {
                    taskId: id
                },
                type: 'POST',
                success: function (data) {
                    $("#deleteModal").modal('hide');

                    if (data != "Success") {
                        alert(data);
                    } else {
                        location.reload();
                    }
                }
            }).always(function () {
                btn.button('reset');
            });
        });
    });
}