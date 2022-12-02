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
                President = alaudebert,
            };
            context.Groups.Add(BDS);

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
                GroupeId = BDS,
                Date = new DateTime(2022, 11, 27),
                Name = "Interpromo",
                Description = "Tournoi sportif entre les promos !",
            };
            Event secretSanta = new Event
            {
                GroupeId = BDS,
                Date = new DateTime(2022, 12, 07),
                Name = "Secret Santa Raclette",
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