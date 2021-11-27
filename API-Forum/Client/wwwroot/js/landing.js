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
                        <button type="button" class="btn btn-warning" onclick="window.location.href='https://localhost:44326/Logins';">Comment</button>
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