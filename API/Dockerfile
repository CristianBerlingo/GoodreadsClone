FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base

RUN mkdir -p /usr/src/api
WORKDIR /usr/src/api

COPY ./publish/release .

EXPOSE 80
EXPOSE 443

ENTRYPOINT [ "dotnet",  "GoodreadsCloneAPI.dll"]