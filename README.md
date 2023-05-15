# Redis Studypoint assignment
## Configuration 2
### Demonstrate Master-Slave replication
The multiple redis servers required for this task are being run in a Docker environment
We've created the docker-compose file in the "Config_2" folder to create and set up our Master-Slave configuration.
In this docker-compose file 4 servers are being created, 1 Master, 2 Replicas, and 1 Sentinel server. The master-slave configuration is made by calling "redis-server --slaveof master 6379" on our replication servers. But this will only replicate data from the amster to the slaves. To "promote" a replica to Master when the Master server is shut down requires the use of Sentinel servers which monitor the availability of a Master and its replicas and will promote a Replica to Master if the Master becomes unavailable.

## Configuration 5
### Demonstrate publish-subscribe pattern
The publisher-Subscriber setup is made with a redis client in a .Net application. Two subscribers is created who listens to two different channels representating eachothers "status" channels. When a player starts a game they publish this status update to their own channel and other people subscribing to that channel will get the message. The implementation can be viewed on lines 6-19 in the file redis_5/PubSubCRUD.cs

## CRUD operations in redis
CRUD operations have been implemented with the Configuration 5 task. As in the configuration 5 task the implementation is made with StackExchange.Redis implementation in .NET.
To implement these operations 3 methods are used.
- StringGet(key) which gets the value associated with the key
- StringSet(key, value) which sets the key/value pair in the database
- KeyDelete(key) which deletes the specified key from the database

Implementation of these operations can be viewed on lines 20-48 in the file redis_5/PubSubCRUD.cs
