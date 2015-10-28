FROM microsoft/aspnet:1.0.0-beta8

EXPOSE 5000
ENTRYPOINT ["dnx", "-p", "project.json", "web"]

COPY project.json /app/
WORKDIR /app
RUN ["dnu", "restore"]
COPY . /app