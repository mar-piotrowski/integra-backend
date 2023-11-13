FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["IntegraBackend/IntegraBackend.csproj", "IntegraBackend/"]
RUN dotnet restore "IntegraBackend/IntegraBackend.csproj"
COPY . .
WORKDIR "/src/IntegraBackend"
RUN dotnet build "IntegraBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IntegraBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IntegraBackend.dll"]
