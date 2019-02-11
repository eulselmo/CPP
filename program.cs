using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.IO;
//Añadir el segundo parámetro
class CoutriesOfTheWorld
{

    public static void Main()
    {
        String[] args = Environment.GetCommandLineArgs();
        if (args.Length == 1) {
         Console.WriteLine("There are no command line arguments.");
         return;
        }

        String  theContinent = args[1];

        IEnumerable<Country> Countries = GetCountries();
        Console.WriteLine("The number of countries: {0}", Countries.Count()); 
        Console.WriteLine();  

        var result = from c in Countries
                where c.Continent == theContinent && c.Population / c.Area > 70
                orderby c.Population/c.Area descending
                select c;

        foreach(Country c in result)
        {
            Console.WriteLine(String.Format("{0, -25} {1, 15:n0} {2, 15:n0} {3, 10:n1}", c.Name, c.Population, c.Area, 1.0*c.Population/c.Area));
        }

    }


       public class Country
        {
            public string Name { get; set; }
            public string Continent { get; set; }
            public int Population { get; set; }
            public int Area { get; set; }
            public double Gdp2010 { get; set; } 
        }

   
    public static IEnumerable<Country> GetCountries()
    {
        var countries = System.IO.File.ReadAllLines("data.csv");
 
        
        return (from line in countries
                let fields = line.Split(',')
                
                select new Country()
                {
                    Name = fields[0].Trim(),
                    Continent = fields[1].Trim(),
                    Population = Convert.ToInt32(fields[2].Trim()),
                    Area = Convert.ToInt32(fields[3].Trim()),   
                    Gdp2010 = Convert.ToDouble(fields[6].Trim())
                });
               
    }

}
