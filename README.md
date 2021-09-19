# mssql-execute
[![Docker Pull](https://img.shields.io/docker/pulls/chri11g6/mssql-execute.svg)](https://hub.docker.com/r/chri11g6/mssql-execute)
[![Docker Stars](https://img.shields.io/docker/stars/chri11g6/mssql-execute.svg?maxAge=2592000)](https://hub.docker.com/r/chri11g6/mssql-execute)

This docker image is made as a Job or Coinjob, and is easy to use. It is a small program that runs a SQL script on a mssql database.

Insert your envoriment arguments in either the Docker Command or Docker-compose, where -v "./execute.sql:/app/execute.sql" or

```yaml
volumes:
    - './execute.sql:/app/execute.sql'
```
is the path to your SQL script.

## Environment

|             | Description              |
|-------------|--------------------------|
| `USERNAME`  | Username to database     |
| `PASSWORD`  | Password to database     |
| `SERVERURL` | Url or Ip address        |
| `PORT`      | Port nummber to database |
| `DATABASE`  | What database name?      |

## Docker command

``` bash
docker run -v "./execute.sql:/app/execute.sql" -e USERNAME=SA -e PASSWORD=<YourStrong@Passw0rd> -e SERVERURL=localhost -e PORT=1433 -e DATABASE=master chri11g6/mssql-execute:v1
```

### Docker-compose

```yaml
version: '3'
services: 
    MsSQLexecute:
        image: chri11g6/mssql-execute:v1

        environment:
            USERNAME: SA
            PASSWORD: '<YourStrong@Passw0rd>'
            SERVERURL: 'localhost'
            PORT: 1433
            DATABASE: master

        volumes: 
           - './execute.sql:/app/execute.sql'

# Use this to connection to other network
networks:
    default:
        external: true
        name: host
```
