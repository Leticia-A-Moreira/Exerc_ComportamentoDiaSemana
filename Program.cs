namespace ComportamentoDiaSemana
{
    class Program
    {
        static void Main(string[] args)
        {
            var seletor = new SeletorEstrategia();
            Console.WriteLine("=== Comportamento por Dia da Semana ===\n");

            // pega o nome do usuário primeiro
            Console.WriteLine("Usuário: ");
            string nomeUsuario = Console.ReadLine() ?? "Anônimo";

            // pergunta se quer consultar o dia atual ou um dia manualmente
            Console.WriteLine("\nOpções:");
            Console.WriteLine(" 1 - Usar o dia atual");
            Console.WriteLine(" 2 - Informar um dia manualmente");
            Console.WriteLine("\nEscolha: ");

            string opcao = Console.ReadLine() ?? "1";

            IEstrategiaDia estrategia;
            string diaConsultado;

            if (opcao.Trim() == "2")
            {
                Console.WriteLine("\nDigite o dia da semana (ex: segunda-feira, quarta): ");
                string diaInformado = Console.ReadLine() ?? "";

                // tenta buscar a estratégia pelo nome 
                // se o dia for inválido, o seletor retorna EstrategiaNula
                estrategia = seletor.ObterEstrategiaPorNome(diaInformado);
                diaConsultado = diaInformado.Trim() == "" ? "não informado" : diaInformado;
            }
            else
            {
                // usa o dia de hoje mesmo
                estrategia = seletor.ObterEstrategiaAtual();
                diaConsultado = seletor.ObterNomeDiaAtual();

            }

            // pede a tarefa ou informação do usuário
            Console.WriteLine("\nInforme uma tareda, nome ou meta para hoje: ");

            string tarefa = Console.ReadLine() ?? "";

            if (tarefa.Trim() == "")
            {
                tarefa = "tarefa sem título";

            }

            // executa a estratégia com a informação do usuário 
            string mensagem = estrategia.Executar(tarefa);

            // imprime o resultado no formato pedido
            Console.WriteLine();
            Console.WriteLine($"Usuário: {nomeUsuario}");
            Console.WriteLine($"Dia consultado: {diaConsultado}");
            Console.WriteLine($"Prioridade: {estrategia.Prioridade}");
            Console.WriteLine($"Mensagem: {mensagem}");

        }
    }
}