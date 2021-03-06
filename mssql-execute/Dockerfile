#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["mssql-execute.csproj", "mssql-execute/"]
RUN dotnet restore "mssql-execute/mssql-execute.csproj"
WORKDIR "/src/mssql-execute"
COPY . .
RUN dotnet build "mssql-execute.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mssql-execute.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV PORT=1433
ENV DELAY=0
ENTRYPOINT ["dotnet", "mssql-execute.dll"]