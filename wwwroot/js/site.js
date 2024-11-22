$(document).ready(function () {
    $('.telefone').mask('(00) 0000-0000');
    $('.cpf').mask('000.000.000-00', { reverse: true });
    $('.rg').mask('00.000.000-0', { reverse: true });
});