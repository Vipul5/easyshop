FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY bin/Release/net8.0/publish .

RUN mkdir /data

ENV ASPNETCORE_ENVIRONMENT=Docker

VOLUME ["/data"]

ENTRYPOINT ["dotnet", "CartService.dll"]