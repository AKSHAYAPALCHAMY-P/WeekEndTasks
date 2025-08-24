namespace DirectoryStringParsing
{
    public class DirectoryCommands
    {
        Stack<string> strOutputString = new Stack<string>();

        public string ProcessCommand(string Command)
        {
            string strPath = "";

            if (Command.Length > 3 && Command[0] == 'c' && Command[1] == 'd' && Command[2] == ' ')
            {
                for(int i = 3; i <Command.Length; i++)
                {
                    strPath += Command[i];
                }
                DirectoryChange(strPath);
            }

            else if (Command == "pwd")
            {
                string[] strFinalPath = strOutputString.ToArray();

                if (strFinalPath.Length == 0)
                    return "/"; 

                string strResult = "/";
                for (int i = strFinalPath.Length - 1; i >= 0; i--)
                {
                    strResult += strFinalPath[i] + "/";
                }

                return strResult;
            }


            return "";
        }


        public void DirectoryChange(string DirectoryPath)
        {
            string[] strParts = new String[100];
            String strCurrentPart = "";
            int Count = 0;

            foreach (char ch in DirectoryPath)
            {
                if (ch == '/')
                {
                    if (strCurrentPart != "")
                    {
                        strParts[Count++] = strCurrentPart; 
                        strCurrentPart = "";
                    }
                }
                else
                {
                    strCurrentPart += ch;
                }
            }

            if (strCurrentPart != "")
            {
                strParts[Count++] = strCurrentPart;
            }

            for (int i = 0; i < Count; i++)
            {
                string part = strParts[i];
                if (part == "." || part == "")
                {
                    continue;
                }
                else if (part == "..")
                {
                    if (strOutputString.Count > 0)
                    {
                        strOutputString.Pop();
                    }
                }
                else
                {
                    strOutputString.Push(part);
                }
            }
        }
    }
}
