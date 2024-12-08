using System;
namespace TextPositionMatch
{
	public class Matcher
    {
        private string text;
        private string subtext;
        private bool caseInsensitive;

        public Matcher(string text, string subtext, bool caseInsensitive)
        {
            this.text = text;
            this.subtext = subtext;
            this.caseInsensitive = caseInsensitive;
        }

        public List<string> FindMatches()
        {
            List<string> matches = new List<string>();

            int index = -1;
            do
            {
                index = text.IndexOf(subtext, index + 1, caseInsensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

                if (index != -1)
                {
                    matches.Add((index + 1).ToString());
                }

            } while (index != -1);

            return matches;
        }
    }
}

