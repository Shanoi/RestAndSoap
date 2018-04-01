FROM mono:latest

RUN mkdir -p release

COPY * /release/

RUN csc release/*.cs -out:release/webserver.exe -r:release/Newtonsoft.Json.dll,release/System.Runtime.Caching.dll

EXPOSE 8733
CMD [ "mono", "webserver.exe" ]