using System;
using System.Collections.Generic;
using System.Linq;

namespace Project2 {
	public static class Extentions {
		private static readonly Dictionary<char, int> RomanMap = new Dictionary<char, int> { // From https://stackoverflow.com/a/26667855/3485939
			{'I', 1},
			{'V', 5},
			{'X', 10},
			{'L', 50},
			{'C', 100},
			{'D', 500},
			{'M', 1000}
		};

		public static int RomanToInteger(string roman) {
			int number = 0;
			for(int i = 0; i < roman.Length; i++)
				if(i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
					number -= RomanMap[roman[i]];
				else
					number += RomanMap[roman[i]];

			return number;
		}

		public static string ToRoman(int number) { //From https://stackoverflow.com/a/11749642/3485939
			if(number < 0 || number > 3999) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
			if(number < 1) return string.Empty;
			if(number >= 1000) return "M" + ToRoman(number - 1000);
			if(number >= 900) return "CM" + ToRoman(number - 900);
			if(number >= 500) return "D" + ToRoman(number - 500);
			if(number >= 400) return "CD" + ToRoman(number - 400);
			if(number >= 100) return "C" + ToRoman(number - 100);
			if(number >= 90) return "XC" + ToRoman(number - 90);
			if(number >= 50) return "L" + ToRoman(number - 50);
			if(number >= 40) return "XL" + ToRoman(number - 40);
			if(number >= 10) return "X" + ToRoman(number - 10);
			if(number >= 9) return "IX" + ToRoman(number - 9);
			if(number >= 5) return "V" + ToRoman(number - 5);
			if(number >= 4) return "IV" + ToRoman(number - 4);
			if(number >= 1) return "I" + ToRoman(number - 1);
			throw new ArgumentOutOfRangeException("something bad happened");
		}

		public static IEnumerable<T> NonDistinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, int requiredCount = 1) {
			//From https://stackoverflow.com/a/15968878/3485939
			return source.GroupBy(keySelector).Where(g => g.Count() > requiredCount).SelectMany(r => r);
		}

		public static IEnumerable<T> MaxMultiple<T>(this IEnumerable<T> source) {
			IOrderedEnumerable<IGrouping<T, T>> test = source.GroupBy(i => i).OrderByDescending(g => g.Count());
			return test.Where(g => g.Count() == test.First().Count()).Select(r => r.Key).ToArray();
		}
	}
}