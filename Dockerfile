#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["cadastro-cliente-mvc/cadastro-cliente-mvc/cadastro-cliente-mvc.csproj", "cadastro-cliente-mvc/cadastro-cliente-mvc/"]
RUN dotnet restore "cadastro-cliente-mvc/cadastro-cliente-mvc/cadastro-cliente-mvc.csproj"
COPY . .
WORKDIR "/src/cadastro-cliente-mvc/cadastro-cliente-mvc"
RUN dotnet build "cadastro-cliente-mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "cadastro-cliente-mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cadastro-cliente-mvc.dll"]