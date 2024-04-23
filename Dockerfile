FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/aspnet:8.0

RUN mkdir /App
COPY ./OcbuuCore/bin/Release/net8.0/publish /App

RUN mkdir /https
COPY ./https /https/

WORKDIR /App

ENTRYPOINT [ "dotnet", "/App/OcbuuCore.dll" ]