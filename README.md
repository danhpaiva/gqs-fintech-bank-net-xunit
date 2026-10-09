# FintechBank

## 📋 Visão Geral da Aplicação

O **FintechBank** é uma solução desenvolvida em C# que centraliza regras de negócio essenciais para o setor financeiro e bancário. O projeto foi estruturado em uma arquitetura limpa e modular, contendo um projeto principal de regras de negócio (`FintechBank.App`) e um projeto dedicado a testes unitários automatizados (`FintechBank.Tests`).

## ⚙️ Requisitos Técnicos

* **Plataforma:** .NET 10 SDK
* **Linguagem:** C# 13+
* **Framework de Testes:** xUnit

---

## 💼 Regras de Negócio Implementadas

### 1. ContaCorrenteService

Responsável pelas regras de gestão de contas correntes:

* **Cálculo de Taxa de Manutenção (`CalcularTaxaManutencao`):**
* Isento (`R$ 0,00`): Para saldos maiores ou iguais a `R$ 5.000,00` ou clientes especiais.
* `R$ 12,50`: Para saldos entre `R$ 1.000,00` e `R$ 4.999,99` (em clientes não especiais).
* `R$ 25,00`: Para saldos abaixo de `R$ 1.000,00` (em clientes não especiais).


* **Validação de Saque (`PodeRealizarSaque`):**
* Permite o saque apenas se o valor solicitado for menor ou igual à soma do saldo atual com o limite do cheque especial.



### 2. EmprestimoService

Responsável pelas regras de crédito e empréstimos:

* **Cálculo de Parcela com Juros por Score (`CalcularValorParcela`):**
* **Score $\ge$ 700:** Taxa de juros total de 5% sobre o valor.
* **Score entre 500 e 699:** Taxa de juros total de 12%.
* **Score < 500:** Taxa de juros total de 20%.
* Retorna o valor da parcela individual dividindo o montante com juros pelo número de parcelas.


* **Aprovação de Empréstimo por Margem Consignável (`AprovarEmprestimo`):**
* Aprova o empréstimo se o valor da parcela comprometer no máximo 30% da renda mensal informada.



---

## 🚀 Como Executar o Projeto

Siga os passos abaixo para clonar, compilar e testar a solução via terminal:

### 1. Clonar o Repositório

```bash
git clone <url-do-repositorio>
cd FintechBank

```

### 2. Compilar a Solução

```bash
dotnet build

```

### 3. Executar os Testes Unitários

Para validar todas as regras de negócio implementadas com 100% de cobertura dos testes unitários, execute:

```bash
dotnet test

```

---

## 🧪 Estrutura de Testes Unitários

A suíte de testes foi construída utilizando o framework **xUnit**, fazendo uso intensivo de **testes parametrizados** (`[Theory]` e `[InlineData]`). Essa abordagem permite testar múltiplos cenários e variações de entradas/saídas em um único método de teste, garantindo alta manutenibilidade e confiabilidade do código:

* **`ContaCorrenteServiceTests`**: Valida com diferentes conjuntos de dados (InlineData) o comportamento da taxa de manutenção para faixas de saldo e status de cliente especial, bem como os limites de aprovação de saque.
* **`EmprestimoServiceTests`**: Testa exaustivamente o impacto do score de crédito no cálculo das parcelas com juros e valida as regras de margem consignável (limite de 30% da renda) para a aprovação de empréstimos.