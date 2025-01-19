# Lamplist Server Instance

Welcome to the server for the Lamplist application.

## Setting up a Secure Linode Instance
https://techdocs.akamai.com/cloud-computing/docs/set-up-and-secure-a-compute-instance

- [ ] Configure failtoban

### UFW Firewall
https://www.linode.com/docs/guides/configure-firewall-with-ufw/

## Hosting ASP.NET Core Application
https://www.linode.com/docs/guides/tutorial-host-asp-net-core-on-linux/

## Kitty
If connecting from a Kitty terminal, and using tmux:

```
kitten ssh {user}@{host}
```

## Upcoming Thoughts for Deployment
- [ ] The NGINX (or whatever else) configuration can be version controlled! Just make sure no secrets are included in the configuration.
    - Once cloned in, config can be coppied or linked to the correct places. Can even make a shell script to automate this.
- [ ] The application is turning into a mono-repo (client, server, tests, soon deployement).
    - Embrace this. Do some research on monorepos. How should it be organized? What kind of benefits do I get from a monorepo?
- [ ] Try out making the PostgreSQL database directly on the linode. No need to find some other SQL service or pay for a Linode database, just use what I already have!
    - Obviously this may not scale well, but I'm not expecting a lot of users so...

