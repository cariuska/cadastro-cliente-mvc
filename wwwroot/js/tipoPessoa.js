$(function () {
    var tipoPessoa = $("#tipoPessoa").val();

    if (tipoPessoa == "F") {
        enableFisica();
    } else {
        enableJuridica();
    }

    $('#tipoPessoa').change(function () {

        var tipoPessoa = $("#tipoPessoa").val();

        if (tipoPessoa == "F") {
            enableFisica();
        } else {
            enableJuridica();
        }

    });

    $('#DataNascimento').blur(function () {

        var DataNascimento = $("#DataNascimento").val();

        DataNascimento = DataNascimento.substring(0, 10);
        DataNascimento = new Date(DataNascimento);

        var hoje = new Date();
        var idade = calculaIdade(DataNascimento, hoje);

        if (idade <= 18) {
            alert("A pessoa deve ter 19 anos ou mais !");
            $("#DataNascimento").val("");
            $("#DataNascimento").focus();
        }

    });

    function calculaIdade(nascimento, hoje) {
        return Math.floor(Math.ceil(Math.abs(nascimento.getTime() - hoje.getTime()) / (1000 * 3600 * 24)) / 365.25);
    }




    function enableFisica() {
        $("#grupoJuridica").hide();
        $("#grupoFisica").show();

        $('#CNPJ').removeAttr('required');
        $('#RazaoSocial').removeAttr('required');
        $('#NomeFantasia').removeAttr('required');

        $('#CPF').prop('required', true);
        $('#DataNascimento').prop('required', true);
        $('#Nome').prop('required', true);
        $('#Sobrenome').prop('required', true);

    }

    function enableJuridica() {
        $("#grupoFisica").hide();
        $("#grupoJuridica").show();

        $('#CPF').removeAttr('required');
        $('#DataNascimento').removeAttr('required');
        $('#Nome').removeAttr('required');
        $('#Sobrenome').removeAttr('required');

        $('#CNPJ').prop('required', true);
        $('#RazaoSocial').prop('required', true);
        $('#NomeFantasia').prop('required', true);

    }

})

