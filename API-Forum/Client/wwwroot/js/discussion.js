$(document).ready(function () {
    $('#tableDiscussion').DataTable({
        'ajax': {
            'url': "/Discussions/GetAll",
            'order': [[0, 'asc']],
            'dataSrc': ''
        },
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
        'columnDefs': [{

            'targets': [6],

            'orderable': false,

        }],

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
                "data": "",
                'render': function (data, type, row, meta) {
                    var date = row['dateDis'].substr(0, 10);
                    var newDate = date.split('-');
                    return newDate[2] + '-' + newDate[1] + '-' + newDate[0];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    if (row['statusComt'] == 0) {
                        return ("Active");
                    }
                    else {
                        return ("Disable");
                    }
                }
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
    $("#postDiskusi").validate({
        rules: {
            title: {
                required: true
            },
            contentD: {
                required: true
            },
            dateDis: {
                required: true
            },
            statusComt: {
                required: true
            },
            userId: {
                required: true
            },
            categoryId: {
                required: true
            },
            typeId: {
                required: true
            }
        },
        errorPlacement: function (error, element) { },
        highlight: function (element) {
            $(element).closest('.form-control').addClass('is-invalid');
        },
        unhighlight: function (element) {
            $(element).closest('.form-control').removeClass('is-invalid');
        }
    });
});



function valid() {
    var ini = $("#postDiskusi").valid();
    console.log(ini);

    if (ini === true) {
        insertData();
    }
    else {
        Swal.fire(
            'Failed!',
            'Please enter all fields.',
            'error'
        );
    }
}

$.ajax({
    url: "/Users/GetAll",
    success: function (result) {
        console.log(result);
        var name = "";
        $.each(result, function (key, val) {
            name += `<option value="${val.userId}">${val.firstName}</option>`
        });
        $("#userId").html(name);
    }
})

$.ajax({
    url: "/Categories/GetAll",
    success: function (result) {
        console.log(result);
        var categoryName = "";
        $.each(result, function (key, val) {
            categoryName += `<option value="${val.categoryId}">${val.categoryName}</option>`
        });
        $("#categoryId").html(categoryName);
    }
})

$.ajax({
    url: "/TypeDiscussions/GetAll",
    success: function (result) {
        console.log(result);
        var typeName = "";
        $.each(result, function (key, val) {
            typeName += `<option value="${val.typeId}">${val.typeName}</option>`
        });
        $("#typeId").html(typeName);
    }
})

function clearTextBox() {
    $('#title').val("");
    $('#contentD').val("");
    $('#dateDis').val("");
    $('#statusComt').val("");
    $('#userId').val(0);
    $('#categoryId').val(0);
    $('#typeId').val(0);
    $('#title').css('border-color', 'lightgrey');
    $('#contentD').css('border-color', 'lightgrey');
    $('#dateDis').css('border-color', 'lightgrey');
    $('#statusComt').css('border-color', 'lightgrey');
    $('#userId').css('border-color', 'lightgrey');
    $('#categoryId').css('border-color', 'lightgrey');
    $('#typeId').css('border-color', 'lightgrey');
}

function insertData() {
    var obj = new Object();
    obj.Title = $('#title').val();
    obj.Content = $('#contentD').val();
    obj.DateDis = $('#dateDis').val();
    obj.StatusComt = $('#statusComt').val();
    obj.UserId = parseInt($('#userId').val());
    obj.CategoryId = parseInt($('#categoryId').val());
    obj.TypeId = parseInt($('#typeId').val());

    console.log(obj);
    $.ajax({
        url: "/Discussions/Discussion",
        type: "POST",
        data: { entity: obj },
        dataType: 'json'
    }).done((result) => {
        console.log(result);
        Swal.fire({
            icon: 'success',
            title: 'Your work has been saved',
        }).then(function () {
            window.location = "/Discussions/CreateDiskusi";
        });
        clearTextBox();
    }).fail((error) => {
        console.log(error);
        Swal.fire({
            title: 'Error!',
            text: 'Do you want to continue',
            icon: 'error',
            confirmButtonText: 'Cool'
        });
    });
}

function deleteDiscussion(DisId) {
    Swal.fire({
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
            }).done((result) => {
                console.log(result);
                Swal.fire({
                    title: "Good job!",
                    text: "DATA BERHASIL DIHAPUS!!",
                    icon: "success",
                    button: "Okey!"
                }).then(function () {
                    window.location = "/Discussions";
                });
            }).fail((error) => {
                console.log(error);
                Swal.fire({
                    title: "Failed!",
                    text: "DATA GAGAL DIHAPUS!!",
                    icon: "error",
                    button: "Close"
                });
            });
        }
        else {
            Swal.fire({
                text: "DATA GAGAL DIHAPUS!!"
            });
        }
    });
}


