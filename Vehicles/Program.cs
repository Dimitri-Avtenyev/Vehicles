using Vehicles;

// get cd and load env vars
var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");
DotEnv.Load(dotenv);

//var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();

await Host.CreateDefaultBuilder(args)
	.ConfigureWebHostDefaults(webbuilder => {
		webbuilder.UseStartup<Startup>();
	})
	.Build()
	.RunAsync();

