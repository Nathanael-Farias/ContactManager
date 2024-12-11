# Contact Manager

**Contact Manager** é um projeto desenvolvido em .NET Core que implementa um sistema de autenticação completo com funcionalidades de gerenciamento de usuários e contatos. Ele utiliza o padrão de arquitetura **MVC (Model-View-Controller)**, garantindo uma separação clara entre lógica de apresentação, lógica de negócios e acesso a dados.

## Funcionalidades

- **Autenticação e Autorização**:
  - Login de usuários com validação e segurança.
  - Recuperação de senha via e-mail.
  - Hashing de senhas para maior segurança.
  - Restrição de acesso com filtros para usuários logados e administradores.
- **Gerenciamento de Usuários**:
  - Criação, edição e exclusão de usuários.
  - Listagem e visualização de detalhes.
- **Gerenciamento de Contatos**:
  - Criação, edição e exclusão de contatos.
  - Pesquisa por e-mail.
- **Interface de Navegação**:
  - Sistema de menu dinâmico.
  - Layouts distintos para usuários logados e não logados.
- **Outros Recursos**:
  - Pop-ups de confirmação para ações importantes.
  - Mensagens de erro e validação personalizadas.

## Estrutura do Projeto

```
ContactManager/
├── Controllers/                # Controladores responsáveis pela lógica de negócios.
│   ├── ContactController.cs    # Gerencia funcionalidades relacionadas a contatos.
│   ├── HomeController.cs       # Gerencia a página inicial.
│   ├── LoginController.cs      # Gerencia o fluxo de login e recuperação de senha.
│   ├── RestrictController.cs   # Gerencia páginas restritas a usuários logados.
│   └── UserController.cs       # Gerencia o CRUD de usuários.
│
├── Data/                       # Configuração do banco de dados e contexto.
│   ├── DataContext.cs          # Contexto do banco de dados (Entity Framework).
│   └── Migrations/             # Arquivos de migração do banco de dados.
│
├── Enums/                      # Enumerações para perfis e permissões.
│   └── EnumProfile.cs          # Define perfis de usuários.
│
├── Filters/                    # Filtros de autorização e navegação.
│   ├── LoggedUserPage.cs       # Filtro para páginas acessíveis apenas por usuários logados.
│   └── RestrictPageOnlyAdmin.cs# Filtro para páginas restritas a administradores.
│
├── Helper/                     # Utilitários e classes auxiliares.
│   ├── Cryptography.cs         # Sistema de hashing para senhas.
│   ├── Email.cs                # Implementação de envio de e-mails.
│   ├── IEmail.cs               # Interface para envio de e-mails.
│   ├── ISection.cs             # Interface para gerenciamento de seções.
│   └── Section.cs              # Implementação do gerenciamento de seções.
│
├── Models/                     # Modelos para dados e lógica de negócios.
│   ├── ContactModel.cs         # Modelo para contatos.
│   ├── ErrorViewModel.cs       # Modelo para exibição de erros.
│   ├── HomeModel.cs            # Modelo para a página inicial.
│   ├── LoginModel.cs           # Modelo para login.
│   ├── ResetPasswordModel.cs   # Modelo para recuperação de senha.
│   └── UserModel.cs            # Modelo para usuários.
│
├── Repository/                 # Repositórios para acesso aos dados.
│   ├── ContactRepository.cs    # Repositório para contatos.
│   ├── IContactRepository.cs   # Interface para repositório de contatos.
│   ├── IUserRepository.cs      # Interface para repositório de usuários.
│   └── UserRepository.cs       # Repositório para usuários.
│
├── ViewComponents/             # Componentes reutilizáveis nas views.
│   └── Menu.cs                 # Componente de menu dinâmico.
│
├── Views/                      # Arquivos de visualização (Views).
│   ├── Contact/                # Views para gerenciamento de contatos.
│   ├── Home/                   # Views para a página inicial.
│   ├── Login/                  # Views para login e recuperação de senha.
│   ├── Restrict/               # Views para páginas restritas.
│   ├── Shared/                 # Layouts e componentes compartilhados.
│   └── User/                   # Views para gerenciamento de usuários.
│
├── wwwroot/                    # Arquivos estáticos (CSS, JS, etc.).
│   ├── css/                    # Estilos do site.
│   ├── js/                     # Scripts JavaScript.
│   └── lib/                    # Bibliotecas de terceiros.
│
├── Program.cs                  # Ponto de entrada do aplicativo.
├── ContactManager.csproj       # Arquivo de configuração do projeto.
└── ContactManager.sln          # Solução do projeto.
```

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: ASP.NET Core MVC
- **Banco de Dados**: SQL Server com Entity Framework Core
- **Front-end**: HTML, CSS, Razor Pages, JavaScript
- **Estilização e Responsividade**: Bootstrap
- **Funcionalidades Avançadas**: jQuery para pop-ups e interatividade
- **Segurança**: Hashing de senhas (SHA1) e filtros de autorização
- **Outras Ferramentas**:
  - Envio de e-mails (System.Net.Mail)
  - Componentes dinâmicos com View Components

## Design Patterns

- **MVC (Model-View-Controller)**: Organização principal do projeto.
- **Repository Pattern**: Implementado para abstrair o acesso aos dados.
- **Factory Pattern**: Utilizado indiretamente na criação de objetos reutilizáveis.

## Imagens do Projeto

Adicione aqui capturas de tela do projeto, como a página inicial, telas de login, gerenciamento de usuários, etc.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.

---

Desenvolvido por Nathanael Farias.
