using System;

namespace VendingMachinebyLubLaby
{
    class Program
    {
        static void Main(string[] args) //Método Principal de execução
        {
            AbrirLayout();
        }
        public static void AbrirLayout() // Menu Principal
        {
            User usuario1 = new User(2.25); // Criando o usuario e os Produtos existentes
            Produto CocaCola = new Produto("Coca-Cola", 15, 2.25);
            Produto FantaUva = new Produto("Fanta Uva", 10, 2.25);
            Produto Guarana = new Produto("Guaraná", 15, 1.85);
            for (int MenuPrincipal = 1; MenuPrincipal >= 1;) //Looping do Menu Principal
            {
                Console.Write($"._______________________________________________.\n" +
                    $"\n\tVending Machine - ASP.NET Luby\n" +
                    $"._______________________________________________.\n" +
                    $"|\t\t\t\t\t\t|\n" +
                    $"| [1] Comprar bebida \t\t\t\t|\n" +
                    $"| [2] Inserir valor \t\t\t\t|\n" +
                    $"| [3] Contabilidade de vendas \t\t\t|\n" +
                    $"|\t\t\t\t\t\t|\n" +
                    $"| [0] Sair do programa \t\t\t\t|\n" +
                    $"|\t\t\t\t\t\t|\n" +
                    $"\tSaldo: R$ {usuario1.carteira}\n" +
                    $"|_______________________________________________|\n\n" +
                    $" > Comando: ");

                int inputKeyUser = Int32.Parse(Console.ReadLine());
                if (inputKeyUser <= 3)
                {
                    switch (inputKeyUser) //Decisão após digitar 
                    {
                        case 1: // [1] Comprar Bebidas
                            for (int Menu = 1; Menu >= 1;)
                            {
                                Console.Clear();
                                Console.Write($"._______________________________________________________.\n" +
                                $"\n\t      Vending Machine - ASP.NET Luby\n" +
                                $"._______________________________________________________.\n" +
                                $"|\t\t\t\t\t\t\t|\n" +
                                $"| \tQuais desses produtos você deseja comprar? \t|\n" +
                                $"|_______________________________________________________|\n" +
                                $"| Produto\t\tEstoque\t\tPreço/Unid.\t|\n" +
                                $"|\t\t\t\t\t\t\t|\n" +
                                $"| [1] {CocaCola.nome}\t\t  {CocaCola.qtdDisp}\t\tR$ {CocaCola.valor}\t\t|\n" +
                                $"| [2] {FantaUva.nome}\t\t  {FantaUva.qtdDisp}\t\tR$ {FantaUva.valor}\t\t|\n" +
                                $"| [3] {Guarana.nome}\t\t  {Guarana.qtdDisp}\t\tR$ {Guarana.valor}\t\t|\n" +
                                $"|\t\t\t\t\t\t\t|\n" +
                                $"| [0] Cancelar \t\t\t\t\t\t|\n" +
                                $"|\t\t\t\t\t\t\t|\n" +
                                $"\tSaldo: R$ {usuario1.carteira}\n" +
                                $"|_______________________________________________________|\n" +
                                $" > Comando: ");
                                inputKeyUser = Int32.Parse(Console.ReadLine());
                                switch (inputKeyUser)//SubMenu de [1] Comprar Bebida
                                {
                                    case 1:
                                        usuario1.Comprar(CocaCola);
                                        break;
                                    case 2:
                                        usuario1.Comprar(FantaUva);
                                        break;
                                    case 3:
                                        usuario1.Comprar(Guarana);
                                        break;
                                    case 0:
                                        Console.Clear();
                                        break;
                                    default:
                                        verificarOpcoes();
                                        break;
                                }
                                Menu = 0; // Fechar Menu de Compra de Bebidas
                            }
                            break; //Fim [1] Comprar Bebidas
                        case 2:
                            usuario1.InserirSaldo();
                            break;
                        case 3:
                                Console.Clear();
                                Console.Write($"._______________________________________________.\n" +
                                $"\n\tVending Machine - ASP.NET Luby\n" +
                                $"._______________________________________________.\n" +
                                $"|\t\t\t\t\t\t|\n" +
                                $"| Quantidade de vendas realizadas: {usuario1.QtdVendas} \t\t|\n" +
                                $"|_______________________________________________|\n" +
                                $"|\t\t\t\t\t\t|\n" +
                                $"| Quantidade recebida: R$ {usuario1.ValorTotalVendas}\t\t\t|\n" +
                                $"|_______________________________________________|\n" +
                                $"|\t\t\t\t\t\t|\n" +
                                $"| [1] Visualizar Log de Vendas\t\t\t|\n" +
                                $"|\t\t\t\t\t\t|\n" +
                                $"| [0] Voltar ao Menu Principal\t\t\t|\n" +
                                $"|_______________________________________________|\n\n" +
                                $" > Comando: ");
                            inputKeyUser = Int32.Parse(Console.ReadLine());
                                switch (inputKeyUser)
                                {
                                    case 1:
                                    Console.Clear();
                                        Console.Write($"\n{usuario1.QtdVendasLog}");
                                        Console.Write($"|----------------------------------------------------" +
                                            $"\n| Total recebido:_________________________R$ {usuario1.ValorTotalVendas}\n" +
                                            $"| Total de Vendas:___________________________{usuario1.QtdVendas}\n" +
                                            $"|\n| Fim do Log.\n\n[Pressione qualquer tecla para voltar ao Menu Principal]");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    default:
                                    Console.Clear();
                                        break;
                                }
                            break;
                        case 0:
                            FinalizarPrograma(); // Line 298
                            break;
                        default:
                            verificarOpcoes();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n[Atenção] Opção indisponível no momento,\nverifique novamente as opções.\n ");
                }

            }
        }
        public static int FecharJanela()
        {
            Console.Write("Deseja realizar a mesma operação?\n" +
                "[1] Sim  -  [2] Não" +
                "\nResposta: ");
            
            int InputKeyN = Int32.Parse(Console.ReadLine());
            if (InputKeyN == 1) //Sim , o MENU passará a ter 1 como valor, e irá retornar a mesma tarefa
            {
                Console.Clear();
                return 1;
            }
            else //Não, o MENU irá fechar, e irá até o Menu Principal
            {
                Console.Clear();
                return 0;
            }
        }
        public static void FinalizarPrograma()
        {
            //0 - Para desligar a confirmação do programa | 1 - Para permanecer a confirmação de saída do programa.
            int ConfirmacaoFechar = 1;
            Console.Clear();
            if (ConfirmacaoFechar >= 1)
            {
                for (int menu = 1; menu > 0;) //Looping de Menu básico
                {
                    Console.Write("[Atenção] Você tem certeza que quer finalizar o programa?\n" +
                        "[1] Sim  -  [2] Não" +
                        "\nResposta: ");
                    int confirmacao = Int32.Parse(Console.ReadLine());
                    if (confirmacao == 1)
                    {
                        Environment.Exit(0);
                    }
                    else if (confirmacao == 2)
                    {
                        Console.Clear();
                        menu--;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("[Programa] Resposta incorreta, verifique as opções disponíveis novamente\n");

                    }
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }
        public static void verificarOpcoes()
        {
            Console.Clear();
            Console.WriteLine("[Alerta] Verifique novamente as opções disponíveis.");
        }
        class Produto 
        {
            private String Nome;
            private int QtdDisp;
            private double Valor;

            public Produto(String Nome, int QtdDisp, double Valor)
            {
                this.Nome = Nome;
                this.QtdDisp = QtdDisp;
                this.Valor = Valor;
            }
            public String nome
            {
                get { return this.Nome; }
                set { nome = value; }
            }
            public int qtdDisp
            {
                get { return this.QtdDisp; }
                set { QtdDisp = value; }
            }
            public double valor
            {
                get { return this.Valor; }
                set { Valor = value; }
            }
        }
        class User
        {
            private double Carteira;
            public String QtdVendasLog = "| Log de Vendas \n| Numero da Venda\tItem Vendido\tPreço vendido\n" +
                "|----------------------------------------------------\n";
            public double ValorTotalVendas = 0;
            public int QtdVendas;

            public User(double QtdInicial)
            {
                this.Carteira = QtdInicial;
            }
            public double carteira
            {
                get { return Math.Round(this.Carteira, 2); }
                set { this.Carteira = value; }
            }
            public string qtdVendasLog
            {
                get { return QtdVendasLog; }
                set { this.QtdVendasLog = value; }
            }
            public void AdicionarLog(String NovoLog)
            {
                this.QtdVendasLog += ($"\n{NovoLog}");
            }
            public Double valorTotalVendas
            {
                get { return ValorTotalVendas; }
                set { this.ValorTotalVendas = value; }
            }
            public int qtdVendas
            {
                get { return QtdVendas; }
                set { this.QtdVendas = value; }
            }
            public Boolean PossuiSaldo(double valorTotalCompra)
            {

                if (this.Carteira >= valorTotalCompra) 
                {
                    return true;
                } 
                else {
                    return false;
                    }
                }
                
            public void Comprar(Produto produtoVendido)
            {
                String InputKeyUser = "";
                if (produtoVendido.qtdDisp > 0)//Se existe a bebida no Estoque
                {
                    for (int Menu = 1; Menu >= 1;)
                    {
                        Console.Clear();
                        Console.Write($"._______________________________________________.\n" +
                         $"\n\tVending Machine - ASP.NET Luby\n" +
                         $"._______________________________________________.\n|\n" +
                         $"| Quantas você deseja comprar? \t\t\t|\n" +
                         $"| Estoque de {produtoVendido.nome}: {produtoVendido.qtdDisp}\t\t\t|\n" +
                         $"|_______________________________________________|\n\n" +
                         $" > Comando: ");
                        int QtdVendido = Int32.Parse(Console.ReadLine());
                        double valorTotalCompra = produtoVendido.valor * QtdVendido;

                        //Quantidade pedida > Estoque
                        if (QtdVendido > produtoVendido.qtdDisp) // Verificar se é mais do que no estoque
                        {
                            for (int Menu1 = 1; Menu1 >= 1;)//Menu Quantidade pedida > Estoque
                            {
                                Console.Clear();
                                Console.Write($"._______________________________________________.\n" +
                                $"\n\tVending Machine - ASP.NET Luby\n" +
                                $"._______________________________________________.\n" +
                                $"| Infelizmente não temos {QtdVendido} {produtoVendido.nome}\n" +
                                $"| em estoque no momento. \t\n|\n" +
                                $"| [1] Cancelar compra\t\t\t\n" +
                                $"| [2] Levar apenas {produtoVendido.qtdDisp} - R$ {produtoVendido.valor * produtoVendido.qtdDisp}\n" +
                                $"| _______________________________________________ \n" +
                                $" > Comando: ");
                                InputKeyUser = Console.ReadLine();
                                switch (InputKeyUser)
                                {
                                    case "1":
                                        Console.Clear();
                                        Menu = 0; //Fechar Menu de Compra
                                        Menu1 = 0;
                                        break;
                                    case "2":
                                        valorTotalCompra = produtoVendido.valor * produtoVendido.qtdDisp; // Novo Valor da Compra
                                        for (int Menu2 = 1; Menu2 >= 1;)
                                        {
                                            if (PossuiSaldo(valorTotalCompra))//Se ele possui Saldo para essa compra
                                            {
                                                valorTotalCompra = produtoVendido.valor * produtoVendido.qtdDisp; //Novo Valor da compra

                                                Console.Clear();
                                                Console.Write($"._______________________________________________.\n" +
                                                $"\n\tVending Machine - ASP.NET Luby\n" +
                                                $"._______________________________________________.\n" +
                                                $"| Confirma a compra de {produtoVendido.qtdDisp} {produtoVendido.nome}?\n" +
                                                $"| Total: R$ {valorTotalCompra}.\n" +
                                                $"|\n" +
                                                $"| [1] Sim  | [2] Não, cancelar compra.\n" +
                                                $"|\n" +
                                                $" > Comando: ");
                                                InputKeyUser = Console.ReadLine();
                                                switch (InputKeyUser)
                                                {
                                                    case "1":
                                                        QtdVendido = produtoVendido.qtdDisp;
                                                        valorTotalCompra = produtoVendido.qtdDisp * produtoVendido.valor;
                                                        produtoVendido.qtdDisp = 0;
                                                        Console.Clear();
                                                        Console.Write($"._______________________________________________.\n" +
                                                        $"\n\tVending Machine - ASP.NET Luby\n" +
                                                        $"._______________________________________________.\n" +
                                                        $"| Compra feita com sucesso!\n" +
                                                        $"|_______________________________________________.\n");
                                                        //Adicionando ao sistema as compras
                                                        qtdVendas++; //Contagem de vendas
                                                        qtdVendasLog += ($"| \t{QtdVendas}\t\t{QtdVendido} {produtoVendido.nome}\t  R$ {valorTotalCompra} \n"); // Log da venda
                                                        ValorTotalVendas += valorTotalCompra; // Adicionado valor total da venda 
                                                        Menu2 = 0;
                                                        Menu1 = 0;
                                                        Menu = 0;
                                                        Troco(valorTotalCompra); //Para ver se houve troco
                                                        break;
                                                    case "2":
                                                        Console.Clear();
                                                        Menu2 = 0;
                                                        Menu1 = 0;
                                                        Menu = 0;//Fechar Menu de Compra
                                                        break;
                                                    default:
                                                        verificarOpcoes();
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                double NovoSaldo = SaldoInsuficiente(valorTotalCompra);
                                                Console.Clear();
                                            }
                                        }
                                        break;
                                    default:
                                        verificarOpcoes();
                                        break;
                                }
                                Menu = 0; //Fechando Menu de compra
                            }//Fim Menu Quantidade pedida > Estoque
                        }
                        // Quantidade pedida está no estoque
                        else if (QtdVendido <= produtoVendido.qtdDisp) // Quantidade pedida menor ou igual a que tem no estoque
                        {
                            for (int Menu1 = 1; Menu1 >= 1;)
                            {
                                if (PossuiSaldo(valorTotalCompra)) //Se ele possui saldo
                                {
                                    Console.Clear();
                                    Console.Write($"._______________________________________________.\n" +
                                    $"\n\tVending Machine - ASP.NET Luby\n" +
                                    $"._______________________________________________.\n" +
                                    $"| Confirma a compra de {QtdVendido} {produtoVendido.nome}?\n" +
                                    $"| Total: R$ {valorTotalCompra}.\n" +
                                    $"|\n" +
                                    $"| [1] Sim  | [2] Não, cancelar compra.\n" +
                                    $"|\n" +
                                    $" > Comando: ");
                                    InputKeyUser = Console.ReadLine();
                                    switch (InputKeyUser)
                                    {
                                        case "1":
                                            produtoVendido.qtdDisp -= QtdVendido;
                                            Console.Clear();
                                            Console.Write($"._______________________________________________.\n" +
                                            $"\n\tVending Machine - ASP.NET Luby\n" +
                                            $"._______________________________________________.\n" +
                                            $"|\t\t\t\t\t\t|\n" +
                                            $"| \t    Compra feita com sucesso!    \t|\n" +
                                            $"|_______________________________________________|\n");
                                            //Adicionando ao sistema as compras
                                            qtdVendas++; //Contagem de vendas
                                            qtdVendasLog += ($"| \t{QtdVendas}\t\t{QtdVendido} {produtoVendido.nome}\t  R$ {valorTotalCompra} \n"); // Log da venda
                                            ValorTotalVendas += valorTotalCompra; // Adicionado valor da compra no total das vendas
                                            Menu1 = 0;
                                            Menu = 0;
                                            Troco(valorTotalCompra); //Para ver se houve troco
                                            break;
                                        case "2":
                                            Console.Clear();
                                            Menu1 = 0;
                                            Menu = 0;
                                            break;
                                        default:
                                            verificarOpcoes();
                                            break;
                                    }
                                }
                                else // Se não houver Saldo, terá opção inserir saldo ou cancelar compra
                                {
                                    double NovoSaldo = SaldoInsuficiente(valorTotalCompra);
                                    Console.Clear();
                                }
                            }


                        }
                        //Quantidade pedida não está no estoque
                        else
                        {
                            Console.Write($"._______________________________________________.\n" +
                                $"\n\tVending Machine - ASP.NET Luby\n" +
                                $"._______________________________________________.\n" +
                                $"| Infelizmente não temos {produtoVendido.nome} em estoque no momento. \t|\n" +
                                $"| [1] Realizar outra compra\t\t\t|\n");
                            InputKeyUser = Console.ReadLine();
                            switch (InputKeyUser)
                            {
                                case "1":
                                    Menu = 0;
                                    break;
                                default:
                                    verificarOpcoes();
                                    break;
                            }
                        }
                    }//Fim do Menu
                }
                else
                {
                    Console.Clear();
                    Console.Write($"._______________________________________________.\n" +
                     $"\n\tVending Machine - ASP.NET Luby\n" +
                     $"._______________________________________________.\n|\n" +
                     $"| Não temos estoque de {produtoVendido.nome}.\n" +
                     $"|\n" +
                     $"| [Pressione qualquer tecla para voltar ao Menu]");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
            public void Troco(double valorTotalCompra)
            {
                if (Carteira>= valorTotalCompra)
                {
                    Carteira -= valorTotalCompra;
                    Console.WriteLine($"|\n| Seu troco: R$ {Math.Round(Carteira, 2)}\n\n" +
                        $"[Pressione qualquer tecla para continuar]");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Carteira = 0;
                }
            }
            public double SaldoInsuficiente(double valorTotalCompra)
            {
                for (int Menu = 1; Menu >= 1;)//Saldo insuficiente
                {
                    String InputKeyUser;
                    Console.Clear();
                    Console.Write($"._______________________________________________.\n" +
                    $"\n\tVending Machine - ASP.NET Luby\n" +
                    $"._______________________________________________.\n" +
                    $"| Seu saldo é insuficiente para completar a compra. \t|\n" +
                    $"| Será necessário mais R$ {valorTotalCompra - Math.Round(this.Carteira,2)}\n" +
                    $"|\n" +
                    $"| Deseja Adicionar mais saldo?\n" +
                    $"| [1] Sim   |  [2] Não, cancelar compra.\n" +
                    $"|\n| > Comando: ");
                    InputKeyUser = Console.ReadLine();
                    switch (InputKeyUser)
                    {
                        case "1":
                            InserirSaldo();
                            if (this.Carteira >= valorTotalCompra)//verificando se o saldo que ele colocou é suficiente
                            {
                                Menu = 0;
                            }
                            break;
                        default:
                            Menu = 0;//fechar todas as operações e voltar ao Menu inicial
                            break;
                    }
                }
                return Carteira;
            }
            public double InserirSaldo()
            {
                for (int Menu2 = 1; Menu2 >= 1;) //Looping do Menu Principal
                {
                    Console.Clear();
                    Console.Write($"._______________________________________________.\n" +
                    $"\n\tVending Machine - ASP.NET Luby\n" +
                    $"._______________________________________________.\n|\n" +
                    $"| Quanto você deseja inserir? Ex.: 12,75 \n| R$ ");
                    String ValorTexto = Console.ReadLine();
                    if (double.Parse(ValorTexto) > 0)
                    {
                        Carteira += double.Parse(ValorTexto);
                        Console.Clear();
                        Console.WriteLine($"[Lub] Seu novo saldo: R${Math.Round(Carteira, 2)}\n\n");
                        Menu2 = FecharJanela();
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write($"\t\t[Atenção] Insira um valor a cima de R$ 0.0 !\n");
                        Console.Write($"._______________________________________________.\n" +
                        $"\n\tVending Machine - ASP.NET Luby\n" +
                        $"._______________________________________________.\n|\n" +
                        $"| Quanto você deseja inserir?\n| R$ ");
                        String ValorTexto2 = Console.ReadLine();
                    }

                }
                return Carteira;
            }
        }
        
    }
}   

