using System;
using System.Collections;
using System.IO;

namespace TypingTutor
{
    internal class Compliments
    {
        private readonly ArrayList _phrases;

        public Compliments()
        {
            _phrases = new ArrayList();

            using (var reader = new StreamReader("compliments.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Do stuff with your line here, it will be called for each 
                    // line of text in your file.
                    _phrases.Add(line);
                }
            }

        }

        public string GetCompliment()
        {
            var r = new Random();
            return _phrases[r.Next(0, _phrases.Count)].ToString();
        }
    }
}