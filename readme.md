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
