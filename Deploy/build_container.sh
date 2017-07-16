mv .dockerignore ../ \
  && cd .. \
  && docker -D build --file Deploy/Dockerfile --tag calendar . \
  && mv .dockerignore Deploy/
