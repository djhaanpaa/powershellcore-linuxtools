using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices;

namespace PowershellCore.Linux.Mangement.Cmdlets
{
    
    /// <summary>
    /// This CmdLet is to be able to get a Kernel Version
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "KernelVersion")]
    public class GetKernelVersion : PSCmdlet
    {
        private readonly CommandLineInterface _commandLineInterface;

        public GetKernelVersion()
        {
            _commandLineInterface = new CommandLineInterface();
        }

        protected override void EndProcessing()
        {
            var runCommand = _commandLineInterface.RunCommand("uname -a").SplitStringBySpaces();
            var isMacOsx = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            var lks = new KernelVersionInfo
            {
                OS = runCommand[0],
                HostName = runCommand[1],
                KernelVersion = runCommand[2],
                Architecture = isMacOsx ? 
                    runCommand[runCommand.Length - 1] : 
                    runCommand[runCommand.Length - 2]
            };
            WriteObject(lks);
        }
    }

    public class KernelVersionInfo
    {
        public string OS { get; set; }
        public string HostName { get; set; }
        public string KernelVersion { get; set; }
        public string Architecture { get; set; }
    }
}