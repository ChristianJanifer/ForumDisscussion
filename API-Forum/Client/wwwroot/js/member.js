﻿$.ajax({
    url: "/Users/GetLanding/",
    success: function (result) {
        console.log(result);
        var listSerah = "";
        $.each(result, function (key, val) {
            listSerah += `
<section class="py-4">
    <div class="card">
        <div class="card-body">
            <div class="container">
                <div class="card">
                    <div class="card-body">
                        <h5>${val.title}</h5>
                        <hr>
                        <span class="category text-body pt-1 mr-3">${val.categoryName}</span>
                    </div>
                </div>
                <div class="card">
                    <div class="card-body">
                        <div class="d-flex justify-content-between py-3 px-5">
                            <div class="row comment">
                                <span class="color2 mr-2 text-white">${val.firstName.substr(0, 1)}</span>
                                <span class="text-body font-weight-bold">${val.firstName} ${val.lastName}</span>
                            </div>
                            <div class="row time text-muted align-self-center">
                                <i class="far fa-clock pr-2"><span class="align-self-center"> ${val.dateDis.substr(0, 10)}</span></i>
                            </div>
                        </div>
                        <hr>
                        <p class="text-muted">
                            ${val.content}
                        </p>
                    </div>
                </div>
                <div class="card">
                    <div class="card-body">
                        <a onclick="getDiskusi(${val.disId})" class="btn btn-primary">Detail Discussion >></a>
                        <button type="button" class="btn btn-secondary" onclick=window.location.reload();>Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
`
        });
        $('#diskusi').html(listSerah);
    },
    error: function (errormessage) {
        alert(errormessage.responseText);
    }
});

function getDiskusi(id) {
    $.ajax({
        url: "/Users/GetDiscussionbyId/" + id,
        success: function (result) {
            console.log(result);
            var listSerah = "";
            $.each(result, function (key, val) {
                listSerah += `
<section class="py-4">
    <div class="card">
        <div class="card-body">
            <div class="container">
                <div class="card">
                    <div class="card-body">
                        <h5>${val.title}</h5>
                        <hr>
                        <span class="category text-body pt-1 mr-3">${val.categoryName}</span>
                    </div>
                </div>
                <div class="card">
                    <div class="card-body">
                        <div class="d-flex justify-content-between py-3 px-5">
                            <div class="row comment">
                                <span class="color2 mr-2 text-white">${val.firstName.substr(0, 1)}</span>
                                <span class="text-body font-weight-bold">${val.firstName} ${val.lastName}</span>
                            </div>
                            <div class="row time text-muted align-self-center">
                                <i class="far fa-clock pr-2"><span class="align-self-center"> ${val.dateDis.substr(0, 10)}</span></i>
                            </div>
                        </div>
                        <hr>
                        <p class="text-muted">
                            ${val.content}
                        </p>
                    </div>
                </div>
                <div class="card">
                    <div class="card-body">
                        <a onclick="getComment(${val.disId})" href="#tampilKomen" class="btn btn-primary" data-toggle="collapse">Show Comment >></a>
                        <button type="button" class="btn btn-secondary" onclick=window.location.reload();>Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
`
            });
            $('#diskusi').html(listSerah);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function getComment(id) {
    $.ajax({
        url: "/Users/GetReplyById/" + id,
        success: function (result) {
            console.log(result);
            var listSerah = "";
            $.each(result, function (key, val) {
                listSerah += `<div class="row">
                                <div class="col">
                                    <div class="card">
                                        <div class="card-body">
                                            <p class="card-text">Oleh : ${val.firstName} | Date published : ${val.dateCom.substr(0, 10)} </p>
                                            <hr>
                                            <p class="card-text">${val.content}</p>
                                        </div>
                                    </div>
                                </div>
                              </div>`
            });
            $('#tampilKomen').html(listSerah);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

$(document).ready(function () {
    $('#tableMember').DataTable({
        'ajax': {
            'url': "Users/GetAllMember",
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
            }
        ]
    });
});

function deleteUser(id) {
    Swal.fire({
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
                    Swal.fire({
                        title: "Good job!",
                        text: "DATA BERHASIL DIHAPUS!!",
                        icon: "success",
                        button: "Okey!",
                    }).then(function () {
                        window.location = "/Users";
                    });
                },
                error: function (errormessage) {
                    Swal.fire({
                        title: "Failed!",
                        text: "DATA GAGAL DIHAPUS!!",
                        icon: "error",
                        button: "Close",
                    });
                }
            });
        } else {
            Swal.fire({
                text: "DATA GAGAL DIHAPUS!!"
            });
        }
    });
}