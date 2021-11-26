
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

$.ajax({
    url: "Users/GetLanding/",
    success: function (result) {
        console.log(result);
        var listSerah = "";
        $.each(result, function (key, val) {
            listSerah += `<div class="row">
                        <div class="col">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title">${val.title}</h5>
                                    <p class="card-text">Oleh : ${val.firstName} ${val.lastName} | Date published : ${val.dateDis.substr(0, 10)} | Kategori : ${val.categoryName}</p>
                                    <a  onclick="getDiskusi(${val.disId})" class="btn btn-primary">Lihat Diskusi >></a>
                                </div>
                            </div>
                        </div>
                    </div>`
        });
        $('#diskusi').html(listSerah);
    },
    error: function (errormessage) {
        alert(errormessage.responseText);
    }
});

$.ajax({
    url: "GetDiscussion/" + 2,
    success: function (result) {
        console.log(result);
        var listSerah = "";
        $.each(result, function (key, val) {
            listSerah += `<div class="row">
                                <div class="col">
                                    <div class="card">
                                        <div class="card-body">
                                            <h5 class="card-title">${val.title}</h5>
                                            <p class="card-text">Oleh : ${val.firstName} ${val.lastName} | Date published : ${val.dateDis.substr(0, 10)} | Kategori : ${val.categoryName}</p>
                                            <hr>
                                            <p class="card-text">${val.content}</p>
                                            <a onclick="getCom(${val.disId})" class="btn btn-primary">Lihat Komentar >></a>
                                        </div>
                                    </div>
                                </div>
                              </div>`
        });
        $('#tampilDiskusi').html(listSerah);
        $.ajax({
            url: "GetReplyById/" + 2,
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
    },
    error: function (errormessage) {
        alert(errormessage.responseText);
    }
});

function getDiskusi(id) {
    window.location = "/Users/Content";
    $.ajax({
        url: "GetDiscussion/" + 2,
        success: function (result) {
            console.log(result);
            var listSerah = "";
            $.each(result, function (key, val) {
                listSerah += `<div class="row">
                                <div class="col">
                                    <div class="card">
                                        <div class="card-body">
                                            <h5 class="card-title">${val.title}</h5>
                                            <p class="card-text">Oleh : ${val.firstName} ${val.lastName} | Date published : ${val.dateDis.substr(0, 10)} | Kategori : ${val.categoryName}</p>
                                            <hr>
                                            <p class="card-text">${val.content}</p>
                                            <a onclick="getCom(${val.disId})" class="btn btn-primary">Lihat Komentar >></a>
                                        </div>
                                    </div>
                                </div>
                              </div>`
            });
            $('#tampilDiskusi').html(listSerah);
            $.ajax({
                url: "GetReplyById/" + 2,
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
                                            <a onclick="getCom(${val.disId})" class="btn btn-primary">Lihat Komentar >></a>
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
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

