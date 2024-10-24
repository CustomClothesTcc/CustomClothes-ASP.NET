namespace CustomClothing.GerenciarArquivo
{
    public class GerenciadorArquivos
    {

        public static string CadastrarImagemProduto(IFormFile file)
        {
            // Verificar se o arquivo é válido
            if (file == null || file.Length == 0)
                throw new ArgumentException("Arquivo inválido.");

            var NomeArquivo = Path.GetFileName(file.FileName);
            var Caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", NomeArquivo);

            // Criar diretório se não existir
            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img")))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img"));
            }

            // Salvar arquivo no diretório
            using (var stream = new FileStream(Caminho, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // Retornar o caminho relativo para salvar no banco
            return Path.Combine("/Img", NomeArquivo);
        }
    }
}