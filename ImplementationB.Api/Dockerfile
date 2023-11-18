FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Implementation2.Api/Implementation2.Api.csproj", "Implementation2.Api/"]
RUN dotnet restore "Implementation2.Api/Implementation2.Api.csproj"
COPY . .
WORKDIR "/src/Implementation2.Api"
RUN dotnet build "Implementation2.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Implementation2.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Implementation2.Api.dll"]
