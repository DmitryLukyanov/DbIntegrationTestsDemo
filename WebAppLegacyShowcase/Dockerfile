FROM mcr.microsoft.com/dotnet/framework/sdk:4.8-windowsservercore-ltsc2019 AS build

COPY . ./src/
WORKDIR /src

RUN nuget restore DbIntegrationTestsDemoLegacy.sln
RUN msbuild DbIntegrationTestsDemoLegacy.sln /p:Configuration=Release /p:BuildingProject=true /p:OutDir=..\PUBLISH
RUN echo $(ls src/PUBLISH/_PublishedWebsites/DbIntegrationTestsDemoLegacy)

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019 AS runtime
WORKDIR /inetpub/wwwroot
COPY --from=build src/src/PUBLISH/_PublishedWebsites/DbIntegrationTestsDemoLegacy/ ./

RUN echo $(ls)