using System;

namespace Projekt2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo anoperacja;
            ConsoleKeyInfo ansledzenie;
            do
            {
                //menu
                Console.WriteLine("\n\n\t\t\t\t\t------------MENU------------\n\n");
                Console.WriteLine("\nA. Obliczanie wartości (sumy) zadanego szeregu potęgowego");
                Console.WriteLine("\nB. Tablicowanie wartości zadanego szeregu potęgowego");
                Console.WriteLine("\nC. Tablicowanie wartości pierwiastka kwadratowego, obliczanego metodą Herona, z wartości zdanego szeregu potęgowego");
                Console.WriteLine("\nD. Tablicowanie wartości n-tego pierwiastka, obliczonego metodą Netwona, z wartości zadanego szeregu potęgowego");
                Console.WriteLine("\nE. Suma podzielników");
                Console.WriteLine("\nF. Palindrom");
                Console.WriteLine("\nX. Koniec programu");
                Console.Write("\nPodaj znak wybranej operacji: ");
                anoperacja = Console.ReadKey();
                Console.Write("\n\nCzy obliczanie ma być realizowane z śledzeniem, czy bez \nnaciśnij klawicz (T/t) jeśli tak, lub dowolny inny klawisz jeżeli nie: ");
                ansledzenie = Console.ReadKey();
                switch (anoperacja.Key)
                {
                    case ConsoleKey.A:
                        {
                            Console.WriteLine("\n\n\tObliczanie wartości (sumy) zadanego szeregu potęgowego:");
                            double anx = anwczytaniedouble("Podaj wartość zmiennej niezależnej x"), aneps;
                            bool anczysledzenie = false;

                            if (ansledzenie.Key == ConsoleKey.T)
                            {
                                anczysledzenie = true;
                            }

                            aneps = anwczytanieEps("Podaj dokładność obliczeń Eps");

                            Console.WriteLine("\n\n\tWartość podanego ciągu: {0, 8:F2}", anSumaSzereguPotegowego(anx, aneps, out ushort anlicznik, anczysledzenie));

                            break;
                        }
                    case ConsoleKey.B:
                        {
                            Console.WriteLine("\n\n\tTablicowaie wartosci zadanego szeregu potęgowego:");
                            double aneps, anpocz, ankon;

                            aneps = anwczytanieEps("Podaj dokładność obliczeń Eps: ");

                            anPrzedzial(out anpocz, out ankon);

                            double anskok;
                            ushort anlicznik = 0;
                            anSkok(out anskok, anpocz, ankon);

                            bool anczysledzenie = false;

                            if (ansledzenie.Key == ConsoleKey.T)
                            {
                                anczysledzenie = true;
                            }
                            anTablicowanieZmianyWartosciSzereguPotegowego(anpocz, ankon, aneps, anskok, anlicznik, anczysledzenie);
                            break;
                        }
                    case ConsoleKey.C:
                        {
                            Console.WriteLine("\n\n\tTablicowanie wartości pierwiastka kwadratowego, obliczanego metodą Herona,\n\tz wartości zdanego szeregu potęgowego:");
                            double aneps = anwczytanieEps("Podaj dokładność obliczeń Eps: "), anpocz, ankon, anskok;
                            ushort anlicznik = 0;
                            anPrzedzial(out anpocz, out ankon);
                            anSkok(out anskok, anpocz, ankon);
                            bool anczysledzenie = false;

                            if (ansledzenie.Key == ConsoleKey.T)
                            {
                                anczysledzenie = true;
                            }

                            anTablicowaniepierwiastkaKwadratowego(anpocz, ankon, aneps, anskok, anlicznik, anczysledzenie);
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            Console.WriteLine("\n\n\tTablicowanie wartości n-tego pierwiastka, obliczonego metodą Netwona, z wartości zadanego szeregu potęgowego:");
                            double aneps = anwczytanieEps("Podaj dokładność obliczeń Eps: "), anpocz, ankon, anskok;
                            ushort anlicznik = 0, anstopien = anwczytanieushort("Podaj stopień pierwiastka:");
                            anPrzedzial(out anpocz, out ankon);
                            anSkok(out anskok, anpocz, ankon);
                            bool anczysledzenie = false;

                            if (ansledzenie.Key == ConsoleKey.T)
                            {
                                anczysledzenie = true;
                            }

                            Tablicowanie_nStopnia(anpocz, ankon, aneps, anskok, anlicznik, anczysledzenie, anstopien);
                            break;
                        }
                    case ConsoleKey.E:
                        {
                            Console.WriteLine("\n\n\tSuma podzielników:");
                            ushort ann = anwczytanieushort("Podaj liczbę wyrazów: ");
                            anSumaPodzielnikowWyswietlanie(ann);
                            break;
                        }
                    case ConsoleKey.F:
                        {
                            Console.WriteLine("\n\n\tPalindrom:");
                            Console.Write("\n\tPodaj ciąg znaków: ");
                            string anslowo = Console.ReadLine();
                            if (anczypalindrom(anslowo))
                                Console.WriteLine("\n\t\tPodany ciąg znaków jest palindromem");
                            else
                                Console.WriteLine("\n\t\tPodany ciąg znaków nie jest palindromem");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\n\n\tERROR - znak spoza menu");
                            break;
                        }
                }
            } while (ansledzenie.Key != ConsoleKey.X);
        }
        static bool anczypalindrom(string anslowo)
        {
            string anlustro = "";
            for (int i = 0; i < anslowo.Length; i++)
            {
                anlustro += anslowo[anslowo.Length - i - 1];
            }
            if (anslowo == anlustro)
                return true;
            return false;
        }
        static void anSumaPodzielnikowWyswietlanie(ushort ann)
        {
            ushort anliczba, ansuma = 0; ;
            for (int i = 0; i < ann; i++)
            {
                Console.Write("\n\tPodaj liczbę nr {0}: ", i + 1);
                if (!ushort.TryParse(Console.ReadLine(), out anliczba))
                {
                    Console.WriteLine("\n\t\tERROR-podana liczba nie jest całkowita i/lub większa od zera");
                    i--;
                }
                else
                {
                    ansuma += ansumadzielnikow(anliczba);
                }
            }
            Console.WriteLine("\n\t\tSuma podzielników podanych liczb to: {0}", ansuma);
        }
        static ushort ansumadzielnikow(ushort anliczba)
        {
            ushort ansuma = 0;
            for (ushort i = 1; i < anliczba; i++)
            {
                if (anliczba % i == 0)
                    ansuma += i;
            }
            return ansuma;
        }
        static double anwczytanieEps(string antekst)
        {
            double aneps;
            while (true)
            {
                Console.Write("\n\t{0} : ", antekst);

                if (double.TryParse(Console.ReadLine(), out aneps) && aneps > 0 && aneps < 1)
                {
                    break;
                }
                else
                    Console.WriteLine("\tERROR - podany Eps nie spełnia warunku: (Eps > 0 && Eps < 1) ");
            }
            return aneps;
        }
        static void anPrzedzial(out double anpocz, out double ankon)
        {
            do
            {
                anpocz = anwczytaniedouble("Podaj lewy koniec przedziału: ");
                ankon = anwczytaniedouble("Podaj prawy koniec przedziału: ");
                if (anpocz >= ankon)
                {
                    Console.WriteLine("\tERROR-podane końce przeziałów są złe");
                }
            } while (anpocz >= ankon);
        }
        static void anSkok(out double anskok, double anpocz, double ankon)
        {
            do
            {
                anskok = anwczytaniedouble("Podaj skok: ");
                if (anskok < 0 || anskok >= (ankon - anpocz) / 2)
                {
                    Console.WriteLine("\tERROR-podany skok jest zły");
                }
            } while (anskok < 0 || anskok >= (ankon - anpocz) / 2);
        }
        static double anwczytaniedouble(string antekst)
        {
            double anliczba;
            while (true)
            {
                Console.Write("\n\t{0} : ", antekst);
                if (double.TryParse(Console.ReadLine(), out anliczba))
                {
                    break;
                }
                else
                    Console.WriteLine("\n\tERROR-podana liczba nie pasuje do typu double!");
            }
            return anliczba;
        }
        static ushort anwczytanieushort(string antekst)
        {
            ushort anliczba;
            while (true)
            {
                Console.Write("\n\t{0} : ", antekst);
                if (ushort.TryParse(Console.ReadLine(), out anliczba))
                {
                    break;
                }
                else
                    Console.WriteLine("\n\tERROR-podana liczba nie pasuje do typu ushort!");
            }
            return anliczba;
        }
        static double anpotega(double anpodstawa, ushort anwykladnik)
        {
            double anwynik = 1;
            for (int i = 0; i < anwykladnik; i++)
            {
                anwynik *= anpodstawa;
            }
            return anwynik;
        }
        static double anSumaSzereguPotegowego(double anx, double aneps, out ushort anlicznik, bool anczysledzenie)
        {
            double anw = 1, ansuma = 1;
            anlicznik = 1;
            while (Math.Abs(anw) > aneps)
            {
                anlicznik++;
                anw *= (-anx / anlicznik);
                ansuma += anw;
                if (anczysledzenie)
                    Console.WriteLine("\n\n\tŚledzenie: W {0} -tej iteracji: SumaSzeregu = {1, 5:F2} , a wartość wyrazu W = {2, 5:F2}", anlicznik - 1, ansuma, anw);
            }
            return ansuma;
        }
        static void anTablicowanieZmianyWartosciSzereguPotegowego(double anpocz, double ankon, double aneps, double anskok, ushort anlicznik, bool anczysledzenie)
        {
            Console.WriteLine("\t\t  x\t S(x)\tLicznik zsumowanych wytazów szeregu potęgowego\n");
            double ansuma;
            while (anpocz <= ankon)
            {
                ansuma = anSumaSzereguPotegowego(anpocz, aneps, out anlicznik, anczysledzenie);
                Console.WriteLine("\t\t{0, 5:F2}\t{1, 5:F2}\t{2,10}\n", anpocz, ansuma, anlicznik);
                anpocz += anskok;
            }
        }
        static double anPierwiatek2Stopnia(double anliczba, double aneps, out ushort anlicznik, bool anczysledzenie)
        {
            anlicznik = 0;
            if (anliczba < 0)
                return 0;

            double anxi = anliczba / 2, anxi_1;

            do
            {
                anxi_1 = anxi;
                anlicznik++;
                anxi = (anxi_1 + anliczba / anxi_1) / 2;
                if (anczysledzenie)
                    Console.WriteLine("\n\n\tŚledzenie: W {0} -tej iteracji: X = {1, 5:F2} , X-1 = {2, 5:F2}\n", anlicznik, anxi, anxi_1);

            } while (Math.Abs(anxi - anxi_1) > aneps);

            return anxi;
        }
        static double anPierwiastekNStopnia(double anliczba, ushort anstopien, double aneps, out ushort anlicznik, bool anczysledzenie)
        {
            anlicznik = 0;
            double anxi = anliczba, anxi_1;

            do
            {
                anxi_1 = anxi;
                anlicznik++;
                anxi = ((anstopien - 1) * anxi_1 + (anliczba / (anpotega(anxi_1, (ushort)(anstopien - 1))))) / anstopien;
                if (anczysledzenie)
                    Console.WriteLine("\n\n\t\t\t\tŚledzenie: W {0} -tej iteracji: X = {1, 5:F2} , X-1 = {2, 5:F2}\n", anlicznik, anxi, anxi_1);

            } while (Math.Abs(anxi - anxi_1) >= aneps);

            return anxi;
        }
        static void anTablicowaniepierwiastkaKwadratowego(double anpocz, double ankon, double aneps, double anskok, ushort anlicznik, bool anczysledzenie)
        {
            Console.WriteLine("\t\t  x\t S(x)\tLicznik zsumowanych wyrazów szeregu potęgowego\tPierwiastek drugiego stopnia\n");
            double ansuma;
            while (anpocz <= ankon)
            {
                ansuma = anSumaSzereguPotegowego(anpocz, aneps, out anlicznik, false);
                Console.WriteLine("\t\t{0, 5:F2}\t{1, 5:F2}\t\t\t{2, 5:F2}\t\t\t\t{3, 5:F2}\n", anpocz, ansuma, anlicznik - 1, anPierwiatek2Stopnia(ansuma, aneps, out anlicznik, anczysledzenie));
                anpocz += anskok;
            }
        }
        static void Tablicowanie_nStopnia(double anpocz, double ankon, double aneps, double anskok, ushort anlicznik, bool anczysledzenie, ushort anstopien)
        {
            Console.WriteLine("\t\t  x\t S(x)\tLicznik zsumowanych wytazów szeregu\tPierwiastek {0} stopnia\n", anstopien);
            double ansuma;
            while (anpocz <= ankon)
            {
                ansuma = anSumaSzereguPotegowego(anpocz, aneps, out anlicznik, false);
                Console.WriteLine("\t\t{0, 5:F2}\t{1, 5:F2}\t\t\t{2, 5:F2}\t\t\t\t{3, 5:F2}\n", anpocz, ansuma, anlicznik - 1, anPierwiastekNStopnia(ansuma, anstopien, aneps, out anlicznik, anczysledzenie));
                anpocz += anskok;
            }
        }
    }
}
