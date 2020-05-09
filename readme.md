# App Mvc Core Identity - [Estudo]

## Ferramentas utilizadas 
- Git
- VsCode

dotnet aspnet-codegenerator identity -dc AspNetCoreIdentityContext --files "Account.Register;Account.Login"


### configurando variavel de ambiente
`
export ASPNETCORE_ENVIRONMENT=Production
`

### variavel de ambiente (Development, Staging, Production)
`
export ASPNETCORE_ENVIRONMENT=<ENVIRONMENT>
`

### rodando em outros perfis (Development, Staging, Production)
`
dotnet run --launch-profile <NAME-PROFILE>
`

## plugins vscode úteis
- Manage User Secrets (gerar user-secret) 
