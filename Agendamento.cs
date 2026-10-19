namespace BarbeariaAgenda;

public class Agendamento
{
    public int Id { get; set; }
    public Cliente Cliente { get; set; } = new Cliente();

    public string Servico { get; set; } = "";
    public DateTime DataHora { get; set; }

}