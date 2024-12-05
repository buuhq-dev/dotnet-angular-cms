```shell
change Blog.Data into Startup project
on Package Manager Console choose: Default Project is Blog.Data

add-migration Initial01

add-migration AddPostFields
add-migration MigrationL320

update-database

yarn add nswag

yarn nswag-admin

dotnet dev-certs https --trust
```

```text
https://github.com/teduinternational/tedu-blog
```