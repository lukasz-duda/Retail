FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Sales/Sales.csproj Sales/
COPY Sales.Messages/Sales.Messages.csproj Sales.Messages/
RUN dotnet restore Sales/Sales.csproj
COPY . .
WORKDIR /src/Sales
RUN dotnet publish Sales.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT dotnet Sales.dll