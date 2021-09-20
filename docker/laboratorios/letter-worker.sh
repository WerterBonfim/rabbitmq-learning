#!/usr/bin/env bash
#
# letter-worker.sh
#
# Titulo:       Cria containers para consumir o rabbitmq
# Autor:        Werter Bonfim
# Manutenção:   Werter Bonfim
# Site:         https://github.com/WerterBonfim
# Data:         20-09-2021
# Versão:       1.0.0

# Exit codes
# ==========
# 0   no error
# 1   script interrupted
# 2   error description

#
# ------------------------------------------------------------------------ #
#  Este programa irá criar containers para consumir ou publicar mensagens no RabbitMQ
#
#  Exemplos:
#      $ ./letter-worker.sh -c 2
#      criar dois consumidores
# ------------------------------------------------------------------------ #
# Histórico:
#
#   v1.0 00/00/00, Werter:
#       - Início do programa
#       - Conta com a funcionalidade X
#
# ------------------------------------------------------------------------ #
# Testado em:
#   bash 4.4.19
# ------------------------------- VARIÁVEIS ------------------------------- #

containers=""

# ------------------------------------------------------------------------ #

# ------------------------------- EXECUÇÃO ----------------------------------------- #

# stric mode
set -euo pipefail

containers="$(docker container ls -f name="consumidor*" -aq)"
# echo "$containers"

# docker container rm "$containers"
docker container ls -f name="consumidor*" -aq  | xargs docker container rm

docker container run --rm --name container1 --network="host" img-consumidor
