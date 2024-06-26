using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FP_Set_1;
namespace FP_Set_1
{
    public class Helpers
    {
        public static int IntInput(string txt)
        {
            int[] src = IntInputArray(txt);
            return src == null ? int.MinValue : src[0];
        }

        public static int[] IntInputArray(string txt)
        {
            try
            {
                Console.Write(txt);
                char[] sep = { ' ', '.', ',', ';', '/' };
                string[] src = Console.ReadLine().Split(sep, StringSplitOptions.RemoveEmptyEntries);
                if (src.Length == 0) return null;
                int[] output = new int[src.Length];
                int i = 0;
                foreach (string s in src)
                {
                    //Console.WriteLine($"DEBUG: input {i} = {s}");
                    checked { output[i] = int.Parse(s); }
                    i++;
                }
                return output;
            }
            catch (OverflowException)
            {
                Console.WriteLine($"ERROR: input was too high / big or too low");
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"ERROR: input 'opt' was empty");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e}");
                return null;
            }
        }

        public static string[] GenericInput(string txt)
        {
            Console.Write(txt);
            char[] sep = { ' ', '.', ',', ';', '/' };
            string[] src = Console.ReadLine().Split(sep, StringSplitOptions.RemoveEmptyEntries);
            if (src.Length == 0) return null;
            return src;
        }
    }
}
namespace FP_SET1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Optiuni:\n" +
            "\t1.Ecuatie de gr. 1\n" +
            "\t2.Ecuatie de gr. 2\n" +
            "\t3.Determinati daca n se divide cu k\n" +
            "\t4.Detreminati daca un an y este an bisect\n" +
            "\t5.Afisati a k-a cifra\n" +
            "\t6.Lungimile laturilor unui triunghi\n" +
            "\t7.Se dau doua variabile numerice a si b ale carori valori sunt date de intrare. \n" +
            "Se cere sa se inverseze valorile lor\n" +
            "\t8.Se dau doua variabile numerice a si b ale carori valori sunt date de intrare.\n" +
            " Se cere sa se inverseze valorile lor fara a folosi alte variabile suplimentare\n" +
            "\t9.Afisati toti divizorii numarului n\n" +
            "\t10.Determinati daca un nr este prim\n" +
            "\t11.Ordine inversa a cifrelor unui nr\n" +
            "\t12.Determinati cate numere integi divizibile cu n se afla in intervalul [a, b]\n" +
            "\t13.Determianti cati ani bisecti sunt intre anii y1 si y2\n" +
            "\t14.Determianti daca un numar n este palindrom\n" +
            "\t15.Se dau 3 numere. Sa se afiseze in ordine crescatoare\n" +
            "\t16.tSe dau 5 numere. Sa se afiseze in ordine crescatoare.\n" +
            "\t17.Determianti cel mai mare divizor comun si cel mai mic multiplu comun a doua numere. \n" +
            "\t18.Afisati descompunerea in factori primi ai unui numar n\n" +
           "\t19.Determinati daca un numar e format doar cu 2 cifre care se pot repeta\n " +
           "\t20.Afisati fractia m/n in format zecimal, cu perioada intre paranteze \n" +
           "\t21.Ghiciti un numar intre 1 si 1024  \n");
            bool ok = true;
            while (ok)
            {
                int opt = Helpers.IntInput("Problema selectata: ");
                switch (opt)
                {
                    case 1: P1(); break;
                    case 2: P2(); break;
                    case 3: P3(); break;
                    case 4: P4(); break;
                    case 5: P5(); break;
                    case 6: P6(); break;
                    case 7: P7(); break;
                    case 8: P8(); break;
                    case 9: P9(); break;
                    case 10: P10(); break;
                    case 11: P11(); break;
                    case 12: P12(); break;
                    case 13: P13(); break;
                    case 14: P14(); break;
                    case 15: P15(); break;
                    case 16: P16(); break;
                    case 17: P17(); break;
                    case 18: P18(); break;
                    case 19: P19(); break;
                    case 20: P20(); break;
                    case 21: P21(); break;
                    case int.MinValue: Console.WriteLine("Invalid Problem number, exiting program..."); ok = false; break;
                }
            }

        }
        private static void P1()
        {
            // Solutia ecuatiei ax+b=0
            float a, b, x;
            Console.WriteLine("Introduceti a si b:");
            a = float.Parse(Console.ReadLine());
            b = float.Parse(Console.ReadLine());
            x = -b / a;
            Console.WriteLine($"Solutia ecuatiei este {x}");
        }

        private static void P2()
        {
            //Rezolvati ecuatia de gradul 2 cu o necunoscuta: ax^2 + bx + c = 0,
            //unde a, b si c sunt date de intrare. Tratati toate cazurile posibile. 
            double a, b, c, d, x1, x2, parteImg, parteReala;
            Console.WriteLine("Introduceti coeficientii lui a, b si c:");
            a = double.Parse(Console.ReadLine());
            b = double.Parse(Console.ReadLine());
            c = double.Parse(Console.ReadLine());
            d = b * b - 4 * a * c;
            if (d > 0)
            {
                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine($"Solutiile ecuatiei sunt {x1} si {x2}");
            }

            else if (d == 0)
            {
                x1 = x2 = -b / (2 * a);
                Console.WriteLine($"Solutia ecuatiei este {x1}");
            }

            else
            {
                parteReala = -b / (2 * a);
                parteImg = Math.Sqrt(-d) / (2 * a);
                Console.WriteLine($"Solutiile ecuatiei sunt {parteReala}+{parteImg}i si {parteReala}-{parteImg}i");
            }


        }
        private static void P3()
        {
            //Determinati daca n se divide cu k, unde n si k sunt date de intrare. 
            Console.WriteLine("Introduceti n si k");
            int n, k;
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());

            if (n % k == 0)
            {
                Console.WriteLine("n divide k");

            }
            else
            {
                Console.WriteLine("n nu divide k");
            }
        }
        private static void P4()
        {
            //Detreminati daca un an y este an bisect. 
            Console.WriteLine("Introduceti anul");
            int y;
            y = int.Parse(Console.ReadLine());
            if ((y % 4 == 0) && (y % 100 != 0))

                Console.WriteLine($"{y} este an bisect");

            else if
                  (y % 400 == 0) Console.WriteLine($"{y} este an bisect");
            else
                Console.WriteLine($"{y} nu este an bisect");
        }
        private static void P5()
        {
            //Extrageti si afisati a k - a cifra de la sfarsitul unui numar.
            //Cifrele se numara de la dreapta la stanga. 
            int n, k;
            Console.WriteLine("Introduceti numarul:");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("a k-a cifra afisata:");
            k = int.Parse(Console.ReadLine());

            int nr = 0;
            while (n != 0)
            {

                nr++;
                if (nr == k)
                {
                    Console.WriteLine(n % 10);
                    return;
                }
                n = n / 10;

            }
            int nn = n % 10 + n / 10;
            Console.WriteLine(nn);
        }
        private static void P6()
        {
            //Detreminati daca trei numere pozitive a, b si c pot fi lungimile laturilor unui triunghi. 

            Console.WriteLine("Introduceti 3 numere naturale ");
            int a, b, c;

            a = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());

            if (a < b + c && b < a + c && c < a + b)
                Console.WriteLine("Triunghi");
            else
                Console.WriteLine("Nu e triunghi");
        }

        private static void P7()
        {
            //(Swap) Se dau doua variabile numerice a si b ale caror valori sunt date de intrare.
            //Se cere sa se inverseze valorile lor. 
            Console.WriteLine("Introduceti a si b: ");
            int a, b;
            string line;
            line = Console.ReadLine();
            char[] separator = new char[] { ' ', ',', ';', '.' };
            string[] tokens = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            a = int.Parse(tokens[0]);
            b = int.Parse(tokens[1]);

            int aux = a;
            a = b;
            b = aux;

            Console.WriteLine($"{a} {b}");
        }

        private static void P8()
        {
            //(Swap restrictionat) Se dau doua variabile numerice a si b ale carori valori sunt date de intrare.
            //Se cere sa se inverseze valorile lor fara a folosi alte variabile suplimentare.

            int a, b;
            Console.WriteLine("Introduceti a si b: ");
            string line;
            line = Console.ReadLine();
            char[] separator = new char[] { ' ', ',', ';', '.' };
            string[] tokens = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            a = int.Parse(tokens[0]);
            b = int.Parse(tokens[1]);


            a = a * b;
            b = a / b;
            a = a / b;
            Console.WriteLine($"Dupa inversare a={a} b={b}");
        }
        private static void P9()
        {
            //Afisati toti divizorii numarului n. 
            int n;
            Console.WriteLine("Introduceti numarul:");
            n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                    Console.WriteLine(i);
            }

        }
        private static void P10()
        {
            int n;
            Console.WriteLine("Introduceti numarul:");
            n = int.Parse(Console.ReadLine());

            if (n == 2)
            {
                Console.WriteLine("Este prim");
                return;
            }

            if (n < 2)
            {
                Console.WriteLine("Nu este prim");
                return;
            }

            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    Console.WriteLine("Nu este prim");
                    return;
                }
            }
            Console.WriteLine("Este prim");

        }
        private static void P11()
        {
            //Afisati in ordine inversa cifrele unui numar n. 
            int n, invers = 0;
            Console.WriteLine("Introduceti numarul:");
            n = int.Parse(Console.ReadLine());

            while (n != 0)
            {
                invers = invers * 10 + n % 10;
                n = n / 10;
            }

            Console.WriteLine($"Ordinea inversa este : {invers}");
        }
        private static void P12()
        {
            //Determinati cate numere intregi divizibile cu n se afla in intervalul [a, b]. 
            int a, b, n, nr;
            Console.WriteLine("Introduceti a,b:");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti n:");
            n = int.Parse(Console.ReadLine());

            nr = b / n - (a - 1) / n;
            Console.WriteLine($"Exista {nr} numere intregi divizibile cu {n} in intervalul [{a} , {b}]");

        }
        private static void P13()
        {
            //Determianti cati ani bisecti sunt intre anii y1 si y2.
            int y1, y2;
            Console.WriteLine("Introduceti y1, y2: ");

            int count = 0;
            y1 = int.Parse(Console.ReadLine());
            y2 = int.Parse(Console.ReadLine());

            for (int y = y1; y <= y2; y++)
            {
                if (((y % 4 == 0) && (y % 100 != 0)) || (y % 400 == 0))
                {

                    count++;

                }

            }
            Console.WriteLine($"Sunt {count} ani bisecti intre anii {y1} si {y2}");

        }
        private static void P14()
        {
            int n, t, r, s = 0;

            Console.WriteLine("Introduceti numarul:");
            n = int.Parse(Console.ReadLine());
            t = n;
            while (n != 0)
            {
                r = n % 10;
                n = n / 10;
                s = s * 10 + r;
            }

            if (t == s)

                Console.WriteLine($"{s} este un palindrom");

            else
                Console.WriteLine($"{s} nu este un palindrom");

        }
        private static void P15()
        {
            //Se dau 3 numere. Sa se afiseze in ordine crescatoare. 
            Console.WriteLine("Introduceti a, b, c: ");
            int a, b, c;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());

            int minim;
            minim = a;
            if (b < minim)
            {
                minim = b;
            }
            if (c < minim)
            {
                minim = c;
            }
            int maxim;
            maxim = a;
            if (b > maxim)
            {
                maxim = b;
            }
            if (c > maxim)
            {
                maxim = c;
            }
            Console.WriteLine($"{minim} {a + b + c - minim - maxim} {maxim}");
        }
        private static void P16()
        {
            //Se dau 5 numere. Sa se afiseze in ordine crescatoare. (nu folositi tablouri)
            int a, b, c, d, e;
            Console.WriteLine("Introduceti 5 numere: ");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            d = int.Parse(Console.ReadLine());
            e = int.Parse(Console.ReadLine());
            int aux;
            for (int count = 0; count < 4; count++)
            {
                if (b < a)
                {
                    aux = a;
                    a = b;
                    b = aux;
                }

                if (c < b)
                {
                    aux = b;
                    b = c;
                    c = aux;
                }

                if (d < c)
                {
                    aux = c;
                    c = d;
                    d = aux;
                }

                if (e < d)
                {
                    aux = d;
                    d = e;
                    e = aux;
                }
            }

            Console.WriteLine($"{a}, {b}, {c}, {d}, {e}");
        }
        private static void P17()
        {
            //Determianti cel mai mare divizor comun si cel mai mic multiplu comun a doua numere.
            //Folositi algoritmul lui Euclid.


            int a, b;
            Console.WriteLine("Introduceti a si b: ");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            int x = a; int y = b;
            while (b != 0)
            {

                int r = a % b;
                a = b;
                b = r;

            }

            int cmmmc = x * y / a;
            Console.WriteLine($"{a} este cel mai mare divizor comun si {cmmmc} este cel mai mic multiplu comun");
        }
        private static void P18()
        {
            //Afisati descompunerea in factori primi ai unui numar n.
            //De ex. pentru n = 1176 afisati 2^3 x 3^1 x 7^2. 
            int n, putere;
            Console.WriteLine("Introduceti numarul:");
            n = int.Parse(Console.ReadLine());
            int divizor = 2;
            while (n > 1)
            {
                if (n % divizor == 0)
                {
                    putere = 0;
                    while (n % divizor == 0)
                    {
                        putere = putere + 1;
                        n = n / divizor;
                    }

                    Console.Write($"{divizor}^{putere} ");


                }
                divizor++;
            }
        }
        private static void P19()
        {
            //Determinati daca un numar e format doar cu 2 cifre care se pot repeta.
            //De ex. 23222 sau 9009000 sunt astfel de numere, pe cand 593 si 4022 nu sunt. 
            int n, c1, c2 = -1, c3 = -1, uc;
            Console.WriteLine("Introduceti numarul");
            n = int.Parse(Console.ReadLine());

            c1 = n % 10;
            n = n / 10;
            while (n != 0)
            {
                uc = n % 10;
                if (c2 == -1 && uc != c1)
                    c2 = uc;
                if (c3 == -1 && uc != c2 && uc != c1)
                    c3 = uc;
                n = n / 10;
            }

            if (c3 == -1)
                Console.WriteLine("Este format doar din 2 cifre care se repeta");
            else
                Console.WriteLine("Nu este format doar din 2 cifre care se repeta");
        }
        private static void P20()
        {
            //Afisati fractia m/n in format zecimal, cu perioada intre paranteze (daca e cazul).
            //Exemplu: 13/30 = 0.4(3). 

            int m, n;
            Console.WriteLine("Introduceti m si n: ");
            m = int.Parse(Console.ReadLine());
            n = int.Parse(Console.ReadLine());

            int parteInt, parteFract;
            parteInt = m / n;
            parteFract = m % n;
            Console.Write($"{parteInt},");
            int cifra, rest;
            List<int> resturi = new List<int>();
            List<int> cifre = new List<int>();
            resturi.Add(parteFract);
            bool periodic = false;
            do
            {
                cifra = parteFract * 10 / n;
                cifre.Add(cifra);

                rest = parteFract * 10 % n;
                if (!resturi.Contains(rest))
                {
                    resturi.Add(rest);
                }
                else
                {
                    periodic = true;
                    break;
                }
                parteFract = rest;
            } while (rest != 0);

            if (!periodic)
            {
                foreach (var item in cifre)
                {
                    Console.Write(item);
                }
            }
            else
            {
                for (int i = 0; i < resturi.Count; i++)
                {
                    if (resturi[i] == rest)
                    {
                        Console.Write("(");
                    }
                    Console.Write(cifre[i]);
                }
                Console.WriteLine(")");
            }

        }
        private static void P21()
        {
            //Ghiciti un numar intre 1 si 1024 prin intrebari de forma "numarul este mai mare sau egal decat x?". 


            Console.WriteLine("Alege un numar intre 1 si 1024");
            int n = int.Parse(Console.ReadLine());

            int start = 1;
            int end = 1024;
            Random rnd = new Random();
            int x = rnd.Next(start, end);

            while (true)
            {
                Console.WriteLine($"Numarul este mai mare sau mai mic decat {x}? (Mai mare/ Mai mic/ Corect)");

                string answerInput = Console.ReadLine();
                if (answerInput == "Mai mare")
                {
                    start = x + 1;
                    x = rnd.Next(start, end);
                }
                else if (answerInput == "Mai mic")
                {
                    end = x - 1;
                    x = rnd.Next(start, end);
                }
                else if (answerInput == "Corect")
                {
                    Console.WriteLine("Am ghicit!");
                    break;
                }
            }
        }
    }
}

