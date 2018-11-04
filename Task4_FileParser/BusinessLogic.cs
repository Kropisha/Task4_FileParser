// <copyright file="BusinessLogic.cs" company="My Company">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task4_FileParser
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// This class is for current program logic
    /// </summary>
    public class BusinessLogic
    {
        /// <summary>
        /// Find how much searching words contains text
        /// </summary>
        /// <param name="path">path to file</param>
        /// <param name="search">word or string for search</param>
        /// <returns>quantity of finding words</returns>
        public int SearchString(string path, string search)
        {
            int count = 0;
            var lines = this.GetLines(path);

            foreach (var line in lines)
            {               
                if (line.Contains(search))
                {
                    Regex regex = new Regex($@"\w*{search}\w*");
                    MatchCollection matches = regex.Matches(line);
                    count += matches.Count;
                }
            }

            return count;
        }

        /// <summary>
        /// Replace one string to another
        /// </summary>
        /// <param name="path">path to file</param>
        /// <param name="search">word or string for search</param>
        /// <param name="replace">word or string for replace</param>
        /// <returns>message with check is something replaced</returns>
        public string ReplaceString(string path, string search, string replace)
        {        
            int count = 0;
            var lines = this.GetLines(path);
            string message = string.Empty;
            ArrayList helper = new ArrayList();
            
            foreach (var line in lines)
            {
                string helpLine = line;
                if (line.Contains(search))
                {
                    Regex regex = new Regex($@"\w*{search}\w*");
                    MatchCollection matches = regex.Matches(line);
                    helpLine = line.Replace(search, replace);
                    count += matches.Count;
                }

                helper.Add(helpLine);   
            }

            string[] myArr = (string[])helper.ToArray(typeof(string));
            File.WriteAllLines(path, myArr);
            message = $"Done. Check your file. I replace string {count} times.";

            if (count == 0)
            {
                message = "Nothing found to replace.";
            }

            return message;
        }

        /// <summary>
        /// Set the path for file with identifier
        /// </summary>
        /// <param name="isOk">is file correct</param>
        /// <returns>string with path</returns>
        internal string PathInitializer(ref bool isOk)
        {
            string path = string.Empty;
            try
            {
                path = Console.ReadLine();
                if (!File.Exists(path))
                {
                    isOk = false;
                    throw new FileNotFoundException("The path to file is incorrect.");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return path;
        }

        /// <summary>
        /// Get string from text
        /// </summary>
        /// <param name="path">path to file</param>
        /// <returns>the line of text file</returns>
        private IEnumerable<string> GetLines(string path)
        {
                StreamReader reader = new StreamReader(path);
                string result = string.Empty;
                string line;
                while (!reader.EndOfStream)
                {
                    if ((line = reader.ReadLine()) != null)
                    {
                        yield return line;
                    }
                }
            reader.Close();
        }
    }
}
