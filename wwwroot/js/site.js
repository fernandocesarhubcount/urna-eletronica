function validarCampos() {
    return $('#codigo').val() >= 10 && $('#codigo').val() <= 99 && $('#codigo').val() != '' && $('#nome').val() != '' && $('#partido').val() != '' && $('#vice').val() != '';
}

function salvar(action) {
    if (this.validarCampos()) {
        var candidato = JSON.stringify({
            'Id': $('#id').val(),
            'Codigo': $('#codigo').val(),
            'Nome': $('#nome').val(),
            'Partido': $('#partido').val(),
            'Vice': $('#vice').val()
        });
        $.ajax({
            type: 'POST',
            url: action,
            contentType: 'application/json',
            data: candidato,
            processData: false,
            success: function (data) {
                alert('Candidato salvo com sucesso!');
                window.location.href = '/Cadastro';
            },
            error: function (result) {
                document.getElementById('tela-erro').innerHTML = document.getElementById('msg-erro').innerHTML;
                document.getElementById('excecao').innerHTML = result.responseJSON.mensagem;
                console.log(result.responseJSON.mensagem);
            }
        });
    } else {
        document.getElementById('tela-erro').innerHTML = document.getElementById('msg-erro').innerHTML;
        document.getElementById('excecao').innerHTML = 'Todos os campos devem ser preenchidos';
    }
}

function removerCandidato(id) {
    $.ajax({
        type: 'DELETE',
        url: '/Cadastro?remover=' + id,
        success: function (data) {
            alert('Candidato removido!');
            window.location.href = '/Cadastro';
        },
        error: function (req, status, error) {
            console.log('Error: ' + error);
        }
    });
}

/* Votação */

function inserirNumero(i) {
    var valor = parseInt(i);
    if (document.getElementById('primeiro').value == '') {
        this.limparTela();
        $('#primeiro').val(valor);
    } else if (document.getElementById('segundo').value == '') {
        $('#segundo').val(valor);
        atualizarTela(this.montarCodigo());
    }
}

function montarCodigo() {
    var codigo = 0;
    if (document.getElementById('primeiro').value != '' && document.getElementById('segundo').value != '') {
        var primeiro = document.getElementById('primeiro').value;
        var segundo = document.getElementById('segundo').value;
        codigo = parseInt('' + primeiro + segundo);
    } else if (document.getElementById('nome').innerHTML == 'Voto em branco') {
        codigo = -2;
    }
    return codigo;
}

function atualizarTela(codigo) {
    $.ajax({
        type: 'POST',
        url: '/Votacao/atualizar-tela',
        data: { codigo: codigo },
        success: function (msg) {
            if (msg != null) {
                document.getElementById('nome').innerHTML = msg.nome;
                document.getElementById('partido').innerHTML = msg.partido;
                document.getElementById('vice').innerHTML = msg.vice;
            } else {
                console.log('Candidato nulo');
            }
        },
        error: function (req, status, error) {
            console.log('Error: ' + error);
        }
    });
}

function votoBranco(voto) {
    this.limparTela();
    document.getElementById('nome').innerHTML = voto;
}

function trocarTelaUrna(tela) {
    document.getElementById('tela-urna').innerHTML = document.getElementById(tela).innerHTML;
}

function confirmar() {
    var codigo = this.montarCodigo();
    if (codigo > 0 || codigo == -2) {
        var candidato = JSON.stringify({
            'Codigo': codigo,
            'Nome': document.getElementById('nome').innerHTML,
            'Partido': document.getElementById('partido').innerHTML,
            'Vice': document.getElementById('vice').innerHTML
        });
        $.ajax({
            type: 'POST',
            url: '/Votacao/vote',
            contentType: 'application/json',
            data: candidato,
            processData: false,
            success: function (data) {
                console.log('Voto computado com sucesso!');
            },
            error: function (error) {
                console.log('Error: ' + error);
            }
        });
        trocarTelaUrna('tela-fim');
    }
}

function limparTela() {
    $('#primeiro').val('');
    $('#segundo').val('');
    document.getElementById('nome').innerHTML = '';
    document.getElementById('partido').innerHTML = '';
    document.getElementById('vice').innerHTML = '';
}