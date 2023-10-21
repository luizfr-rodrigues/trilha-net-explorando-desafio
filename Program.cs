using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

GeradorHospedes gerador = new GeradorHospedes(hospedes);
gerador.GerarHospedes(3);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 4, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 5);
reserva.CadastrarSuite(suite);

try
{
    reserva.CadastrarHospedes(gerador.Hospedes);

    // Exibe a quantidade de hóspedes e o valor da diária
    Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
    foreach (var p in hospedes)
    {
        Console.WriteLine($"\tNome: {p.NomeCompleto}");
    }

    Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria().ToString("R$ 0.00")}");    
}
catch (System.Exception e) 
{
    Console.WriteLine($"Não foi possível realizar a reserva. Erro: {e.Message}");
}
