Comandos para atualizar banco de dados (na pasta da API):
dotnet tool install --global dotnet-ef
dotnet ef migrations add AddProductDataTableOnDB
dotnet ef database update

RabbitMQ no Chrome: acessar pelo 127.0.0.1:porta

Sobre filas do RabbitMQ:
Fanout Exchange é usado para disseminar uma mensagem para todas as filas conectadas.
Direct Exchange é usado quando você deseja que a mensagem seja enviada para uma ou mais filas específicas, dependendo da chave de roteamento.