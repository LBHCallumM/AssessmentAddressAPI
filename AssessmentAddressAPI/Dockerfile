FROM mcr.microsoft.com/dotnet/sdk:6.0
RUN dotnet tool install --global dotnet-ef --version 6.0.6

# Copy csproj and restore as distinct layers
COPY ./AssessmentAddressAPI.sln ./
COPY ./AssessmentAddressAPI/AssessmentAddressAPI.csproj ./AssessmentAddressAPI/

RUN dotnet restore ./AssessmentAddressAPI/AssessmentAddressAPI.csproj


COPY . ./
RUN dotnet build -c Release -o out
RUN dotnet publish -c Release -o out

EXPOSE 3000
CMD ASPNETCORE_URLS=http://+:${PORT:-3000} dotnet ./out/AssessmentAddressAPI.dll
