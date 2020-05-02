#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-bionic AS base
RUN apt-get update  < /dev/null > /dev/null
RUN apt-get remove -qq krb5-config krb5-user  < /dev/null > /dev/null
RUN apt-get install -qq krb5-config  < /dev/null > /dev/null
RUN apt-get install -qq krb5-user  < /dev/null > /dev/null
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
WORKDIR /src
COPY S2DbTester.csproj ./
RUN dotnet restore "./S2DbTester.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "S2DbTester.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "S2DbTester.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY launch.sh /launch.sh
RUN chmod u+x /launch.sh
ENTRYPOINT /launch.sh
