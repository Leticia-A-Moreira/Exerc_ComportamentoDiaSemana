namespace ComportamentoDiaSemana
{
    // padrão Null Object - evita ficar checando nulo no código principal
    // se não tem estratégia pro dia, usa essa aqui
    // responde às questões de reflexão 1 e 2 do exercício
    public class EstrategiaNula : IEstrategiaDia{
        private readonly string _nomeDia;
         public EstrategiaNula(string nomeDia = "desconhecido") {
            _nomeDia = nomeDia;
        }
        public string NomeDia => _nomeDia;
        public string Prioridade => "INDEFINIDA";
        public string Executar(string informacaoUsuario){
            // não joga exceção, só avisa que não tem estratégia
            return $"Nenhuma estratégia definida para o dia \"{_nomeDia}\". Sem interrupções.";
        }
    }
    // esse cara é responsavel por mapear dia -> estratégia
    // centraliza tudo aqui pra não ficar if/else espalhado
    public class SeletorEstrategia{
        // dicionario com os dias todos mapeados
        private readonly Dictionary<string, IEstrategiaDia> _estrategias;
        public SeletorEstrategia()
        {
            _estrategias = new Dictionary<string, IEstrategiaDia>(StringComparer.OrdinalIgnoreCase) {
                { "segunda",        new EstrategiaSegunda() },
                { "segunda-feira",  new EstrategiaSegunda() },
                { "terca",          new EstrategiaTerca()   },
                { "terça",          new EstrategiaTerca()   },
                { "terca-feira",    new EstrategiaTerca()   },
                { "terça-feira",    new EstrategiaTerca()   },
                { "quarta",         new EstrategiaQuarta()  },
                { "quarta-feira",   new EstrategiaQuarta()  },
                { "quinta",         new EstrategiaQuinta()  },
                { "quinta-feira",   new EstrategiaQuinta()  },
                { "sexta",          new EstrategiaSexta()   },
                { "sexta-feira",    new EstrategiaSexta()   },
                { "sabado",         new EstrategiaSabado()  },
                { "sábado",         new EstrategiaSabado()  },
                { "domingo",        new EstrategiaDomingo() },
            };
        }
        // retorna a estratégia do dia atual do sistema
        public IEstrategiaDia ObterEstrategiaAtual(){
            // DayOfWeek começa no domingo (0) e vai até sabado (6)
            var hoje = DateTime.Now.DayOfWeek;
            var nomeDia = ConverterDayOfWeek(hoje);
            return ObterEstrategiaPorNome(nomeDia);
        }
        // consulta manual por nome do dia - requisito 4 do exercício
        public IEstrategiaDia ObterEstrategiaPorNome(string nomeDia){
            if (_estrategias.TryGetValue(nomeDia.Trim(), out var estrategia))
                return estrategia;
            // retorna null object em vez de null ou exceção
            return new EstrategiaNula(nomeDia);
        }
        // helper pra converter o enum do C# pro nome em pt-br
        private string ConverterDayOfWeek(DayOfWeek dia){
            return dia switch
            {
                DayOfWeek.Monday    => "segunda-feira",
                DayOfWeek.Tuesday   => "terça-feira",
                DayOfWeek.Wednesday => "quarta-feira",
                DayOfWeek.Thursday  => "quinta-feira",
                DayOfWeek.Friday    => "sexta-feira",
                DayOfWeek.Saturday  => "sábado",
                DayOfWeek.Sunday    => "domingo",
                _                   => "desconhecido"   // nunca deve cair aqui, mas compilador reclama sem isso
            };
        }
        // retorna o nome do dia atual formatado
        public string ObterNomeDiaAtual(){
            return ConverterDayOfWeek(DateTime.Now.DayOfWeek);
        }
    }
}
