using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_0
{
    internal class Player
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name=new string("");
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string password = new string("");
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private int totalGames = 0;
        public int TotalGames
        {
            get { return totalGames; }
            set { totalGames = value; }
        }
        private int winGames = 0;
        public int WinGames
        {
            get { return winGames; }
            set { winGames = value; }
        }
        public Player(int id, string name, string password, int totalGames, int winGames)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.totalGames = totalGames;
            this.winGames = winGames;
        }
        public Player() { }
    }
}
