namespace WeakReferenceSample.WeakTable
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    class Program
    {
        static void Main()
        {
            WeakKey();
            StrongKey();
        }

        private static void WeakKey()
        {
            var people = new[]
            {
                new Person(1, "Jurian Naul"),
                new Person(2, "Thomas Bent"),
                new Person(3, "Ellen Carson"),
                new Person(4, "Katrina Lauran"),
                new Person(5, "Monica Ausbach"),
            };

            var locations = new ConditionalWeakTable<Person, string>();

            locations.Add(people[0], "Shinon");
            locations.Add(people[1], "Lance");
            locations.Add(people[2], "Pidona");
            locations.Add(people[3], "Loanne");
            locations.Add(people[4], "Loanne");

            foreach (var p in people)
            {
                string location;
                if (locations.TryGetValue(p, out location))
                    Console.WriteLine(p.Name + " at " + location);
            }
        }

        private static void StrongKey()
        {
            var people = new[]
            {
                new Person(1, "Jurian Naul"),
                new Person(2, "Thomas Bent"),
                new Person(3, "Ellen Carson"),
                new Person(4, "Katrina Lauran"),
                new Person(5, "Monica Ausbach"),
            };

            var locations = new Dictionary<Person, string>();

            locations.Add(people[0], "Shinon");
            locations.Add(people[1], "Lance");
            locations.Add(people[2], "Pidona");
            locations.Add(people[3], "Loanne");
            locations.Add(people[4], "Loanne");

            foreach (var p in people)
            {
                string location;
                if (locations.TryGetValue(p, out location))
                    Console.WriteLine(p.Name + " at " + location);
            }
        }
    }
}
