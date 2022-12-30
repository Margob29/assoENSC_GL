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
                Promo = 2024,
                Status = 3,
            };
            Student mbiret = new Student
            {
                Name = "Mbiret",
                EmailAdress = "mbiret@ensc.fr",
                Promo = 2024,
                Status = 3,
            };
            context.Students.AddRange(alaudebert, mbiret);

            //Add group
            Group BDS = new Group
            {
                Name = "BDS",
                // President = alaudebert,
                Description = "C'est ce qu'a affirmé, sur Telegram, le chef adjoint du cabinet de la présidence ukrainienne, Kirill Timoshenko. « Cinq femmes qui venaient d'accoucher étaient encore présentes. Miraculeusement, personne n'a été blessé », a-t-il expliqué.",
                Students = new List<Student> { alaudebert, mbiret }
            };

            Group BDE = new Group
            {
                Name = "BDE",
                // President = mbiret,
                Description = "C'est ce qu'a affirmé, sur Telegram, le chef adjoint du cabinet de la présidence ukrainienne, Kirill Timoshenko. « Cinq femmes qui venaient d'accoucher étaient encore présentes. Miraculeusement, personne n'a été blessé », a-t-il expliqué.",
                Students = new List<Student> { alaudebert }
            };
            context.Groups.AddRange(BDS, BDE);
            context.SaveChanges();

            var bds = context.Groups.Where(g => g.Name == "BDS").FirstOrDefault();

            // Vérifier que le groupe a été trouvé
            if (bds != null)
            {
                // Incrémenter le compteur de membre
                bds.NbMembers = 2;
            }

            var bde = context.Groups.Where(g => g.Name == "BDE").FirstOrDefault();

            // Vérifier que le groupe a été trouvé
            if (bde != null)
            {
                // Incrémenter le compteur de membre
                bde.NbMembers = 1;
            }

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
            Event krystal = new Event
            {
                Group = BDS,
                Date = new DateTime(2022, 11, 27),
                Name = "Krystal",
                Description = "Tournoi sportif entre les écoles !",
            };
            Event wes = new Event
            {
                Group = BDS,
                Date = new DateTime(2022, 12, 07),
                Name = "WES",
                Description = "Week end ski",
            };

            context.Events.AddRange(interpromo, secretSanta, krystal, wes);

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