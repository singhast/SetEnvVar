using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SetEnvVar
{
    class ExecOptions
    {
        [Option(longName: "project", Required = true)]
        public string Project
        {
            get;
            set;
        }

        [Option(longName: "set", Required = true)]
        public string Variable
        {
            get;
            set;
        }

        [Option(longName: "type", Required = true)]
        public string VariableType
        {
            get;
            set;
        }


        [Option(longName: "KeepEncrypted", Required = false)]
        public bool KeepEncrypted
        {
            get;
            set;
        }


        [Option(longName: "regex", Required = false)]
        public string ValueRegex
        {
            get;
            set;
        }

        [Option('h', "help", Required = false, HelpText = "Print help")]
        public bool IsHelpOperation
        {
            get;
            set;
        }



        [HelpOption]
        internal string getusage()
        {
            var usage = new StringBuilder();

            usage.AppendLine(string.Format("SetEnvVar {0}", Assembly.GetExecutingAssembly().GetName().Version));
            usage.AppendLine(" Usage Help");
            usage.AppendLine("   odbcman --help ");
            usage.AppendLine("   odbcman -h ");

            return usage.ToString();

        }


    }
}
