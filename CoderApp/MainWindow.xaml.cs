using System.Windows;
using System.Windows.Controls;

namespace CoderApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_OpenFile(object sender, RoutedEventArgs e) //открытие файла
        {
            TextBefore.Text = DataProcessing.OpenFile();
        }

        private void Button_Encode(object sender, RoutedEventArgs e) //кодирование текста
        {
            string key = Coder.GetEnteredKey(Key.Text.ToString());
            if (key != "" && key != "Введите ключ...")
            {
                string fileText = TextBefore.Text;
                if (fileText == "" || fileText == "Откройте файл с исходным текстом или введите его...")
                {
                    MessageBox.Show("Текст для кодирования отсутствует! :(\nНапишите его или загрузите, нажав кнопку \"Открыть\" и повторите попытку.", "Уведомление");
                }
                else
                {
                    TextAfter.Text = Coder.Encode(fileText, key);
                }
            }

        }

        private void Button_Decode(object sender, RoutedEventArgs e) //декодирование текста
        {
            string key = Coder.GetEnteredKey(Key.Text.ToString());
            
            if (key != "" && key != "Введите ключ...")
            {
                if (Key.Text.ToString() != "Введите ключ...")
                {
                    key = Key.Text.ToString();
                }
                else
                {
                    MessageBox.Show("Вы ещё не ввели ключ!", "Уведомление");
                }

                string fileText = TextBefore.Text;

                if (fileText == "" || fileText == "Откройте файл с исходным текстом или введите его...")
                {
                    MessageBox.Show("Текст для декодирования отсутствует! :(\nНапишите его или загрузите, нажав кнопку \"Открыть\" и повторите попытку.", "Уведомление");
                }
                else
                {
                    TextAfter.Text = Coder.Decode(fileText, key);
                }
            }
        }

        private void Button_SaveToTXT(object sender, RoutedEventArgs e) //сохранение текста в формате .txt
        {
            DataProcessing.SaveFileToTXT(TextAfter.Text);
        }

        private void Button_SaveToDOCX(object sender, RoutedEventArgs e) //сохранение текста в формате .docx
        {
            DataProcessing.SaveFileToDOCX(TextAfter.Text);
        }

        private void Button_ChangeText(object sender, RoutedEventArgs e) //перенос текста из поля "ПОСЛЕ" в поле "ДО"
        {
            if (TextAfter.Text != "Здесь будет новый текст:)" && TextAfter.Text != "")
            {
                TextBefore.Text = TextAfter.Text;
                TextAfter.Text = "Здесь будет новый текст:)";
            }
        }

        private void TextAfter_TextChanged(object sender, TextChangedEventArgs e)
        { }

        private void TextBefore_TextChanged(object sender, TextChangedEventArgs e)
        { }
    }
}
