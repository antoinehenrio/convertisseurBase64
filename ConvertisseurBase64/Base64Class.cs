using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConvertisseurBase64
{
    public static class Base64Class
    {
        public static string Encode(byte[] source)
        {
            Stopwatch stopwatch = new();
            
            string result = "";
            string binary = "";
            int i;
            int sourceSize = source.Length;
            for (i = 0; i < sourceSize; i++)
            {
                binary += Convert.ToString(source[i], 2).PadLeft(8, '0');
            }
            int size = binary.Length;
            int nbGroupes = size / 6;
            int countOctets = 0;
            while (countOctets < size)
            {
                Double numericValue = binaryToNumeric(binary.Substring(countOctets, 6));
                countOctets += 6;
                result += Base64Letters[(int) numericValue].ToString();
            }
            return result;
        }

        public static int binaryToNumeric(string binary)
        {
            
            int compteur;
            double converted = 0;
            for (compteur = 0; compteur < 6; compteur++)
            {
                double power = 5 - compteur;
                double toPower = Double.Parse(binary.Substring(compteur, 1));
                double result = Math.Pow(2, power) * toPower;
                converted += result;
            }
            return (int) converted;
        }

        private static readonly char[] Base64Letters = new[]
                                        {
                                              'A'
                                            , 'B'
                                            , 'C'
                                            , 'D'
                                            , 'E'
                                            , 'F'
                                            , 'G'
                                            , 'H'
                                            , 'I'
                                            , 'J'
                                            , 'K'
                                            , 'L'
                                            , 'M'
                                            , 'N'
                                            , 'O'
                                            , 'P'
                                            , 'Q'
                                            , 'R'
                                            , 'S'
                                            , 'T'
                                            , 'U'
                                            , 'V'
                                            , 'W'
                                            , 'X'
                                            , 'Y'
                                            , 'Z'
                                            , 'a'
                                            , 'b'
                                            , 'c'
                                            , 'd'
                                            , 'e'
                                            , 'f'
                                            , 'g'
                                            , 'h'
                                            , 'i'
                                            , 'j'
                                            , 'k'
                                            , 'l'
                                            , 'm'
                                            , 'n'
                                            , 'o'
                                            , 'p'
                                            , 'q'
                                            , 'r'
                                            , 's'
                                            , 't'
                                            , 'u'
                                            , 'v'
                                            , 'w'
                                            , 'x'
                                            , 'y'
                                            , 'z'
                                            , '0'
                                            , '1'
                                            , '2'
                                            , '3'
                                            , '4'
                                            , '5'
                                            , '6'
                                            , '7'
                                            , '8'
                                            , '9'
                                            , '+'
                                            , '/'
                                        };

    }
}
