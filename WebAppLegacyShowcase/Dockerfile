FROM mcr.microsoft.com/dotnet/framework/sdk:4.8-windowsservercore-ltsc2019 AS build
RUN echo $(ls)
COPY . ./src/
RUN echo $(ls)
WORKDIR /src
RUN echo $(ls)

RUN nuget restore DbIntegrationTestsDemoLegacy.sln
RUN msbuild DbIntegrationTestsDemoLegacy.sln /p:Configuration=Release /p:BuildingProject=true /p:OutDir=..\PUBLISH
RUN echo $(ls -R)
RUN echo $(ls ./PUBLISH/_PublishedWebsites/WebAppLegacyShowcase)

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019 AS runtime
WORKDIR /inetpub/wwwroot
COPY --from=build src/src/PUBLISH/_PublishedWebsites/WebAppLegacyShowcase/ ./

RUN echo $(ls -R)