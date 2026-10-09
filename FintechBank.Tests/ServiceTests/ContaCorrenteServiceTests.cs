using FintechBank.App.Services;

namespace FintechBank.Tests.ServiceTests;

public class ContaCorrenteServiceTests
{
    private readonly ContaCorrenteService _contaCorrenteService;

    public ContaCorrenteServiceTests()
    {
        _contaCorrenteService = new ContaCorrenteService();
    }

    [Theory]
    [InlineData(6000.00, false, 0.00)]  // Saldo alto -> Isento
    [InlineData(500.00, true, 0.00)]   // Cliente Especial -> Isento
    [InlineData(2500.00, false, 12.50)] // Saldo intermediário -> R$ 12,50
    [InlineData(300.00, false, 25.00)]  // Saldo baixo -> R$ 25,00
    public void CalcularTaxaManutencao_DeveRetornarTaxaCorreta(decimal saldo, bool clienteEspecial, decimal taxaEsperada)
    {
        // Act
        decimal resultado = _contaCorrenteService.CalcularTaxaManutencao(saldo, clienteEspecial);

        // Assert
        Assert.Equal(taxaEsperada, resultado);
    }

    [Theory]
    [InlineData(1000.00, 500.00, 1200.00, true)]  // Dentro do limite total -> true
    [InlineData(1000.00, 500.00, 1600.00, false)] // Excede saldo + limite -> false
    public void PodeRealizarSaque_DeveRetornarBooleanoEsperado(decimal saldo, decimal limiteChequeEspecial, decimal valorSaque, bool esperado)
    {
        // Act
        bool resultado = _contaCorrenteService.PodeRealizarSaque(saldo, limiteChequeEspecial, valorSaque);

        // Assert
        Assert.Equal(esperado, resultado);
    }
}