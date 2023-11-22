namespace Web_atrio.Donnees
{
    public class DbInitializer
    {
        public static void Initialize(PersonneContext context)
        {

            if (context.Personnes.Any()
                && context.Emploies.Any())
            {
                return;   // DB has been seeded
            }

            var cto = new Emploi { NomEntreprise = "Microsoft", PosteOccupe = "CTO", DateDebut = new DateTime(2008, 3, 1, 7, 0, 0) };
            var rh = new Emploi { NomEntreprise = "Google", PosteOccupe = "RH", DateDebut = new DateTime(2010, 8, 3, 6, 0, 0) };
            var ingenieur = new Emploi { NomEntreprise = "FaceBook", PosteOccupe = "ingenieur", DateDebut = new DateTime(2018, 7, 2, 5, 0, 0) };
            var manager = new Emploi { NomEntreprise = "Tesla", PosteOccupe = "Manager", DateDebut = new DateTime(2020, 6, 1, 7, 0, 0) };
            var Admin = new Emploi { NomEntreprise = "airbus", PosteOccupe = "Admin", DateDebut = new DateTime(2023, 2, 4, 9, 0, 0) };

            var personnes = new Personne[]
            {
                new Personne
                {
                        Nom  = "Laurent",
                        Prenom = "Descarte",
                        DateNaissance = new DateTime(1970,4,3,4,3,3),
                        Emploies = new List<Emploi>()
                        {
                            Admin,
                            ingenieur,
                        }
                },
                new Personne
                {
                        Nom  = "Jean",
                        Prenom = "Socrate",
                        DateNaissance = new DateTime(1970,4,3,4,3,3),
                        Emploies = new List<Emploi>()
                        {
                            cto,
                            rh,
                            ingenieur
                        }
                },
                new Personne
                {
                        Nom  = "Paul",
                        Prenom = "Spinoza",
                        DateNaissance = new DateTime(1970,4,3,4,3,3),
                }
            };

            context.Personnes.AddRange(personnes);
            context.SaveChanges();
        }
    }
}
