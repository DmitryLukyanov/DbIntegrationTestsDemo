FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# generated based on the solution file
WORKDIR /root
COPY . ./ProjectReference
COPY . ./DbIntegrationTestsDemo

RUN ls -R
WORKDIR ./DbIntegrationTestsDemo/DbIntegrationTestsDemo
RUN ls -R
RUN dotnet restore

# run tests on docker run
ENTRYPOINT ["dotnet", "test"]