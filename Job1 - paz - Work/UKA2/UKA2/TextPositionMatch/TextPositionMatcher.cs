using System;
namespace TextPositionMatch
{
	public class TextPositionMatcher
	{
		public TextPositionMatcher()
		{
		}

        public string FindPositionOfText(string text, string subText)
        {
            //var matches = new List<int>();
            //var index = 0;

            //while ((index = text.IndexOf(subText, index, StringComparison.OrdinalIgnoreCase)) != -1)
            //{
            //    index++;
            //    matches.Add(index);
            //}

            //return string.Join(",", matches);

            var matches = new List<int>();
            int subIndex = 0;


            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == subText[subIndex])
                {
                    if (subIndex == subText.Length - 1)
                    {
                        int index = i - subText.Length + 1;
                        matches.Add(index);
                        Console.WriteLine("Substring '" + subText + "' found at index " + index);
                        subIndex = 0;
                    }
                    else
                    {
                        subIndex++;
                    }
                }
                else
                {
                    subIndex = 0;
                }

                if (subIndex == 1 && i < text.Length - 1 && text[i + 1] == subText[1])
                {
                    subIndex++;
                }
            }

            return string.Join(",", matches);
        }
    }
}

