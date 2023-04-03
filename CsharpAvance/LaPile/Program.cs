using LaPile.Classes;

Pile<string> pileString = new Pile<string>();
pileString.Push("Coucou0");
pileString.Push("Coucou1");
pileString.Push("Coucou2");
pileString.Push("Coucou3");
pileString.Push("Coucou4");
pileString.Pop();
Console.WriteLine(pileString.Get(2));
Console.WriteLine("--------------");

Pile<decimal> pileDecimal = new Pile<decimal>();
pileDecimal.Push(10m);
pileDecimal.Push(10.1m);
pileDecimal.Push(10.2m);
pileDecimal.Push(10.3m);
pileDecimal.Push(10.4m);
pileDecimal.Pop();
Console.WriteLine(pileDecimal.Get(2));
Console.WriteLine("--------------");

Pile<Personne> pilePersonne = new Pile<Personne>();
pilePersonne.Push(new Personne("Maxime", "Maillot", 0));
pilePersonne.Push(new Personne("Maxime", "Maillot", 1));
pilePersonne.Push(new Personne("Maxime", "Maillot", 2));
pilePersonne.Push(new Personne("Maxime", "Maillot", 3));
pilePersonne.Push(new Personne("Maxime", "Maillot", 4));
Console.WriteLine(pilePersonne.Get(2));