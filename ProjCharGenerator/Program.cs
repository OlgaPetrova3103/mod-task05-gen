using System;
using System.Text;
using System.IO;

/*
 * namespace generator
{
    class CharGenerator 
    {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя"; 
        private char[] data;
        private int size;
        private Random random = new Random();
        public CharGenerator() 
        {
           size = syms.Length;
           data = syms.ToCharArray(); 
        }
        public char getSym() 
        {
           return data[random.Next(0, size)]; 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CharGenerator gen = new CharGenerator();
            SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            for(int i = 0; i < 1000; i++) 
            {
               char ch = gen.getSym(); 
               if (stat.ContainsKey(ch))
                  stat[ch]++;
               else
                  stat.Add(ch, 1); Console.Write(ch);
            }
            Console.Write('\n');
            foreach (KeyValuePair<char, int> entry in stat) 
            {
                 Console.WriteLine("{0} - {1}",entry.Key,entry.Value/1000.0); 
            }
            
        }
    }
}
 */

namespace generator
{
    class Zadanie_1
    {
        private string syms = "абвгдежзийклмнопрстуфхцчшщьыэюя";
        private char[] data;
        private int size;
        private Random random = new Random();
        public int[,] arr; 
        int summa = 0;
        public Zadanie_1(string file)
        {
            arr = new int[31, 31];
            using (StreamReader r = new StreamReader(file))
            {
                for (int i = 0; i < 31; i++)
                {
                    string test = r.ReadLine();
                    string[] temp = test.Split(new Char[] { ' ' });
                    for (int j = 0; j < 31; j++)
                    {
                        arr[i, j] = int.Parse(temp[j]);
                    }
                }
            }
            size = syms.Length;//число букв алфавита
            data = syms.ToCharArray();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    summa += arr[i, j];
        }
        public string getSym()
        {
            int m = random.Next(0, summa);
            int j = 0;
            int i = 0;

            for (i = 0; i < size; i++)
            {
                int F = 0;
                for (j = 0; j < size; j++)
                {
                    if (m < arr[i, j])
                    {
                        F = 1;
                        break;
                    }
                }
                if (F == 1) break;
            }
            return data[i].ToString() + data[j].ToString() ;
        }
    }
    class Zadanie_2
    {
        private Random random = new Random();
        int summa = 0;
        public int[] ver;
        public string[] words;
        public int sum;
        public Zadanie_2(string file)
        {
            sum = 0;
            ver = new int[100];
            words = new string[100];
            using (StreamReader sr = new StreamReader(file))
            {
                for (int i = 0; i < 100; ++i)
                {
                    string line = sr.ReadLine();
                    string[] temp = line.Split(new Char[] { ' ' });
                    words[i] = temp[0];
                    ver[i] = Int32.Parse(temp[1]);
                    sum += ver[i];
                }
            }
        }
            public string getSym()
        {
            int m = random.Next(0, summa);
            int i = 0;
            for (i = 0; i < 100; i++) 
                if (m < ver[i])
                    break;
            return words[i];
        }
    }
    class Zadanie_3
    {
        private Random random = new Random();
        int summa = 0;
        public int[] ver;
        public string[] words1;
        public string[] words2;
        public int sum;
        public Zadanie_3(string file)
        {
            sum = 0;
            ver = new int[100];
            words1 = new string[100];
            words2 = new string[100];
            using (StreamReader sr = new StreamReader(file))
            {
                for (int i = 0; i < 100; ++i)
                {
                    string line = sr.ReadLine();
                    string[] temp = line.Split(new Char[] { ' ' });
                    words1[i] = temp[0];
                    words2[i] = temp[1];
                    ver[i] = Int32.Parse(temp[3]);
                    sum += ver[i];
                }
            }
        }
        public string getSym()
        {
            int m = random.Next(0, summa);
            int i = 0;
            for (i = 0; i < 100; i++)
                if (m < ver[i])
                    break;
            return words1[i].ToString() + words2[i].ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Zadanie_1 z1 = new Zadanie_1("task_1.txt");
            Zadanie_1 z2 = new Zadanie_1("task_2.txt");
            Zadanie_1 z3 = new Zadanie_1("task_3.txt");

            using (StreamWriter r = new StreamWriter("otv_1.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string str = z1.getSym();
                    r.Write(str[0]);
                    r.Write(str[1]);
                    r.Write(" ");
                }
            }
            using (StreamWriter r = new StreamWriter("otv_2.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string str = z2.getSym();
                    for (int j = 0; j < str.Length; j++)
                        r.Write(str[j]);
                        r.Write(' ');
                }
            }
            using (StreamWriter r = new StreamWriter("otv_3.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    string str = z3.getSym();
                    for (int j = 0; j < str.Length; j++)
                        r.Write(str[j]);
                        r.Write(' ');
                }
            }
            Console.ReadKey();
        }
    }
}

