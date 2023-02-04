namespace Pokemon {

	public enum Type {

		Normal,
		Fire,
		Water,
		Electric,
		Grass,
		Ice,
		Fighting,
		Poison,
		Ground,
		Flying,
		Psychic,
		Bug,
		Rock,
		Ghost,
		Dragon,
		Dark,
		Steel,
		Fairy
	}

	namespace Combat {

		public enum TypeComparison {
			Resistant,
			Neutral,
			Weak,
			Immune
		}

		public class TypeComparator {

			private static List<string> defenderColumns = new List<string>();
			private static List<List<string>> attackerRows = new List<List<string>>();

			public static TypeComparison? CompareTypes(Type attacker, Type defender) {
				TypeComparison? typeComparison = null;

				if (defenderColumns.Count == 0 && attackerRows.Count == 0) {
					Load();
				}

				var defenderIndex = defenderColumns.IndexOf(defender.ToString());

				int? attackerIndexOption = null;
				var attackIterator = attackerRows.GetEnumerator();
				var i = 0;
				var searchingForAttackIndex = true;
				while (attackIterator.MoveNext() && searchingForAttackIndex) {
					var row = attackIterator.Current;
					if (row[0].Equals(attacker.ToString())) {
						attackerIndexOption = i;
						searchingForAttackIndex = false;
					} else {
						i++;
					}
				}

				if (attackerIndexOption.HasValue) {
					var attackerIndex = attackerIndexOption.Value;
					var typeComparator = attackerRows[attackerIndex][defenderIndex + 1];
					
					TypeComparison tempTypeComparison;
					var wasParsed = Enum.TryParse(typeComparator, out tempTypeComparison);

					if (wasParsed) {
						typeComparison = tempTypeComparison;
					}
				}

				return typeComparison;
			}

			public static void Load() {
				var typeReader = new File.TypeReader();
				var types = typeReader.Read();

				var columns = types.ElementAt(0);
				defenderColumns.AddRange(columns);

				var rows = types.GetRange(1, types.Count - 1);
				attackerRows.AddRange(rows);
			}
		}	
	}
}

namespace Pokemon.File {

	public class TypeReader {
		
		public List<List<String>> Read() {
			var types = new List<List<String>>();

			try {
				using (StreamReader sr = new StreamReader("types.csv")) {
					string line;

					while ((line = sr.ReadLine()) != null) {
						var row = new List<String>();
						var lineSplit = line.Split(",");

						row.AddRange(lineSplit);
						types.Add(row);
					}
				}
			} catch (Exception e) {
				Console.WriteLine("Could not read file.");
				Console.WriteLine(e.Message);
			}

			return types;
		}
	}
}