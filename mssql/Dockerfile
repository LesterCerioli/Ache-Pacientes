FROM mcr.microsoft.com/mssql/server
COPY all.sql all.sql
COPY auto-setup-db.sql auto-setup-db.sql

RUN /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P myPassword -i auto-setup-db.sql