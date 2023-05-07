using System;
namespace Vehicles
{
	public static class DotEnv
	{
		public static void Load(string filePath)
		{
			if (!File.Exists(filePath)) {
				return;
			}
			foreach (var line in File.ReadAllLines(filePath)) {
				var lines = line.Split("=", StringSplitOptions.RemoveEmptyEntries);

				if (lines.Length != 2) {
					continue;
				}
				Environment.SetEnvironmentVariable(lines[0], lines[1]);
			}
		}
	}
}

