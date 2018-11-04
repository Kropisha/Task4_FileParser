// <copyright file="UI.cs" company="My Company">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>

namespace Task4_FileParser
{
    using System;
    using System.IO;
    using System.Linq;
    using ShowMenuLib;

    /// <summary>
    /// Present visualization for user
    /// </summary>
    internal class UI : GetMenu
    {
        /// <summary>
        /// Show logic depending on the choice
        /// </summary>
        /// <param name="i">position of user choice(from top)</param>
        public override void UserChoice(int i)
        {
            UserAction action;
            do
            {
                Console.SetCursorPosition(0, 0);
                Enum.TryParse(this.ShowMenu(" Welcome to the lucky tickets task!").ToString(), out action);
                Console.WriteLine();
                Console.ResetColor();

                switch (action)
                {
                    case UserAction.Help:
                        Help helper = new Help();
                        try
                        {
                            Console.ResetColor();
                            Console.WriteLine(helper.References(@"..\..\Files\ParserRef.txt"));
                        }
                        catch (FileNotFoundException ex)
                        {
                            Console.WriteLine("Some problem with file" + ex.Message);
                        }

                        Console.ReadKey();
                        break;
                    case UserAction.Program:
                        Console.ResetColor();
                        this.TaskWithFiles();
                        break;
                    case UserAction.Quit:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

                Console.Clear();
            }
            while (action != UserAction.Quit);
        }

        /// <summary>
        /// Show menu for board task
        /// </summary>
        /// <param name="type">The header-line of menu</param>
        /// <returns>user choice</returns>
        public override char ShowMenu(string type)
        {
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(type);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("           1.Help                 ");
            Console.WriteLine("           2.Do it                ");
            Console.WriteLine("           3.Quit                 ");
            Console.WriteLine();
            Console.WriteLine(" What is your choice? [tap number]");

            return Console.ReadKey().KeyChar;
        }

        /// <summary>
        /// Get menu for task
        /// </summary>
        private void TaskWithFiles()
        {
            Console.WriteLine("Please, write the path to file, which contained method name.");
            Console.WriteLine("Example: ../../Files/Example.txt");
            bool isOk = true;
            BusinessLogic bl = new BusinessLogic();
            string path = bl.PathInitializer(ref isOk);
            if (isOk)
            {
                Console.WriteLine("What will you want to find?");
                string search = Console.ReadLine();
                Console.WriteLine("Do you want to replace this word on another? [y/yes] if you want");
                string key = Console.ReadLine();
                char condition = 'n';
                try
                {
                    condition = key.ToLower().First();
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Be attentive!");
                    Console.Beep();
                    Console.ReadLine();
                }

                BusinessLogic fw = new BusinessLogic();
                FileParser fp = new FileParser(path, search);

                if (condition == 'y')
                {
                    Console.WriteLine("What do you want to write instead of this string?");
                    string replace = Console.ReadLine();
                    fp.ReplacementString = replace;
                    Console.WriteLine(fw.ReplaceString(fp.Path, fp.SearchString, fp.ReplacementString));
                }
                else
                {
                    int count = 0;
                    count = fw.SearchString(fp.Path, fp.SearchString);
                    Console.WriteLine($"This file contains {count} strings with '{fp.SearchString}'");
                }
            }

            Console.ReadKey();
        }
    }
}
