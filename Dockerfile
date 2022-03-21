FROM mcr.microsoft.com/dotnet/runtime:5.0

COPY bin/Release/net5.0 App/
WORKDIR /App
CMD ["dotnet", "CodingTracker.dll"]