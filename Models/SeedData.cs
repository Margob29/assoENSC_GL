namespace ENSC.Data;
using ENSC.Models;
public class SeedData
{
    public static void InitBd()
    {
        using (var context = new ENSCContext())
        {
            //If BD is empty
            if (context.Events.Any())
            {
                return;
            }
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
                President = alaudebert,
            };
            Group BDE = new Group
            {
                Name = "BDE",
                President = mbiret,
            };
            context.Groups.AddRange(BDS, BDE);

            //Add member
            Member Margo = new Member
            {
                IdStudent = mbiret,
                IdGroup = BDS,
            };
            Member Alex = new Member
            {
                IdStudent = alaudebert,
                IdGroup = BDS,
            };
            context.Members.AddRange(Margo, Alex);

            //Add events
            Event interpromo = new Event
            {
                Group = BDS,
                Date = new DateTime(2022, 11, 27),
                Name = "Interpromo",
                Description = "Tournoi sportif entre les promos !",
            };
            Event secretSanta = new Event
            {
                Group = BDE,
                Date = new DateTime(2022, 12, 07),
                Name = "Gala",
                Description = "Petite soirée chill entre nous",
            };
            context.Events.AddRange(interpromo, secretSanta);

            //Add GroupViewer
            GroupViewer BDSSecretSanta = new GroupViewer
            {
                IdEvent = secretSanta,
                IdGroup = BDS,
            };
            context.GroupViewers.Add(BDSSecretSanta);
            context.SaveChanges();
        }
    }
}