#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/AwesomeDelivery.Customers.API/AwesomeDelivery.Customers.API.csproj", "src/AwesomeDelivery.Customers.API/"]
COPY ["src/AwesomeDelivery.Customers.Application/AwesomeDelivery.Customers.Application.csproj", "src/AwesomeDelivery.Customers.Application/"]
COPY ["src/AwesomeDelivery.Customers.Core/AwesomeDelivery.Customers.Core.csproj", "src/AwesomeDelivery.Customers.Core/"]
COPY ["src/AwesomeDelivery.Customers.Infrastructure/AwesomeDelivery.Customers.Infrastructure.csproj", "src/AwesomeDelivery.Customers.Infrastructure/"]
RUN dotnet restore "src/AwesomeDelivery.Customers.API/AwesomeDelivery.Customers.API.csproj"
COPY . .
WORKDIR "/src/src/AwesomeDelivery.Customers.API"
RUN dotnet build "AwesomeDelivery.Customers.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AwesomeDelivery.Customers.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AwesomeDelivery.Customers.API.dll"]
