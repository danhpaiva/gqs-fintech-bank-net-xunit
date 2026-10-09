using FintechBank.App.Services;
using static System.Console;

WriteLine("Iniciando aplicação FintechBank...");
ContaCorrenteService contaCorrenteService = new ContaCorrenteService();
decimal saldo = 3000.00m;
decimal taxaManutencao = contaCorrenteService.CalcularTaxaManutencao(saldo, false);
WriteLine($"Saldo: R$ {saldo}, Taxa de Manutenção: R$ {taxaManutencao}");

EmprestimoService emprestimoService = new EmprestimoService();
decimal valorTotalEmprestimo = 10000.00m;
int parcelas = 10;
int scoreCredito = 650;
decimal valorParcela = emprestimoService.CalcularValorParcela(valorTotalEmprestimo, parcelas, scoreCredito);
WriteLine($"Valor total do empréstimo: R$ {valorTotalEmprestimo}, Parcelas: {parcelas}, Score de Crédito: {scoreCredito}, Valor da Parcela: R$ {valorParcela}");