$.ajax({
    url: "/Users/GetLanding/",
    success: function (result) {
        console.log(result);
        var listSerah = "";
        $.each(result, function (key, val) {
            listSerah += `
<section class="py-4">
                <div class="card">
                    <div class="card-body">
                        <h6 class="h2 font-weight-bold">${val.title}</h6>
                        <div class="d-flex justify-content-between py-3 px-5">
                          <div class="row comment">
                                <span class="text-body font-weight-bold">By. ${val.firstName} ${val.lastName}</span>
                          </div>
                          <div class="row time text-muted align-self-center">
                                <span class="text-body pt-1 mr-3">${val.categoryName}</span>
                          </div>
                          <div class="row time text-muted align-self-center">
                                <i class="far fa-clock pr-2"><span class="align-self-center"> ${val.dateDis.substr(0, 10)}</span></i>
                          </div>
                        </div>
                        <hr>
                        <p class="text-muted">
                            <h5>${val.content}</h5>
                        </p>
                        <hr>
                        <button onclick="getDiskusi(${val.disId})" class="btn btn-primary">Detail Discussion >></button>
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
        url: "/Users/GetDiscussion/" + id,
        success: function (result) {
            console.log(result);
            var listSerah = "";
            $.each(result, function (key, val) {
                listSerah += `
<section class="py-4">
                <div class="card">
                    <div class="card-body">
                        <h6 class="h2 font-weight-bold">${val.title}</h6>
                        <div class="d-flex justify-content-between py-3 px-5">
                          <div class="row comment">
                                <span class="text-body font-weight-bold">By. ${val.firstName} ${val.lastName}</span>
                          </div>
                          <div class="row time text-muted align-self-center">
                                <span class="text-body pt-1 mr-3">${val.categoryName}</span>
                          </div>
                          <div class="row time text-muted align-self-center">
                                <i class="far fa-clock pr-2"><span class="align-self-center"> ${val.dateDis.substr(0, 10)}</span></i>
                          </div>
                        </div>
                        <hr>
                        <p class="text-muted">
                            <h5>${val.content}</h5>
                        </p>
                        <hr>
                        <button type="button" class="btn btn-warning" href="#postKomen" data-toggle="collapse">Comment</button>
                        <button type="button" class="btn btn-secondary" onclick=window.location.reload();>Back</button>
                    </div>
                </div>
</section>
`
                $("#dis").val(val.disId);
            });
            $('#diskusi').html(listSerah);
            $.ajax({
                url: "/Users/GetReplyById/" + id,
                success: function (result) {
                    console.log(result);
                    var listSerah = "";
                    $.each(result, function (key, val) {
                        listSerah += `<section class="py-4">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="d-flex justify-content-between py-3 px-5">
                                              <div class="row comment">
                                                    <span class="text-body font-weight-bold">By. ${val.firstName} ${val.lastName}</span>
                                              </div>
                                              <div class="row time text-muted align-self-center">
                                                    <i class="far fa-clock pr-2"><span class="align-self-center"> ${val.dateCom.substr(0, 10)}</span></i>
                                              </div>
                                            </div>
                                            <hr>
                                            <p class="text-muted">
                                                <h5>${val.content}</h5>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                              </div>
                            </section>`
                    });
                    $('#tampilKomen').html(listSerah);
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

$(document).ready(function () {
    $("#formComment").validate({
        rules: {
            contentComment: {
                required: true
            },
            dateCom: {
                required: true
            },
            userId: {
                required: true
            },
            disId: {
                required: true
            }
        },
        errorPlacement: function (error, element) { },
        highlight: function (element) {
            $(element).closest('.form-control').addClass('is-invalid');
        },
        unhighlight: function (element) {
            $(element).closest('.form-control').removeClass('is-invalid');
        }
    });
});

function validComment() {
    var ini = $("#formComment").valid();
    console.log(ini);

    if (ini === true) {
        insertComment();
    }
    else {
        Swal.fire(
            'Failed!',
            'Please enter all fields.',
            'error'
        );
    }
}

function insertComment() {
    var obj = new Object();
    obj.Content = $("#contentComment").val();
    obj.DateComment = $("#dateCom").val();
    obj.UserId = $("#user").val();
    obj.DisId = $("#dis").val();

    console.log(obj);
    $.ajax({
        url: "/Comments/Comment/",
        type: "POST",
        data: { entity: obj },
        dataType: 'json'
    }).done((result) => {
        console.log(result);
        Swal.fire({
            icon: 'success',
            title: 'Your work has been saved',
        }).then(function () {
            window.location = "/Discussions/LihatDiskusi";
        });
        clearTextBoxx();
    }).fail((error) => {
        console.log(error);
        Swal.fire({
            title: 'Error!',
            text: 'Do you want to continue',
            icon: 'error',
            confirmButtonText: 'Cool'
        });
    });
}

