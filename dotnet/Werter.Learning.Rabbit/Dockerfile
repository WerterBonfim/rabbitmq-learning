FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY ["Werter.Learning.Rabbit.LetterConsumer/Werter.Learning.Rabbit.LetterConsumer.csproj", "Werter.Learning.Rabbit.LetterConsumer/"]
COPY ["Werter.Learning.Rabbit.Models/Werter.Learning.Rabbit.Models.csproj", "Werter.Learning.Rabbit.Models/"]

RUN dotnet restore "Werter.Learning.Rabbit.LetterConsumer/Werter.Learning.Rabbit.LetterConsumer.csproj"

COPY ["Werter.Learning.Rabbit.LetterConsumer/", "Werter.Learning.Rabbit.LetterConsumer/"]
COPY ["Werter.Learning.Rabbit.Models/", "Werter.Learning.Rabbit.Models/"]


WORKDIR "/src/Werter.Learning.Rabbit.LetterConsumer"
RUN dotnet build "Werter.Learning.Rabbit.LetterConsumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Werter.Learning.Rabbit.LetterConsumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Werter.Learning.Rabbit.LetterConsumer.dll"]
