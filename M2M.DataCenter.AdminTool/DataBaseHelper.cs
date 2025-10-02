using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;

namespace M2M.DataCenter.AdminTool
{
    public class SqlHelper
    {
        public static TextWriter StandardOutput;
        public static TextWriter ErrorOutput;

        /// <summary>
        /// Parse Parameters then Run a .sql script trough osql.
        /// </summary>
        /// <param name="fileName">the .sql script</param>
        /// <param name="connStringBuilder">object that holds all connection information.</param>
        /// <param name="args">The arguments passed to the sql script.</param>
        public static void RunSqlScript(string fileName, SqlConnectionStringBuilder connStringBuilder, Dictionary<string, string> variables, int test)
        {
            // simple checks
            if (!Path.GetExtension(fileName).Equals(".sql", StringComparison.InvariantCulture))
                throw new Exception("The file doesn't end with .sql.");

            FileInfo file = ProcessArgs(fileName, variables);

            // create cmd line
            StringBuilder cmd = new StringBuilder(string.Format(
                "OSQL -S \"{0}\" -i \"{1}\" -n -m {2} -r 0",
                /*0*/connStringBuilder.DataSource,
                /*1*/file.ToString(), test));
            if (connStringBuilder.IntegratedSecurity)
                cmd.Append(" -E");
            else
                cmd.AppendFormat(" -U {0} -P {1}",
                    /*0*/connStringBuilder.UserID,
                    /*1*/connStringBuilder.Password);

            // create the process
            var process = new System.Diagnostics.Process();
            process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
            process.StartInfo.FileName = "cmd";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.ErrorDataReceived += new DataReceivedEventHandler(process_ErrorDataReceived);
            process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);

            // start the application
            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
            process.StandardInput.WriteLine("@ECHO OFF");
            process.StandardInput.WriteLine(cmd.ToString());
            process.StandardInput.WriteLine("EXIT");
            process.StandardInput.Flush();
            process.WaitForExit();

            //delete temporary file
            file.Delete();
        }

        private static void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != string.Empty)
                if (StandardOutput == null)
                    Console.WriteLine(e.Data);
                else
                {
                    StandardOutput.WriteLine(e.Data);
                    StandardOutput.Flush();
                }
        }

        private static void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != string.Empty)
                if (ErrorOutput == null)
                    Console.WriteLine(e.Data);
                else
                {
                    ErrorOutput.WriteLine(e.Data);
                    ErrorOutput.Flush();
                }
        }

        private static FileInfo ProcessArgs(string fileName, Dictionary<string, string> variables)
        {
            FileInfo f = new FileInfo(fileName);
            string sqlScript = f.OpenText().ReadToEnd();
            foreach (KeyValuePair<string, string> kvp in variables)
            {
                sqlScript = sqlScript.Replace(String.Format("$({0})", kvp.Key), kvp.Value);
            }

            FileInfo newFile = new FileInfo("tmpSql.sql");
            using (var w = newFile.CreateText())
            {
                w.Write(sqlScript);
                w.Flush();
            }
            return newFile;
        }
    }
}


