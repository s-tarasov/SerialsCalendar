FROM microsoft/aspnet

COPY . /app
WORKDIR /app/Calendar.Web
RUN ["kpm", "restore"]

COPY Deploy/docker-entrypoint.sh /entrypoint.sh
ENTRYPOINT ["/entrypoint.sh"]

EXPOSE 5004