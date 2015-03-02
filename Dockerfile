FROM microsoft/aspnet

COPY . /app
WORKDIR /app/Web
RUN ["kpm", "restore"]

EXPOSE 5004
ENTRYPOINT ["k", "kestrel"]