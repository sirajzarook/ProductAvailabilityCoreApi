#!/bin/bash

docker stop prodcutavailability
docker rm prodcutavailability

BASE_DIR=`pwd`

# If we detect Windows, then replace some backslashes with double forward slashes
if [[ `uname -o` == 'Msys' ]]; then
	BASE_DIR=${BASE_DIR//\//\/\/}
	HOME_DIR='//c//Users//'`whoami`
else
	HOME_DIR='//Users//'`whoami`
fi

echo "Running docker with prodcutavailability service"
docker run  -d --name prodcutavailability \
	-p 15097:80 \
	--restart always \
	prodcutavailability
	
