FROM microsoft/aspnet:1.0.0-beta5

COPY . /app
WORKDIR /app/Calendar.Web

COPY /Deploy/docker-entrypoint.sh /entrypoint.sh

#RUN dnu restore	
RUN bash -c ' while ! dnu restore; do :; done '

ENTRYPOINT ["/entrypoint.sh"]

EXPOSE 5004