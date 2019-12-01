cp .dockerignore ../ \
  && cd .. \
  && docker -D build --file Deploy/Dockerfile --tag calendar . \
  && rm .dockerignore
