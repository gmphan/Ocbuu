#!/bin/sh
dotnet build -c Release OcbuuCore
dotnet publish -c Release OcbuuCore
#docker build --tag ocbuu-image .
#docker tag ocbuu-image ocbuuregistry.azurecr.io/ocbuu-image:latest
# this line replace the two lines above.
docker build --tag ocbuuregistry.azurecr.io/ocbuu-image:latest .
docker push ocbuuregistry.azurecr.io/ocbuu-image:latest