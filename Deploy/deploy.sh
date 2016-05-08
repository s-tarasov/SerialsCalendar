echo_time() {
    date +"%R $*"
}

echo_time 'save image' && sudo docker save -o calendar.image calendar \
	&& echo_time 'upload image' && rsync -av --progress /src/Deploy/calendar.image root@episondar.info.tm:/deploy/Web/calendar.image \
	&& echo_time 'connect to server' && { ssh root@episondar.info.tm /bin/bash << EOF
		echo 'stop nginx' && docker stop nginx && docker rm nginx \
		&& echo 'stop site' && docker stop calendar && docker rm calendar && docker rmi calendar \
		&& echo 'load image' && docker load --input /deploy/Web/calendar.image \
		&& echo 'start site' && docker run -t -v /deploy/Web:/configs -d --name calendar calendar /port=5004 \
		&& echo 'start nginx' && docker run -d -p 80:80 -v /usr/local/etc/nginx:/etc/nginx/conf.d -v /usr/local/var/log/nginx:/var/log/nginx --link calendar:calendar --name nginx nginx
EOF
	} && echo_time 'deploy complete'
