FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Client/Client.csproj Client/
COPY Sales.Messages/Sales.Messages.csproj Sales.Messages/
RUN dotnet restore Client/Client.csproj
COPY . .
WORKDIR /src/Client
RUN dotnet publish Client.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
EXPOSE 80
WORKDIR /app
COPY --from=build /app/publish .
COPY --from=build /src src/
CMD dotnet Client.dll