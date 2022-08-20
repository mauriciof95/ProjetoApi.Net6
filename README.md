# Api .NET6 com JWT

Projeto de estudo sobre api usando .net6 e database postgreSQL.

**Repositorio Front-End Angular:** https://github.com/mauriciof95/ProjetoFrondEndAgular

1. Implementado login gerando um token de acesso, onde estão contiadas as informações do usuario como também suas permissões.
2. Implementado o refresh token para caso o token atual expire, o usuario não precisa refazer o login.
3. Implementado o gerenciamento de acesso dos usuarios usando claims (as permissões). Por Exemplo, o usuario pode ter acesso a lista de produtos, mas não pode cadastrar, editar e/ou deletar os registros.
