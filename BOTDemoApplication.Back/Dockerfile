FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["BOTDemoApplication.Back/BOTDemoApplication.Back.csproj", "BOTDemoApplication.Back/"]
RUN dotnet restore "BOTDemoApplication.Back/BOTDemoApplication.Back.csproj"
COPY . .
WORKDIR "/src/BOTDemoApplication.Back"
RUN dotnet build "BOTDemoApplication.Back.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BOTDemoApplication.Back.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BOTDemoApplication.Back.dll"]