/*

namespace CustomClothing.GerenciarArquivo

{
     
    public class GerenciadorArquivos
    {
       
        public static string CadastrarImagemProduto(IFormFile file)
        {
            var NomeArquivo = Path.GetFileName(file.FileName);
            var Caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", NomeArquivo);
            try
            {
                using (var stream = new FileStream(Caminho, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao salvar o arquivo.", ex);
            }


            return Path.Combine("/Img", NomeArquivo).Replace("\\", "/");
        }
    }
      
}

   */