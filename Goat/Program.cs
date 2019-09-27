namespace Goat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] goatsAndCourses = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            int courses = goatsAndCourses[1];

            List<int> inputGoats = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .OrderByDescending(g => g)
                                    .ToList();

            int raftLoad = inputGoats[0];

            List<int> attemptGoats = new List<int>(inputGoats);

            for (int i = 1; i <= courses; i++)
            {            
                FillRaft(raftLoad, attemptGoats);

                if (i == courses && attemptGoats.Count != 0)
                {
                    raftLoad++;
                    attemptGoats = new List<int>(inputGoats); // refill the attemptGoats list
                    i = 0; // start everything all over again
                }
            }

            Console.WriteLine(raftLoad);
        }

        public static void FillRaft(int maxRaftLoad, List<int> attemptGoats)
        {
            int raftCurrentWeight = 0;

            for (int i = 0; i < attemptGoats.Count; i++)
            {
                int boardingGoat = attemptGoats[i];

                if (raftCurrentWeight + boardingGoat <= maxRaftLoad)
                {
                    raftCurrentWeight += boardingGoat;
                    attemptGoats.Remove(boardingGoat);
                    i--;
                }
            }
        }
    }
}
