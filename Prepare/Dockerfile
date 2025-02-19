FROM mcr.microsoft.com/mssql/server:2017-latest

# Tools
# install zsh and oh-my-zsh
RUN apt update && apt install -y wget git 

# install dev tools
RUN apt install -y vim tmux


# SQL
ARG SQL_PASSWD="SQLServer2017"
ENV ACCEPT_EULA="Y"
ENV SA_PASSWORD="${SQL_PASSWD}"
ENV MSSQL_PID="Express"

ENV PATH=$PATH:/opt/mssql-tools/bin

WORKDIR "/root"

# Setup db
ARG NORTHWIND_SQL_GITHUB="https://raw.githubusercontent.com/Microsoft/sql-server-samples/master/samples/databases/northwind-pubs/instnwnd.sql"
ARG NORTHWIND_SQL="/usr/share/instnwnd.sql"
RUN wget "${NORTHWIND_SQL_GITHUB}" -O "${NORTHWIND_SQL}"
COPY apply_sql_changes .

RUN echo "Docker steps are completed!"

