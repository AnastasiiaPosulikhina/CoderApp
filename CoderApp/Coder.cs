using System;
using System.Windows;

namespace CoderApp
{
    public class Coder
    {
        public static string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public static string GetEnteredKey(string enteredKey) //получение введённого пользователем ключа
        {
            string key = "";

            if (enteredKey != "Введите ключ...")
            {
                key = enteredKey;
            }
            else
            {
                MessageBox.Show("Вы ещё не ввели ключ!", "Уведомление");
            }
            return key;
        }

        public static int GetLetterIndex(char letter) //получение индекса буквы
        {
            for (var i = 0; i < alphabet.Length; ++i)
            {
                if (alphabet[i] == letter)
                    return i;
            }
            return -1;
        }

        public static string VigenereCoder(string text, string key, bool encode) //шифр Виженера
        {
            string result = "";

            try
            {
                int[][] vigenereTable = new int[alphabet.Length][];

                for (int i = 0; i < alphabet.Length; i++)
                {
                    int[] letterCodeArr = new int[alphabet.Length];

                    for (int j = 0; j < alphabet.Length; j++)
                        letterCodeArr[j] = (i + j) % alphabet.Length;

                    vigenereTable[i] = letterCodeArr;
                }

                char[] keyToChar = new char[key.Length];
                int letterIndex = 0;

                for (int i = 0; i < key.Length; i++)
                {
                    if (GetLetterIndex(char.ToLower(key[i])) != -1)
                        keyToChar[letterIndex++] = key[i];
                }

                letterIndex = 0;

                for (int i = 0; i < text.Length; i++)
                {
                    if (encode == true)
                    {
                        int letterIndexOfGivenText = GetLetterIndex(char.ToLower(text[i]));

                        if (letterIndexOfGivenText != -1)
                        {
                            int letterIndexOfKey = GetLetterIndex(char.ToLower(keyToChar[letterIndex % keyToChar.Length]));
                            result += alphabet[vigenereTable[letterIndexOfKey][letterIndexOfGivenText]];
                            letterIndex++;
                        }
                        else
                            result += text[i];
                    }
                    else if (encode == false)
                    {
                        int letterIndexOfGivenText = GetLetterIndex(char.ToLower(text[i]));

                        if (letterIndexOfGivenText != -1)
                        {
                            int letterIndexOfKey = GetLetterIndex(char.ToLower(keyToChar[letterIndex % keyToChar.Length]));

                            for (int j = 0; j < alphabet.Length; j++)
                            {
                                if (alphabet[vigenereTable[letterIndexOfKey][j]] == char.ToLower(text[i]))
                                {
                                    result += alphabet[j];
                                }
                            }
                            letterIndex++;
                        }
                        else
                            result += text[i];
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Вы используете неверный алфавит или иные некорректные символы! Повторите попытку.", "Уведомление");
            }

            return result;
        }

        public static string Encode(string text, string key) //метод, отвечающий за шифрование текста
        {
            return VigenereCoder(text, key, true);
        }

        public static string Decode(string text, string key) //метод, отвечающий за дешифрование текста
        {
            return VigenereCoder(text, key, false);
        }
    }
}
