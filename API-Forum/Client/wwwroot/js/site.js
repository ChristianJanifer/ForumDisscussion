$.ajax({
    url: "https://localhost:44312/API/Users",
    success: function (result) {
        console.log(result);
    }
});

$(document).ready(function () {
    $('#tabelSW').DataTable({
        'ajax': {
            'url': "GetProfile",
            'dataType': 'json',
            'dataSrc': '',
        },
        'columns': [
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return row['firstName'] + ' ' + row['lastName'];
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    if (row['phone'].search(0) == 0) {
                        return row['phone'].replace('0', '+62');
                    } else {
                        return row['phone'];
                    }
                }
            },
            {
                "data": "email"
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    if (row['gender'] == 0) {
                        return ("Male");
                    }
                    else {
                        return ("Female");
                    }
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    var date = row['birthDate'].substr(0, 10);
                    return date;
                }
            }
        ]
    });

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
