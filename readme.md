## Connect to dockerized Postgres container

### From command line:

1. Access docker container:

   - Command: `docker exec -it <CONTAINER_NAME> bash`
   - (Use `docker ps` to find the container name)

2. Access the database with psql:

   - Command `psql -U <POSTGRES_USER> -d <POSTGRES_DB>`
   - (Both variables can be found in `compose.yml`)

### From application:

Verify that connection string contains `Host=localhost:<PORT_NUMBER>`

- Port number mapping can be found in `compose.yml`

## Migrations

When running migrations, make sure the connection string is correct. That is,
when running the app and database in docker, the connection string is different
from when running the app locally. Moreover, it also differs between connecting
to a local database (local Postgres instance) and a database running in docker.
In the latter case, make sure to append the port number to localhost.

## Commands

Create string of 64 bytes: `openssl rand -base64 64`

## User Secrets

User secrets are used to store sensitive values that are otherwise stored in .env files

List secrets: `dotnet user-secrets list`

Set secret: `dotnet user-secrets add "<KEY>" "<VALUE>"`

Remove secret: `dotnet user-secrets remove <KEY>`

Secrets on Windows are stored in:
C:\Users\<USER_NAME>\AppData\Roaming\Microsoft\UserSecrets\<SECRETS_ID>\secrets.json
