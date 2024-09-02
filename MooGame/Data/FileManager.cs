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
					//$"{nameAndScore[0]}, {nameAndScore[1]}"
					//string name = nameAndScore[0];
					//int guesses = Convert.ToInt32(nameAndScore[1]);
					//PlayerData playerData = new PlayerData(name, guesses);
					//int positionInList = playerStatistics.IndexOf(playerData);
					//if (positionInList < 0)
					//{
					//	playerStatistics.Add(playerData);
					//}
					//else
					//{
					//	playerStatistics[positionInList].Update(guesses);
					//}
				}				
			};
				
			
			return playerString;
		}
	}
}
