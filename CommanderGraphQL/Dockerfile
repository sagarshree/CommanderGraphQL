FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CommanderGraphQL/CommanderGraphQL.csproj", "CommanderGraphQL/"]
RUN dotnet restore "CommanderGraphQL/CommanderGraphQL.csproj"
COPY . .
WORKDIR "/src/CommanderGraphQL"
RUN dotnet build "CommanderGraphQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CommanderGraphQL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CommanderGraphQL.dll"]
