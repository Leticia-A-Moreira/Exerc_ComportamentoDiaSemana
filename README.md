Utilizei IA para auxiliar na construção do README.
# Comportamento por Dia da Semana

Programa orientado a objetos em C# que identifica o dia atual da semana e delega a execução de uma ação para uma estratégia específica.

---

## Como executar

**Pré-requisito:** .NET 8 SDK instalado.

```bash
# entrar na pasta do projeto
cd ComportamentoDiaSemana

# compilar e rodar
dotnet run
```

O programa vai pedir seu nome, se quer usar o dia atual ou informar um manualmente, e uma tarefa/meta do dia.

---

## Estrutura do projeto

```
ComportamentoDiaSemana/
├── Program.cs              # entrada do programa, interação com o usuário
├── IEstrategiaDia.cs       # interface base para todas as estratégias
├── EstrategiasDia.cs       # estratégias concretas (uma por dia da semana)
├── SeletorEstrategia.cs    # seletor de estratégia + padrão Null Object
└── ComportamentoDiaSemana.csproj
```

### Resumo da estrutura

- **`IEstrategiaDia`** — define o contrato: `NomeDia`, `Prioridade` e `Executar(string)`.
- **`EstrategiaSegunda/Terca/.../Domingo`** — implementações concretas, cada uma com sua mensagem e prioridade (ALTA, MEDIA ou BAIXA).
- **`EstrategiaNula`** — implementação do padrão Null Object; usada quando o dia informado não tem estratégia associada.
- **`SeletorEstrategia`** — mapeia nomes de dias para estratégias usando um `Dictionary`, expõe `ObterEstrategiaAtual()` (usa `DateTime.Now`) e `ObterEstrategiaPorNome(string)` para consulta manual.
- **`Program`** — lê as entradas do usuário e chama o seletor sem nenhum `if/else` sobre qual mensagem exibir.

---

## Exemplos de execução

### Entrada válida (dia atual = quarta-feira)

```
=== Comportamento por Dia da Semana ===

Usuário: Ana
Opções:
  1 - Usar o dia atual
  2 - Informar um dia manualmente

Escolha: 1

Informe uma tarefa, nome ou meta para hoje: Implementar relatório

Usuário: Ana
Dia consultado: quarta-feira
Prioridade: MEDIA
Mensagem: Dia de revisão: verifique o andamento da atividade "Implementar relatório".
```

### Entrada inválida (dia inexistente ou sem estratégia)

```
=== Comportamento por Dia da Semana ===

Usuário: Carlos
Opções:
  1 - Usar o dia atual
  2 - Informar um dia manualmente

Escolha: 2

Digite o dia da semana (ex: segunda-feira, quarta): feriado

Informe uma tarefa, nome ou meta para hoje: Descansar

Usuário: Carlos
Dia consultado: feriado
Prioridade: INDEFINIDA
Mensagem: Nenhuma estratégia definida para o dia "feriado". Sem interrupções.
```

---

## Questões de reflexão

### 1. Como evitar verificações repetidas de valores nulos no código principal?

Usando o **padrão Null Object**. Em vez de retornar `null` quando não existe estratégia para um dia, o `SeletorEstrategia` retorna uma instância de `EstrategiaNula`, que implementa a mesma interface `IEstrategiaDia`. O `Program.cs` nunca precisa checar `if (estrategia == null)` — ele simplesmente chama `estrategia.Executar(tarefa)` e a `EstrategiaNula` responde de forma segura com uma mensagem padrão. Isso elimina verificações defensivas espalhadas pelo código e mantém o fluxo principal limpo.

### 2. Qual padrão de projeto pode ser utilizado para representar a ausência de uma estratégia de forma segura?

O padrão **Null Object** (Objeto Nulo). Ele consiste em criar uma implementação concreta da interface que representa a ausência de comportamento real — sem lançar exceções e sem retornar nulo. O objeto nulo simplesmente "não faz nada" (ou faz algo neutro) de forma controlada.

### 3. Como esse padrão foi incorporado à solução?

A classe `EstrategiaNula` implementa `IEstrategiaDia` com comportamento neutro: retorna `"INDEFINIDA"` como prioridade e uma mensagem informando que não há estratégia para o dia. O `SeletorEstrategia.ObterEstrategiaPorNome()` retorna essa instância quando o dia não existe no dicionário, garantindo que o programa continue funcionando sem interrupção mesmo para dias inválidos ou não mapeados — atendendo diretamente ao requisito 5 do exercício.
