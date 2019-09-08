FROM microsoft/dotnet:2.1-aspnetcore-runtime

RUN mkdir -p /usr/src/api
WORKDIR /usr/src/api

COPY ./publish/release .

EXPOSE 80

ENTRYPOINT [ "dotnet",  "GoodreadsCloneAPI.dll"]