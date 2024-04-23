### Generate cert and configure local machine:
```
dotnet dev-certs https -ep ./https/aspnetapp.pfx -p crypticpassword
dotnet dev-certs https --trust
```

### Build, tag and push the Docker image
```
docker build --tag ocbuu-image .
docker tag ocbuu-image ocbuuregistry.azurecr.io/ocbuu-image:latest
docker push ocbuu.azurecr.io/ocbuu-image:latest
```
### Run the container image with ASP.NET Core configured for HTTP:
```
docker run --rm -it --name ocbuu -p 8080:8080 --env-file variables.env ocbuu-image
```

### Run the container image with ASP.NET Core configured for HTTPS:
```
docker run --rm -it --name ocbuu -p 443:443 --env-file variables.env ocbuu-image
```
