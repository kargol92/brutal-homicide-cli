using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrutalHomicide
{
    class Menu
    {
        public Menu()
        {
            isRunning = true;

            currentOption = 0;
            options = new string[4];
            options[0] = "Singleplayer";
            options[1] = "Multiplayer";
            options[2] = "About";
            options[3] = "Exit";
        }

        public void run()
        {
            while (isRunning)
            {
                display();
                checkKey();
            }
        }

        void display()
        {
            Console.Clear();
            Console.WriteLine(logo);

            for (int i = 0; i < options.Length; i++)
            {
                if (currentOption == i) Console.WriteLine("[ " + options[i] + " ]");
                else Console.WriteLine("  " + options[i]);
            }
        }

        void checkKey()
        {
            pressedKey = Console.ReadKey().Key;

            if (pressedKey == ConsoleKey.UpArrow)
            {
                if (currentOption > 0)
                    currentOption--;
                else
                    currentOption = options.Length - 1;
            }
            else if (pressedKey == ConsoleKey.DownArrow)
            {
                if (currentOption < options.Length - 1)
                    currentOption++;
                else
                    currentOption = 0;
            }
            else if (pressedKey == ConsoleKey.Enter)
            {
                if (currentOption == 0)
                    new Game().run();
                else if (currentOption == 3)
                    isRunning = false;
            }
        }


        string logo =
            " ______   ______ _     _ _______ _______       \n" +
            " |_____] |_____/ |     |    |    |_____| |     \n" +
            " |_____] |    \\_ |_____|    |    |     | |_____\n" +
            "                                               \n" +
            " _     _  _____  _______ _____ _______ _____ ______  _______\n" +
            " |_____| |     | |  |  |   |   |         |   |     \\ |______\n" +
            " |     | |_____| |  |  | __|__ |_____  __|__ |_____/ |______\n" +
            "                                                            \n" +
            "\t\t\t\t\t    the_black_coder\n";

        ConsoleKey pressedKey;
        bool isRunning;
        string[] options;
        int currentOption;
    }
}
