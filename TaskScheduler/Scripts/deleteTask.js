$(document).ready(function () {
    $('body').delegate(".editDelete a:last-child", 'click',function () {
        var id = +$(this).data('taskid');

        $("#deleteModal").modal('show');

        $(".modal-footer .btn-primary").click(function () {
            $.ajax({
                url: "/Task/Delete",
                data: {
                    taskId: id
                },
                type: 'POST',
                success: function (data) {
                    $("#deleteModal").modal('hide');

                    if(data == "success")
                        location.reload();
                },
                complete: function () {
                }
            });
        });
    });
});