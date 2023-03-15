using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace atividade1
{
    internal class Program
    {

        static void delay_dot (int duration)
        {
            Console.Write("\n\n");
            for (int i = 0; i < 64; i++) {
            
            Console.Write('-');
                System.Threading.Thread.Sleep(duration/64);
            }
            Console.Write("\n\n");
        }

        static void delay(int duration)
        {
                System.Threading.Thread.Sleep(duration);
        }





        static void exercicio1()
        {
            Console.Clear();
            Console.WriteLine("\n               Exercício 1\n\n");
            DateTime dt_now = DateTime.Now;
            int hora = dt_now.Hour;
            int opcao = 0;
            string[] greetings = new string[3];
            greetings[0] = "Bom dia, ";
            greetings[1] = "Boa tarde, ";
            greetings[2] = "Boa noite, ";
            if (hora >= 18 && hora < 6)  opcao = 2;
            if (hora >= 6  && hora < 12) opcao = 0;
            if (hora >= 12 && hora < 18) opcao = 1;

            Console.WriteLine(greetings[opcao] + System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName + ".");
            Console.WriteLine("Você está utilizando a máquina " + System.Environment.MachineName);
            Console.WriteLine("Hoje é " + string.Format("{0:D}", dt_now));
            Console.WriteLine("\n\n");
        }

        static string texto()
        {            
            return "3.2649195;9300419;8240871%2791073;3917173;9851056#9925124,4763040." +
                "0965918;9309297%1010589;5634190,7310819#0258142,0929306.0592849#2628868;1392209;49417" +
                "11%6802169%3655235.1180040#6889981;4529558,3395538;3095206.8162707,5306168" +
                "%3277453.0758859,8014857.6402319%2329297.7429486#4680437%5500518#7865391" +
                "#2873377#8086382#5447877%5426116,5085634%7224325#5798439,1178516%431207" +
                "2.0796522.9304179;0434651%6509028#4787438#8491024%3015385,5290222%529492" +
                "7%5561596.0460024%1321386,1368206;3408249,6508625.7336954%8002371;7576263" +
                "%3747889#7408701%0201462#4900590;9622169#0048623%4969522%4528884#49907" +
                "86.3003232;6365305%3586311.5647329%3264194;2114295,3171009;9876958,4020305," +
                "1632979%0031475.2552181%2602640.5303671.8059160%4988532.4693670%9150725,3" +
                "340225,6376627.0780785;0990199.4341820.0463039%3299347,7393254%4523854#660" +
                "3120%9368998#5944279,9085068#8137433,3239866,6379195#7431356.5898614.58104" +
                "97.3487996#5400022#6149677,8533754%6088682%2032031.6332587,7284531#923933" +
                "1%8866454,3964222#3314980#8428029.2546101;7316677%0460178;8789264;9316756." +
                "1965642;7585590,7383219;9062609,8482023,5717895;2684729;0466794%5370084,0484" +
                "922;4599156,5815576%3414149.1343440#16129";
        }

        static void exercicio2()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\tExercício 2\n");
            string text = texto();
            char[] text_char_array = text.ToCharArray();

            string numeros = Regex.Replace(text, @"[^\d]", "");
            char[] numeros_char_array = numeros.ToCharArray();

            int maior = 0, index = 0; ;
            int produto = 1;
            for (int i = 0; i < numeros_char_array.Length - 4; i++)
            {
                produto = 1;
                for (int j = 0; j < 5; j++)
                {
                    produto *= (int)char.GetNumericValue(numeros_char_array[i + j]);
                }
                if (produto > maior)
                {
                    maior = produto;
                    index = i;
                }
            }

            Console.WriteLine("\t\t\t texto original \t\t\t\t\t    texto novo \n");
            int a = 0, b = 0, c = 0;
            int print_width = 50;
            int p_text = 0 , p_numeros = 0;

            for (; a < text_char_array.Length + numeros_char_array.Length;)
            {
                Console.Write("      ");
                for (b = 0; b < print_width && p_text < text_char_array.Length; b++) {
                    Console.Write(text_char_array[p_text]);
                    p_text++;
                }
                Console.Write("        ");
                for (c = 0; c < print_width && p_numeros < numeros_char_array.Length; c++) {
                    if (p_numeros >= index && p_numeros <= index + 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(numeros_char_array[p_numeros]);
                    p_numeros++;
                }
                Console.Write("\n");
                a += b + c;
            }
            Console.WriteLine($"\n\tMaior produto de todos os 5 caracteres sequenciais de 0 a 996 : {maior}");
            delay(1000);
        }

        static void exercicio3()
        {
            Console.Clear();
            Console.WriteLine("\n               Exercício 3\n\n");

            string text = texto();
            string numeros = Regex.Replace(text, @"[^\d]", "");
            char[] numeros_char_array = numeros.ToCharArray();
            int print_width = 50;


            string[] array_strings = new string[40];
            int sub_count = 0;

            for (int i = 1; i < numeros_char_array.Length - 1; i++)
            {
                if(i % print_width == 1)
                {
                    Console.Write("\n\t\t");
                }
                if (numeros_char_array[i] == '1' && (numeros_char_array[i - 1] == '1' || numeros_char_array[i + 1] == '1')) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(numeros_char_array[i].ToString());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(numeros_char_array[i].ToString());
                }
            }
            Console.WriteLine("\n\n");

            int index_inicio_substring = 0;
            int soma;
            for (int i = 1; i < numeros_char_array.Length; i++)
            {
                if (numeros_char_array[i] == '1' && numeros_char_array[i - 1] == '1')
                {
                    array_strings[sub_count] = numeros.Substring(index_inicio_substring, i - index_inicio_substring+1);  
                    char[] substring_char_array = array_strings[sub_count].ToCharArray();
                    soma = 0;
                    for (int j = 0; j < array_strings[sub_count].Length; j++)
                    {
                        soma += int.Parse(array_strings[sub_count][j].ToString());
                    }

                    Console.WriteLine($"substring {sub_count}:");
                    for (int k = 0; k < substring_char_array.Length; k++)
                    {
                        if (k % print_width == 0)
                        {
                            Console.Write("\n\t\t");
                        }
                        if (k >= substring_char_array.Length-2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write(substring_char_array[k]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(
                        $"\n\n\tsoma = {soma}\n" +
                        $"\tquantidade de caracteres : {array_strings[sub_count].Length}\n\n\n"
                    );

                    sub_count++;
                    index_inicio_substring = i + 1;
                    Console.ReadLine();

                }
            }

            Console.WriteLine("\n\n");



            

        }

            static void Main(string[] args)
        {
            int ex = 0;
            Console.WriteLine("\n\n        II           II      IIIIIII     IIIIIIIIIIIIII        III                       IIIIIIIIIIII \n        II           II    III     III         II             II II                      II           \n        II           II    II                  II            II   II                     II           \n        II           II     IIIII              II           II     II                    IIIIIIIIIII  \n        II           II         IIIII          II          II       II                            III \n        II           II             II         II         IIIIIIIIIIIII                             II\n        II           II    III     III         II        II           II                 III       III\n        IIIIIIIIII   II     IIIIIIIII          II       II             II                 IIIIIIIIIII ");
            delay(500);
            delay_dot(1000);


            ex++;
            //Console.WriteLine($"\n\nEnter para ir para o exercício {ex}");
            //Console.ReadLine() ;
            exercicio1();
            ex++;
            Console.WriteLine($"\n\nEnter para ir para o exercício {ex}");
            Console.ReadLine();
            exercicio2();
            delay(2000);
            delay_dot(800);
            ex++;
            Console.WriteLine($"\n\nEnter para ir para o exercício {ex}");
            Console.ReadLine();
            exercicio3();






            Console.Write("\n\npressione qualquer tecla para sair...");
            Console.ReadLine();
        }
    }
}
