Comandos para atualizar banco de dados (na pasta da API):
dotnet tool install --global dotnet-ef
dotnet ef migrations add AddProductDataTableOnDB
dotnet ef database update