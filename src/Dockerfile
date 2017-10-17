FROM microsoft/dotnet:2.0.0-sdk
ARG source
WORKDIR /app
COPY . /app
RUN /bin/bash "compile.sh"
RUN /bin/bash "cleanup.sh"
ENV ASPNETCORE_URLS http://productavailability:80
EXPOSE 80
ENTRYPOINT ["dotnet", "ProdcutAvailability.dll"]

