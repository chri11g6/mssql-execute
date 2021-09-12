# mssql-execute
Docker Job

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

## Docker-compose

```yaml
version: '3'
services: 
    MsSQL:
        image: chri11g6/mssql-execute:v1

        environment:
            USERNAME: SA
            PASSWORD: '<YourStrong@Passw0rd>'
            SERVERURL: 'localhost'
            PORT: 1433
            DATABASE: master

        volumes: 
           - './execute.sql:/app/execute.sql'
```