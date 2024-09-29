using Seido.Utilities.SeedGenerator;
namespace GU1_Zoo_record_indexer;

public enum enKind { Moose, Wolf, Deer, Eagle, Hawk, Aligator, Elephant, Lion, Monkey };
public enum enMood { Happy, Sleepy, Sad, Hungry, Lazy, Quick, Slow };

// Vi gör om våran class till en record, record kommer att automatiskt skapa get/set och constructor för: 'Name', 'Age', 'Kind' 'Mood'
public record rcAnimal(string Name, int Age, enKind Kind, enMood Mood)
{
	/*
	Vi vill ha en constructor som slumpar (random:ar) fram alla värden, så här gör vi en ny constructor "rcAnimal(csSeedGenerator rnd)"
	i den constructorn så kallar vi på den automatiskt skapade constructorn med ordet 'this'.
	eftersom record har automatiskt skapat vårat innehåll, så finns det en constructor som ser ut såhär:
		public rcAnimal(string _Name, int _Age, endKind _Kind, enMood _Mood)
		{
			Name = _Name;
			Age = _Age;
			Kind = _Kind;
			Mood = _Mood;
		}
		
		och vi kallar denna constructor this

		så vi skickar in våra slumpade värdet från rnd till this
	*/
	public rcAnimal(csSeedGenerator rnd) : this(rnd.PetName, rnd.Next(1, 100), rnd.FromEnum<enKind>(), rnd.FromEnum<enMood>()) { }

	// Record har också skapat en ToString, men vi vill ha en bättre, så vi gör en här
	public override string ToString() => $"{Name} the {Age} year old {Mood} {Kind}";
}
