# Utilizando migrations

Caso adicione ou altere propriedades em alguma entidade na camada de domínio que é transformada em tabela, será necessário criar uma nova migration para atualizar o banco de dados.

Caso altere algo na pasta Configurations desse projeto, também é necessário criar uma migration.

Para fazer isso, execute o comando abaixo no projeto Infrastructure:
```bash
dotnet ef migrations add <NomeDaMigrationEmPascalCase>
```

Depois, para aplicar a migration no banco de dados, execute o comando abaixo substituindo \<connection string\> pela connection string do `appsettings.Development.json`, alterando o Host de `ludome.database` por `localhost`:

```bash
dotnet ef database update --connection <connection string>
```

Caso veja que há prolemas ao atualizar, pode apagar o banco (container + volume) e iniciar a aplicação novamente para recriá-lo.

O banco de dados é criado somente ao inicar a aplicação. Logo, para rodar o comando acima, é necessário que a aplicação tenha sido executada pelo menos uma vez.