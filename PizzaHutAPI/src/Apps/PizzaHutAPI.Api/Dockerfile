#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#ENV ASPNETCORE_URLS=https://+:5006;http://+:5005
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Apps/PizzaHutAPI.Api/PizzaHutAPI.Api.csproj", "src/Apps/PizzaHutAPI.Api/"]
COPY ["src/Common/PizzaHutAPI.Infrastructure/PizzaHutAPI.Infrastructure.csproj", "src/Common/PizzaHutAPI.Api.Infrastructure/"]
COPY ["src/Common/PizzaHutAPI.Application/PizzaHutAPI.Application.csproj", "src/Common/PizzaHutAPI.Api.Application/"]
COPY ["src/Common/PizzaHutAPI.Domain/PizzaHutAPI.Domain.csproj", "src/Common/PizzaHutAPI.Api.Domain/"]
RUN dotnet restore "src/Apps/PizzaHutAPI.Api/PizzaHutAPI.Api.csproj"
COPY . .
WORKDIR "/src/src/Apps/PizzaHutAPI.Api"
RUN dotnet build "PizzaHutAPI.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PizzaHutAPI.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PizzaHutAPI.Api.dll"]