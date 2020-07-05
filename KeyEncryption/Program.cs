using System;
using System.Collections.Generic;

namespace KeyEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*Para finalizar ingrese 'exit'* \n");

            string text = requestInput("Ingrese el texto a cifrar\n");
            
            while (text != "exit")
            {
                validateText(text);

                string fragmentText = requestInput("\nIngrese la longitud del fragmento\n");
                
                short fragmentLenght = convertAndValidateFragmentLenght(fragmentText);

                List <List<KeyValuePair<string, string>>> encryptedFragmentList = Encryptor.Encryptor.EncodeText(text, fragmentLenght);

                string encryptedText = Encryptor.Encryptor.GetEncryptedText(encryptedFragmentList);

                string orderedKeys = Encryptor.Encryptor.GetOrderedKeys(encryptedFragmentList);               

                Console.WriteLine("\nTexto cifrado: " + encryptedText + "\n");

                Console.WriteLine("Claves ordenadas:\n" + orderedKeys);

                Console.WriteLine("Texto Descifrado: " + text + "\n");

                text = requestInput("Ingrese el texto a cifrar\n");

            }

        }

        private static short convertAndValidateFragmentLenght(string fragmentText)
        {
            validateExit(fragmentText);

            short fragmentLenght;

            Int16.TryParse(fragmentText, out fragmentLenght);

            while (fragmentLenght < 1)
            {
                validateExit(fragmentText);
                fragmentText = requestInput("\nIngrese un numero positivo\n");
                Int16.TryParse(fragmentText, out fragmentLenght);
            }

            return fragmentLenght;
        }

        private static void validateText(string text)
        {
            while (String.IsNullOrWhiteSpace(text))
            {
                text = requestInput("Ingrese el texto a cifrar\n");
            }

            validateExit(text);

        }

        private static void validateExit(string text)
        {
            if (text == "exit")            
                Environment.Exit(0);
        }

        private static string requestInput(string messageText)
        {
            Console.WriteLine(messageText);
            return Console.ReadLine();
        }

    }
}
