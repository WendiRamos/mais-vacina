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
        document.getElementById("erroNasc").className = "visivel";
        return false;
    }
    document.getElementById("erroNasc").className = "invisivel";
    return true;
}

function validarEndereco() {
    var endereco = document.getElementById("endereco").value;
    endereco = endereco.trim();
    if (endereco === "" || endereco.length < 20 || endereco.length > 200) {
        document.getElementById("erroEndereco").className = "visivel";
        return false;
    }
    document.getElementById("erroEndereco").className = "invisivel";
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
            document.getElementById("erroCpf").className = "visivel";
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
            document.getElementById("erroCpf").className = "visivel";
            return false
        }
    }
    document.getElementById("erroCpf").className = "invisivel";
    return true;
}

function validarEmail() {
    var email = document.getElementById("email").value;
    email = email.trim();
    if (email === "" || email.length < 12 || email.length > 50) {
        document.getElementById("erroEmail").className = "visivel";
        return false;
    }
    document.getElementById("erroEmail").className = "invisivel";
    return true;
}

function validarUsuario() {
    var usuario = document.getElementById("usuario").value;
    usuario = usuario.trim();
    if (usuario === "" || usuario.length < 5 || usuario.length > 10) {
        document.getElementById("erroUsuario").className = "visivel";
        return false;
    }
    document.getElementById("erroUsuario").className = "invisivel";
    return true;
}

function validarSenha() {
    var senha = document.getElementById("senha").value;
    senha = senha.trim();
    if (senha === "" || senha.length < 8 || senha.length > 25) {
        document.getElementById("erroSenha").className = "visivel";
        return false;
    }
    document.getElementById("erroSenha").className = "invisivel";
    return true;
}

function confirmarSenha() {
    var senhaConfirma = document.getElementById("senhaConfirma").value;
    senhaConfirma = senhaConfirma.trim();
    if (senhaConfirma === "" || senhaConfirma.length < 8 || senhaConfirma.length > 25) {
        document.getElementById("erroSenhaConfirma").textContent = "Insira uma confirmação de senha válida!";
        document.getElementById("erroSenhaConfirma").className = "visivel";
        return false;
    }
    var senha = document.getElementById("senha").value;
    if (senha !== senhaConfirma) {
        document.getElementById("erroSenhaConfirma").textContent = "As senhas não coincidem!";
        document.getElementById("erroSenhaConfirma").className = "visivel";
        return false;
    }
    document.getElementById("erroSenhaConfirma").className = "invisivel";
    return true;
}


/*****************************************************************************/

function validarCadastro() {
    var nomeValido = validarNome();
    var nascValido = validarNasc();
    var enderecoValido = validarEndereco();
    var cpfValido = validarCpf();
    var emailValido = validarEmail();

    return nomeValido && nascValido && enderecoValido && cpfValido && emailValido;

}

function validarRegister() {
    var nomeValido = validarNome();
    var usuarioValido = validarUsuario();
    var emailValido = validarEmail();
    var senhaValida = validarSenha();
    var confirmaValido = confirmarSenha();

    return nomeValido && usuarioValido && emailValido && senhaValida && confirmarSenha;

}

function validarLogin() {
    var usuarioValido = validarUsuario();
    var emailValido = validarEmail();
    var senhaValida = validarSenha();
    return usuarioValido && emailValido && senhaValida;
}
