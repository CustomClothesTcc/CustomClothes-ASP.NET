function Personalizar() {
    var file = document.getElementById("file").value;
    var desc = document.getElementById("descricao").value;
    var descr = document.getElementById("descimg").value;
    var tamanho = document.getElementById("tamanho").value;
    var tecido = document.getElementById("tecido").value;
    var cor = document.getElementById("cor").value;
    var qtd = document.getElementById("qtd").value;
    var txtotal = document.getElementById("Txtotal").value;

    if (file && desc && descr && tamanho && tecido && cor && qtd && txtotal != null) {
        window.alert("Estampa Adicionada com Sucesso!");
    }

    else {
        document.getElementById("descricao").value = "";
        document.getElementById("descimg").value = "";
        document.getElementById("tamanho").value = "";
        document.getElementById("tecido").value = "";
        document.getElementById("cor").value = "";
        document.getElementById("qtd").value = "";
        document.getElementById("Txtotal").value = "";

        window.alert("Verifique se preencheu todos os Campos!");
    }
}
