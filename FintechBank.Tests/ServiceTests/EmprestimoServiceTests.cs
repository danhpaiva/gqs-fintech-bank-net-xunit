using FintechBank.App.Services;

namespace FintechBank.Tests.ServiceTests;

public class EmprestimoServiceTests
{
    private readonly EmprestimoService _emprestimoService;

    public EmprestimoServiceTests()
    {
        _emprestimoService = new EmprestimoService();
    }

    [Theory]
    [InlineData(10000.00, 10, 800, 1050.00)] // Score alto: 5% de juros -> R$ 10.500 / 10 = R$ 1.050
    [InlineData(10000.00, 10, 600, 1120.00)] // Score médio: 12% de juros -> R$ 11.200 / 10 = R$ 1.120
    [InlineData(10000.00, 10, 400, 1200.00)] // Score baixo: 20% de juros -> R$ 12.000 / 10 = R$ 1.200
    public void CalcularValorParcela_DeveRetornarValorCorretoComJuros(decimal valorTotal, int parcelas, int scoreCredito, decimal valorParcelaEsperado)
    {
        // Act
        decimal resultado = _emprestimoService.CalcularValorParcela(valorTotal, parcelas, scoreCredito);

        // Assert
        Assert.Equal(valorParcelaEsperado, resultado);
    }

    [Theory]
    [InlineData(5000.00, 1500.00, true)]  // Parcela = 30% da renda -> Aprovado
    [InlineData(5000.00, 1600.00, false)] // Parcela > 30% da renda -> Recusado
    public void AprovarEmprestimo_DeveRetornarBooleanoEsperado(decimal rendaMensal, decimal valorParcela, bool esperado)
    {
        // Act
        bool resultado = _emprestimoService.AprovarEmprestimo(rendaMensal, valorParcela);

        // Assert
        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void CalcularValorParcela_DeveLancarArgumentException_QuandoParcelasMenorOuIgualAZero(int parcelasInvalidas)
    {
        // Arrange
        decimal valorTotal = 10000.00m;
        int scoreCredito = 700;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            _emprestimoService.CalcularValorParcela(valorTotal, parcelasInvalidas, scoreCredito)
        );

        Assert.Equal("O número de parcelas deve ser maior que zero. (Parameter 'parcelas')", exception.Message);
    }
}