using System.Linq;
using System.Management.Automation;

namespace PowershellCore.Linux.Mangement.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "KernelVersion")]
    public class GetKernelVersion : PSCmdlet
    {
        private CommandLineInterface _commandLineInterface;

        public GetKernelVersion()
        {
            _commandLineInterface = new CommandLineInterface();
        }

        protected override void EndProcessing()
        {
            var runCommand = _commandLineInterface.RunCommand("uname -a").SplitStringBySpaces();
            WriteObject(new
            {
                OS = runCommand[0],
                HostName = runCommand[1],
                KernelVersion = runCommand[2],
                Architecture = runCommand[runCommand.Length-1]
            });
        }
    }
}