sudo docker rm calendar -f 

cd /src/Deploy/ \
&& sudo sh /src/Deploy/build_container.sh \
&& sudo docker run --name calendar -it -p 80:80 \
-v /src/Deploy/appsettings.Production.json:/app/appsettings.Production.json \
-v /src/Deploy/Calendar.db:/app/Calendar.db \
calendar