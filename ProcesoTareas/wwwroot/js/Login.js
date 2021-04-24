jQuery(document).ready(function ($) {

    $('#txtUsuario').focus();

    $('#btnEntrar').on('click', function () {

        if ($('#txtUsuario').val() != "" & $('#txtclave').val() != "") {
            Validate($('#txtUsuario').val(), $('#txtclave').val());
        }
        else {
            Swal.fire(
                'error',
                'favor de ingresar usuario y clave',
                'error'

            );
        }
    });


    function Validate(usuario, clave) {

        var record = {
            nombreusuario: usuario,
            Clave: clave 

        };

        $.ajax({
            url: '/Login/Autherize',
            async: false,
            type: 'POST',
            data: record,
            beforeSend: function (xhr, opts) {
            },
            complete: function () {
            },
            success: function (data) {
                if (data.status == true) {
                    window.location.href = "/Home/Index";
                }
                else if (data.status == false) {

                    Swal.fire(
                        'error',
                        data.message,
                        'error'
                    );
                }
            },
            error: function (data) {
                Swal.fire(
                    'error',
                    data.message,
                    'error'
                );

            }
        });

    }

});