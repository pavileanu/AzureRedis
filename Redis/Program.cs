using StackExchange.Redis;

string connectionString = "";

using (var cache = ConnectionMultiplexer.Connect(connectionString))
{
    IDatabase db = cache.GetDatabase();

    var result = await db.ExecuteAsync("ping");
    Console.WriteLine($"PING = {result.Type} : {result}");

    bool setValue = await db.StringSetAsync("keys:mircea", "100");
    Console.WriteLine($"SET: {setValue}");

    string getValue = await db.StringGetAsync("keys:mircea");
    Console.WriteLine($"GET: {getValue}");
}