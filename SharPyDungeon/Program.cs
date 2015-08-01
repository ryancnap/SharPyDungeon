/// <summary>
/// This is the first class to be translated in my project of translating 
/// pyDungeon, my Python3k-based dungeon-crawler knock, to C#.
/// In various iterations it will become more idiomatic. 
/// DialogueManager() is intended to be called by another (not yet implemented) class. 
/// </summary>
using System;


namespace DialogueManager
{
    class DialogueManager
    {
        // fileContents must be made public to the class,
        // otherwise it's out of scope when concatenated to in the
        // while loop.
        public string fileContents;

        // Really not sure if I even need this; I know every class
        // needs a Main() method for entry point, but I'm not sure what
        // C# idioms indicate when the main method isn't really necessary.
        public static void Main(string[] args)
        {
            // Leaving this out 'cause compiler bitched.
            // string npcName;

            // Below instantiation is only for testing;
            // I'm not gonna attempt TDD in C# yet, so this will have
            // to do for now. bus.txt was created in bin/debug (which
            // is the out directory) just for this purpose.
            DialogueManager dialogue = new DialogueManager();
            string content = dialogue.getDialogue("dialogue.txt");
            Console.WriteLine(content);
        

        }

        public string getDialogue(string filePath)
        {
            // Exception handling is useless here.
            // Although it is exceptional, as the text file containing dialogue should
            // be created prior to the DM running...
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            string dialogueDirectory = filePath;

            // Read til EOF, concat all lines into fileContents string,
            // return fileContents string after closing file stream.
            StreamReader reader = new StreamReader(dialogueDirectory);

            // Kind of makes me miss Python's 'in'; I'll get over it.
            while (reader.EndOfStream == false)
            {
                string line = reader.ReadLine();
                fileContents += line;
            }

            reader.Close();
            return fileContents;
        }
    }
}
