# Lamplist Server Instance

Welcome to the server for the Lamplist application.

## Setting up a Secure Linode Instance
https://techdocs.akamai.com/cloud-computing/docs/set-up-and-secure-a-compute-instance

- [ ] Configure failtoban

### UFW Firewall
https://www.linode.com/docs/guides/configure-firewall-with-ufw/

## Hosting ASP.NET Core Application
https://www.linode.com/docs/guides/tutorial-host-asp-net-core-on-linux/

### NGINX
NGINX configuration is located at `{project}/nginx` directory. Create a link for all files in this directory into the Linode Instance nginx configuration path.

By default:
```
sudo mv /etc/nginx/nginx.conf /etc/nginx/nginx.conf.bak
sudo ln -s ./nginx.conf /etc/nginx/nginx.conf
sudo ln -s ./proxy.conf /etc/nginx/proxy.conf
```
### Server Location
By default, the server should be located at `/var/www/server`. This uses the expected location for web servers, and separates the production code from the main repository.

From the projects root directory:
```
sudo cp -r ./server /var/www/server
```

### Systemd
Add the system file to SystemD, enable and reload. This will start the application at startup of the VM, and will autorestart if not running:

From the projects root directory:
```
sudo cp  ./nginx/lamplist-server.service /etc/systemd/system/lamplist-server.service
sudo systemctl enable lamplist-server
sudo systemctl start lamplist-server
```

Check that the service is running with `systemctl status lamplist-server`.

## Kitty
If connecting from a Kitty terminal, and using tmux:

```
kitten ssh {user}@{host}
```

## Upcoming Thoughts for Deployment
- [ ] The application is turning into a mono-repo (client, server, tests, soon deployement).
    - Embrace this. Do some research on monorepos. How should it be organized? What kind of benefits do I get from a monorepo?
- [ ] Error on server side that says "HOST" is null for data context. Not getting the value from user-secrets? Not the correct host name?
    - Ignore cors errors for the time being. May be a red herring

