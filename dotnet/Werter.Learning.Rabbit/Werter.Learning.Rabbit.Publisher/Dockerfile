FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Werter.Learning.Rabbit.Publisher/Werter.Learning.Rabbit.Publisher.csproj", "Werter.Learning.Rabbit.Publisher/"]
RUN dotnet restore "Werter.Learning.Rabbit.Publisher/Werter.Learning.Rabbit.Publisher.csproj"
COPY . .
WORKDIR "/src/Werter.Learning.Rabbit.Publisher"
RUN dotnet build "Werter.Learning.Rabbit.Publisher.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Werter.Learning.Rabbit.Publisher.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Werter.Learning.Rabbit.Publisher.dll"]
