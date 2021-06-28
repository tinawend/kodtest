using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace kodtest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> frequences = new List<int>();
            List<int> reaccuringFrequences = new List<int>();  
            List<int> lastFrequences = new List<int>();
            
            ReadFile(frequences, lastFrequences, reaccuringFrequences);
            Console.WriteLine("Resulting frequency after all changes in frequencys have been applied: " + lastFrequences.First());
            Console.WriteLine("First reaccuring frequency: " + reaccuringFrequences.First());
           
        }

        /**
        * reads the file and calculates resulting frequences 
        */
        static void ReadFile(List<int> frequences, List<int> lastFrequences, List<int> reaccuringFrequences)
        {
            int startPoint = 0;
            var path = "input.txt";
            using var sr = new StreamReader(path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                startPoint += Int32.Parse(line);
                if(!frequences.Contains(startPoint))
                {
                    frequences.Add(startPoint);
                    StartStreamOver(sr, startPoint, lastFrequences);
                } else {
                    ReaccuringFrequency(reaccuringFrequences, startPoint);
                }
            }
            sr.Close();
        }
        /**
        * Reads the file again
        */
        static void StartStreamOver(StreamReader sr, int startPoint, List<int> lastFrequences)
        {
            if(sr.EndOfStream)
            {
                LastResultingFrequency(startPoint, lastFrequences);
                sr.DiscardBufferedData();
                sr.BaseStream.Seek(1, SeekOrigin.Begin);
            }
        }

        /**
        *adding the last resulting frequence to a list after all changes in frquency has been applied
        */
        static void LastResultingFrequency(int startPoint, List<int> lastFrequences)
        {
            lastFrequences.Add(startPoint);
        }

        /**
        * Adding reacurring frequencies to a list
        */
        static void ReaccuringFrequency(List<int> reaccuringFrequences, int startPoint)
        {
            reaccuringFrequences.Add(startPoint);
        }

    }
}
