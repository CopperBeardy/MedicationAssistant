#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["MedicationAssistant/MedicationAssistant.csproj", "MedicationAssistant/"]
RUN dotnet restore "MedicationAssistant/MedicationAssistant.csproj"
COPY . .
WORKDIR "/src/MedicationAssistant"
RUN dotnet build "MedicationAssistant.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MedicationAssistant.csproj" -c Release -o /app/publish

#COPY out /wwwroot/MedicationAssistant out /wwwroot/

FROM base AS final
EXPOSE 5000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MedicationAssistant.dll"]