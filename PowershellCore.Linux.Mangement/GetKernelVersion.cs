using System;
using System.Management.Automation;

namespace PowershellCore.Linux.Mangement
{
    [Cmdlet(VerbsCommon.Get, "KernelVersion")]
    public class GetKernelVersion : PSCmdlet
    {
        protected override void EndProcessing()
        {
            WriteObject(new { KernelVersion = "1.0"});
        }
    }
}
