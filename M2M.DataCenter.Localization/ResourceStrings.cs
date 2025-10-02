using System;
using System.Reflection;
using System.Resources;

namespace M2M.DataCenter.Localization
{
    public enum StringFormatters
    {
        NoChange = 0,

        ToUpper = 1,

        ToLower = 2,

        AddPrompt = 3,

        AddEqualSign = 4,

        AddParenthesis = 5
    }

	public class ResourceStrings
	{
        private static readonly ResourceStrings m_Instance = new ResourceStrings();
        private readonly ResourceManager m_ResourceStrings = null;
        
		private ResourceStrings()
		{
            m_ResourceStrings = new ResourceManager("M2M.DataCenter.Localization.DataCenter", Assembly.GetExecutingAssembly());
            
        }

        public static string GetString(string key)
        {
            string result = "";

            bool makeUpper = false;
            bool makeLower = false;
            bool addEqualSign = false;
            bool addPrompt = false;
            bool addParenthesis = false;
            
            while (key.Contains("#"))
            {
                bool upper = key.StartsWith("#+");
                bool lower = key.StartsWith("#-");
                bool equalSign = key.EndsWith("#=");
                bool prompt = key.EndsWith("#:");
                bool parenthesis = key.StartsWith("#()");
                
                makeUpper = makeUpper || upper;
                makeLower = makeLower || lower;
                addEqualSign = addEqualSign || equalSign;
                addPrompt = addPrompt ||prompt ;
                addParenthesis = addParenthesis || parenthesis;

                if (lower || upper)
                    key = key.Substring(2, key.Length - 2);

                if (prompt || equalSign)
                {
                    key = key.Substring(0, key.Length - 2);
                }

                if (parenthesis)
                    key = key.Substring(3, key.Length - 3);
            }

            
            result = m_Instance.m_ResourceStrings.GetString(key);
            
            if (result == null)
                return "[" + key + "]";

            if (makeUpper)
                result = result.ToUpper();

            if (makeLower)
                result = result.ToLower();

            if (addPrompt)
                result = result += ":";

            if (addEqualSign)
                result = result += " =";

            if (addParenthesis)
                result = "(" + result + ")";

            return result;
        }

        public static string GetString(Enum key)
        {
            string keyName = key.GetType().Name + "." + key.ToString();
            return GetString(keyName);
        }

        public static string GetString(Enum key, StringFormatters formatter)
        {
            string keyName = key.GetType().Name + "." + key.ToString();

            switch (formatter)
            {
                case StringFormatters.ToLower:
                    keyName = "#-" + keyName;
                    break;
                case StringFormatters.ToUpper:
                    keyName = "#+" + keyName;
                    break;
                case StringFormatters.AddPrompt:
                    keyName = keyName + "#:";
                    break;
                case StringFormatters.AddEqualSign:
                    keyName = keyName + "#=";
                    break;
                case StringFormatters.AddParenthesis:
                    keyName = "#()" + keyName;
                    break;
            }

            return GetString(keyName);
        }

        //public static string GetString(bool key)
        //{
        //    string keyName = key.GetType().Name + "." + key.ToString();
        //    return GetString(keyName);
        //}                
                       
        //public static string FormatString(Enum key, object value)
        //{
        //    string keyName = key.GetType().Name + "." + key.ToString();
        //    string formatString = GetString(keyName);
        //    return String.Format(formatString, value);
        //}

        //public static string FormatString(Enum key, object value1, object value2)
        //{
        //    string keyName = key.GetType().Name + "." + key.ToString();
        //    string formatString = GetString(keyName);
        //    return String.Format(formatString, value1, value2);
        //}
        
        //public static string ExtractInnerKeys(string result)
        //{
        //    while (result.Contains("#^"))
        //    {
        //        string innerKeyOrig = result.Substring(result.IndexOf("#^") + 2, result.IndexOf("^#") - (result.IndexOf("#^") + 2));
        //        bool lowerCase = false;
        //        string innerKey = innerKeyOrig.Trim();
                
        //        string newString = GetString(innerKey);
        //        if (lowerCase)
        //        {
        //            newString = newString.ToLower();
        //        }
        //        result = result.Replace("<%" + innerKeyOrig + "%>", newString);
        //    }
        //    return result;
        //}
	}
}
