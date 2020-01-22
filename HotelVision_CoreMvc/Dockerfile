FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY HotelVision_CoreMvc/HotelVision_CoreMvc.csproj HotelVision_CoreMvc/
RUN dotnet restore "HotelVision_CoreMvc/HotelVision_CoreMvc.csproj"
COPY . .
WORKDIR "/src/HotelVision_CoreMvc"
RUN dotnet build "HotelVision_CoreMvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HotelVision_CoreMvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotelVision_CoreMvc.dll"]
