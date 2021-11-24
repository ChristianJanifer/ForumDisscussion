$(document).ready(function () {
    $('#tableDiscussion').DataTable({
        'ajax': {
            'url': "/Discussions/GetAll",
            'order': [[0, 'asc']],
            'dataSrc': ''
        },
        'columns': [
            {
                data: 'no', name: 'id', render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "disId"
            },
            {
                "data": "title"
            },
            {
                "data": "content"
            },
            {
                "data": "dateDis"
            },
            {
                "data": "statusComt"
            },
            {
                "data": "userId"
            },
            {
                "data": "categoryId"
            },
            {
                "data": "typeId"
            },
            {
                "data": "status"
            },
            {
                "data": " ",
                "render": function (data, type, row, meta) {
                    var button = '<td>' +
                        '<button type="button" onclick="deleteDiscussion(' + row['disId'] + ');" class="btn btn-danger text-center"><i class="fa fa-trash"></i></button>' +
                        '</td > ';
                    return button;
                }
            }
        ]
    });
});

$(document).ready(function () {

    $("#formDiscussion").validate({
        rules: {
            title: "required",
            content: "required",
            dateDis: "required",
            statusComt: "required",
            userId: "required",
            categoryId: "required",
            typeId: "required",
            status: "required"
        },
        messages: {
            title: "Please input",
            content: "Please input",
            dateDis: "Please input ",
            statusComt: "Please input",
            userId: "Please input",
            categoryId: "Please input",
            typeId: "Please input ",
            status: "Please input "
        },
        submitHandler: function () {
            var obj = new Object();
            obj.Title = $('#title').val();
            obj.Content = $('#content').val();
            obj.DateDis = $('#dateDis').val();
            obj.StatusComt = $('#statusComt').val();
            obj.UserId = $('#userId').val();
            obj.CategoryId = $('#categoryId').val();
            obj.TypeId = $('#typeId').val();
            obj.Status = $('#status').val();

            console.log(obj);
            $.ajax({
                url: "/Discussions/Discussion",
                'type': 'POST',
                'data': { entity: obj },
                'dataType': 'json',
            }).done((result) => {
                if (result == 200) {
                    swal({
                        title: "Good job!",
                        text: "Data Berhasil Ditambahkan!!",
                        icon: "success",
                        button: "Okey!",
                    }).then(function () {
                        window.location = "/Discussions";
                    });

                    $('#title').val("");
                    $('#content').val("");
                    $('#dateDis').val("");
                    $('#statusComt').val("");
                    $('#userId').val("");
                    $('#categoryId').val("");
                    $('#typeId').val("");
                    $('#status').val("");

                } else if (result == 400) {
                    swal({
                        title: "Failed!",
                        text: "Data Gagal Dimasukan!!",
                        icon: "error",
                        button: "Close",
                    });
                }
            }).fail((error) => {
                swal({
                    title: "Failed!",
                    text: "Data Gagal Dimasukan!!",
                    icon: "error",
                    button: "Close",
                });
            });
        }
    });
});

function deleteDiscussion(DisId) {
    swal({
        title: "Are you sure?",
        text: "Hapus Data Ini !!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: "/Discussions/Delete/" + DisId,
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: "DELETE",
                dataType: "json",
                data: { "": DisId },
                success: function (result) {
                    swal({
                        title: "Good job!",
                        text: "DATA BERHASIL DIHAPUS!!",
                        icon: "success",
                        button: "Okey!",
                    }).then(function () {
                        window.location = "/Discussions";
                    });
                },
                error: function (errormessage) {
                    swal({
                        title: "Failed!",
                        text: "DATA GAGAL DIHAPUS!!",
                        icon: "error",
                        button: "Close",
                    });
                }
            });
        } else {
            swal("DATA GAGAL DIHAPUS!!");
        }
    });
}