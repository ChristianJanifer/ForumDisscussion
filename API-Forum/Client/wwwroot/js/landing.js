$(document).ready(function () {
    $('#tabelLand').DataTable({
        'ajax': {
            'url': "Users/GetLanding",
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
                    var button = '<td> <button onclick="getCom(' + row['disId'] + ');" class="btn btn-primary btn-sm text-center" data-toggle="modal" data-target="#exampleModal">See Comment </button></td>';
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
        url: "Users/GetReplybyId/" + id,
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