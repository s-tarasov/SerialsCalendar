FROM microsoft/aspnet

COPY . /app
WORKDIR /app/Calendar.Web
RUN ["kpm", "restore"]
RUN ["kpm", "build", "--configuration=Release"]

COPY Deploy/docker-entrypoint.sh /entrypoint.sh
ENTRYPOINT ["/entrypoint.sh"]

EXPOSE 5004