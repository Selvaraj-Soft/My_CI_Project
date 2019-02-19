using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Topics
{
   public class RegeXP
    {
       private static string str,pattern, GameNameIndex;
        public static string[] obj;
        static void _findStartChar()
         {

             str = "System.Text.RegularExpressions.Regex-Ector (System.String pattern, System.Text.RegularExpressions.RegexOptions options, System.TimeSpan matchTimeout, System.Boolean useCache) [0x000c6] in <a67b90c5acf54694896b770f716b945d>:0 ";
            MatchCollection mac = Regex.Matches(str, @"\bT\S*"); //<------Regex used for extracting the Starting Letter Word('S')

            foreach (var extractedData in mac)
            {
                Console.WriteLine(extractedData);
            }

            MatchCollection mac1 = Regex.Matches(str, @"\bS\S*g\b");//<------Regex used for extracting with Starting & End Letter  Word('S' & 'g')
            foreach (var extractedData1 in mac1)
            {
                Console.WriteLine(extractedData1);
            }

        }


        static void _replace()
        {

            str = "A character class matches any one of a set of characters. The following table describes the character classes − ";
             pattern = "\\s+";  //<-- Finding whitespaces(\s) between the strings & replaces with custom string("_")
            string replacement = "_";
            Regex obj = new Regex(pattern);
            string result = obj.Replace(str, replacement);
            Console.WriteLine(result);
        }

        static void _match_date()
        {
            pattern = @"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}";
            string patternB = @"^[a-z]\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}";

            Regex reg = new Regex(pattern);
            Regex reg1 = new Regex(patternB);

            string[] str = { "+91-9678967101", "9678967101457A", "+91-9678-967101", "+91-96789-67101", "+919678967101" };
            //Input strings for Match valid mobile number. 

            Console.WriteLine("\n"+reg1.IsMatch(str[1])+" ---->>"+ "The following {0} number is valid with Country code,fourdigit operator code,6digit unique code",str[1]);
            
            foreach (string data in str)
            {
                Console.WriteLine("\n" + reg.IsMatch(data) + " ---->>" + "The following {0} number is valid with Country code,fourdigit operator code,6digit unique code", data);
            }

        }
        public static string pchregex()
        {
            

            var response = "  <a href=\"/iw-paths/5k-chefs-special?ref=featured&gamega=24210/FeaturedArea/FA20000-6\" data-onclick=\"PCHGA.trackEvent('InstantWin', 'pathstart', '5-000-00-chefs-special/FeaturedArea/FA20000-6'); \" >\r\n                            \t\t\t\t\t\t\t\t   <img  width=\"650\" height=\"400\"  src=\"/images/24210/ChefSpecial-HP_Module_650x400_2017.gif\"/>\r\n\t\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t\t</div>\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t<div class=\"imagediv\" id=\"mg_16\" >\r\n\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t<!-- Banner removed per B-17080 Remove all tags from featured area -->\r\n                                                        <a href=\"/iw-paths/2-500-00-smart-home?ref=featured&gamega=20123/FeaturedArea/FA20000-7\" data-onclick=\"PCHGA.trackEvent('InstantWin', 'pathstart', '2-500-00-smart-home/FeaturedArea/FA20000-7')";

            string mypattern = "<a href=\"/iw-paths/(.*?)?ref=featured";

            var myRegex = new Regex(mypattern);

            Console.WriteLine("*** Is there a Match? ***");
            if (myRegex.IsMatch(response))
            {
                Console.WriteLine("Yes");
            }
            else Console.WriteLine("No");

            MatchCollection AllMatches = myRegex.Matches(response);
            Match mymatch = myRegex.Match(response);
            obj = new string[mymatch.Length];
            Console.WriteLine("Singhle match -->"+mymatch.Value);
            for (int i = 0; i < mymatch.Length; i++)
            {
                obj[i] = mymatch.Groups[1].Value;
                Console.WriteLine(mymatch.Groups[1].Value + "<<--------Single match values");
                
                mymatch = mymatch.NextMatch();
               
            }
            GameNameIndex = obj[0];

            Console.WriteLine("\n" + "*** Number of Matches ***");
            Console.WriteLine(AllMatches.Count);          
            
            
                //for (int i=0;i< AllMatches.Count;i++)
                //{
                //foreach (Match SomeMatch in AllMatches)
                //{
                //    obj[i] = SomeMatch.Groups[1].Value;
                //    //string data = obj[1];
                //    Console.WriteLine("Matches--->>" + obj[i]);
                //}
                                     
                //}
               
            
            
            return obj[1];
            
        }

        public static void Main(string[] args)
        {
            //_findStartChar();
            //_replace();
            //_match_date();
            pchregex();
            Console.WriteLine(obj[1]+"Print value");
            Console.WriteLine(GameNameIndex + "Print Index value");

            Console.ReadLine();
        }

    }
}
