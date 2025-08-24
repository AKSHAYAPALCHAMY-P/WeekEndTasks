using DirectoryStringParsing;

namespace DirectoryCommandsTest
{
    [TestClass]
    public sealed class DirectoryCommandsTestCase
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            var dc = new DirectoryCommands();

            List<string> commands = new List<string>
            {
                "cd /home",
                "cd user",
                "pwd",
                "cd ..",
                "pwd",
                "cd ./projects/../code",
                "pwd"
            };

            List<string> expected = new List<string>
            {
                "/home/user/",
                "/home/",
                "/home/code/"
            };

            List<string> actual = new List<string>();

            foreach (var cmd in commands)
            {
                string strOutput = dc.ProcessCommand(cmd);
                if (!string.IsNullOrEmpty(strOutput))
                {
                    actual.Add(strOutput);
                }
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCase2()
        {
            var dc = new DirectoryCommands();

            List<string> commands = new List<string>
            {
                "cd /",
                "cd home",
                "cd ./user//",
                "cd ../..",
                "cd ../..",
                "cd var/log",
                "pwd",
                "cd /etc/./nginx/../ssh",
                "pwd",
                "cd ..",
                "pwd"
            };

            List<string> expected = new List<string>
            {
                "/var/log/",
                "/etc/ssh/",
                "/etc/"
            };

            List<string> actual = new List<string>();

            foreach (var cmd in commands)
            {
                string strOutput = dc.ProcessCommand(cmd);
                if (!string.IsNullOrEmpty(strOutput))
                {
                    actual.Add(strOutput);
                }
            }

            CollectionAssert.AreEqual(expected, actual);
        }

    }

}
