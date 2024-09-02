using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Data
{
	public class FileManager : IFileManager
	{
        public FileManager()
        {
            
        }
        public void SavePlayerScore(string name, int numGuesses, string path)
		{
			StreamWriter output = new StreamWriter(path, append: true);
			output.WriteLine(name + "," + numGuesses);
			output.Close();
		}
		public List<string[]> ReadData(string path)
		{
			List<PlayerData> playerStatistics = new List<PlayerData>();
			List<string[]> playerString = new List<string[]>();
			using (StreamReader reader = new StreamReader(path))
			{				
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					string[] nameAndScore = line.Split(new string[] { "," }, StringSplitOptions.TrimEntries);
					playerString.Add(nameAndScore);					
				}				
			};
			
			return playerString;
		}
	}
}
