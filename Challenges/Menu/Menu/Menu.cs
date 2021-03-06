﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Challenges;

namespace Challenges
{
    class Menu
    {
        static void Main()
        {
            bool quit = false;

            List<string> programNames = new List<string>
            {
                "Name Generator",
                "Higher/Lower, Heads/Tails",
                "Temperature Converter",
                "Calculate Age",
                "Encryption/Decryption",
                "FizzBuzz",
                "Quit"
            };

            while (!quit)
            {
                Console.Clear();
                string programChoice = SelectProgram(programNames);

                RunProgram(programChoice);

                if (programChoice != "Quit")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\nSelect another program [y/n]?\n> ");
                    string input = Console.ReadLine();
                    Console.ResetColor();

                    if (input == "y" || input == "yes")
                    {
                        continue;
                    }
                }

                quit = true;
            }

            Console.Clear();
            Console.WriteLine("Thank you for playing!\n");
            Console.Write("Press enter to exit...");
            Console.ReadLine();
            Environment.Exit(0);
        }

        static string SelectProgram(List<string> programs)
        {
            string input;
            int number;
            string error = "";

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Main Menu\n");
                Console.ResetColor();

                Console.WriteLine("Select a game:\n");

                foreach (var game in programs.Select((Value, Index) => new { Value, Index }))
                {
                    Console.WriteLine($"{game.Index + 1}. {game.Value}");
                }
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("> ");
                input = Console.ReadLine();
                Console.ResetColor();

                if (!Int32.TryParse(input, out number))
                {
                    error = "\nInvalid Input. Enter the game number you want to play.";
                    continue;
                }
                else if (number > programs.Count || number < 1)
                {
                    error = "\nInvalid Number. Please enter a valid game number.";
                    continue;
                }
                break;
            }

            Console.Clear();
            return programs[number - 1];
        }

        static void RunProgram(string program)
        {
            switch (program)
            {
                case "Name Generator":
                    NameGenerator.GenerateName();
                    break;
                case "Higher/Lower, Heads/Tails":
                    HigherLowerHeadsTails.SelectGame();
                    break;
                case "Temperature Converter":
                    TemperatureConverter.Menu();
                    break;
                case "Calculate Age":
                    CalculateAgeinSeconds.CalculateAge();
                    break;
                case "Encryption/Decryption":
                    EncryptionDecryption.Menu();
                    break;
                case "FizzBuzz":
                    FizzBuzz.Play();
                    break;
                case "Quit":
                    break;
                default:
                    Console.WriteLine("Invaild input.");
                    break;
            }
        }
    }
}
