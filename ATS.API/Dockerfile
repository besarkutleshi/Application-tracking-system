#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ATS.API/ATS.API.csproj", "ATS.API/"]
COPY ["ATS.Infrastructure/ATS.Infrastructure.csproj", "ATS.Infrastructure/"]
COPY ["ATS.Application/ATS.Application.csproj", "ATS.Application/"]
COPY ["ATS.Domain/ATS.Domain.csproj", "ATS.Domain/"]
RUN dotnet restore "ATS.API/ATS.API.csproj"
COPY . .
WORKDIR "/src/ATS.API"
RUN dotnet build "ATS.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ATS.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ATS.API.dll"]