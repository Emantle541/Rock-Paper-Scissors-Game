using System;

namespace Final_Project
{
    public class Score
    {
        public int Win,Loss,Tie;
        public String Name;

        public Score(string Name, int Win, int Loss, int Tie)
        {
            this.Name = Name;
            this.Win = Win;
            this.Loss = Loss;
            this.Tie = Tie;
        }


    }
}