FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SendGrid.Webhook/SendGrid.Webhook.csproj", "SendGrid.Webhook/"]
RUN dotnet restore "SendGrid.Webhook/SendGrid.Webhook.csproj"
COPY . .
WORKDIR "/src/SendGrid.Webhook"
RUN dotnet build "SendGrid.Webhook.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SendGrid.Webhook.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SendGrid.Webhook.dll"]