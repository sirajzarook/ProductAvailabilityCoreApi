#!/bin/bash
cd ProdcutAvailability/
# Publish the project ready for deployment in the container
dotnet publish --configuration Release -o ../Release
