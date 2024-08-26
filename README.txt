# Checklist API

## Índice

- [Descrição](#descrição)
- [Recursos](#recursos)
- [Tecnologias e Pacotes](#tecnologias-e-pacotes)
- [Configuração](#configuração)
- [Uso](#uso)
- [Segurança](#segurança)
- [Contribuição](#contribuição)
- [Licença](#licença)

## Descrição

Este projeto é uma aplicação para gerenciar checklists de veículos. Ele permite a criação, visualização e gerenciamento de checklists que devem ser realizados diariamente após o carregamento e descarregamento de produtos. A aplicação é projetada com uma abordagem orientada a domínio (DDD) para garantir uma estrutura de código limpa e escalável.

## Recursos

- **Autenticação JWT**: Autenticação segura utilizando tokens JWT.
- **CRUD Completo**: Operações completas de CRUD para checklists, veículos, e executores.
- **Validação de Dados**: Validação de dados robusta tanto no lado do cliente quanto no lado do servidor.
- **Documentação API com Swagger**: Documentação interativa da API para facilitar o teste e a integração.

## Tecnologias e Pacotes

### Backend

- **.NET 8**
- **Entity Framework Core**:
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.SqlServer`
  - `Microsoft.EntityFrameworkCore.Tools`
- **AutoMapper**:
  - `AutoMapper.Extensions.Microsoft.DependencyInjection`
- **Autenticação JWT**:
  - `Microsoft.AspNetCore.Authentication.JwtBearer`
  - `Microsoft.IdentityModel.Tokens`
- **Swagger**:
  - `Swashbuckle.AspNetCore`
- **Banco de Dados**:
  - **SQL Server 16**

## Configuração

### Ambiente de Desenvolvimento

1. **Clone o repositório**:

   ```bash
   git clone https://github.com/developerkaue/checklistapi
   ```

2. **Navegue até o diretório do projeto**:

   ```bash
   cd ChecklistApi
   ```

3. **Restaurar pacotes**:

   ```bash
   dotnet restore
   ```

4. **Configurar variáveis de ambiente**: Defina as variáveis necessárias para a aplicação, como a chave secreta JWT e as credenciais do banco de dados.
    
   (JWT esta diretamente no codigo para facilitar o teste e demonstrar o uso do token, claro que em ambiente de produção isso deverá estar em variaveis de ambiente para manter a segurança da api.)
   Login: "admin" - "password"
   Exemplo de configuração de variáveis de ambiente no arquivo `appsettings.json`:

   ```json
   {

     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=SeuBanco;Trusted_Connection=True;"
     }
   }
   ```

5. **Executar o projeto**:

   ```bash
   dotnet run
   ```

### Ambiente de Produção

1. **Configurar o ambiente**: Siga as melhores práticas para segurança, como usar variáveis de ambiente e configurar um serviço de gerenciamento de segredos.

2. **Publicar o projeto**:

   ```bash
   dotnet publish -c Release
   ```

3. **Configurar o servidor**: Siga as diretrizes do seu servidor para hospedar e configurar a aplicação.

## Uso

- **Acesse a documentação da API**: Navegue até `http://localhost:5000/swagger` para interagir com a documentação Swagger e testar os endpoints da API.
- **Autenticação**: Use o endpoint de login para obter um token JWT e inclua-o no cabeçalho `Authorization` para acessar os endpoints protegidos.

## Segurança

- **Segurança dos Tokens**: Certifique-se de que os tokens JWT são mantidos seguros e nunca expostos.
- **Variáveis de Ambiente**: Armazene chaves e credenciais em variáveis de ambiente em vez de codificá-las diretamente no código.
- **Revisão de Segurança**: Realize revisões de segurança regulares e audite as permissões de acesso.

## Contribuição

Sinta-se à vontade para contribuir com o projeto! Aqui estão alguns passos para contribuir:

1. **Fork o repositório**.
2. **Crie uma branch para a sua modificação**:
   
   ```bash
   git checkout -b sua-modificacao
   ```

3. **Faça suas alterações e commit**:
   
   ```bash
   git commit -am 'Adiciona nova funcionalidade'
   ```

4. **Push para a branch**:
   
   ```bash
   git push origin sua-modificacao
   ```

5. **Abra um Pull Request**.
