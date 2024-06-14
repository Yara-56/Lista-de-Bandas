﻿// Screen Sound
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound da Yara!";
//List<string> listaDasBandas = new List<string> { "U2", "The Beatles", "Calypso" };

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Link Park", new List<int> {10, 8, 6});
bandasRegistradas.Add("Beatles", new List<int>());
void ExibirLogo()
{
    Console.WriteLine(@"

██╗░░░██╗░█████╗░██████╗░░█████╗░██╗░██████╗  ██████╗░██╗░░░░░░█████╗░██╗░░░██╗
╚██╗░██╔╝██╔══██╗██╔══██╗██╔══██╗╚█║██╔════╝  ██╔══██╗██║░░░░░██╔══██╗╚██╗░██╔╝
░╚████╔╝░███████║██████╔╝███████║░╚╝╚█████╗░  ██████╔╝██║░░░░░███████║░╚████╔╝░
░░╚██╔╝░░██╔══██║██╔══██╗██╔══██║░░░░╚═══██╗  ██╔═══╝░██║░░░░░██╔══██║░░╚██╔╝░░
░░░██║░░░██║░░██║██║░░██║██║░░██║░░░██████╔╝  ██║░░░░░███████╗██║░░██║░░░██║░░░
░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═════╝░  ╚═╝░░░░░╚══════╝╚═╝░░╚═╝░░░╚═╝░░░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para resgistrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a media de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.WriteLine("\nDigite a sua opcao: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: ExibirMedia();
            break;
        case -1: Console.WriteLine("Tchau");
            break;
        default: Console.WriteLine("Opcao invalida");
            break;

    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das bandas");
    Console.WriteLine("Digite o nome da banda que deseja registrar");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Todas as bandas registradas");

    //for (int i = 0; i < listaDasBandas.Count; i++)
    //{
      //  Console.WriteLine($"Banda:  {listaDasBandas[i]} ");
    //}

    foreach (string banda in bandasRegistradas.Keys)
    {

        Console.WriteLine($"Banda:  { banda}");
    }

    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu(); 
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    //digite qual banda deseja avaliar
    // se a banda existir no dicionario > atribuir uma nota
    // senao, volta ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite qual banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso!");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();

    } else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} nao foi encontrada!");
        Console.WriteLine("Digite alguma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void ExibirMedia()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir media da banda");
    Console.Write("Digite o nome da banda que deseja exibir a media: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandasRegistradas [nomeDaBanda];
        Console.WriteLine($"A media da banda {nomeDaBanda} e {notasDaBanda.Average()}.");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} nao foi encontrada ");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal ");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();

    }
}

ExibirOpcoesDoMenu();