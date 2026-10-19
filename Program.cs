using BarbeariaAgenda;

List<Cliente> clientes = new List<Cliente>();

int proximoIdCliente = 1;

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== Barbearia Agenda ===");
    Console.WriteLine();
    Console.WriteLine("1. Cadastrar Cliente");
    Console.WriteLine();
    Console.WriteLine("2. Listar Clientes");
    Console.WriteLine();
    Console.WriteLine("0. Sair");
    Console.WriteLine();
    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine() ?? "";

    switch (opcao)
    {
        case "1":
            CadastrarCliente();
            break;
        case "2":
            ListarClientes();
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
} 
void CadastrarCliente()
{
    Console.WriteLine("=== Cadastro de Cliente ===");
    Console.Write("Nome: ");
    string nome = Console.ReadLine() ?? "";
    Console.Write("Idade: ");
    int idade = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Telefone: ");
    string telefone = Console.ReadLine() ?? "";

    Cliente cliente = new Cliente
    {
        Id = proximoIdCliente++,
        Nome = nome,
        Idade = idade,
        Telefone = telefone,
    };

    clientes.Add(cliente);
    Console.WriteLine("Cliente cadastrado com sucesso!");
}
void ListarClientes()

{
    if (clientes.Count == 0)
    {
        Console.WriteLine("Nenhum cliente cadastrado.");
        return;
    }
    Console.WriteLine("=== Lista de Clientes ===");
    foreach (var cliente in clientes)
    {
        Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Idade: {cliente.Idade}, Telefone: {cliente.Telefone}");
    }
}