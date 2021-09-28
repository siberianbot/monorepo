# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /src

ADD Accounting.Common/ /src/Accounting.Common
ADD Accounting.Common.DomainModel/ /src/Accounting.Common.DomainModel/
ADD Accounting.DataAccess/ /src/Accounting.DataAccess/
ADD Accounting.DataAccess.Design/ /src/Accounting.DataAccess.Design/
ADD Accounting.DataAccess.Extensions/ /src/Accounting.DataAccess.Extensions/
ADD Accounting.DataAccess.Implementation/ /src/Accounting.DataAccess.Implementation/
ADD Accounting.Service/ /src/Accounting.Service/
ADD Accounting.Service.Entries/ /src/Accounting.Service.Entries/

WORKDIR /src/Accounting.Service.Entries
RUN dotnet restore
RUN dotnet publish -c release -o /app/Accounting.Service.Entries --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app/Accounting.Service.Entries
COPY --from=build-env /app/Accounting.Service.Entries ./
ENTRYPOINT ["dotnet", "Accounting.Service.Entries.dll"]