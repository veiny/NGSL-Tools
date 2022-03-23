using System;
using System.Collections.Generic;
using System.IO;

namespace NewGeneralListWpf.NGSL
{
    internal class NewGeneralServiceList
    {
        private List<string> ngsl_words;
        private string? ngsl_filename;
        private Random random;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ngsl_filename">录入文件名词 NGSL_word2818.txt</param>
        public NewGeneralServiceList(string ngsl_filename)
        {
            random = new Random(Guid.NewGuid().GetHashCode());
            ngsl_words = new List<string>();
            this.ngsl_filename = ngsl_filename;
            InitWords();
        }
        public List<string> Words { get => ngsl_words; }
        public string AnyOneWord()
        {
            return ngsl_words[random.Next(0, ngsl_words.Count - 1)];
        }
        public string[] AnyWords(int count)
        {
            string[] words = new string[count];
            for (int i = 0; i < count; i++)
            {
                words[i] = AnyOneWord();
            }
            return words;
        }
        private void InitWords()
        {
            if (ngsl_filename == null) throw new ArgumentNullException(nameof(ngsl_filename) + "is null! please select a words txt file.");
            using (TextReader sr = new StreamReader(ngsl_filename))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    ngsl_words.Add(line.Trim());
                }
            }
        }
    }
}
