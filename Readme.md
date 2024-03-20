
#EJECTUR MIGRATIONS
Ingresar al proyecto donde tienes la migraciones por lo regular siempre es en infrastructure
dotnet ef migrations add InitialMigrations -c CleanTemplateDbContext -p  CleanTemplate.Infrastructure.Core.csproj -s ../../Services/CleanTemplate.Services.Api/CleanTemplate.Services.Api.csproj

#EJECUTAR DATABASE
dotnet ef database update -c CleanTemplateDbContext -p CleanTemplate.Infrastructure.Core.csproj -s ../../Services/CleanTemplate.Services.Api/CleanTemplate.Services.Api.csproj

Otra forma podría ser esta:
dotnet ef database update  --connection "server=localhost; database=CLEANDB_V1; User Id=sa; Password=SqlPwdStrong3202; Trusted_Connection=False;Encrypt=False"

Los paquetes para CleanTemplate.Application.Core
- MediatR.Extensions.Microsoft.DependencyInjection
- FluentValidation
- FluentValidation.DependencyInjectionExtensions
- AutoMapper
- AutoMapper.Extensions.Microsoft.DependencyInjection