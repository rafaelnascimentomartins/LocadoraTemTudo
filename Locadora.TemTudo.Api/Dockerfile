#FROM -> Define a imagem que estara utilizando no projeto.
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
#Expor a porta da aplica??o na porta 80
EXPOSE 80
#WORKDIR Define a pasta padr?o do container
WORKDIR /app


#Copiando os arquivos de projeto para dentro da pasta app (definida acima em workdir)
COPY *.csproj ./
#restaurar todos os pacotes da aplica??o
RUN dotnet restore 

#Copiando tudo dentro da pasta de container "/app"
COPY ../ ./
#Publicando aplica??o em release, out -> pasta que ficar? dentro do /app
RUN dotnet publish -c Release -o out

#Utilizando um pacote mais leve runtime para rodar a dll (aplica??o)
FROM  mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
#Configurando container para ser executado, no momento que levantar a aplica??o
ENTRYPOINT ["dotnet", "Locadora.TemTudo.Api.dll"]