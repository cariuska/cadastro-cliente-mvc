$(function () {

    $("#CPF").inputmask("mask", {
        "mask": "999.999.999-99"
    }, {
        reverse: true
    });

    $("#CNPJ").inputmask("mask", {
        "mask": "99.999.999/9999-99"
    }, {
        reverse: true
    });

    $("#DataNascimento").inputmask("mask", {
        "mask": "99/99/9999"
    }, {
        reverse: true
    });

    $("#CEP").inputmask("mask", {
        "mask": "99999-999"
    }, {
        reverse: true
    });

    

});