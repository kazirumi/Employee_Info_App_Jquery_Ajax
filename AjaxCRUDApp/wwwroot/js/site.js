// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

/*const { type } = require("jquery");*/

// Write your JavaScript code.


function AddOrEdit(URL, ActionTitle) {
   /* console.log(URL);*/
    $.ajax({
        type: "GET",
        url: URL,
        success: (res) => {
            /*console.log(res);*/
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(ActionTitle);
            $('#form-modal').modal('show');

        },
        error: (err) => {
            console.log(err);
        }
    });


}


function SaveEmployee(form) {
    try {
        /*console.log(form);*/
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: (res) => {
                console.log(res);

                if (res.isValid) {
                    $('.table-show').empty();
                    $('.table-show').html(res.html);
                    $('#form-modal').modal('hide');
                }
                else {
                    $('#form-modal .modal-body').html(res.html);
                }
               
            },
            error: (err) => {
                console.log(err);
            }
        });
    } catch (e) {
        console.log(e);
    }

    return false;
}


function DeleteEmployee (URL) {
    if(confirm("Are Sure Deleting this Emloyee?"))
    $.ajax({

        type: "GET",
        url: URL,
        success: (res) => {
            $('.table-show').empty();
           $('.table-show').html(res);
            },
        error: (err) => { console.log(err); }
    });
}