using System.Diagnostics;

namespace PowershellCore.Linux.Mangement
{
    public class CommandLineInterface
    {
        public string RunCommand(string str)
        {
            var escapedArgs = str.Replace("\"", "\\\"");
            
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }

        
    }

    public static class StringExts
    {
        public static string[] SplitStringBySpaces(this string str)
        {
            return str.Split(' ');
        }
    }
}