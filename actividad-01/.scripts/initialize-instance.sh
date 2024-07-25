#!/usr/bin/env bash

## Installs all dependencies, like .git 
## To run the file you need to make it executable. chmod +x initialize-project.sh

# Function to check if a commmand exists
command_exists() {
  command -v "$1" > /dev/null 2>&1
}

# Check if the script is being run as root
if [ "$EUID" -ne 0 ]; then
    echo "This script must be run as root. Re-running with sudo..."
    sudo "$0" "$@"
    exit $?
fi

# Check if .NET is installed
if ! command_exists dotnet; then

  # install .net from ubuntu
  echo "Installing .NET from Ubuntu Feed"
  apt-get update && \
  apt-get install -y dotnet-sdk-8.0
fi

# Display the installed .NET SDK version
echo ".NET SDK version:"
dotnet --version

echo "Initialization complete"