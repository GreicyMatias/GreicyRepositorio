﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidades
{
    //CONTROLE DE FLUXO
    class UnidadeVIII_Slides
    {
        static void Main1(string[] args)
        {
            Random num = new Random();
            double nota = num.NextDouble();
            string resultado = null;
            resultado = (nota >= 0.7) ? "Aprovado" : "Reprovado";
            Console.WriteLine(resultado);
            Console.ReadKey();
        }
        static void Main2(string[] args)
        {
            Random gerador = new Random();
            double preco = gerador.NextDouble();
            string resultado = null;
            string caminho = null;
            resultado = (preco >= 0.5) ? "CARO" : "BARATO";
            string camisa = null;
            camisa = (preco >= 0.5) ? "VERMELHA" : "AZUL";
            caminho = (preco >= 0.5) ? "Vá para a direita" : "Vá para a esquerda";
            Console.WriteLine("Preço: {0}; \nCor:  {1};\n{2}.",resultado, camisa,caminho);
            Console.ReadKey();
        }
        static void Main3(string[] args)
        {
            Random gerador = new Random();
            int A = gerador.Next(1, 5);
            int B = gerador.Next(1, 5);
            double divisao = A % B;
            string resultado = null;
            resultado = (divisao == 0) ? "A DIVISIVEL POR B" : "A NÃO É DIVISIVEL POR B";
            Console.WriteLine(resultado);
            Console.ReadKey();
        }

        //INSTRUÇÕES REPETIÇÕES
        static void Main4(string[] args)
        {
            //REPITA 5 VEZES;
            int i = 0;
            for (i = 0; i < 5; i++)
            {
                Console.WriteLine("Repita a mensagem...\n");
                Console.ReadKey();                
            }            
        }
        static void Main5(string[] args)
        {
            //IMPRIME 100
            int i = 0;
            for (i = 1; i < 101; i++)
            {
                Console.WriteLine(i);                
            }
            Console.ReadKey();
        }
        static void Main6(string[] args)
        {
            //IMPRIME 100, EXCETO MULTIPLOS DE 3
            int i = 0;
            for (i = 1; i < 101; i++)
            {
                if (i % 3 == 0)
                {
                    continue;
                }else
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
        static void Main7(string[] args)
        {
            //DIVIDE MAIOR INTEIRO
            int num = 2147483647;
            int i = 0;
            int div = num;
            for (i = 0; div > 100; i++)
            {
                div = div / 2;
                Console.WriteLine(div+"\n");
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {

        }
    }
}
