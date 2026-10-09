namespace FintechBank.App.Services;

public class ContaCorrenteService
{
    /// <summary>
    /// Calcula a taxa de manutenção da conta corrente com base no saldo e se o cliente é especial.
    /// </summary>
    public decimal CalcularTaxaManutencao(decimal saldo, bool clienteEspecial)
    {
        if (saldo >= 5000.00m || clienteEspecial)
        {
            return 0.00m;
        }

        if (saldo >= 1000.00m && saldo <= 4999.99m)
        {
            return 12.50m;
        }

        return 25.00m;
    }

    /// <summary>
    /// Verifica se o saque pode ser realizado considerando o saldo e o limite do cheque especial.
    /// </summary>
    public bool PodeRealizarSaque(decimal saldo, decimal limiteChequeEspecial, decimal valorSaque)
    {
        return valorSaque <= (saldo + limiteChequeEspecial);
    }
}