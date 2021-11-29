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
                        <button type="button" class="btn btn-warning" onclick="window.location.href='/Logins';">Comment</button>
                        <button type="button" class="btn btn-secondary" onclick=window.location.reload();>Back</button>
                    </div>
                </div>
</section>
`
            });
            $('#diskusi').html(listSerah);
            $.ajax({
                url: "/Users/GetReplyById/" + id,
                success: function (result) {
                    console.log(result);
                    var listSerah = "";
                    $.each(result, function (key, val) {
                        listSerah += `
                            <section class="py-4">
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

$.ajax({
    url: "/Categories/GetAll",
    success: function (result) {
        console.log(result);
        var listSerah = "";
        $.each(result, function (key, val) {
            listSerah += `
<button class="btn" onclick="getDiskusiCat(${val.categoryId})">${val.categoryName}</button><br>
`
        });
        $('#category').html(listSerah);
    },
    error: function (errormessage) {
        alert(errormessage.responseText);
    }
});

function getDiskusiCat(id) {
    $.ajax({
        url: "/Users/GetDiscussionByCat/" + id,
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
}
