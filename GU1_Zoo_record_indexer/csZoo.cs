using Seido.Utilities.SeedGenerator;

namespace GU1_Zoo_record_indexer;

// Record, fungerar precis som i csAnimal (läs där)
public record rcZoo(string NameOfZoo, List<rcAnimal> animals)
{
	// Här gör vi en ny constructor som lånar ifrån den automatiskt genererade constructorn från record
	public rcZoo(string _nameOfZoo, int numberOfAnimals) : this(_nameOfZoo, []) // '[]' betyder här att vi skickar in en tom lista som start för våran lista
	{
		var rnd = new csSeedGenerator();
		for (int i = 0; i < numberOfAnimals; i++)
		{
			animals.Add(new rcAnimal(rnd));
		}
	}

	// Här ger vi vårat zoo ett standard namn
	public rcZoo() : this("Biggest zoo", [])
	{
		var rnd = new csSeedGenerator();

		foreach (enKind kind in Enum.GetValues(typeof(enKind)))
		{
			foreach (enMood mood in Enum.GetValues(typeof(enMood)))
			{
				animals.Add(new rcAnimal(rnd) { Kind = kind, Mood = mood });
			}
		}

	}


	// Här är vad vi kallar för en indexer, den skickar tillbaka en string, när vi skriver till exempel smallZoo[0], då skickar den tillbaka det första djuret i smallZoo.animals
	public string this[int idx]
	{
		get
		{
			if (idx >= animals.Count) throw new IndexOutOfRangeException();
			return animals[idx].ToString();
		}
	}

	public override string ToString()
	{
		string ret = NameOfZoo + "\n";
		foreach (var animal in animals)
		{
			ret += animal + "\n";
		}
		return ret;
	}
}
