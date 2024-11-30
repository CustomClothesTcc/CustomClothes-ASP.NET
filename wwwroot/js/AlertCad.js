document.addEventListener('DOMContentLoaded', function () {
    const botaoCadastrar = document.getElementById('btnCad');

    botaoCadastrar.addEventListener('click', function (event) {
        // Impedir o envio do formulário inicialmente
        event.preventDefault();

        // Selecionar todos os campos obrigatórios
        const camposObrigatorios = document.querySelectorAll('form [required]');
        let todosPreenchidos = true;

        // Verificar se todos os campos obrigatórios estão preenchidos
        camposObrigatorios.forEach(campo => {
            if (!campo.value.trim()) {
                todosPreenchidos = false;
                campo.classList.add('is-invalid'); // Adiciona classe para destacar erro
            } else {
                campo.classList.remove('is-invalid'); // Remove destaque de erro se estiver preenchido
            }
        });

        if (todosPreenchidos) {
            alert('Cadastro realizado com sucesso!');
            document.querySelector('form').submit(); // Enviar o formulário
        } else {
            alert('Por favor, preencha todos os campos obrigatórios antes de continuar.');
        }
    });
});
