$(function () {

    //

    $('#CEP').blur(function () {

        var cep = $("#CEP").val();

        $("#Logradouro").val("");
        $("#Bairro").val("");
        $("#Cidade").val("");
        $("#UF").val("");

        var url = "https://viacep.com.br/ws/" + cep + "/json/";

        $.ajax({
            url: url,
            contentType: "application/json",
            dataType: 'json',
            success: function (result) {

                if (!result.erro) {

                    var Logradouro = result.logradouro;
                    var Bairro = result.bairro;
                    var Cidade = result.localidade;
                    var UF = result.uf;

                    $("#Logradouro").val(Logradouro);
                    $("#Bairro").val(Bairro);
                    $("#Cidade").val(Cidade);
                    $("#UF").val(UF);
                } else {
                    alert("CEP Inválido!")
                    $("#CEP").val("");
                    $("#CEP").focus();
                }
            }
        })
    });

});