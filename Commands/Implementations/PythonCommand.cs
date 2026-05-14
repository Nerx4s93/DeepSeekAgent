using DeepSeekAgent.Commands.CommandResults;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSeekAgent.Commands.Implementations;

public class PythonCommand : LocalCommand
{
    public PythonCommand(LocalCommandContext context) : base(context) { }

    public override string Group => "TOOLS";
    public override string Name => "PYTHON";
    public override string ShortDescription => "выполнение Python-кода";

    public override async Task<CommandResult> ExecuteAsync(string payload)
    {
        return await Task.Run(() =>
        {
            try
            {
                var code = ExtractPythonCode(payload);

                var startInfo = new ProcessStartInfo
                {
                    FileName = "python",
                    Arguments = "-",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    StandardErrorEncoding = Encoding.UTF8
                };

                startInfo.EnvironmentVariables["PYTHONIOENCODING"] = "utf-8";

                using var process = new Process { StartInfo = startInfo };
                process.Start();

                using (var streamWriter = new StreamWriter(process.StandardInput.BaseStream, new UTF8Encoding(false)))
                {
                    streamWriter.Write(code);
                }

                var exited = process.WaitForExit(30000);

                var output = "";
                var error = "";

                if (!exited)
                {
                    try
                    {
                        process.Kill(true);
                    }
                    catch { }

                    error = "Execution timed out (30 seconds)";
                }
                else
                {
                    output = process.StandardOutput.ReadToEnd();
                    error = process.StandardError.ReadToEnd();
                }

                var executeResult = !string.IsNullOrEmpty(error)
                    ? $"Error:\n{error}"
                    : output;

                var resultText = $"""
                    RESPONSE PYTHON
                    {executeResult}
                    END RESPONSE
                    """;

                return (CommandResult)new ContinueResult(resultText);
            }
            catch (Exception ex)
            {
                return (CommandResult)new ContinueResult(ex.Message);
            }
        });
    }

    public static string ExtractPythonCode(string input)
    {
        var startMarker = "```python";
        var endMarker = "```";

        var start = input.IndexOf(startMarker, StringComparison.OrdinalIgnoreCase);

        if (start == -1)
        {
            return input.Trim();
        }

        start += startMarker.Length;

        var end = input.IndexOf(endMarker, start, StringComparison.OrdinalIgnoreCase);

        if (end == -1)
        {
            return input[start..].Trim();
        }

        return input[start..end].Trim();
    }
}