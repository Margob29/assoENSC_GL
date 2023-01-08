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

            Role president = new Role
            {
                Name = "Président",
                Description = "Référent du club",
            };


            Role respoEvent = new Role
            {
                Name = "Responsable événements",
                Description = "Les meilleurs quoi",
            };

            context.Roles.AddRange(respoEvent, president);

            // Add student
            Student alaudebert = new Student
            {
                Name = "Alaudebert",
                EmailAdress = "alaudebert@ensc.fr",
                Promo = 2024,
            };
            Student mbiret = new Student
            {
                Name = "Mbiret",
                EmailAdress = "mbiret@ensc.fr",
                Promo = 2024,
            };
            Student classerre = new Student
            {
                Name = "CLasserre",
                EmailAdress = "classerre@ensc.fr",
                Promo = 2025,
            };
            context.Students.AddRange(alaudebert, mbiret);

            //Add group
            Group BDS = new Group
            {
                Name = "BDS",
                // President = alaudebert,
                Description = "C'est ce qu'a affirmé, sur Telegram, le chef adjoint du cabinet de la présidence ukrainienne, Kirill Timoshenko. « Cinq femmes qui venaient d'accoucher étaient encore présentes. Miraculeusement, personne n'a été blessé », a-t-il expliqué.",
            };

            Group BDE = new Group
            {
                Name = "BDE",
                // President = mbiret,
                Description = "C'est ce qu'a affirmé, sur Telegram, le chef adjoint du cabinet de la présidence ukrainienne, Kirill Timoshenko. « Cinq femmes qui venaient d'accoucher étaient encore présentes. Miraculeusement, personne n'a été blessé », a-t-il expliqué.",
            };
            context.Groups.AddRange(BDS, BDE);
            context.SaveChanges();

            Member mmbiret = new Member
            {
                Group = BDE,
                Student = mbiret,
                Role = president,
            };
            Member mclasserre = new Member
            {
                Group = BDE,
                Student = classerre,
                Role = respoEvent,
            };
            Member malaudebert = new Member
            {
                Group = BDS,
                Student = alaudebert,
                Role = president,
            };

            context.Members.AddRange(mmbiret, malaudebert, mclasserre);

            var bds = context.Groups.Where(g => g.Name == "BDS").FirstOrDefault();

            // Vérifier que le groupe a été trouvé
            if (bds != null)
            {
                // Incrémenter le compteur de membre
                bds.NbMembers = 1;
            }

            var bde = context.Groups.Where(g => g.Name == "BDE").FirstOrDefault();

            // Vérifier que le groupe a été trouvé
            if (bde != null)
            {
                // Incrémenter le compteur de membre
                bde.NbMembers = 2;
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