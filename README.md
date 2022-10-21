# Retail

Asynchronous message-based communication.

## Start

Start infrastructure then services.

### Infrastructure

`docker-compose -f infrastructure.yml up --build`

RabbitMQ available at http://localhost:15672 for username and password `guest`.

### Services

`docker-compose -f services.yml up --build`

Client available at http://localhost.

### Local environment

#### Client

    cd Client
    ./start.sh

Client available at http://localhost:5000.

#### Sales

    cd Sales
    ./start.sh