FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Indimin.API/Indimin.API.csproj", "Indimin.API/"]
RUN dotnet restore "Indimin.API/Indimin.API.csproj"
COPY . .
WORKDIR "/src/Indimin.API"
RUN dotnet build "Indimin.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Indimin.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Indimin.API.dll"]
