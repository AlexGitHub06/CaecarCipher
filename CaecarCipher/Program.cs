using System;
using System.Text;

namespace CaesarCipher 
{
    internal class Program
    {
        static void Main()
        {
            Tuple<string,int> info =  GetEncryptInfo();
            string word = info.Item1;
            int offset = info.Item2 % 26;

            string encrypted = Shift(word, offset); // encrypt
            Console.WriteLine("encrypted: {0}", encrypted);
            string decrypted = Shift(encrypted, -offset); //decrypt
            Console.WriteLine("decrypted: {0}", decrypted);
        }

        public static string Shift(string s, int offset)
        {
            StringBuilder encrypted = new StringBuilder("",s.Length);
            
            foreach(char c in s)
                
            {
                if(Char.ToUpper(c) + offset <= 90 && offset >= 0 || Char.ToUpper(c) + offset >= 65 && offset < 0)
                {
                    encrypted.Append((char)(c + offset));
                }

                else if(Char.ToUpper(c) + offset > 90 && offset >= 0)
                {
                    encrypted.Append((char)(c - 26 + offset));
                }

                else if(Char.ToUpper(c) + offset < 65 && offset < 0)
                {
                    encrypted.Append((char)(c + 26 + offset));
                }                     
            }

            return encrypted.ToString();
        }

        public static Tuple<string,int> GetEncryptInfo()
        {
            Console.WriteLine("What string is being encrypted?: ");
            string word = Console.ReadLine();
            Console.WriteLine("By what offset is it being encrypted?: ");
            int shift = int.Parse(Console.ReadLine());

            return new Tuple<string, int>(word,shift);

        }
    }
}