# run tests
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

COPY ./InterestEndToEndTest.Console .
RUN dotnet restore

RUN dotnet publish -c release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "InterestEndToEndTest.Console.dll"]

