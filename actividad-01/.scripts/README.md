# Scripts

There are 2 main scripts

- [initialize-instance.sh](#initialize-instance.sh)
- [create-project.sh](#create-project)

To run this scripts, you need first to make them executable: `sudo chmod +x <file>`

## Initialize Instance

This [file](initialize-instance.sh) will download the .NET runtime in the ubuntu instance

## Create Project

This [file](create-project.sh) needs 2 arguments. It will build and publish the app located on `<project_folder>` (the
first argument passed) and cp the published app into `<service_folder>`(the second argument)

- `<project_folder>`: project location, can be absolute or relative to the pwd.
- `<service_folder>`: name of the folder where to store the published files. Its created inside of `/var/`. **If file
  already exists, then its deleted**

```
./create-project.sh ../Actividad.Api api
```

## Registering System Service

To make an app into a system service so that it can start when the system boots, we can create a file like this
in `/etc/systemd/system/<my-service>.service`, where name is the name of the app.

_app.service_
```
[Unit]
Description="My service"
After=network.target

[Service]
WorkingDirectory=/var/<app>
ExecStart=<command>
Restart=always
RestartSec=10
SyslogIdentifier=<my-app-name>
User=ubuntu

[Install]
WantedBy=multi-user.target
```

After creating the file you need to reload the system configuration `sudo systemctl daemon-reload`.  
Enable the service `sudo systemctl enable <my-service>`  
Start the service `sudo systemctl start <my-service>`  
Stop the service `sudo systemctl stop <my-service>`
Disable the service `sudo systemctl disable <my-service>`


Check status of the service: `sudo systemctl status <my-service>`

See example [here](https://medium.com/@The_Anshuman/creating-a-service-in-linux-a-step-by-step-guide-61d7c1d200af):

> [!NOTE]
> See example here for app Actividad01.Api, service name _my-api_ [my-api.service]
