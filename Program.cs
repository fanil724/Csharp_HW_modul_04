using System;

namespace C_sharp_HW_modul_04
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // TicTacToe ticTacToe = new TicTacToe();
            // ticTacToe.runGame();
            Morze morze = new Morze();
            string s = "proper";
            
            morze.print(morze.translationMorze(s));
            
            Console.WriteLine(morze.translationString(morze.translationMorze(s)));
        }
    }
}