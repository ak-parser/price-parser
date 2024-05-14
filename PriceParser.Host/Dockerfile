#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
# Needed for excel engine
RUN apt-get update && apt-get install -y libgdiplus libc6-dev && ln -s /usr/lib/libgdiplus.so /usr/lib/gdiplus.dll
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Lynkco.Warranty.WebAPI.Host/Lynkco.Warranty.WebAPI.Host.csproj", "Lynkco.Warranty.WebAPI.Host/"]
COPY ["Lynkco.Warranty.WebAPI.Domain/Lynkco.Warranty.WebAPI.Domain.csproj", "Lynkco.Warranty.WebAPI.Domain/"]
COPY ["Lynkco.Warranty.WebAPI.Data/Lynkco.Warranty.WebAPI.Data.csproj", "Lynkco.Warranty.WebAPI.Data/"]
COPY ["Lynkco.Warranty.WebAPI.Application/Lynkco.Warranty.WebAPI.Application.csproj", "Lynkco.Warranty.WebAPI.Application/"]
COPY ["Lynkco.Warranty.WebAPI.Infrastructure/Lynkco.Warranty.WebAPI.Infrastructure.csproj", "Lynkco.Warranty.WebAPI.Infrastructure/"]
RUN dotnet restore "Lynkco.Warranty.WebAPI.Host/Lynkco.Warranty.WebAPI.Host.csproj"
COPY . .
WORKDIR "/src/Lynkco.Warranty.WebAPI.Host"
RUN dotnet build "Lynkco.Warranty.WebAPI.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lynkco.Warranty.WebAPI.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lynkco.Warranty.WebAPI.Host.dll", "--environment=Development"]