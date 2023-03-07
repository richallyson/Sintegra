using System.Diagnostics;

namespace SintegraMVC.Util
{
    public class SintegraUtil
    {
        public static bool ValidarInscricaoEstadual(string inscricao, string uf)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = @"C:\digite-seu-caminho\TesteSintegra\Sintegra\bin\Debug\net7.0\Sintegra.exe",
                Arguments = $"{inscricao} {uf}",
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using var process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            process.StandardInput.WriteLine(); // enviar entrada vazia para o aplicativo console

            var output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);

            process.WaitForExit();

            return process.ExitCode == 0; // retornar false se o código de saída for diferente de 0
        }
    }
}
