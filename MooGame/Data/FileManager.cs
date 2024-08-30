using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Data
{
	public class FileManager
	{
        public FileManager()
        {
            
        }
        public void SavePlayerScore(string name, int numGuesses)
		{
			StreamWriter output = new StreamWriter("result.txt", append: true);
			output.WriteLine(name + "," + numGuesses);
			output.Close();
		}
		private List<PlayerData> ReadData()
		{
			List<PlayerData> playerStatistics = new List<PlayerData>();
			using (StreamReader reader = new StreamReader("result.txt"))
			{				
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					string[] nameAndScore = line.Split(new string[] { "," }, StringSplitOptions.None);
					string name = nameAndScore[0];
					int guesses = Convert.ToInt32(nameAndScore[1]);
					PlayerData playerData = new PlayerData(name, guesses);
					int positionInList = playerStatistics.IndexOf(playerData);
					if (positionInList < 0)
					{
						playerStatistics.Add(playerData);
					}
					else
					{
						playerStatistics[positionInList].Update(guesses);
					}
				}				
			};
				
			
			return playerStatistics;
		}
	}
}
