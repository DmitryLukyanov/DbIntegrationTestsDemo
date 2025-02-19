FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# generated based on the solution file
WORKDIR /root
# clarify paths
COPY . ./ProjectReference
COPY . ./DbIntegrationTestsDemo

WORKDIR ./DbIntegrationTestsDemo/DbIntegrationTestsDemo
RUN dotnet restore

# run tests on docker run
ENTRYPOINT ["dotnet", "test"]