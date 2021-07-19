function validarNome() {
    var nome = document.getElementById("nome").value;
    nome = nome.trim();
    if (nome === "" || nome.length < 9 || nome.length > 50) {
        document.getElementById("erroNome").className = "visivel";
        
        return false;
    }
    document.getElementById("erroNome").className = "invisivel";
    return true;
}

function validarNasc() {
    var nasc = document.getElementById("nasc").value;
    nasc = nasc.trim();
    if (nasc === "") {
        return false;
    }
    return true;
}

function validarEndereço() {
    var endereço = document.getElementById("endereco").value;
    endereço = endereço.trim();
    if (endereço === "" || endereço.length < 20 || endereço.length > 200) {
        return false;
    }
    return true;
}

function validarCpf() {
    var cpf = document.getElementById("cpf").value;
    cpf = cpf.trim();
    if (!cpf === "" || !cpf.length < 11 || !cpf.length > 15) {
        exp = /\.|\-/g
        cpf = cpf.toString().replace(exp, "");
        var digitoDigitado = eval(cpf.charAt(9) + cpf.charAt(10));
        var soma1 = 0, soma2 = 0;
        var vlr = 11;
        if (
            !cpf ||
            cpf.length != 11 ||
            cpf == "00000000000" ||
            cpf == "11111111111" ||
            cpf == "22222222222" ||
            cpf == "33333333333" ||
            cpf == "44444444444" ||
            cpf == "55555555555" ||
            cpf == "66666666666" ||
            cpf == "77777777777" ||
            cpf == "88888888888" ||
            cpf == "99999999999"
        ) {
            return false
        }

        for (i = 0; i < 9; i++) {
            soma1 += eval(cpf.charAt(i) * (vlr - 1));
            soma2 += eval(cpf.charAt(i) * vlr);
            vlr--;
        }
        soma1 = (((soma1 * 10) % 11) == 10 ? 0 : ((soma1 * 10) % 11));
        soma2 = (((soma2 + (2 * soma1)) * 10) % 11);

        var digitoGerado = (soma1 * 10) + soma2;
        if (digitoGerado != digitoDigitado) {
            return false
        }
    }
    return true;
}

function validarEmail() {
    var email = document.getElementById("email").value;
    email = email.trim();
    if (email === "" || email.length < 12 || email.length > 50) {
        return false;
    }
    return true;
}

/*****************************************************************************/

function validarCadastro() {
    return validarNome() && validarNasc() && validarEndereco() && validarCpf() && validarEmail();
}

function validarLogin() {

}
