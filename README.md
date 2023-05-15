# Redis Studypoint assignment
## Configuration 2
### Demonstrate Master-Slave replication
The multiple redis servers required for this task are being run in a Docker environment
We've created the docker-compose file in the "Config_2" folder to create and set up our Master-Slave configuration.
In this docker-compose file 4 servers are being created, 1 Master, 2 Replicas, and 1 Sentinel server. The master-slave configuration is made by calling "redis-server --slaveof master 6379" on our replication servers. But this will only replicate data from the amster to the slaves. To "promote" a replica to Master when the Master server is shut down requires the use of Sentinel servers which monitor the availability of a Master and its replicas and will promote a Replica to Master if the Master becomes unavailable.

## Configuration 5
### Demonstrate publish-subscribe pattern
