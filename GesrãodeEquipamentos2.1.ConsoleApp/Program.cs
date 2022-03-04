﻿using System;

namespace GesrãodeEquipamentos2._1.ConsoleApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string[,] equipamentos = new string[5, 6];
            string[,] chamados = new string[5, 5];
            

            string opcao = "";
            while (opcao != "9")
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nControle de Equipamento 1.0\n");
                Console.WriteLine(" 1 - Cadastro de novo equipamento\n 2 - Inventario de equipamentos cadastrados\n" +
                    " 3 - Editar equipamentos\n 4 - Excluir equipamento\n 5 - Registrar chamado\n" +
                    " 6 - visualizar chamados\n 7 - editar chamados\n 8 - excluir chamados\n 9 - sair");
                opcao = Console.ReadLine();
                Console.Clear();

                switch (opcao)
                {

                    case "1":

                        CadastroEquipamento(equipamentos);

                        break;

                    case "2":
                        VisualizarEquipamentos(equipamentos);
                        break;

                    case "3":
                        EditarEquipamentos(equipamentos);
                        break;

                    case "4":
                       equipamentos = ExcluirEquipamentos(equipamentos, chamados);
                        break;

                    case "5":
                        RegistrarChamados(equipamentos, chamados);
                        break;

                    case "6":
                        VisualizarChamados(chamados);
                        break;

                    case "7":
                        EditarChamados(chamados);
                        break;

                    case "8":
                        ExcluirChamados(chamados);
                        break;
                }
            }

        }

        //Requisito 2.4: Como funcionário Junior quer ter a possibilidade de excluir um chamado.
        private static void ExcluirChamados(string[,] chamados)
        {
            {
                Console.WriteLine("Digite o id do chamado que deseja EDITAR:");
                int idExcluirOpção = Convert.ToInt32(Console.ReadLine());

                if (idExcluirOpção == Convert.ToInt32(chamados[idExcluirOpção, 0]))
                {
                    chamados[idExcluirOpção, 0] = null;
                    chamados[idExcluirOpção, 1] = null;
                    chamados[idExcluirOpção, 2] = null;
                    chamados[idExcluirOpção, 3] = null;
                    chamados[idExcluirOpção, 4] = null;

                }
                else
                {
                    Console.WriteLine("Este id é invalido!");
                }

            }
        }

            /*Requisito 2.3: Como funcionário Junior quer ter a possibilidade de editar um chamado que esteja
            registrado, sendo que ele possa editar todos os campos.
                • Deve ter os mesmos critérios que o Requisito 2.1

             • Deve ter a título do chamado; [0,1]
                • Deve ter a descrição do chamado; [0,2]
                • Deve ter um equipamento; xxxx
                • Deve ter uma data de abertura; [0,4]*/
            private static void EditarChamados(string[,] chamados)
        {
            Console.WriteLine("Digite o id do chamado que deseja EDITAR:");
            int idEditarOpcao = Convert.ToInt32(Console.ReadLine());

            if (idEditarOpcao == Convert.ToInt32(chamados[idEditarOpcao, 0]))
            {
                string opcaoEditar = "";
                while (opcaoEditar != "4")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n<Editar os chamados de ID: " + chamados[idEditarOpcao, 0] + " \nDigite a opção que deseja editar:");
                    Console.WriteLine(" 1 - Titulo do chamado \n 2 - Descrição do chamado " +
                        "\n 3 - Data da Abertura \n 4 - Sair");
                    opcaoEditar = Console.ReadLine();
                    Console.Clear();

                    switch (opcaoEditar)
                    {

                        case "1":

                            Console.WriteLine("Titulo do chamado:");
                            chamados[idEditarOpcao, 1] = Console.ReadLine();

                            break;

                        case "2":
                            Console.WriteLine("Descrição do chamado:");
                            chamados[idEditarOpcao, 2] = Console.ReadLine();
                            break;

                        case "3":
                            Console.WriteLine("Data da Abertura:");
                            chamados[idEditarOpcao, 4] = Console.ReadLine();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Este id é invalido!");
            }

        }





        /*
        Requisito 2.2: Como funcionário Junior quer ter a possibilidade de visualizar todos os chamados
        registrados para controle.
            • Deve mostrar o título do chamado;
            • Deve mostrar o equipamento;
            • Deve mostrar a data de abertura;
            • Número de dias que o chamado está aberto*/
        private static void VisualizarChamados(string[,] chamados)
        {
            Console.WriteLine("<Chamados Cadastrados>\nDigite o id referente ao chamado que deseja visualizar ou 'T' se deseja visulizar todos os CHAMADOS:");
            string opcaoVisualizar = Console.ReadLine();
            if (opcaoVisualizar == "T" || opcaoVisualizar == "t")
            {

                for (int i = 0; i < chamados.Length; i++)
                {

                    if (chamados[i, 0] != null)
                    {
                        DateTime dataAbertura = Convert.ToDateTime(chamados[i, 4]);
                        TimeSpan tempoChamada = DateTime.Today - dataAbertura;
                        double dias = tempoChamada.TotalDays;
                        Console.WriteLine("Titulo: " + chamados[i, 1] + "\n Equipamento: " + chamados[i, 3] +
                            "\nDescrição: " + chamados[0, 2] + "\nData de Abertura: " + dataAbertura + "\nDias de chamado em Aberto: " + dias);
                        Console.WriteLine();

                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            else
            {
                Console.WriteLine("Não existe nenhum equipamento com esta ID.");
            }
            Console.ReadLine();
        }


        /*Requisito 2.1: Como funcionário Junior quer ter a possibilidade de registrar os chamados de
          manutenções que são efetuadas nos equipamentos registrados
            • Deve ter a título do chamado; 
            • Deve ter a descrição do chamado; 
            • Deve ter um equipamento; 
            • Deve ter uma data de abertura; */
        private static void RegistrarChamados(string[,] equipamentos, string[,] chamados)
        {
            Console.WriteLine("Digite o ID do equipamento que pretende registrar um CHAMADO:");
            int idEquipamentoChamado = Convert.ToInt32(Console.ReadLine());
            if (idEquipamentoChamado == Convert.ToInt32(equipamentos[idEquipamentoChamado, 0]))
            {
                //Aqui já estou linkando o ID do equipamento ao chamado, pela matriz de equipametos
                chamados[idEquipamentoChamado, 0] = equipamentos[idEquipamentoChamado, 0];
                Console.WriteLine("Digite o Titulo da Chamada:");
                chamados[idEquipamentoChamado, 1] = Console.ReadLine();
                Console.WriteLine("Digite a descrição do chamado:");
                chamados[idEquipamentoChamado, 2] = Console.ReadLine();
                //Aqui ja estou linkando o NOME do equipamento ao chamado, pela matriz de equipamentos
                chamados[idEquipamentoChamado, 3] = equipamentos[idEquipamentoChamado, 1];
                Console.WriteLine("Digite a data da abertura:");
                chamados[idEquipamentoChamado, 4] = Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Chamado registrado com SUCESSO!!!");
                Console.ReadLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Este id é invalido!!!");
            }
        }
        //**Requisito 1.4: Como funcionário, Junior quer ter a possibilidade de excluir um equipamento que esteja
        /*registrado.
            • A lista de equipamentos deve ser atualizada
            • Caso o equipamento esteja vinculado num chamado, não deve permitir a exclusão deste equipamento.*/

        private static string[,] ExcluirEquipamentos(string[,] equipamentos, string[,] chamados)
        {
            Console.WriteLine("Digite o id do equipamento que deseja EXCLUIR:");
            int idExcluirOpcao = Convert.ToInt32(Console.ReadLine());

            if (Convert.ToString(idExcluirOpcao) == chamados[idExcluirOpcao, 0])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Este equipamento, tem um CHAMADO em aberto, favor, finalize o chamado!!!");
            }
            else if (idExcluirOpcao == Convert.ToInt32(equipamentos[idExcluirOpcao, 0]))
            {
                
                string[,] equipamentosCadastrados = new string[5, 6];
                string[,] chamadosCadastrados = new string[5, 5];
                for (int i = 0; i < idExcluirOpcao; i++)
                {
                    equipamentosCadastrados[i, 0] = equipamentos[i, 0];
                    equipamentosCadastrados[i, 1] = equipamentos[i, 1];
                    equipamentosCadastrados[i, 2] = equipamentos[i, 2];
                    equipamentosCadastrados[i, 3] = equipamentos[i, 3];
                    equipamentosCadastrados[i, 4] = equipamentos[i, 4];
                    equipamentosCadastrados[i, 5] = equipamentos[i, 5];
                }
                int j = idExcluirOpcao;
                int k = idExcluirOpcao + 1;

                do
                {
                    
                        if(equipamentos[k,0] != null)
                        {
                            int idEquipamentos = Convert.ToInt32(equipamentos[k, 0]);
                            equipamentosCadastrados[j, 0] = Convert.ToString(idEquipamentos - 1);
                        }
                        else
                        {
                            equipamentosCadastrados[j, 0] = equipamentos[k, 0];
                        }
                        
                        equipamentosCadastrados[j, 1] = equipamentos[k, 1];
                        equipamentosCadastrados[j, 2] = equipamentos[k, 2];
                        equipamentosCadastrados[j, 3] = equipamentos[k, 3];
                        equipamentosCadastrados[j, 4] = equipamentos[k, 4];
                        equipamentosCadastrados[j, 5] = equipamentos[k, 5];

                        k++;
                        j++;

                    
                } while (equipamentos[j, 0] != null);
                int l = -1;
                int m = -1;
                do
                {
                    l++;
                    if (idExcluirOpcao == Convert.ToInt32(equipamentosCadastrados[l, 0]))
                    {
                        continue;
                    }
                    else
                    {
                        m++;
                        if (chamados[l, 0] != null)
                        {
                            int iDChamados = Convert.ToInt32(chamados[l, 0]);
                            chamadosCadastrados[m, 0] = Convert.ToString(iDChamados - 1);

                        }
                        chamadosCadastrados[m, 1] = chamados[l, 1];
                        chamadosCadastrados[m, 2] = chamados[l, 2];
                        chamadosCadastrados[m, 3] = chamados[l, 3];
                        chamadosCadastrados[m, 4] = chamados[l, 4];

                        chamados[l, 0] = null;
                        chamados[l, 1] = null;
                        chamados[l, 2] = null;
                        chamados[l, 3] = null;
                        chamados[l, 4] = null;

                    }
                }while(equipamentos[l,0] != null);
                
                for (int i = 0; i < k; i++)
                {
                    chamados[i, 0] = chamadosCadastrados[i, 0];
                    chamados[i, 1] = chamadosCadastrados[i, 1];
                    chamados[i, 2] = chamadosCadastrados[i, 2];
                    chamados[i, 3] = chamadosCadastrados[i, 3];
                    chamados[i, 4] = chamadosCadastrados[i, 4];
                    
                }
                
                return equipamentosCadastrados;
            }
            
            else if (idExcluirOpcao != Convert.ToInt32(equipamentos[idExcluirOpcao, 0]))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não existe nenhum equipamento com esta ID.");
            }
            return equipamentos;
        }
        //**Requisito 1.3: Como funcionário, Junior quer ter a possibilidade de editar um equipamento, sendo
        /*que ele possa editar todos os campos.
         • Deve ter os mesmos critérios que o Requisito 1.1*/
        private static void EditarEquipamentos(string[,] equipamentos)
        {
            Console.WriteLine("Digite o id do equipamento que deseja EDITAR:");
            int idEditarOpcao = Convert.ToInt32(Console.ReadLine());

            if (idEditarOpcao == Convert.ToInt32(equipamentos[idEditarOpcao, 0]))
            {
                string opcaoEditar = "";
                while (opcaoEditar != "6")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n<Editar o equipamento de ID: " + equipamentos[0, 0] + " \nDigite a opção que deseja editar:");
                    Console.WriteLine(" 1- Nome do equipamento\n 2- Valor do equipamento" +
                        "\n 3- Numero de série\n 4- Data de fabricação\n 5-Fabricante\n " +
                        " 6- Sair da edição");
                    opcaoEditar = Console.ReadLine();
                    Console.Clear();

                    switch (opcaoEditar)
                    {

                        case "1":

                            Console.WriteLine("Nome do equipamento:");
                            equipamentos[idEditarOpcao, 1] = Console.ReadLine();

                            break;

                        case "2":
                            Console.WriteLine("Valor do equipamento:");
                            equipamentos[idEditarOpcao, 2] = Console.ReadLine();
                            break;

                        case "3":
                            Console.WriteLine("Numero de série:");
                            equipamentos[idEditarOpcao, 3] = Console.ReadLine();
                            break;

                        case "4":
                            Console.WriteLine("Data de Fabricação:");
                            equipamentos[idEditarOpcao, 4] = Console.ReadLine();
                            break;

                        case "5":
                            Console.WriteLine("Fabricante:");
                            equipamentos[idEditarOpcao, 5] = Console.ReadLine();
                            break;


                    }
                }
            }
            else
            {
                Console.WriteLine("Este id é invalido!");
            }
        }

        //**Requisito 1.2: Como funcionário, Junior quer ter a possibilidade de visualizar todos os equipamentos
        /*registrados em seu inventário.
          • Deve mostrar o nome;
          • Deve mostrar o número de série;
          • Deve mostrar a fabricante;*/
        private static void VisualizarEquipamentos(string[,] equipamentos)
        {

            Console.WriteLine("<Inventario de equipamentos cadastrados>\nDigite 'T' para visualizar todos os equipamentos cadastrados ou apenas o id do equipamento que deseja visualizar:");
            string opcaoVisualizar = Console.ReadLine();
            if (opcaoVisualizar == "T" || opcaoVisualizar == "t")
            {
                for (int i = 0; i < equipamentos.Length; i++)
                {
                    if (equipamentos[i, 0] != null)
                    {
                        Console.WriteLine("id: " + equipamentos[i, 0] + "\n     Nome: " + equipamentos[i, 1] + "\n     Número de Série: " + equipamentos[i, 3] + "\n      Fabricante: " + equipamentos[i, 5]);
                        Console.WriteLine();

                    }
                    else
                    {
                        break;
                    }
                }
                Console.ReadLine();
            }
            else
            {
                for (int i = 0; i < equipamentos.Length; i++)
                {
                    if (opcaoVisualizar == equipamentos[i, 0])
                    {
                        Console.WriteLine("id: " + equipamentos[i, 0] + "\n     Nome: " + equipamentos[i, 1] + "\n     Número de Série: " + equipamentos[i, 3] + "\n      Fabricante: " + equipamentos[0, 5]);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("não existe equipamento cadastrado com esse ID!");
                        break;
                    }
                }
                Console.ReadLine();
            }
        }

        //**Requisito 1.1: Como funcionário, Junior quer ter a possibilidade de registrar equipamentos
        /*• Deve ter um nome com no mínimo 6 caracteres;
          • Deve ter um preço de aquisição;
          • Deve ter um número de série;
          • Deve ter uma data de fabricação;
          • Deve ter uma fabricante;*/
        private static void CadastroEquipamento(string[,] equipamentos)
        {
            for (int i = 0; i < equipamentos.Length; i++)
            {

                if (equipamentos[i, i] == null)
                {

                    equipamentos[i, 0] = Convert.ToString(i);


                    Console.WriteLine("<Cadastro de equipamento>");
                    Console.WriteLine("Nome do equipamento:");
                    equipamentos[i, 1] = Console.ReadLine();

                    Console.WriteLine("Valor do equipamento:");
                    equipamentos[i, 2] = Console.ReadLine();

                    Console.WriteLine("Numero de série:");
                    equipamentos[i, 3] = Console.ReadLine();

                    Console.WriteLine("Data de fabricação:");
                    equipamentos[i, 4] = Console.ReadLine();

                    Console.WriteLine("Fabricante:");
                    equipamentos[i, 5] = Console.ReadLine();


                    Console.Clear();
                    break;
                }
                else
                    continue;
                }
                


            
        }
    
    }

}

