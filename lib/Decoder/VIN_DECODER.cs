using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PassThruJ2534.lib.Decoder
{
    public class VIN_DECODER
    {
        // Decode World Manufacturer Identifier (first 3 characters)
        public static string DecodeWMI(string wmi)
        {
            // Expanded list of global manufacturers (sample of some major ones)
            switch (wmi)
            {
                // Australia
                case "6FP": return "Ford (Australia)";
                case "6G1": return "GM Holden (Australia)";
                case "7A3": return "Toyota (Australia)";

                // United States
                case "1HG": return "Honda (USA)";
                case "1FT": return "Ford (USA)";
                case "1G1": return "Chevrolet (USA)";

                // Japan
                case "JHM": return "Honda (Japan)";
                case "JTD": return "Toyota (Japan)";
                case "JF1": return "Subaru (Japan)";

                // Germany
                case "WAU": return "Audi (Germany)";
                case "WVW": return "Volkswagen (Germany)";
                case "WDB": return "Mercedes-Benz (Germany)";

                // Italy
                case "ZFF": return "Ferrari (Italy)";
                case "ZAM": return "Maserati (Italy)";

                // Korea
                case "KNA": return "Kia (South Korea)";
                case "KMH": return "Hyundai (South Korea)";

                // UK
                case "SCC": return "Lotus (United Kingdom)";
                case "SAL": return "Land Rover (United Kingdom)";

                // Add more as needed for a more comprehensive WMI list
                default: return "Unknown Manufacturer";
            }
        }

        // Decode Vehicle Descriptor Section (characters 4-9)
        public static string DecodeVDS(string vds)
        {
            // Sample decoding, could be extended to decode body type, engine type, etc.
            return $"Vehicle Type: {vds.Substring(0, 1)}\n" +
                   $"Model: {vds.Substring(1, 2)}\n" +
                   $"Safety/Equipment: {vds.Substring(3, 1)}\n" +
                   $"Engine Type: {vds.Substring(4, 1)}";
        }

        // Decode Vehicle Identifier Section (characters 10-17)
        public static string DecodeVIS(string vis)
        {
            string yearCode = vis.Substring(0, 1);
            string year = DecodeYear(yearCode);
            return $"Year: {year}\nSerial Number: {vis.Substring(1, 6)}";
        }

        // Decode Year (based on the 10th character)
        public static string DecodeYear(string yearCode)
        {
            // Expanded year decoding from 2000-2024
            switch (yearCode)
            {
                case "Y": return "2000";
                case "1": return "2001";
                case "2": return "2002";
                case "3": return "2003";
                case "4": return "2004";
                case "5": return "2005";
                case "6": return "2006";
                case "7": return "2007";
                case "8": return "2008";
                case "9": return "2009";
                case "A": return "2010";
                case "B": return "2011";
                case "C": return "2012";
                case "D": return "2013";
                case "E": return "2014";
                case "F": return "2015";
                case "G": return "2016";
                case "H": return "2017";
                case "J": return "2018";
                case "K": return "2019";
                case "L": return "2020";
                case "M": return "2021";
                case "N": return "2022";
                case "P": return "2023";
                case "R": return "2024";
                default: return "Unknown Year";
            }
        }
    }
}

