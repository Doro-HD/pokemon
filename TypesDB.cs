namespace Pokemon {

	public enum Type {
		FIRE,
		GRASS
	}

	namespace Combat {

		public class TypeComparator {

			private static List<String> defenderColumns;
			private static List<List<String>> attackerRows;

			public static void CompareTypes(Type attacker, Type defender) {
				if (defenderColumns.Count == 0 && attackerRows.Count == 0) {
					Load();
				}

				var defenderIndex = defenderColumns.IndexOf(defender.ToString());

				int? attackerIndex = null;
				var attackIterator = attackerRows.GetEnumerator();
				var i = 0;
				var searchingForAttackIndex = true;
				while (attackIterator.MoveNext() && searchingForAttackIndex) {
					var row = attackIterator.Current;
					if (row[0].Equals(attacker.ToString())) {
						attackerIndex = i;
						searchingForAttackIndex = false;
					} else {
						i++;
					}
				}

				if (attackerIndex.HasValue()) {
					var typeComparator = attackerRows[attackerIndex][defenderIndex];
					Console.WriteLine(typeComparator);
				}

			}

			public static void Load() {
				var typeReader = new File.TypeReader();
				var types = typeReader.Read();

				var columns = types.ElementAt(0);
				defenderColumns.AddRange(columns);

				var rows = types.GetRange(1, types.Count);
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