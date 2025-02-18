FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /root
COPY . .

RUN dotnet restore

# run tests on docker run
ENTRYPOINT ["dotnet", "test"]