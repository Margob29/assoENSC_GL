namespace Data;
using ENSC;
public class SeedData
{
    public static void InitBd()
    {
        using (var context = new ENSCContext())
        {
            // Add student
            Student alaudebert = new Student
            {
                Name = "Alaudebert",
                EmailAdress = "alaudebert@ensc.fr",
                Promo = new DateTime(2024),
                Status = 3,

            };
            Student mbiret = new Student
            {
                Name = "Mbiret",
                EmailAdress = "mbiret@ensc.fr",
                Promo = new DateTime(2024),
                Status = 3,

            };
            context.Students.AddRange(alaudebert, mbiret);

            //Add group
            Group BDS = new Group
            {
                Name = "BDS",

            };
            context.Groups.AddRange(BDS);

            context.SaveChanges();
        }
    }
}