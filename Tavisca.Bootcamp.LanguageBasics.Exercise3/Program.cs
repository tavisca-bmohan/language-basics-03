using System;
using System.Collections.Generic;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        public class Dish
        {
            public int P, C, F, T, index;
            public Dish(int i, int p, int c, int f)
            {
                index = i;
                P = p;
                C = c;
                F = f;
                T = 5 * p + 5 * c + 9 * f;
            }
        }

        class sortByVal : IComparer<Dish>
        {
            char x;
            public sortByVal(char c)
            {
                x = c;
            }
            public int Compare(Dish d1, Dish d2)
            {
                //Dish d1 = (Dish)a;
                //Dish d2 = (Dish)b;
                switch (x)
                {
                    case 'p':
                        return (d1.P > d2.P) ? 1 : ((d1.P < d2.P) ? -1 : 0);
                    case 'c':
                        return (d1.C > d2.C) ? 1 : ((d1.C < d2.C) ? -1 : 0);
                    case 't':
                        return (d1.T > d2.T) ? 1 : ((d1.T < d2.T) ? -1 : 0);
                    case 'f':
                        return (d1.F > d2.F) ? 1 : ((d1.F < d2.F) ? -1 : 0);
                    case 'P':
                        return (d1.P > d2.P) ? -1 : ((d1.P < d2.P) ? 1 : 0);
                    case 'C':
                        return (d1.C > d2.C) ? -1 : ((d1.C < d2.C) ? 1 : 0);
                    case 'T':
                        return (d1.T > d2.T) ? -1 : ((d1.T < d2.T) ? 1 : 0);
                    case 'F':
                        return (d1.F > d2.F) ? -1 : ((d1.F < d2.F) ? 1 : 0);
                }
                return 0;
            }
        }

        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            // Add your code here.
            int n = protein.Length;
            Dish[] dis = new Dish[n];
            for (int i = 0; i < n; i++)
            {
                dis[i] = new Dish(i, protein[i], carbs[i], fat[i]);
                //di.Add(d);
            }

            int[] ans = new int[dietPlans.Length];
            int j = 0;
            string s;
            foreach (string st in dietPlans)
            {
                s = st;
                List<Dish> al = new List<Dish>(dis);
                for (int i = 0; i < s.Length; i++)
                {
                    List<Dish> li = new List<Dish>();
                    char c = s[i];
                    al.Sort(new sortByVal(c));
                    Dish dish = al[0];
                    foreach (Dish k in al)
                    {
                        switch (c)
                        {
                            case 'p':
                                if (k.P == dish.P) li.Add(k);
                                break;
                            case 'P':
                                if (k.P == dish.P) li.Add(k);
                                break;
                            case 'c':
                                if (k.C == dish.C) li.Add(k);
                                break;
                            case 'C':
                                if (k.C == dish.C) li.Add(k);
                                break;
                            case 'f':
                                if (k.F == dish.F) li.Add(k);
                                break;
                            case 'F':
                                if (k.F == dish.F) li.Add(k);
                                break;
                            case 't':
                                if (k.T == dish.T) li.Add(k);
                                break;
                            case 'T':
                                if (k.T == dish.T) li.Add(k);
                                break;
                        }
                    }
                    al.Clear();
                    foreach (Dish k in li)
                        al.Add(k);
                }
                ans[j] = al[0].index;
                j++;
            }

            return ans;
            throw new NotImplementedException();
        }
    }
}
