#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/AchePacientes.Api/AchePacientes.Api.csproj", "src/AchePacientes.Api/"]
COPY ["src/AchePacientes.Application/AchePacientes.Application.csproj", "src/AchePacientes.Application/"]
COPY ["src/AchePacientes.Domain/AchePacientes.Domain.csproj", "src/AchePacientes.Domain/"]
COPY ["src/AchePacientes.CrossCutting/AchePacientes.CrossCutting.csproj", "src/AchePacientes.CrossCutting/"]
COPY ["src/AchePacientes.Infrastructure/AchePacientes.Infrastructure.csproj", "src/AchePacientes.Infrastructure/"]
RUN dotnet restore "src/AchePacientes.Api/AchePacientes.Api.csproj"
COPY . .
WORKDIR "/src/src/AchePacientes.Api"
RUN dotnet build "AchePacientes.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AchePacientes.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AchePacientes.Api.dll"]