FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src

COPY . .
RUN dotnet restore
RUN dotnet build -c Release --no-restore

FROM build AS publish
RUN dotnet publish /src/SendGrid.Webhook/SendGrid.Webhook.csproj -c Release -o /app --no-restore

FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /src
COPY --from=publish /app .
ENTRYPOINT [ "dotnet", "SendGrid.Webhook.dll"]