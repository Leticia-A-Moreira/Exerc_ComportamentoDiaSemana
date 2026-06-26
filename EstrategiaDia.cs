namespace ComportamentoDiaSemana
{
    public class EstrategiaSegunda : IEstrategiaDia
    {
        public string NomeDia => "segunda-feira";
        public string Prioridade => "ALTA";
        public string Executar(string informacaoUsuario)
        {
            return $"Dia de definir o que importa: organize suas prioridades em torno de \"{informacaoUsuario}\".";
        }
    }
    public class EstrategiaTerca : IEstrategiaDia
    {
        public string NomeDia => "terça-feira";
        public string Prioridade => "ALTA";
        public string Executar(string informacaoUsuario)
        {
            return $"Não deixe acumular: avance nas tarefas pendentes começando por \"{informacaoUsuario}\".";
        }
    }
    public class EstrategiaQuarta : IEstrategiaDia
    {
        public string NomeDia => "quarta-feira";
        public string Prioridade => "BAIXA";
        public string Executar(string informacaoUsuario)
        {
            return $"Dia de revisão: verifique o andamento da atividade \"{informacaoUsuario}\".";
        }
    }
    public class EstrategiaQuinta : IEstrategiaDia
    {
        public string NomeDia => "quinta-feira";
        public string Prioridade => "MEDIA";
        public string Executar(string informacaoUsuario)
        {
            return $"Compartilhe o progresso: colabore com alguém da equipe sobre \"{informacaoUsuario}\".";
        }
    }
    public class EstrategiaSexta : IEstrategiaDia
    {
        public string NomeDia => " sexta-feira";
        public string Prioridade => "ALTA";
        public string Executar(string informacaoUsuario)
        {
            return $"Antes de fechar a semana: registre o que foi concluído em \"{informacaoUsuario}\".";
        }
    }

    public class EstrategiaSabado : IEstrategiaDia
    {
        public string NomeDia => "sábado";
        public string Prioridade => "MEDIA";
        public string Executar(string informacaoUsuario)
        {
            return $"Fim de semana: aproveite para um estudo livre ou descanse. Se quiser, revise \"{informacaoUsuario}\".";
        }
    }

    public class EstrategiaDomingo : IEstrategiaDia
    {
        public string NomeDia => "domingo";
        public string Prioridade => "MEDIA";
        public string Executar(string informacaoUsuario)
        {
            return $"Prepare-se para a semana: planeje como vai abordar \"{informacaoUsuario}\" nos próximos dias.";
        }
    }
}