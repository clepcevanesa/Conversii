using System;

class ConversieBaza
{
    static void Main()
    {
        // Numărul în baza sursă și baza destinație
        string numarSursa = "10110.101"; // Numărul în baza 2
        int bazaSursa = 2;
        int bazaDestinatie = 10; // Baza în care dorim să convertim numărul

        // Convertirea din baza sursă în baza 10
        double rezultatBaza10 = ConversieBazaInBaza10(numarSursa, bazaSursa);

        // Convertirea din baza 10 în baza destinație
        string rezultatBazaDestinatie = ConversieBaza10InBazaDestinatie(rezultatBaza10, bazaDestinatie);

        // Afișarea rezultatului
        Console.WriteLine($"Numărul {numarSursa} în baza {bazaSursa} este echivalent cu {rezultatBazaDestinatie} în baza {bazaDestinatie}.");
    }

    // Funcție pentru convertirea din baza sursă în baza 10
    static double ConversieBazaInBaza10(string numar, int baza)
    {
        string[] parti = numar.Split('.'); // Împărțirea numărului între partea întreagă și cea fracționară (dacă există)

        double parteIntreaga = 0;
        for (int i = 0; i < parti[0].Length; i++)
        {
            int cifra = CaracterInCifra(parti[0][i]);
            parteIntreaga += cifra * Math.Pow(baza, parti[0].Length - 1 - i);
        }

        double parteFractionara = 0;
        if (parti.Length > 1)
        {
            for (int i = 0; i < parti[1].Length; i++)
            {
                int cifra = CaracterInCifra(parti[1][i]);
                parteFractionara += cifra * Math.Pow(baza, -(i + 1));
            }
        }

        return parteIntreaga + parteFractionara;
    }

    // Funcție pentru convertirea din baza 10 în baza destinație
    static string ConversieBaza10InBazaDestinatie(double numar, int baza)
    {
        int parteIntreaga = (int)Math.Floor(numar);
        double parteFractionara = numar - parteIntreaga;

        string rezultatIntreg = ConversieBaza10InBazaDestinatieIntreg(parteIntreaga, baza);
        string rezultatFractionar = ConversieBaza10InBazaDestinatieFractionar(parteFractionara, baza);

        return rezultatIntreg + rezultatFractionar;
    }

    // Funcție pentru convertirea părții întregi din baza 10 în baza destinație
    static string ConversieBaza10InBazaDestinatieIntreg(int numar, int baza)
    {
        string rezultat = "";
        while (numar > 0)
        {
            int rest = numar % baza;
            char cifra = CifraInCaracter(rest);
            rezultat = cifra + rezultat;
            numar /= baza;
        }

        return rezultat;
    }

    // Funcție pentru convertirea părții fracționare din baza 10 în baza destinație
    static string ConversieBaza10InBazaDestinatieFractionar(double numar, int baza)
    {
        const int precizie = 15; // Precizia pentru părțile fracționare
        string rezultat = ".";
        for (int i = 0; i < precizie; i++)
        {
            numar *= baza;
            int parteIntreaga = (int)Math.Floor(numar);
            char cifra = CifraInCaracter(parteIntreaga);
            rezultat += cifra;
            numar -= parteIntreaga;
        }

        return rezultat;
    }

    // Funcție pentru transformarea unei cifre în caracter corespunzător
    static char CifraInCaracter(int cifra)
    {
        if (cifra < 10)
        {
            return (char)('0' + cifra);
        }
        else
        {
            return (char)('A' + cifra - 10);
        }
    }

    // Funcție pentru transformarea unui caracter în cifra corespunzătoare
    static int CaracterInCifra(char caracter)
    {
        if (caracter >= '0' && caracter <= '9')
        {
            return caracter - '0';
        }
        else
        {
            return caracter - 'A' + 10;
        }
    }
}
