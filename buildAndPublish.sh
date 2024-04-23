#!/bin/sh
dotnet build -c Release OcbuuCore
dotnet publish -c Release OcbuuCore
docker build --tag ocbuu-image .
docker tag ocbuu-image ocbuuregistry.azurecr.io/ocbuu-image:latest
docker push ocbuu.azurecr.io/ocbuu-image:latest