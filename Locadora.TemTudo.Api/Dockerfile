#FROM -> Define a imagem que estara utilizando no projeto.
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
#Expor a porta da aplicação na porta 80
EXPOSE 5000
#WORKDIR Define a pasta padrão do container
WORKDIR /app


#Copiando os arquivos de projeto para dentro da pasta app (definida acima em workdir)
COPY *.csproj ./
#restaurar todos os pacotes da aplicação
RUN dotnet restore 

#Copiando tudo dentro da pasta de container "/app"
COPY ../ ./
#Publicando aplicação em release, out -> pasta que ficará dentro do /app
RUN dotnet publish -c Release -o out

#Utilizando um pacote mais leve runtime para rodar a dll (aplicação)
FROM  mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
#Configurando container para ser executado, no momento que levantar a aplicação
ENTRYPOINT ["dotnet", "locadora.dll"]
#ENTRYPOINT ["dotnet", "run"]