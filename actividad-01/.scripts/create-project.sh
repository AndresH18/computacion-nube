#!/usr/bin/env bash

# Check if the required arguments are passed
if [ $# -lt 2 ]; then
    echo "Usage: $0 <project_folder> <service_folder>"
    exit 1
fi

# project folder, Relative to .scripts location
PROJECT_FOLDER="$1"
# Folder in /var/ to store the project
SERVICE_FOLDER="$2"

# Check if the script is being run as root
if [ "$EUID" -ne 0 ]; then
    echo "This script must be run as root. Re-running with sudo..."
    sudo "$0" "$@"
    exit $?
fi

# Move to folder
cd "$PROJECT_FOLDER" || (echo "Failed to move to $SERVICE_FOLDER" & exit)

# build project
dotnet restore
# publish project
dotnet publish

# create service folder in /var/
mkdir /var/"$SERVICE_FOLDER"
# copy publish to service folder
cp bin/Release/net8.0/publish/ /var/"$SERVICE_FOLDER"