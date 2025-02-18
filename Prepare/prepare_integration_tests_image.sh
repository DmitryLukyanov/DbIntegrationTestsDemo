CONTAINER_NAME="integration-tests"

docker rm -f "${CONTAINER_NAME}" \
   && echo "Container ${CONTAINER_NAME} was removed" \
   || :

docker build -t integration-tests --no-cache --progress=plain -f ./../DbIntegrationTestsDemo/Dockerfile ./../

# NOTE: Use the below for debugging
# Case 1: run and mount local integration-tests folder to the container opt/integration-tests
# docker run \
#   -d \
#   --name "${CONTAINER_NAME}" \
#   -v "$( pwd )/integration-tests:/opt/integration-tests" \
#   integration-tests

# Case 2: run in tail mode
# docker run -d \
#  --name ${CONTAINER_NAME} \
#  --entrypoint tail \
#  integration-tests \
#  -f /dev/null

#docker exec -it ${CONTAINER_NAME} zsh
