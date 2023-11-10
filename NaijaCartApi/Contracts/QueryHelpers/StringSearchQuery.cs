namespace NaijaCartApi.Contracts.QueryHelpers
{
    public class StringSearchQuery
    {
        internal string[] SearchStrings { get; private set; } = Array.Empty<string>();

        public string SearchText
        {
            get
            {
                return string.Join(' ', SearchStrings);
            }
            set
            {
                char[] separators = new char[1] { ' ' };
                SearchStrings = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        internal bool CanSearch => SearchStrings.Length > 0;
    }
}
