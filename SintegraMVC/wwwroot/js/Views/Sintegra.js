$(function () {
    $('#InscricaoEstadual').keypress(function (event) {
        if (event.which < 48 || event.which > 57) {
            event.preventDefault();
        }
    }).attr('maxlength', 16).attr('placeholder', 'Insira somente números');

    $('#Estado').keypress(function (event) {
        var inputValue = String.fromCharCode(event.which);
        var pattern = /^[a-zA-Z]+$/;
        if (!pattern.test(inputValue)) {
            event.preventDefault();
        } else {
            $(this).val($(this).val() + inputValue.toUpperCase());
            event.preventDefault();
        }
    }).attr('maxlength', 2).attr('placeholder', 'Insira somente letras');

    $('#btnValidar').click(function () {
        var sintegra = {
            InscricaoEstadual: $('#InscricaoEstadual').val(),
            Uf: $('#Estado').val()
        };

        $.ajax({
            url: 'sintegra/validar-inscricao-estadual',
            type: 'POST',
            data: JSON.stringify(sintegra),
            contentType: 'application/json',
            success: function (result) {
                console.log(result);
                if (result) {
                    alert('A inscrição estadual pertence a esse estado!');
                } else {
                    alert('A inscrição estadual está incorreta ou não pertence a esse estado!');
                    $('#InscricaoEstadual').val('');
                    $('#Estado').val('');
                }
            },
            error: function (xhr, status, error) {
                console.log(xhr.responseText);
                // Lide com o erro aqui
            }
        });
    });
});