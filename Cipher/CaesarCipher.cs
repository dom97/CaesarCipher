using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    public class CaesarCipher
    {
        private Int32 key;
        private static Int32 firstAscii = 65;
        private static Int32 alphabetLength = 26;

        public CaesarCipher(Int32 key)
        {
            this.key = key;
        }

        public String Encode(String text)
        {
            return CodeText(text, true);
        }

        public String Decode(String cipherText)
        {
            return CodeText(cipherText, false);
        }

        private Char EncodeCharacter(Char character)
        {
            var ascii = (Int32)character;
            ascii = (ascii + key - firstAscii) % alphabetLength + firstAscii;
            return (Char)ascii;
        }

        private Char DecodeCharacter(Char character)
        {
            var ascii = (Int32)character;
            var letter = ascii - firstAscii;
            letter = letter - key;

            if (letter < 0)
                letter = alphabetLength + letter;

            return (Char)(letter + firstAscii); 
        }

        private String CodeText(String text, Boolean encode)
        {
            var builder = new StringBuilder();
            text = text.ToUpper();

            for (var i = 0; i < text.Length; i++)
            {
                var currentCharacter = text.ElementAt(i);

                if (Char.IsLetter(currentCharacter))
                {
                    if (encode)
                    {
                        var enocdedChar = EncodeCharacter(currentCharacter);
                        builder.Append(enocdedChar);
                    }
                    else
                    {
                        var decodedChar = DecodeCharacter(currentCharacter);
                        builder.Append(decodedChar);
                    }
                }
                else
                {
                    builder.Append(currentCharacter);
                }
            }

            return builder.ToString();
        }
    }
}
