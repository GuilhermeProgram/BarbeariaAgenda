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
    Console.WriteLine("3. Editar Cliente");
    Console.WriteLine();
    Console.WriteLine("4. Excluir Cliente");
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
        case "3":
            EditarCliente();
            break;
        case "4":
            ExcluirCliente();
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
    int idade = LerInteiro("Idade: ");
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
        Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Idade: {cliente.Idade}, Telefone: {cliente.Telefone}, Cadastro: {cliente.DataCadastro:dd/MM/yyyy}");
    }
}

int LerInteiro(string mensagem)
{
    while (true)
    {
        Console.Write(mensagem);
        string texto = Console.ReadLine() ?? "";

        if (int.TryParse(texto, out int numero))
        {
            return numero;
        }
        Console.WriteLine("Valor inválido, digite um número.");
    }
}

Cliente? BuscarCliente(int id)
{
    foreach (var cliente in clientes)
    {
        if (cliente.Id == id)
        {
            return cliente;
        }
    }
    return null;
}

void EditarCliente()
{
    ListarClientes();
    int id = LerInteiro("Id do cliente para editar: ");
    Cliente? cliente = BuscarCliente(id);

    if (cliente == null)
    {
        Console.WriteLine("Cliente não encontrado.");
        return;
    }

    Console.Write("Novo nome: ");
    cliente.Nome = Console.ReadLine() ?? "";
    Console.Write("Novo telefone: ");
    cliente.Telefone = Console.ReadLine() ?? "";
    cliente.Idade = LerInteiro("Nova idade: ");
    Console.WriteLine("Cliente atualizado!");
}

void ExcluirCliente()
{
    ListarClientes();
    int id = LerInteiro("Id do cliente para excluir: ");
    Cliente? cliente = BuscarCliente(id);

    if (cliente == null)
    {
        Console.WriteLine("Cliente não encontrado.");
        return;
    }

    Console.Write($"Tem certeza que deseja excluir {cliente.Nome}? (s/n) ");
    string resposta = Console.ReadLine() ?? "";

    if (resposta.ToLower() == "s")
    {
        clientes.Remove(cliente);
        Console.WriteLine("Cliente excluído!");
    }
    else
    {
        Console.WriteLine("Exclusão cancelada.");
    }
}
