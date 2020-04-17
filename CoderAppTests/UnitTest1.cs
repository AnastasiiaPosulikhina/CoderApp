using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoderAppTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGettingLetterIndex()
        {
            Assert.AreEqual(0, CoderApp.Coder.GetLetterIndex('а'));
            Assert.AreEqual(1, CoderApp.Coder.GetLetterIndex('б'));
            Assert.AreEqual(2, CoderApp.Coder.GetLetterIndex('в'));
            Assert.AreEqual(31, CoderApp.Coder.GetLetterIndex('ю'));
            Assert.AreEqual(32, CoderApp.Coder.GetLetterIndex('я'));
            Assert.AreEqual(-1, CoderApp.Coder.GetLetterIndex(' '));
            Assert.AreEqual(-1, CoderApp.Coder.GetLetterIndex('!'));
            Assert.AreEqual(-1, CoderApp.Coder.GetLetterIndex(','));
            Assert.AreEqual(-1, CoderApp.Coder.GetLetterIndex('F'));
        }

        [TestMethod]
        public void TestVigenereCoder()
        {
            string textToEncode = "поздравляю, ты получил исходный текст!!! " +
                "в принципе понять, что тут используется шифр виженера не особо трудно, " +
                "основная подсказка заключается именно в наличии ключа у этого шифра! " +
                "в данной задаче особый интерес составляет то, как вы реализуете именно " +
                "сам процесс расшифровки. теперь дело осталось за малым, доделать программу " +
                "до логического конца, выполнить все условия задания и опубликовать свою работу! " +
                "молодец, это были достаточно трудные и интересные два с половиной месяца, но " +
                "впереди нас ждет еще множество открытий, и я надеюсь общих свершений! от лица " +
                "компании FirstLineSoftware и университета итмо, я рад поздравить тебя с официальным " +
                "окончанием наших курсов с# для начинающих! мы хотим пожелать успехов в дальнейшем " +
                "погружении в мир ит и программирования с использованием стека технологий .Net, " +
                "море терпения и интересных задач!";

            string textToDecode = "бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!! " +
                "у ъящэячэц ъэюоык, едщ бдв саэацкшгнбяр гчеа кчфцшубп цу ьгщпя вщвсящ, " +
                "эвэчрысй юяуъщнщхо шпуъликугбз чъцшья с цощъвчщ ъфмес ю лгюлэ ёъяяр! " +
                "с моыящш шпмоец щаярдш цяэубфъ аьгэотызуа дщ, щръ кй юцкъщчьуац уыхэцэ " +
                "ясч юбюяуяг ыовзсгюамщщ. внютвж тхыч эядкъябе цн юкъль, мэсццогл шяьфыоэьь " +
                "ть эщсщжнашанэ ыюцен, уёюяыцчан мах гъъьуун шпмоыъй ч яяьпщъхэтпык яущм бпйэае! " +
                "чэьюмуд, оээ скфч саьбрвчёыа эядуцйт ъ уьгфщуяяёу фси а эацэтшцэч юпапёи, ьь " +
                "уъубфмч ысь хффы ужц чьяцнааущ эгъщйаъф, ч п эиттпьк ярвчг гмубзньцы! щб ьшяо " +
                "шачюрэсч FirstLineSoftware ц ешчтфщацдпбр шыыь, р ыоф ячцсвкрщве бттй а ядсецсцкюкх " +
                "эшашёрэсуъ якжще увюгщр в# уфн ысвчюпжзцж! чй ёюычъ бщххыибй еьюхечр п хкъмэншёцч " +
                "юятщвфцшчщ с хчю ъэ ч аачсюсчыщачрняун в шъюьэжцясиьццч агфуо ацаьяычсцы .Net, " +
                "чэбф ыуюбпьщо с чыдпяхбцйг щктрж!";

            string key = "скорпион";

            Assert.AreEqual(textToDecode, CoderApp.Coder.Encode(textToEncode, key));
            Assert.AreEqual("щаща щыша эащу.", CoderApp.Coder.Encode("мама мыла раму.", "мама"));
            Assert.AreEqual("хэеёх сбящяып: чнсрюв!", CoderApp.Coder.Encode("котик говорит: мяяууу!", "котэ"));

            Assert.AreEqual(textToEncode, CoderApp.Coder.Decode(textToDecode, key));
            Assert.AreEqual("мама мыла раму.", CoderApp.Coder.Decode("щаща щыша эащу.", "мама"));
            Assert.AreEqual("котик говорит: мяяууу!", CoderApp.Coder.Decode("хэеёх сбящяып: чнсрюв!", "котэ"));
        }
    }
}
