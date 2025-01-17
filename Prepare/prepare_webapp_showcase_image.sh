CONTAINER_NAME="webapp-showcase"

docker rm -f "${CONTAINER_NAME}" \
   && echo "Container ${CONTAINER_NAME} was removed" \
   || :

docker build -t webapp-showcase -f ./../WebAppShowcase/Dockerfile ./../WebAppShowcase/ 
# --progress=plain --no-cache

# NOTE: Use the below for debugging
# docker run -d \
#  --name ${CONTAINER_NAME} \
#  --entrypoint tail \
#  webapp-showcase \
#  -f /dev/null

#docker exec -it ${CONTAINER_NAME} zsh
