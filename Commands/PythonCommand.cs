using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSeekAgent.Commands;

public class PythonCommand : LocalCommand
{
    public override string Name => "PYTHON";
    public override string Description => "Выполнение Python-кода. Возвращает stdout или stderr.";

    public override async Task<string> ExecuteAsync(string input)
    {
        return await Task.Run(() =>
        {
            try
            {
                var code = ExtractPythonCode(input);

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

                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                var executeResult = !string.IsNullOrEmpty(error) ? $"Error:\n{error}" : output;

                var result = $"""
                RESPONSE PYTHON
                {executeResult}
                END RESPONSE
                """;

                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
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