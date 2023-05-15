using StackExchange.Redis;

Console.WriteLine("Hello, World!");
/*ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");
IDatabase db = redis.GetDatabase();
Console.WriteLine(db.ToString());
Console.WriteLine(db.ListGetByIndex("a", 1));
*/
/*var channel = redis.GetSubscriber().Subscribe("users:1");
channel.OnMessage(msg =>
{
	Console.WriteLine((string)msg.Message);
});*/

using (var con = ConnectionMultiplexer.Connect("localhost:6379"))
{
	//Creating 2 subscribers symbolising 2 different players
	var sub1 = con.GetSubscriber();
	var sub2 = con.GetSubscriber();

	//Subscribing to the other players status channel
	sub1.Subscribe("users:2", (c, v) => {
		Console.WriteLine("Player1: Got notification: " + (string)v);
	});

	sub2.Subscribe("users:1", (c, v) => {
		Console.WriteLine("Player2: Got notification: " + (string)v);
	});

	//Publishing that player1 started a game
	sub1.Publish("users:1", "\"Player 1\" Started playing Counter Strike");
	Console.ReadKey();

	//Reading playername from DB
	var user_1_name = con.GetDatabase().StringGet("users:1:name");
	Console.WriteLine($"Reading user 1's name from DB (users:1:name): {user_1_name}");
	Console.ReadKey();


	//Creating new player
	con.GetDatabase().StringSet("users:3:name", "player_name_3");
	//Check if new player is added
	var user_3_name = con.GetDatabase().StringGet("users:3:name");
	Console.WriteLine($"Reading user 3's name from DB (users:3:name): {user_3_name} | expected \"player_name_3\"");
	Console.ReadKey();


	//Update player 3 name
	con.GetDatabase().StringSet("users:3:name", "player_name_3_1");
	//check if player 3's name is updated
	user_3_name = con.GetDatabase().StringGet("users:3:name");
	Console.WriteLine($"Reading user 3's name from DB (users:3:name): {user_3_name} | expected \"player_name_3_1\"");
	Console.ReadKey();


	//Delete player 3's name from DB
	con.GetDatabase().KeyDelete("users:3:name");
	//check if player 3's name has been removed
	user_3_name = con.GetDatabase().StringGet("users:3:name");
	Console.WriteLine($"Reading user 3's name from DB (users:3:name): {user_3_name} | expected \"nil\"");
	
}
