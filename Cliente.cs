namespace BarbeariaAgenda;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public int Idade { get; set; }
    public string Telefone { get; set; } = "";
    public DateTime DataCadastro { get; set; } = DateTime.Now;

}