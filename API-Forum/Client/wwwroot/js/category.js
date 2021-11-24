﻿$(document).ready(function () {
    $('#tableCategory').DataTable({
        'ajax': {
            'url': "/Categories/GetAll",
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
                "data": "categoryId"
            },
            {
                "data": "categoryName"
            },
            {
                "data": " ",
                "render": function (data, type, row, meta) {
                    var button = '<td>' +
                        '<button type="button" onclick="deleteCategory(' + row['categoryId'] + ');" class="btn btn-danger text-center"><i class="fa fa-trash"></i></button>' +
                        '</td > ';
                    return button;
                }
            }
        ]
    });
});

$(document).ready(function () {

    $("#formCategory").validate({
        rules: {
            categoryName: "required"
        },
        messages: {
            categoryName: "Please input Category Name"
        },
        submitHandler: function () {
            var obj = new Object();
            obj.CategoryName = $('#categoryName').val();
            console.log(obj);
            $.ajax({
                url: "/Categories/Category",
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
                        window.location = "/Categories";
                    });

                    $('#categoryName').val("");
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

function deleteCategory(CategoryId) {
    swal({
        title: "Are you sure?",
        text: "Hapus Data Ini !!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: "/Categories/Delete/" + CategoryId,
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: "DELETE",
                dataType: "json",
                data: { "": CategoryId },
                success: function (result) {
                    swal({
                        title: "Good job!",
                        text: "DATA BERHASIL DIHAPUS!!",
                        icon: "success",
                        button: "Okey!",
                    }).then(function () {
                        window.location = "/Categories";
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