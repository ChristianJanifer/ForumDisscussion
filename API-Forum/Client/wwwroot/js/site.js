$.ajax({
    url: "https://localhost:44312/API/Users",
    success: function (result) {
        console.log(result);
    }
});

$(document).ready(function () {
    $("#register").validate({
        rules: {
            firstName: {
                required: true
            },
            lastName: {
                required: true
            },
            phone: {
                required: true
            },
            birthDate: {
                required: true
            },
            email: {
                required: true
            },
            password: {
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

$(document).ready(function () {
    $('#tabelLand').DataTable({
        'ajax': {
            'url': "GetLanding",
            'dataType': 'json',
            'dataSrc': '',
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
});

function getCom(id) {
    listSerah = "";
    listCo = "";
    listDa = "";
    listFn = "";
    listLn = "";
    $.ajax({
        url: "GetReplybyId/" + id,
        success: function (result) {
            console.log(result);

            for (let i = 0; i < result.length; i++) {
                listCo += `<p>${result[i].content}</p>`;
                listDa += `<p>${result[i].dateComment}</p>`;
                listFn += `<p>${result[i].firstName}</p>`;
                listLn += `<p>${result[i].lastName}</p>`;
            }

            listSerah += `  <div class="container-fluid">
                                <div class="row">
                                    <table class="table">
                                        <tr>
                                            <td>Comments</td>
                                            <td>Date Comments</td>
                                            <td>First Name</td>
                                            <td>Last Name</td>
                                        </tr>
                                        <tr>
                                            <td>${listCo}</td>
                                            <td>${listDa}</td>
                                            <td>${listFn}</td>
                                            <td>${listLn}</td>
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


function Valid() {
    var ini = $("#register").valid();
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

function clearTextBox() {
    $('#firstName').val("");
    $('#lastName').val("");
    $('#phone').val("");
    $('#birthDate').val("");
    $('#gender').val(0);
    $('#email').val("");
    $('#password').val("");
    $('#firstName').css('border-color', 'lightgrey');
    $('#lastName').css('border-color', 'lightgrey');
    $('#phone').css('border-color', 'lightgrey');
    $('#birthDate').css('border-color', 'lightgrey');
    $('#gender').css('border-color', 'lightgrey');
    $('#email').css('border-color', 'lightgrey');
    $('#password').css('border-color', 'lightgrey');
}

function insertData() {
    var obj = new Object();

    obj.FirstName = $('#firstName').val();
    obj.LastName = $('#lastName').val();
    obj.Phone = $('#phone').val();
    obj.BirthDate = $('#birthDate').val();
    obj.Gender = parseInt($('#gender').val());
    obj.Email = $('#email').val();
    obj.Password = $('#password').val();

    console.log(obj);
    $.ajax({
        url: "Registers/Register",
        type: "POST",
        data: { entity: obj },
        dataType: 'json'
    }).done((result) => {
        console.log(result);
        Swal.fire(
            'Your account has been created.',
            'Please sign in to enter forum',
            'success'
        );
        clearTextBox();
    }).fail((error) => {
        console.log(error);
    });
}

function resetPassword() {
    var obj = new Object();

    obj.Email = $('#email').val();
    obj.Password = $('#password').val();

    console.log(obj);
    $.ajax({
        url: "ResetPassword",
        type: "PUT",
        data: { entity: obj },
        dataType: 'json'
    }).done((result) => {
        console.log(result);
        Swal.fire(
            'Your account has been created.',
            'Please sign in to enter forum',
            'success'
        );
        clearTextBox();
    }).fail((error) => {
        console.log(error);
    });
}
