using System;
using System.Collections.Generic;
using System.Linq;


namespace KeyEncryption.Encryptor
{
    public static class Encryptor
    {
        public static List<List<KeyValuePair<string, string>>> EncodeText(string text, short fragmentLenght)
        {
            //split text in fragments
            List<string> fragments = splitFragments(text, fragmentLenght);

            List<List<KeyValuePair<string, string>>> encryptedKeyValueList = new List<List<KeyValuePair<string, string>>>();
            Random random = new Random();
            string code;

            //encode each fragment
            foreach (string fragment in fragments)
            {
                List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

                //encode each letter in this fragment
                foreach (char letter in fragment)
                {
                    KeyValuePair<string, string> pair = list.FirstOrDefault(keyValuePair => keyValuePair.Key == letter.ToString());

                    if (pair.Key != null)
                    {
                        code = pair.Value;
                    }
                    else
                    {
                        code = random.Next(1000, 9999).ToString();
                    }

                    list.Add(new KeyValuePair<string, string>(letter.ToString(), code));
                }

                encryptedKeyValueList.Add(list);
            }

            return encryptedKeyValueList;
        }        

        private static List<string> splitFragments(string text, short fragmentLenght)
        {
            int count = 0;

            List<string> fragments = new List<string>();

            while (count < text.Length)
            {
                if (count + fragmentLenght < text.Length)
                {
                    fragments.Add(new string(text.ToCharArray(count, fragmentLenght)));
                }
                else
                {
                    fragments.Add(new string(text.ToCharArray(count, text.Length - count)));
                }

                count = count + fragmentLenght;
            }

            return fragments;
        }

        public static string GetEncryptedText(List<List<KeyValuePair<string, string>>> encryptedKeyValueList)
        {
            string encryptedText = "";

            foreach (List<KeyValuePair<string, string>> fragment in encryptedKeyValueList)
            {
                foreach (KeyValuePair<string, string> pair in fragment)
                {
                    encryptedText += pair.Value;
                }

            }

            return encryptedText;
        }

        public static string GetOrderedKeys(List<List<KeyValuePair<string, string>>> encryptedKeyValueList)
        {
            string orderedKeys = "\n";

            foreach (List<KeyValuePair<string, string>> fragment in encryptedKeyValueList)
            {
                foreach (KeyValuePair<string, string> pair in fragment)
                {
                    orderedKeys += "'" + pair.Key + "'" + " = " + "'" + pair.Value + "'" + " ";
                }

                orderedKeys += "\n";
            }

            return orderedKeys;
        }
    }
}
