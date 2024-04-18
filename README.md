# Sistema de Gestão de Solicitação de Materiais e Serviços - ASP.NET Core MVC

## Descrição do Projeto

O Sistema de Gestão de Solicitação de Materiais e Serviços é uma aplicação web desenvolvida utilizando o framework ASP.NET Core MVC. O sistema visa simplificar e agilizar o processo de solicitação, gestão de estoque e compra de materiais e serviços por parte dos diferentes departamentos de uma organização. Com recursos abrangentes e uma interface intuitiva, os usuários podem facilmente realizar diversas operações, desde o cadastro de produtos até a geração de ordens de compra para fornecedores.

## Recursos Principais

1. **Cadastro de Produtos e Serviços:** Os usuários têm a capacidade de cadastrar novos produtos e serviços, fornecendo informações detalhadas, como nome, código EAN, preço unitário, descrição, fornecedor associado, entre outros.

2. **Gestão de Usuários e Departamentos:** O sistema permite o cadastro e gerenciamento de usuários, incluindo informações como matrícula, nome e departamento ao qual estão associados.

3. **Cadastro de Fornecedores:** Os fornecedores podem ser registrados no sistema, fornecendo dados como nome, endereço, e-mail, CNPJ, inscrição estadual e municipal.

4. **Solicitação de Materiais e Serviços:** Os usuários podem solicitar a compra de materiais ou serviços por meio de uma interface intuitiva, fornecendo detalhes como quantidade, departamento solicitante, usuário responsável, entre outros.

5. **Controle de Estoque:** O sistema permite o registro de entrada e saída de produtos do estoque, fornecendo informações detalhadas sobre as transações, como número da nota fiscal, quantidade, fornecedor, entre outros.

6. **Geração Automática de Ordens de Compra:** Ao selecionar um fornecedor, o sistema é capaz de gerar automaticamente ordens de compra com base nos pedidos internos de aquisição pendentes, garantindo uma gestão eficiente do processo de compra.

## Detalhes de Implementação

- **Banco de Dados:** Utiliza o Microsoft SQL Server como banco de dados, com o script de criação disponível na pasta `Database`.
- **Execução do Projeto:** Utilize o comando `dotnet watch` na raiz do projeto para iniciar o aplicativo.
- **Arquitetura:** O projeto segue a arquitetura MVC (Model-View-Controller) usando Asp.net Razor Pages e é estruturado conforme os princípios SOLID.
- **URL de Acesso:** O aplicativo está disponível em `http://localhost:5110/`, enquanto a documentação da API pode ser acessada em `http://localhost:5110/Swagger`.
- **Padrão de Projeto:** O método Factory foi empregado para abstração de algumas entidades concretas, promovendo uma arquitetura mais flexível e escalável.

## Pré-requisitos

- .NET Core SDK (versão XX.XX.XX)
- Microsoft SQL Server (versão XX.XX.XX)

## Como Executar

1. Clone este repositório.
2. Navegue até a pasta raiz do projeto.
3. Execute o comando `dotnet watch` para iniciar o aplicativo.
4. Acesse `http://localhost:5110/` em seu navegador para utilizar o sistema.

## Documentação da API

A documentação da API está disponível no Swagger em `http://localhost:5110/Swagger`.

## Contribuindo

Contribuições são bem-vindas! Para sugestões, correções ou novos recursos, sinta-se à vontade para abrir uma issue ou enviar um pull request.

## Licença

Este projeto está licenciado sob a Licença [MIT](LICENSE).
