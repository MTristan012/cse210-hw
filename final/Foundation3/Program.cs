class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Elm St", "Salt Lake", "UT", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Address address3 = new Address("Escarcega 9", "Ometoxtla", "Pue", "Mexico");

        Event lecture = new Lecture("C# Programming", "Learn about C# and .NET", new DateTime(2024, 6, 01), "10:00 AM", address1, "Vaughn Poulson", 100);
        Event reception = new Reception("Company Party", "End of year celebration", new DateTime(2024, 12, 20), "7:00 PM", address2, "notreal@email.com");
        Event outdoorGathering = new OutdoorGathering("Picnic", "Anniversary picnic", new DateTime(2024, 8, 10), "12:00 PM", address3, "Sunny");

        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(outdoorGathering.GetFullDetails());
    }
}