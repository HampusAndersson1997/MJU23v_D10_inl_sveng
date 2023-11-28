namespace MJU23v_D10_inl_sveng
{
    internal class Program
    {
        //NYI 21 gör en Print() metod
        static List<SweEngGloss> dictionary;
        class SweEngGloss
        {
            public string word_swe, word_eng;
            public SweEngGloss(string word_swe, string word_eng)
            {
                this.word_swe = word_swe; this.word_eng = word_eng;
            }
            public SweEngGloss(string line)
            {
                string[] words = line.Split('|');
                this.word_swe = words[0]; this.word_eng = words[1];
            }
        }
        static void Main(string[] args) //FIXME 1 Lägg till commandot "hjälp" så att man kan veta vad man kan fråga efter
        {
            string defaultFile = "..\\..\\..\\dict\\sweeng.lis";
            Console.WriteLine("Welcome to the dictionary app!");
            do
            {
                Console.Write("> "); //TODO 2 gör till en metod
                string[] argument = Console.ReadLine().Split();
                string command = argument[0];
                if (command == "quit")
                {
                    Console.WriteLine("Goodbye!");
                }
                else if (command == "load")
                {
                    string path = defaultFile;
                    if (argument.Length == 2)
                    {
                        path = argument[1];
                    }
                    using (StreamReader sr = new StreamReader(path)) //FIXME: exception error, file not found exception
                    {
                        //TODO 4 gör en metod
                        dictionary = new List<SweEngGloss>(); // Empty it!
                        string line = sr.ReadLine();
                        while (line != null)
                        {
                            //TODO 5 gör en metod
                            SweEngGloss gloss = new SweEngGloss(line);
                            dictionary.Add(gloss);
                            line = sr.ReadLine();
                        }
                    }
                }
                else if (command == "list")
                {
                    foreach (SweEngGloss gloss in dictionary)
                    {
                        Console.WriteLine($"{gloss.word_swe,-10}  - {gloss.word_eng,-10}");
                    }
                }
                else if (command == "new")
                {
                    if (argument.Length == 3)
                    {
                        dictionary.Add(new SweEngGloss(argument[1], argument[2]));
                    }
                    else if (argument.Length == 1)
                    {
                        //TODO 8 gör en metod
                        Console.WriteLine("Write word in Swedish: ");
                        string swe = Console.ReadLine();
                        Console.Write("Write word in English: ");
                        string eng = Console.ReadLine();
                        dictionary.Add(new SweEngGloss(swe, eng));
                    }
                }
                else if (command == "delete")
                {
                    Delete(argument);                    
                }
                else if (command == "translate")
                {
                    Translate(argument);                    
                }
                else
                {
                    Console.WriteLine($"Unknown command: '{command}'");
                }
            } //NYI 17 lägg in exceptions
            //NYI 18 lägg in FileNotFoundException
            //NYI 18 lägg in try-catch
            while (true);
        }
        public static void Delete(string[] argument)
        {
            if (argument.Length == 3)
            {
                //TODO 12 gör en metod
                int index = -1;
                for (int i = 0; i < dictionary.Count; i++) //TODO 11 döp om alla i
                {
                    SweEngGloss gloss = dictionary[i];
                    if (gloss.word_swe == argument[1] && gloss.word_eng == argument[2])
                        index = i;
                }
                dictionary.RemoveAt(index);
            }
            else if (argument.Length == 1)
            {
                //TODO 13 gör en metod
                Console.WriteLine("Write word in Swedish: ");
                string swe = Console.ReadLine();
                Console.Write("Write word in English: ");
                string eng = Console.ReadLine();
                int index = -1;
                for (int i = 0; i < dictionary.Count; i++)
                {
                    SweEngGloss gloss = dictionary[i];
                    if (gloss.word_swe == swe && gloss.word_eng == eng)
                        index = i;
                }
                dictionary.RemoveAt(index);
            }
        }
        public static void Translate(string[] argument)
        {
            string word = "";
            if (argument.Length == 2) 
            {
                word = argument[1];
            }
            else if (argument.Length == 1) 
            {
                Console.WriteLine("Write word to be translated: ");
                word = Console.ReadLine();
            }
            foreach (SweEngGloss gloss in dictionary)
            {
                if (gloss.word_swe == word)
                    Console.WriteLine($"English for {gloss.word_swe} is {gloss.word_eng}");
                if (gloss.word_eng == word)
                    Console.WriteLine($"Swedish for {gloss.word_eng} is {gloss.word_swe}");
            }                    
        }
            
            //TODO 19 lägg till static metoder
    } // NYI 20 lägg till static metoder
}