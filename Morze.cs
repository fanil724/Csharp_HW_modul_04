using System;
using System.Text;

namespace C_sharp_HW_modul_04
{
    public class Morze
    {
        public string[] translationMorze(string str)
        {
            string[] text = new string[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                text[i] = morse[indexString(str[i])];
            }

            return text;
        }

        public string translationString(string[] str)
        {
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                text.Append(english[indexChar(str[i])]);
            }

            string s = text.ToString();
            return s;
        }

        int indexChar(string s)
        {
            for (int i = 0; i < morse.Length; i++)
            {
                if (string.Compare(s, morse[i]) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public void print(string[] str)
        {
            foreach (var item in str)
            {
                Console.Write(item + $" ");
            }

            Console.WriteLine();
        }

        int indexString(char c)
        {
            for (int i = 0; i < english.Length; i++)
            {
                if (c == english[i])
                {
                    return i;
                }
            }

            return -1;
        }
        
        private char[] english =
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
            'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
            'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0',
            ',', '.', '?'
        };

        private string[] morse =
        {
            ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..",
            ".---", "-.-", ".-..", "--", "-.", "---", ".---.", "--.-", ".-.",
            "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", ".----",
            "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.",
            "-----", "--..--", ".-.-.-", "..--.."
        };
    }
}