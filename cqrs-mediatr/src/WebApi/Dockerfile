FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/WebApi/WebApi.csproj", "src/WebApi/"]
COPY ["src/Application/Application.csproj", "src/Application/"]
COPY ["src/Administrativo/Administrativo.csproj", "src/Administrativo/"]
COPY ["src/Core/CQRS.csproj", "src/Core/"]
COPY ["src/Data/Dados.csproj", "src/Data/"]
COPY ["src/Matricula/Atendimento.csproj", "src/Matricula/"]
RUN dotnet restore "src/WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/src/WebApi"
RUN dotnet build "WebApi.csproj" -c Development -o /app/publish

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Development -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]