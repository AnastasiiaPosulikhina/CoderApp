using System;
using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using Word = Microsoft.Office.Interop.Word;

namespace CoderApp
{
    class DataProcessing
    {
        public static string OpenFile() //метод, позволяющий открыть файл в формате .txt/.doc/.docx
        {
            string fileText = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text file (*.txt)|*.txt|Docx files (*.docx)|*.docx|Doc files (*.doc)|*.doc";

            if (openFileDialog.ShowDialog() == true)
            {
                if (openFileDialog.FileName.EndsWith("docx"))
                {
                    try
                    {
                        Word.Application wordApp = new Word.Application();
                        Word.Document wordDocument = wordApp.Documents.Open(openFileDialog.FileName);
                        Word.Range wordContentRange = wordDocument.Content;
                        fileText = wordContentRange.Text;

                        if (wordDocument != null)
                        {
                            wordDocument.Close();
                        }

                        if (wordApp != null)
                        {
                            wordApp.Quit();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Открываемый файл повреждён!", "Ошибка");
                    }
                }
                else
                    fileText = File.ReadAllText(openFileDialog.FileName, Encoding.UTF8);
            }

            return fileText;
        }

        public static void SaveFileToTXT(string text) //метод, позволяющий сохранить файл в формате .txt
        {
            if (text != "Здесь будет новый текст:)" && text != "")
            {
                try
                {
                    bool isFileSaved = false;
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text file (*.txt)|*.txt";

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        File.WriteAllText(saveFileDialog.FileName, text, Encoding.UTF8);
                        isFileSaved = true;
                    }

                    if(isFileSaved == true)
                        MessageBox.Show("Файл успешно сохранён.", "Уведомление");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Не удалось сохранить файл! Попробуйте ещё раз.", "Уведомление");
                }
            }
            else
                MessageBox.Show("Поле \"ПОСЛЕ\" ещё не заполнено!", "Уведомление");
        }

        public static void SaveFileToDOCX(string text) //метод, позволяющий сохранить файл в формате .docx
        {
            if (text != "Здесь будет новый текст:)" && text != "")
            {
                try
                {
                    bool isFileSaved = false;
                    object oMissing = System.Reflection.Missing.Value;

                    Word.Application wordApp = new Word.Application();
                    Word.Document wordDocument = wordApp.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                    wordDocument.Content.Font.Size = 14;
                    wordDocument.Content.Font.Bold = 0;
                    wordDocument.Content.Text += text;

                    wordDocument.Save();
                    isFileSaved = true;

                    wordDocument.Close();
                    wordApp.Quit();

                    if (isFileSaved == true)
                        MessageBox.Show("Файл успешно сохранён.", "Уведомление");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Не удалось сохранить файл! Попробуйте ещё раз.", "Уведомление");
                }
            }
            else
                MessageBox.Show("Поле \"ПОСЛЕ\" ещё не заполнено!", "Уведомление");
        }
    }
}
