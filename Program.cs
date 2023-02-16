//Ethan Mantle
//IT 2040
//Completed on: 12/8/2022
//Time to Complete: 5 hours, 28 minutes


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            bool correctcase = true;
            while(correctcase == true)
            {
            List<Score> ScoreList = ReadFile();
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");
            Console.WriteLine("1. Start New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Quit");
            Console.WriteLine("Enter Choice:");
            String Choice = Console.ReadLine();
            switch(Choice)
            {
                case "1":
                    Score NewPlayer = NewGame();
                    ScoreList.Add(NewPlayer);
                    WriteFile(ScoreList);
                    correctcase = false;
                    break;

                case "2":
                    LoadGame(ScoreList);
                    WriteFile(ScoreList);
                    correctcase = false;
                    break;

                case "3":
                    PrintLeaderboard(ScoreList);
                    break;

                default:
                    Console.WriteLine("Not a correct input!");
                    break;

            }
            }
        }

        static void WriteFile(List<Score> ScoreList)
        {
            using (StreamWriter filewriter = new StreamWriter ("player_log.csv"))
            {
                foreach(Score Player in ScoreList)
                {
                    filewriter.WriteLine($"{Player.Name},{Player.Win},{Player.Loss},{Player.Tie}");
                }
                Console.WriteLine("Data Successfully Written.");
            }
            
        }

        static void PrintLeaderboard(List<Score> ScoreList)
        {
            string[] scores = System.IO.File.ReadAllLines("player_log.csv");    
            int Column = 1;  
            Console.WriteLine("Players Sorted by Wins:", Column);   
            foreach (string str in FindInfo(scores, Column))  
            {  
                Console.WriteLine(str);  
            } 
        }  
        //Could only get it to print all of them sorted by wins

        static IEnumerable<string> FindInfo(IEnumerable<string> file, int num)  
        {    
            var scoreQuery = from line in file
                let fields = line.Split(',')  
                orderby fields[num] descending  
                select line;  
  
        return scoreQuery;  
        }

        static List<Score> ReadFile()
        {
            List<Score> ScoreList = new List<Score>();
            string[] lines = File.ReadAllLines("player_log.csv");
            for(int index = 0;index<lines.Length;index++)
            {
                string DataLine = lines[index];
                string[] data = DataLine.Split(',');

                try
                {
                    String name = data[0];
                    int win = Convert.ToInt32(data[1]);
                    int loss = Convert.ToInt32(data[2]);
                    int tie = Convert.ToInt32(data[3]);
                    

                    Score PlayerInfo = new Score(name,win,loss,tie);
                    ScoreList.Add(PlayerInfo);
                }
                catch(Exception)
                {
                    Console.WriteLine($"Exception");
                    continue;
                }
            }

            return ScoreList;
        }


        static void LoadGame(List<Score> ScoreList)
        {
                String Name;
                Console.WriteLine("What is your Name?\n");
                Name = Console.ReadLine();
                bool Found = false;
                Console.WriteLine($"Welcome back {Name}");
                foreach(Score Player in ScoreList)
                {
                    if(Player.Name==Name)
                    {
                        RPSGame(Player);
                        Found = true;
                        Console.WriteLine($"Hello {Name}");
                        break;
                    }
                }
                if(Found==false)
                {
                    Console.WriteLine("Player was not found!");
                }
        }


        static Score NewGame()
        {
            String Name;
            Console.WriteLine("What is Your Name?\n");
            Name = Console.ReadLine();
            Console.WriteLine($"Hello {Name}, Lets Play!\n");
            Score PlayerScore = new Score($"{Name}", 0, 0, 0);
            RPSGame(PlayerScore);
            return PlayerScore;
        }


        

        static void RPSGame(Score PlayerScore)
        {
            int round = 1;
            bool PlayAgain = true;
            while(PlayAgain == true)
            {
                Console.WriteLine($"Round {round}\n");
                Random randomChoice = new Random();
                int computerChoice = randomChoice.Next(1,4);
                Console.WriteLine("1. Rock");
                Console.WriteLine("2. Paper");
                Console.WriteLine("3. Scissors");
                Console.WriteLine("What will it be?\n");
                String GameChoice = Console.ReadLine();
                if(computerChoice == 1)
                {
                    if(GameChoice == "1")
                    {
                        Console.WriteLine("You Chose Rock\n");
                        Console.WriteLine("The Computer Chose Rock\n");
                        Console.WriteLine("It is a tie.\n");
                        PlayerScore.Tie++;
                    }
                    else if(GameChoice == "2")
                    {
                        Console.WriteLine("You Chose Paper\n");
                        Console.WriteLine("The Computer Chose Rock\n");
                        Console.WriteLine("You Win!\n");
                        PlayerScore.Win++;
                    }
                    else if(GameChoice == "3")
                    {
                        Console.WriteLine("You Chose Scissors\n");
                        Console.WriteLine("The Computer Chose Rock\n");
                        Console.WriteLine("The Computer Wins!\n");
                        PlayerScore.Loss++;
                    }
                }
                else if(computerChoice == 2)
                {
                   if(GameChoice == "1")
                    {
                        Console.WriteLine("You Chose Rock\n");
                        Console.WriteLine("The Computer Chose Paper\n");
                        Console.WriteLine("The Computer Wins!\n");
                        PlayerScore.Loss++;
                    }
                    else if(GameChoice == "2")
                    {
                        Console.WriteLine("You Chose Paper\n");
                        Console.WriteLine("The Computer Chose Paper\n");
                        Console.WriteLine("It's a Tie.\n");
                        PlayerScore.Tie++;
                    }
                    else if(GameChoice == "3")
                    {
                        Console.WriteLine("You Chose Scissors\n");
                        Console.WriteLine("The Computer Chose Paper\n");
                        Console.WriteLine("You Win!\n");
                        PlayerScore.Win++;
                    } 
                }
                else if(computerChoice == 3)
                {
                    if(GameChoice == "1")
                    {
                        Console.WriteLine("You Chose Rock");
                        Console.WriteLine("The Computer Chose Scissors");
                        Console.WriteLine("You Win!\n");
                        PlayerScore.Win++;
                    }
                    else if(GameChoice == "2")
                    {
                        Console.WriteLine("You Chose Paper");
                        Console.WriteLine("The Computer Chose Scissors");
                        Console.WriteLine("The Computer Wins!\n");
                        PlayerScore.Loss++;
                    }
                    else if(GameChoice == "3")
                    {
                        Console.WriteLine("You Chose Scissors");
                        Console.WriteLine("The Computer Chose Scissors");
                        Console.WriteLine("Its a Tie.\n");
                        PlayerScore.Tie++;
                    }
                }
                round++;
                Console.WriteLine("What would you like to do?\n");
                Console.WriteLine("1. Play Again");
                Console.WriteLine("2. View Player Statistics");
                Console.WriteLine("3. View Leaderboard");
                Console.WriteLine("4. Quit\n");
                Console.WriteLine("Enter Choice:");
                String Choice = Console.ReadLine();
                switch(Choice)
                {
                    case "1":
                        continue;

                    case "2":
                        float WLRatio = PlayerScore.Win/PlayerScore.Loss;
                        Console.WriteLine($"{PlayerScore.Name}, here are your gameplay statistics...");
                        Console.WriteLine($"Wins:{PlayerScore.Win}");
                        Console.WriteLine($"Losses:{PlayerScore.Loss}");
                        Console.WriteLine($"Ties:{PlayerScore.Tie}\n");
                        Console.WriteLine($"Win/Loss Ratio: {WLRatio}");
                        Console.WriteLine("File Successfully written.");
                        PlayAgain = false;
                        break;

                    case "3":
                        //PrintLeaderboard(ScoreList);
                        break;
                    
                    case "4":
                        PlayAgain = false;
                        Console.WriteLine("File Successfully written.");
                        break;
                }

                Console.ReadLine();
            }
            }

        }
            

    }
    
