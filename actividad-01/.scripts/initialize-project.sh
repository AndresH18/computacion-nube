##!/usr/bin/env bash
#
## This script installs the required dependencies like git, .NET and downloads the latest version of the repository.
## To run the file you need to make it executable. chmod +x initialize-project.sh
#
## Variables
#REPO_URL="https://github.com/AndresH18/computacion-cientifica.git"
#ACTIVITY_FOLDER="actividad-01"
#
## Function to check if a command exists
#command_exists() {
#    command -v "$1" >/dev/null 2>&1
#}
#
## Check if the script is being run as root
#if [ "$EUID" -ne 0 ]; then
#    echo "This script must be run as root. Re-running with sudo..."
#    sudo "$0" "$@"
#    exit $?
#fi
#
## Check if Git is installed and install it if not
#if ! command_exists git; then
#    echo "Git is not installed. Installing Git..."
#    apt-get update
#    apt-get install -y git
#    if ! command_exists git; then
#        echo "Git installation failed. Please install Git manually and try again."
#        exit 1
#    fi
#fi
#
## Clone or update the repository
#if [ -d "$ACTIVITY_FOLDER" ]; then
#    echo "Repository already exists. Pulling the latest changes..."
#    cd "$ACTIVITY_FOLDER" || exit
#    git pull origin main
#else
#    echo "Cloning the repository..."
#    git clone "$REPO_URL"
#    cd "$ACTIVITY_FOLDER" || exit
#fi
#
## Check if .NET is installed
#if ! command_exists dotnet; then
#
#  # install .net from ubuntu
#  echo "Installing .NET from Ubuntu Feed"
#  apt-get update && \
#  apt-get install -y dotnet-sdk-8.0
#fi
#
## Display the installed .NET SDK version
#echo ".NET SDK version:"
#dotnet --version
#
#echo "Initialization complete"