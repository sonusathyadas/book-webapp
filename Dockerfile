FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["BookManager.csproj", "./"]
RUN dotnet restore "BookManager.csproj"

COPY . .
RUN dotnet publish "BookManager.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ENV ASPNETCORE_HTTP_PORTS=8080 \
    ConnectionStrings__DefaultConnection="Data Source=/data/books.db"

EXPOSE 8080
VOLUME ["/data"]
RUN mkdir /data && chown $APP_UID:$APP_UID /data
COPY --from=build --chown=$APP_UID:$APP_UID /app/publish .

USER $APP_UID
ENTRYPOINT ["dotnet", "BookManager.dll"]