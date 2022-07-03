using TextMatch.Modules;

namespace TextMatch.Services
{
    public class SerachIndexService
    {
        public SerachIndexService()
        {

        }

        public string getSubTextIndex(string text, string subText)
        {
            char[] textChars = stringToCharArr(text);
            char[] subTextChar = stringToCharArr(subText);

            IndexedArray[] groupChars = collectCharArrInGroupOf(textChars, subText.Length);

            string matchIndexes = foundIndex(subTextChar, groupChars);

            return matchIndexes;
        }

        private char[] stringToCharArr(string txt)
        {
            char[] chars = new char[txt.Length];

            for (int i = 0; i < txt.Length; i++)
            {
                //I am using Char ToLower here even if I could wrote my own function to map the ASCII codes to make it case insensitive.
                chars[i] = Char.ToLower(txt[i]);
            }

            return chars;
        }

        IndexedArray[] collectCharArrInGroupOf(char[] charArr, int length)
        {
            IndexedArray[] iArr = new IndexedArray[charArr.Length + 1 - length];

            for (int i = 0; i < charArr.Length + 1 - length; i++)
            {
                iArr[i] = new IndexedArray();
                iArr[i].index = i+1;
                iArr[i].chars = new char[length];
                for (int j = 0 + i; j < length + i; j++)
                {
                    iArr[i].chars[j - i] = charArr[j];
                }
            };
            return iArr;
        }

        string foundIndex(char[] subchar, IndexedArray[] orginalChar)
        {
            string s = "";
            foreach (IndexedArray c in orginalChar)
            {
                if (c.chars.SequenceEqual(subchar))
                {
                    s += c.index.ToString()+",";
                }
            }
            return s.Remove(s.Length-1);
        }
    }
}
