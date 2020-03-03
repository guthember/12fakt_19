using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace nezoter
{
  class Program
  {
    static char[,] fogl = new char[15, 20];
    static int[,] kat = new int[15, 20];
    static int[] eladtak = new int[6];
    
    static void Elso() 
    {
      // Adatok beolvasása
      Console.WriteLine("1. feladat");

      StreamReader file = new StreamReader("foglaltsag.txt");

      for (int i = 0; i < 15; i++)
      {
        string sor = file.ReadLine();
        for (int j = 0; j < 20; j++)
        {
          fogl[i, j] = sor[j];
        }
      }

      file.Close();

      StreamReader fKat = new StreamReader("kategoria.txt");

      for (int i = 0; i < 15; i++)
      {
        string sor = fKat.ReadLine();
        for (int j = 0; j < 20; j++)
        {
          kat[i, j] = Convert.ToInt32(sor[j].ToString());
        }
      }

      fKat.Close();


    }

    static void Masodik()
    {
      Console.WriteLine("\n2. feladat");
      Console.Write("Kérek egy sort: ");
      int sor = Convert.ToInt32(Console.ReadLine()) - 1;
      Console.Write("Kérek egy szek: ");
      int szek = Convert.ToInt32(Console.ReadLine()) - 1;
      if (fogl[sor, szek] == 'o')
      {
        Console.WriteLine("Ez szabad!");
      }
      else
      {
        Console.WriteLine("Ez foglalt");
      }
    }

    static void Harmadik()
    {
      Console.WriteLine("\n3. feladat");
      int db = 0;
      for (int i = 0; i < 15; i++)
      {
        for (int j = 0; j < 20; j++)
        {
          if (fogl[i,j] == 'x')
          {
            db++;
          }
        }

      }

      double mennyi = Math.Round(((double) db / 300 * 100), 0);
      Console.WriteLine("Az előadásra eddig {0} adatak el, ez az nézőtér {1}%-a",db, mennyi);

    }

    static void Negyedik()
    {
      Console.WriteLine("\n4. feladat");

      for (int i = 0; i < 15; i++)
      {
        for (int j = 0; j < 20; j++)
        {
          if (fogl[i,j]== 'x')
          {
            eladtak[kat[i, j]]++;
          }
        }
      }

      int max = 1; // azt feltételezzük, hogy az első kategória
                   // a legnagyobb
      for (int i = 2; i < 6; i++)
      {
        if (eladtak[max] < eladtak[i])
        {
          max = i;
        }
      }

      Console.WriteLine("A legtöbb jegyet a(z) {0}. kategóriában adták el.",max);
    }

    static void Otodik()
    {
      Console.WriteLine("\n5. feladat");
      int ossz = eladtak[1]* 5000 + eladtak[2] * 4000 + eladtak[3] * 3000+
        eladtak[4] * 2000 + eladtak[5] * 1500;
      Console.WriteLine("Bevétel: {0}",ossz);
    }


    static void Hatodik()
    {
      Console.WriteLine("\n6. feladat");
      int ures = 0;

      for (int i = 0; i < 15; i++)
      {
        if (fogl[i,0] == 'o' && fogl[i,1] == 'x')
        {
          ures++;
        }
        if (fogl[i, 19] == 'o' && fogl[i, 18] == 'x')
        {
          ures++;
        }

        for (int j = 1; j < 19; j++)
        {
          if (fogl[i, j] == 'o' && fogl[i, j - 1] == 'x' && fogl[i, j + 1] == 'x')
          {
            ures++;
          }
        }
      }

      Console.WriteLine("Üres helyek száma: {0}",ures);
    }

    static void Hetedik()
    {
      Console.WriteLine("\n7. feladat");
      Console.WriteLine("Adatok fájlba írása");
      StreamWriter ki = new StreamWriter("szabad.txt");

      for (int i = 0; i < 15; i++)
      {
        string sor = "";

        for (int j = 0; j < 20; j++)
        {
          if (fogl[i,j] == 'o')
          {
            sor += kat[i, j];
          }
          else
          {
            sor += 'x';
          }
        }
        ki.WriteLine(sor);
      }


      ki.Close();
    }


    static void Main(string[] args)
    {
      Elso();
      Masodik();
      Harmadik();
      Negyedik();
      Otodik();
      Hatodik();
      Hetedik();
      Console.ReadLine();
    }
  }
}
