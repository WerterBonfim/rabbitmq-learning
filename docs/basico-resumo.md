### Resumo do livro: The optimal Rabbitmq Guide - From Beginner to advanced

# Benefícios de uma arquitetura de microsserviços

* Desenvolvimento e manutenção mais fácil
	- divisão do app serviços, um para cada funcionalidade
	- cada serviço não precisa se preocupar com interrupções
de outros serviços.



* Isolamento obrigatório
	- Isola a falha em um único modulo. Exemplo: Se um serviço parar os
outros continuaram sem interferir nos outros serviços.
	
* Maior velocidade e produtividade
	- Fácil manutenção 
	- Fácil de testar

* Escalabilidade aprimorada
	- 


## Porque e quando usar o RabbitMQ

- Baixo acoplamento entre o remetente e o receptor

## Exchanges

- As mensagens são encaminhadas para uma exchange (correios, mercado livre. Como se fosse um roteador).
- O trabalho dele é rotear as mensagens para a fila correta, ele faz isso com a ajuda
do binding (ligações) e routing keys (chave de roteamento). 
O biding faz a ligação entre a fila e o exchange. A routing key é como um endereço 
para a mensagem.

### Tipos de Exchanges

Direct: envia mensagens para uma fila baseada na chave de roteamento (routing key). 
Exemplo se uma fila usa a chave de roteamento 'processar-pdf', ...

Topic: baseada em coriga para combinar com a chave de roteamento.

Fanout (espalhar): manda as mensagens para todas as filas que são vinculadas a ela.

Header: usa atributos de cabeçalho para rotear

# RabbitMQ e conceitos 

* Producer: Aplicação que envia a mensagem

* Consumer: Aplicação que recebe a mensagem

* Queue: A fila é o lugar onde as mensagens são armazenadas antes de ser consumida
pelo consumidor, ou de outra forma, removida da fila.
 
* Connection: Conexão TCP entre a aplicação e o RabbitMQ (Corretora/Corretor)

* Channel: Uma conexão virtual dentro de uma conexão. Ao publicar ou 
consumir mensagem ou se inscrever em uma fila, tudo é feito em um canal.

* Exchange: Teoricamente, o exchange (correios, mercado livre) é o primeiro 
ponto de entrada para uma mensagem. Ela recebe mensagens dos produtores e 
os envia para as filas, dependendo das regras definidas pela categoria do corretor (exchange).
Uma fila precisa ser vinculada a pelo menos um corretor (exchange) para poder
receber mensagens.

* Binding (ligação/vinculo): Um binding é uma associação ou relação entre uma fila
e um corretor. Isso descreve qual fila está interessada em mensagens de uma 
determinada corretora.

* RoutingKey (chave de ligação): A chave que a corretora analisa no momento decidir
como endereçar a mensagem para a fila. Pense na chave de ligação como um
endereço de destino para uma mensagem.

* AMQP (Advanced Message Queueng Protocol): O protocolo primário usado pelo 
RabbitMQ para mensagens.

* Users: É possível se conectar ao RabbitMQ com um determinado nome de usuário e senha, 
com permissões atribuídas, como diretos de leitura, gravação e configuração.
Os usuários podem também receber permissões para hosts virtuais específicos.

* Vhost: Virtual host ou Vhost, segrega aplicativos que estão usando a mesma
instância do RabbitMQ. Diferentes usuários pode ter diferentes privilégios de acesso
para diferentes vhosts e filas, e a exchange podem ser criadas para existirem apenas
em um vhost.

* Acknowledgments and Confirms (Confirmações): indicadores de que mensagens
foram recebidas ou postas em prática. Confirmações(Acknowledgements) podem ser
usadas em ambas as direções; por exemplo, um consumidor pode indicar ao servidor que
recebeu/processou uma mensagem e o servidor pode relatar a mesma coisa ao produtor.

Exchange são agentes que endereçam as mensagens, vivendo em um virtual host (Vhost) 
com o RabbitMQ. Exchange aceitam menagens de uma ‘app’ produtor e endereçam para a fila de mensagem com a ajuda dos atributos de cabeçalho
