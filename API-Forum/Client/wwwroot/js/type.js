$(document).ready(function () {
    $('#tableType').DataTable({
        'ajax': {
            'url': "/TypeDiscussions/GetAll",
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
                "data": "typeId"
            },
            {
                "data": "typeName"
            },
            {
                "data": " ",
                "render": function (data, type, row, meta) {
                    var button = '<td>' +
                        '<button type="button" onclick="deleteType(' + row['typeId'] + ');" class="btn btn-danger text-center"><i class="fa fa-trash"></i></button>' +
                        '</td > ';
                    return button;
                }
            }
        ]
    });
});

$(document).ready(function () {
    $("#formType").validate({
        rules: {
            typeName: "required"
        },
        messages: {
            typeName: "Please input Type Name"
        },
        submitHandler: function () {
            var obj = new Object();
            obj.TypeName = $('#typeName').val();
            console.log(obj);
            $.ajax({
                url: "/TypeDiscussions/TypeDiscussion",
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
                        window.location = "/TypeDiscussions";
                    });
                    $('#typeName').val("");
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

function deleteType(TypeId) {
    swal({
        title: "Are you sure?",
        text: "Hapus Data Ini !!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: "/TypeDiscussions/Delete/" + TypeId,
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: "DELETE",
                dataType: "json",
                data: { "": TypeId },
                success: function (result) {
                    swal({
                        title: "Good job!",
                        text: "DATA BERHASIL DIHAPUS!!",
                        icon: "success",
                        button: "Okey!",
                    }).then(function () {
                        window.location = "/TypeDiscussions";
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