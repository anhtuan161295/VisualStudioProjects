using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    partial interface Assignment_15_ITropCyclone
    {
        string composition(string componentOne, string componentTwo, string componentThree);
        string factors(string factorOne, string factorTwo, string factorThree, string factorFour, string factorFive, string factorSix);
    }
    partial interface Assignment_15_ITropCyclone
    {
        string warningCentres(string warnCentre);
        int speed(int knots);
    }
    partial interface Assignment_15_ITropCyclone
    {
        string effects(string effectOne, string effectTwo, string effectThree, string effectFour, string effectFive);
    }

    class Assignment_15 : Assignment_15_ITropCyclone
    {
        public string composition(string componentOne, string componentTwo, string componentThree){
            return componentOne + "," + componentTwo + "," + componentThree;
        }
        public string warningCentres(string warnCentre){
            return warnCentre;
        }
        public string factors(string factorOne, string factorTwo, string factorThree, string factorFour, string factorFive, string factorSix){
            return factorOne + "," + factorTwo + "," + factorThree + "," + factorFour + "," + factorFive + "," + factorSix;
        }
        public int speed(int knots){
            return knots;
        }
        public string effects(string effectOne, string effectTwo, string effectThree, string effectFour, string effectFive){
            return effectOne + "," + effectTwo + "," + effectThree + "," + effectFour + "," + effectFive;
        }
        static void Main(string[] args){
            Assignment_15 ass_15 = new Assignment_15();
            Console.WriteLine("\t\tTropical Cyclone\n");
            Console.WriteLine("Composition : " + ass_15.composition("Clouds", "Wind", "Thunderstorms\n"));
            Console.WriteLine("WarningCentres : " + ass_15.warningCentres("Regional Specialized Meteorological Centers\n"));
            Console.WriteLine("Factors : " + ass_15.factors("Water Temperatures", "Latent Heat", "Troposphere", "Wind Shear", "Equator", "Coriolis Force\n"));
            Console.WriteLine("Speed : " + ass_15.speed(68) + "\n");
            Console.WriteLine("Effects : " + ass_15.effects("Strong Winds", "Storm Surge", "Tornadoes", "Eyewall Mesovortics", "Precipitation"));
        }
    }
}
