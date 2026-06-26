namespace ComportamentoDiaSemana
{
    public interface IEstrategiaDia
    {
        // interface base para todas as estrategias
        // cada dia da semana vai ter sua propria implementacao, para a prioridade e infos
        string NomeDia
        {
            get;
        }
        string Prioridade // Alta, Média ou Baixa
        {
            get;
        }
        // recebe a tarefa/info do usuário e monta a mensagem
        string Executar (string informacaoUsuario);
    }
}