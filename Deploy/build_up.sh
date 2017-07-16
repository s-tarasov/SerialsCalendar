sudo docker rm calendar -f 

cd /src/Deploy/ \
&& sudo sh /src/Deploy/build_container.sh \
&& sudo docker run --name calendar -it -p 5000:80 --link mysql:mysql -v /src/Deploy/appsettings.Production.json:/app/appsettings.Production.json calendar