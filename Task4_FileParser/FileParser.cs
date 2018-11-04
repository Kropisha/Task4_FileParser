// <copyright file="FileParser.cs" company="My Company">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task4_FileParser
{
    /// <summary>
    /// Represents an instance of FileParser
    /// </summary>
    internal class FileParser
    {
        /// <summary>
        /// current string with word for search
        /// </summary>
        private string forSearch;

        /// <summary>
        /// current string with word for replace
        /// </summary>
        private string forReplace;

        /// <summary>
        /// current path to file
        /// </summary>
        private string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileParser"/> class
        /// </summary>
        /// <param name="path">path to file</param>
        /// <param name="search"> string for search</param>
        public FileParser(string path, string search)
        {
            this.Path = path;
            this.SearchString = search;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileParser"/> class
        /// </summary>
        /// <param name="path">path to file</param>
        /// <param name="search">string for search</param>
        /// <param name="replace">string for replace</param>
        public FileParser(string path, string search, string replace)
        {
            this.Path = path;
            this.SearchString = search;
            this.ReplacementString = replace;
        }

        /// <summary>
        /// Gets or sets the path to file
        /// </summary>
        public string Path
        {
            get
            {
                return this.path;
            }

            set
            {
                this.path = value;
            }
        }

        /// <summary>
        /// Gets or sets the search string
        /// </summary>
        public string SearchString
        {
            get
            {
                return this.forSearch;
            }

            set
            {
                this.forSearch = value;
            }
        }

        /// <summary>
        /// Gets or sets the replacement string
        /// </summary>
        public string ReplacementString
        {
            get
            {
                return this.forReplace;
            }

            set
            {
                this.forReplace = value;
            }
        }
    }
}
