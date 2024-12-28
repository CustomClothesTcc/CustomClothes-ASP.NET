<h1>🛒 Custom Clothing - E-commerce</h1>
<p>
  Este projeto é um sistema de e-commerce desenvolvido em <b>ASP.NET Core MVC</b>, conectado ao banco de dados <b>MySQL</b>.  
  Ele permite gerenciar produtos, realizar compras, e organizar dados com uma arquitetura modular que favorece escalabilidade e organização.
</p>

---

<h2>🏗️ Arquitetura do Projeto</h2>
<p>A estrutura do projeto foi planejada para separar responsabilidades e facilitar a manutenção:</p>
<pre>
CarrinhoCompra/         # Funções e lógica relacionadas ao carrinho de compras.
Controllers/            # Controladores que gerenciam as requisições HTTP.
Cokkie/                 # Gerenciamento de cookies e dados persistentes no cliente.
doc/                    # Documentação adicional do projeto.
GerenciarArquivo/       # Manipulação de arquivos, como uploads ou logs.
Libraries/              # Bibliotecas utilitárias customizadas.
Models/                 # Modelos de dados e classes de domínio.
Properties/             # Configurações globais do projeto.
Repositorio/            # Lógica de acesso a dados e repositórios.
Views/                  # Arquivos de interface do usuário (Razor Pages).
wwwroot/                # Recursos estáticos, como CSS, JavaScript e imagens.
appsettings.json        # Configurações do aplicativo, incluindo banco de dados.
CustomClothing.csproj   # Arquivo de configuração do projeto.
CustomClothing.sln      # Solução do projeto para o Visual Studio.
package-lock.json       # Controle de dependências do projeto.
Program.cs              # Ponto de entrada principal do aplicativo.
</pre>

---

<h2>📋 Funcionalidades</h2>
<ul>
  <li><b>Gestão de Produtos:</b> Adicionar, editar e excluir produtos disponíveis na loja.</li>
  <li><b>Carrinho de Compras:</b> Gerenciamento de itens adicionados para compra.</li>
  <li><b>Autenticação:</b> Sistema de login e registro para usuários.</li>
  <li><b>Pedidos:</b> Registro e exibição de pedidos realizados pelos clientes.</li>
  <li><b>Integração com Banco de Dados:</b> Persistência de dados usando MySQL.</li>
</ul>

---

<h2>🚀 Como Usar</h2>
<ol>
  <li>Clone este repositório:</li>
  <pre>
git clone https://github.com/CustomClothesTcc/CustomClothes-ASP.NET.git
  </pre>
  <li>Abra o projeto no Visual Studio.</li>
  <li>Certifique-se de que o MySQL está instalado e configurado.</li>
  <li>Atualize a string de conexão no arquivo <code>appsettings.json</code>:</li>
  <pre>
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CustomClothingDB;User=root;Password=12345678;"
  }
}
  </pre>
  <p>
    <b>Aviso:</b> O projeto segue o padrão de acesso ao banco de dados da ETEC, com o login <code>root</code> e a senha <code>12345678</code>. Altere conforme necessário para o seu ambiente.
  </p>
  <li>Restaure os pacotes NuGet:</li>
  <pre>
dotnet restore
  </pre>
  <li>Execute o projeto:</li>
  <pre>
dotnet run
  </pre>
  <li>Acesse o sistema no navegador em <a href="http://localhost:5000" target="_blank">http://localhost:5000</a>.</li>
</ol>

---

<h2>🛠️ Tecnologias Utilizadas</h2>
<ul>
  <li><b>ASP.NET Core MVC:</b> Framework para construção do backend e views.</li>
  <li><b>MySQL:</b> Banco de dados relacional para persistência de informações.</li>
  <li><b>Bootstrap:</b> Framework CSS para estilização e design responsivo.</li>
  <li><b>Entity Framework Core:</b> ORM para interação com o banco de dados MySQL.</li>
  <li><b>Razor Pages:</b> Motor de renderização de interface do usuário.</li>
</ul>

---

<h2>📑 Documentação</h2>
<p>
  A pasta <code>doc/</code> contém materiais adicionais para referência, como:
</p>
<ul>
  <li>Diagramas de casos de uso e arquitetura.</li>
  <li>Manuais de configuração e operação do sistema.</li>
  <li>Especificações das funcionalidades implementadas.</li>
</ul>

---
