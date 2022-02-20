# https://hub.docker.com/_/microsoft-dotnet-sdk/
# Debian 10 based
# FROM mcr.microsoft.com/dotnet/sdk:latest AS build
# Ubuntu 20.04
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

# install nodejs & npm
RUN curl -fsSL https://deb.nodesource.com/setup_16.x | bash -
RUN apt-get install -y nodejs apt-utils
RUN node --version
RUN npm install -g npm
RUN npm --version


WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Directory.Build.props .

# project files for restore
COPY BLL/*.csproj ./BLL/
COPY DAL/*.csproj ./DAL/
COPY Domain.App/*.csproj ./Domain.App/
COPY Helpers/*.csproj ./Helpers/
COPY MetaApi.DTO.v1/*.csproj ./MetaApi.DTO.v1/
COPY PublicApi.DTO.v1/*.csproj ./PublicApi.DTO.v1/
COPY Sky24Api.DTO.v1/*.csproj ./Sky24Api.DTO.v1/
COPY WebApp/*.csproj ./WebApp/

RUN dotnet restore


# copy everything else and build app
COPY BLL/. ./BLL/
COPY DAL/. ./DAL/
COPY Domain.App/. ./Domain.App/
COPY Helpers/. ./Helpers/
COPY MetaApi.DTO.v1/. ./MetaApi.DTO.v1/
COPY PublicApi.DTO.v1/. ./PublicApi.DTO.v1/
COPY Sky24Api.DTO.v1/. ./Sky24Api.DTO.v1/
COPY WebApp/. ./WebApp/

# build js/css stuff
#COPY SiteJS/. ./SiteJS/
#WORKDIR /source/SiteJS
#RUN npm install -g npm@latest
#RUN npm install
#RUN npm run build

# build and publish WebApp
WORKDIR /source/WebApp
RUN dotnet publish -c release -o /app --no-restore


# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal

# set timezone
# https://serverfault.com/questions/683605/docker-container-time-timezone-will-not-reflect-changes
ENV TZ 'Europe/Tallinn'
RUN echo $TZ > /etc/timezone && \
    apt-get update && apt-get install -y tzdata && \
    rm /etc/localtime && \
    ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && \
    dpkg-reconfigure -f noninteractive tzdata && \
    apt-get clean

WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "WebApp.dll"]
