using System;

namespace Aplication_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            //Declaraçao de variaveis
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")//trata a entrada pra deixar sempre em caixa alta
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();//instacia objeto aluno
                        aluno.Nome = Console.ReadLine();//seta o nome que o usuario colocar no console

                        Console.WriteLine("Informe a nota do aluno: ");
                        //aluno.Nota = Console.ReadLine();//nota eh decimal e readline retorna string, precisando converter o valor lido
                        
                        /* var nota = decimal.Parse(Console.ReadLine());//var eh inferencia de tipo, o que tiver atribuindo a variavel o var jah pega seu tipo
                        aluno.Nota = nota;//problema, se nao conseguir converter, vai dar erro */
                       
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {   //no if, se ele conseguir converter a entrada, ja a atribui para nota
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;


                    case "2":

                        foreach(var a in alunos)
                        {
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                                //se a.nome nao for vazio, eh listado na tela
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            }
                            
                        }
                        break;


                    case "3":

                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for(int i=0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal/nrAlunos;
                        ConceitoEnum conceitoGeral;

                        if(mediaGeral < 2)
                        {
                            conceitoGeral = ConceitoEnum.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = ConceitoEnum.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = ConceitoEnum.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = ConceitoEnum.B;
                        }

                        else 
                        {
                            conceitoGeral = ConceitoEnum.A;
                        }
                        Console.WriteLine($"Media geral: {mediaGeral} - Conceito: {conceitoGeral}");

                        break;


                    default:
                        throw new ArgumentOutOfRangeException("Valor Invalido!");
                }

                //Para ler novamente a nova opçao do usuario apos ele ter feito o que foi solicitado anteriormente
                /* Console.WriteLine("Informe a opçao desejada:");
                Console.WriteLine("1 - Inserir novo aluno");
                Console.WriteLine("2 - Listar ALunos");
                Console.WriteLine("3 - Calcular media geral");
                Console.WriteLine("X - Sair");
                Console.WriteLine();

                opcaoUsuario = Console.ReadLine();//ler o que o usuario informou no console */

                //Melhorando:
                opcaoUsuario = ObterOpcaoUsuario();

            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Informe a opçao desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar ALunos");
            Console.WriteLine("3 - Calcular media geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();//ler o que o usuario informou no console
            return opcaoUsuario;
        }
    }
}
