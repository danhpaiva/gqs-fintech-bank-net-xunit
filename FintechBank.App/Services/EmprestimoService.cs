namespace FintechBank.App.Services;

public class EmprestimoService
{
    /// <summary>
    /// Calcula o valor da parcela do empréstimo aplicando a taxa de juros baseada no score de crédito.
    /// </summary>
    public decimal CalcularValorParcela(decimal valorTotal, int parcelas, int scoreCredito)
    {
        if (parcelas <= 0)
        {
            throw new ArgumentException("O número de parcelas deve ser maior que zero.", nameof(parcelas));
        }

        decimal fatorJuros = scoreCredito switch
        {
            >= 700 => 1.05m,
            >= 500 and <= 699 => 1.12m,
            _ => 1.20m
        };

        decimal valorComJuros = valorTotal * fatorJuros;
        return valorComJuros / parcelas;
    }

    /// <summary>
    /// Verifica se o empréstimo pode ser aprovado com base na renda mensal e no valor da parcela.
    /// </summary>
    public bool AprovarEmprestimo(decimal rendaMensal, decimal valorParcela)
    {
        return valorParcela <= (rendaMensal * 0.30m);
    }
}