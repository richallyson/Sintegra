class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Environment.Exit(2); // Parâmetros inválidos
        }

        var inscricao = args[0];
        var uf = args[1];

        var retorno = SintegraUtil.ConsisteInscricaoEstadual(inscricao, uf);

        if (retorno == 0)
        {
            Console.WriteLine("Inscrição válida");
        }
        else
        {
            Console.WriteLine("Inscrição inválida");
            Environment.Exit(1); // Inscrição inválida
        }
    }
}