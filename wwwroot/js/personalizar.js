const uploadImagem = document.getElementById('file');
const imagemPreview = document.getElementById('imagemPreview');
const containerPreview = document.getElementById('containerPreview');

// Função para pré-visualizar a imagem
uploadImagem.addEventListener('change', (event) => {
    const file = event.target.files[0];
    if (file) {
        const leitor = new FileReader();
        leitor.onload = (e) => {
            imagemPreview.src = e.target.result;
            imagemPreview.classList.remove('d-none');
            containerPreview.querySelector('.textoUpload').classList.add('d-none');
            containerPreview.querySelector('.iconeCamiseta').classList.add('d-none');
        };
        leitor.readAsDataURL(file);
    }
});