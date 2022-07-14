using System;
using System.Collections.Generic;
using System.Linq;

namespace proj2
{
    class Program3
    {
        public static List<List<string>> aparting(string machine)
        {
            List<List<string>> result=new List<List<string>>();
            //string[] transitions=machine.Split("00");  
            List<string> transitions = machine.Split(new string[]{ "00" },StringSplitOptions.None).ToList();
            long lng=transitions.Count;
            for (int i = 0; i < lng; i++)
            {
                string[] taktak=transitions[i].Split('0');
                result.Add(taktak.ToList());
            }
            return result;
        }

        public static string findfinal(List<List<string>> machinelist)
        {
            string result=machinelist[0][0];
            long lng=machinelist.Count;
            for (int i = 0; i < lng; i++)
            {
                if(result.Length < machinelist[i][2].Length)
                    result=machinelist[i][2];
            }
            return result;
        }

        public static List<string> solve1(List<List<string>> machinelist,List<string> tests,string final)
        {
            List<string> result=new List<string>();
            long n=tests.Count;
            for (int i = 0; i < n; i++)
            {
                result.Add(solve2(machinelist,tests[i],final));
            }
            return result;
        }
        
        public static string solve2(List<List<string>> machinelist,string tests,string final)
        {
            
            string current="1";
            List<string> tape=new List<string>();

            for (int i = 0; i < 10; i++)
                tape.Add("1");

            if(tests.Length==0)
                tape.Add("1");
            else
                tape.AddRange(tests.Split('0').ToList());

            for (int i = 0; i < 10; i++)
                tape.Add("1");
            
            int k=10;
            int n=tests.Length;
            bool stop = false;

            while(!stop)
            {
                stop=true;
                for (int j = 0; j < machinelist.Count; j++)
                {
                    string start=machinelist[j][0];
                    string end=machinelist[j][2];
                    string read=machinelist[j][1];
                    string write=machinelist[j][3];
                    string head=machinelist[j][4];
                    if(start==current && read==tape[k])
                    {
                        current=end;
                        tape[k]=write;
                        if(head=="1")
                            k--;
                        else
                            k++;
                        stop=false;
                    }
                }
            }
            if(current==final)
                return "Accepted";
            return "Rejected";
        }
        
        static void Main3(string[] args)
        {
            // Console.WriteLine("Hello World!");
            string machine=Console.ReadLine();
            long n=long.Parse(Console.ReadLine());
            List<string> tests=new List<string>();
            for (int i = 0; i < n; i++)
            {
                string test=Console.ReadLine();
                tests.Add(test);
            }
            List<List<string>> machinelist=aparting(machine);
            string final=findfinal(machinelist);
            List<string> result=solve1(machinelist,tests,final);
            foreach (string i in result)
            {
                System.Console.WriteLine(i);
            }
        }
    }
}
