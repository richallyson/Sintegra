using System;
using System.Runtime.InteropServices;

public class SintegraUtil
{
#if WIN64
        private const string SintegraDllPath = @"C:\Windows\SysWOW64\sintegra.dll";
#else
    private const string SintegraDllPath = @"C:\Windows\System32\sintegra.dll";
#endif

    [DllImport(SintegraDllPath, CallingConvention = CallingConvention.StdCall)]
    public static extern int ConsisteInscricaoEstadual(string Insc, string UF);

    [DllImport("sintegra.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern int VersaoDLL();

    public static bool ValidarInscricaoEstadual(string inscricao, string uf)
    {
        var retorno = ConsisteInscricaoEstadual(inscricao, uf);

        if (retorno == 0)
        {
            Console.WriteLine("Inscrição válida");
            return true; // inscrição VÁLIDA
        }

        if (retorno == 1)
        {
            Console.WriteLine("Inscrição inválida");
            return false; // inscrição INVÁLIDA
        }

        throw new ArgumentException("Parâmetros inválidos");
    }
}