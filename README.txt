# Checklist API

## �ndice

- [Descri��o](#descri��o)
- [Recursos](#recursos)
- [Tecnologias e Pacotes](#tecnologias-e-pacotes)
- [Configura��o](#configura��o)
- [Uso](#uso)
- [Seguran�a](#seguran�a)
- [Contribui��o](#contribui��o)
- [Licen�a](#licen�a)

## Descri��o

Este projeto � uma aplica��o para gerenciar checklists de ve�culos. Ele permite a cria��o, visualiza��o e gerenciamento de checklists que devem ser realizados diariamente ap�s o carregamento e descarregamento de produtos. A aplica��o � projetada com uma abordagem orientada a dom�nio (DDD) para garantir uma estrutura de c�digo limpa e escal�vel.

## Recursos

- **Autentica��o JWT**: Autentica��o segura utilizando tokens JWT.
- **CRUD Completo**: Opera��es completas de CRUD para checklists, ve�culos, e executores.
- **Valida��o de Dados**: Valida��o de dados robusta tanto no lado do cliente quanto no lado do servidor.
- **Documenta��o API com Swagger**: Documenta��o interativa da API para facilitar o teste e a integra��o.

## Tecnologias e Pacotes

### Backend

- **.NET 8**
- **Entity Framework Core**:
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.SqlServer`
  - `Microsoft.EntityFrameworkCore.Tools`
- **AutoMapper**:
  - `AutoMapper.Extensions.Microsoft.DependencyInjection`
- **Autentica��o JWT**:
  - `Microsoft.AspNetCore.Authentication.JwtBearer`
  - `Microsoft.IdentityModel.Tokens`
- **Swagger**:
  - `Swashbuckle.AspNetCore`
- **Banco de Dados**:
  - **SQL Server 16**

## Configura��o

### Ambiente de Desenvolvimento

1. **Clone o reposit�rio**:

   ```bash
   git clone https://github.com/developerkaue/checklistapi
   ```

2. **Navegue at� o diret�rio do projeto**:

   ```bash
   cd ChecklistApi
   ```

3. **Restaurar pacotes**:

   ```bash
   dotnet restore
   ```

4. **Configurar vari�veis de ambiente**: Defina as vari�veis necess�rias para a aplica��o, como a chave secreta JWT e as credenciais do banco de dados.
    
   (JWT esta diretamente no codigo para facilitar o teste e demonstrar o uso do token, claro que em ambiente de produ��o isso dever� estar em variaveis de ambiente para manter a seguran�a da api.)
   Login: "admin" - "password"
   Exemplo de configura��o de vari�veis de ambiente no arquivo `appsettings.json`:

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

### Ambiente de Produ��o

1. **Configurar o ambiente**: Siga as melhores pr�ticas para seguran�a, como usar vari�veis de ambiente e configurar um servi�o de gerenciamento de segredos.

2. **Publicar o projeto**:

   ```bash
   dotnet publish -c Release
   ```

3. **Configurar o servidor**: Siga as diretrizes do seu servidor para hospedar e configurar a aplica��o.

## Uso

- **Acesse a documenta��o da API**: Navegue at� `http://localhost:5000/swagger` para interagir com a documenta��o Swagger e testar os endpoints da API.
- **Autentica��o**: Use o endpoint de login para obter um token JWT e inclua-o no cabe�alho `Authorization` para acessar os endpoints protegidos.

## Seguran�a

- **Seguran�a dos Tokens**: Certifique-se de que os tokens JWT s�o mantidos seguros e nunca expostos.
- **Vari�veis de Ambiente**: Armazene chaves e credenciais em vari�veis de ambiente em vez de codific�-las diretamente no c�digo.
- **Revis�o de Seguran�a**: Realize revis�es de seguran�a regulares e audite as permiss�es de acesso.

## Contribui��o

Sinta-se � vontade para contribuir com o projeto! Aqui est�o alguns passos para contribuir:

1. **Fork o reposit�rio**.
2. **Crie uma branch para a sua modifica��o**:
   
   ```bash
   git checkout -b sua-modificacao
   ```

3. **Fa�a suas altera��es e commit**:
   
   ```bash
   git commit -am 'Adiciona nova funcionalidade'
   ```

4. **Push para a branch**:
   
   ```bash
   git push origin sua-modificacao
   ```

5. **Abra um Pull Request**.
