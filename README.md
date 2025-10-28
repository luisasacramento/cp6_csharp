# SimpleStoreApi

**Tema**: Loja simples — API para gerenciar produtos (CRUD) sem persistência em banco (in-memory).

## Endpoints
- GET /api/products
- GET /api/products/{id}
- POST /api/products
- PUT /api/products/{id}
- DELETE /api/products/{id}

## Como executar
1. Instale o .NET SDK 7 ou 8.
2. No terminal:
   ```bash
   dotnet restore
   dotnet run
   ```
3. Acesse https://localhost:5001/swagger para testar.
