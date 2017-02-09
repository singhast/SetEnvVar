using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetEnvVar
{
    class Program
    {
        static void Main(string[] args)
        {
            ParserSettings parserSettings = new ParserSettings();
            Parser parser = new Parser(parserSettings);

            ExecOptions options = new ExecOptions();

            parser.ParseArguments(args, options);

            string[] problems = Validate(options);
            if (problems.Length == 0)
                HandleOptions(options);
            else
            {
                foreach (string problem in problems)
                    Console.WriteLine(problems);
                Console.WriteLine(options.getusage());
            }
        }

        private static string[] Validate(ExecOptions options)
        {
            List<string> issues = new List<string>();
            if (!string.IsNullOrWhiteSpace(options.Project))
            {
                if (!string.IsNullOrWhiteSpace(options.Variable))
                {
                    if (!string.IsNullOrWhiteSpace(options.VariableType))
                    {
                        switch (options.VariableType.ToLower())
                        {
                            case "file": 
                                break;
                            case "value": 
                                break;
                            case "folder": ;
                                break;
                            default:
                                issues.Add(string.Format("Unknown Type:{0", options.VariableType));
                                break;
                        }
                    }
                    else
                    {
                        issues.Add("Variable Type is required");
                    }

                }
                else
                    issues.Add("Variable is required");

            }
            else
                issues.Add("Project is required");

            return issues.ToArray();

        }

        private static void HandleOptions(ExecOptions options)
        {

        }
    }
}
