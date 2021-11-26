$(document).ready(function () {
    $('#tableUser').DataTable({
        'ajax': {
            'url': "GetLanding",
            'dataSrc': ''
        },
        'columns': [
            {
                "data": "disId",
            },
            {
                "data": "title",
            },
            {
                "data": "content",
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    var date = row['dateDis'].substr(0, 10);
                    return date;
                }
            },
            {
                "data": "categoryName",
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['firstName'] + ' ' + row['lastName'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    var button = '<td> <button onclick="getCom(' + row['disId'] + ');" class="btn btn-primary btn-sm text-center" data-toggle="modal" data-target="#exampleModal">Click Comment </button></td>';
                    return button;
                }
            }
        ]
    });

    $('#tableMember').DataTable({
        'ajax': {
            'url': "Users/GetProfile",
            'dataSrc': ''
        },
        'columns': [
            {
                "data": "userId",
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['firstName'] + ' ' + row['lastName'];
                }
            },
            {
                "data": "email",
            },
            {
                'data': '',
                'render': function (data, type, row, meta) {
                    var date = row['birthDate'].substr(0, 10);
                    var newDate = date.split('-');
                    return newDate[2] + '-' + newDate[1] + '-' + newDate[0];
                }
            },
            {
                'data': '',
                'render': function (data, type, row, meta) {
                    if (row['gender'] == 0) {
                        return 'Male';
                    } else {
                        return 'Female';
                    }
                }
            },
            {
                'data': '',
                'render': function (data, type, row, meta) {
                    if (row['phone'].substr(0, 1) == '0') {
                        return '+62' + row['phone'].substr(1);
                    }
                    else {
                        return '+62' + row['phone'];
                    }
                }
            },
            {
                "data": " ",
                "render": function (data, type, row, meta) {
                    var button = '<td>' +
                        '<button type="button" onclick="deleteUser(' + row['userId'] + ');" class="btn btn-danger text-center"><i class="fa fa-trash"></i></button>' +
                        '</td > ';
                    return button;
                }
            }
        ]
    });
});


function getCom(id) {
    listSerah = "";
    listCo = "";
    listDa = "";
    listFn = "";
    $.ajax({
        url: "GetReplybyId/" + id,
        success: function (result) {
            console.log(result);

            for (let i = 0; i < result.length; i++) {
                listCo += `<p>${result[i].content}</p>`;
                listDa += `<p>${result[i].dateCom.substr(0, 10)}</p>`;
                listFn += `<p>${result[i].firstName}</p>`;
            }

            listSerah += `  <div class="container-fluid">
                                <div class="row">
                                    <table class="table">
                                        <tr>
                                            <td>Comments</td>
                                            <td>Date Comments</td>
                                            <td>First Name</td>
                                        </tr>
                                        <tr>
                                            <td>${listCo}</td>
                                            <td>${listDa}</td>
                                            <td>${listFn}</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                         `;
            $('.modal-body').html(listSerah);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function deleteUser(id) {
    swal({
        title: "Are you sure?",
        text: "Hapus Data Ini !!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: "Users/DeleteUser/" + id,
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: "DELETE",
                dataType: "json",
                data: { id: id },
                success: function (result) {
                    swal({
                        title: "Good job!",
                        text: "DATA BERHASIL DIHAPUS!!",
                        icon: "success",
                        button: "Okey!",
                    }).then(function () {
                        window.location = "/Users";
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