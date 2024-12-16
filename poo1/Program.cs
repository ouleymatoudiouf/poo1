using System;
using System.Collections.Generic;

class Personne
{
    protected string nom;
    protected string prenom;

    public Personne(string nom, string prenom)
    {
        this.nom = nom;
        this.prenom = prenom;
    }

    public virtual void AfficherDetails()
    {
        Console.WriteLine($"Nom : {nom}, Prénom : {prenom}");
    }
}

class Enseignant : Personne
{
    private string matiere;

    public Enseignant(string nom, string prenom, string matiere) : base(nom, prenom)
    {
        this.matiere = matiere;
    }

    public override void AfficherDetails()
    {
        base.AfficherDetails();
        Console.WriteLine($"Matière enseignée : {matiere}");
    }
}

class Etudiant : Personne
{
    private string niveauEtudes;

    public Etudiant(string nom, string prenom, string niveauEtudes) : base(nom, prenom)
    {
        this.niveauEtudes = niveauEtudes;
    }

    public override void AfficherDetails()
    {
        base.AfficherDetails();
        Console.WriteLine($"Niveau d'études : {niveauEtudes}");
    }
}

interface IPersonne
{
    void AjouterPersonne(Personne personne);
    void AfficherPersonnes();
    void AfficherEnseignants();
    void AfficherEtudiants();
}

class IPersonneImpl : IPersonne
{
    private List<Personne> personnes = new List<Personne>();

    public void AjouterPersonne(Personne personne)
    {
        personnes.Add(personne);
        Console.WriteLine("Personne ajoutée avec succès !");
    }

    public void AfficherPersonnes()
    {
        foreach (Personne p in personnes)
        {
            p.AfficherDetails();
            Console.WriteLine("");
        }
    }

    public void AfficherEnseignants()
    {
        foreach (Personne p in personnes)
        {
            if (p is Enseignant)
            {
                p.AfficherDetails();
                Console.WriteLine("");
            }
        }
    }

    public void AfficherEtudiants()
    {
        foreach (Personne p in personnes)
        {
            if (p is Etudiant)
            {
                p.AfficherDetails();
                Console.WriteLine("            ");
            }
        }
    }
}

class GestionPersonnes
{
    static void Main(string[] args)
    {
        IPersonneImpl gestionnaire = new IPersonneImpl();
        int choix;

        do
        {
            Console.WriteLine("\nMenu :");
            Console.WriteLine("1. Ajouter une personne");
            Console.WriteLine("2. Afficher toutes les personnes");
            Console.WriteLine("3. Afficher tous les enseignants");
            Console.WriteLine("4. Afficher tous les étudiants");
            Console.WriteLine("5. Quitter");
            Console.Write("Votre choix : ");

            if (!int.TryParse(Console.ReadLine(), out choix))
            {
                Console.WriteLine("Entrée invalide, veuillez entrer un numéro.");
                continue;
            }

            switch (choix)
            {
                case 1:
                    Console.Write("Entrez le type de personne (1. Enseignant, 2. Étudiant) : ");
                    if (!int.TryParse(Console.ReadLine(), out int type))
                    {
                        Console.WriteLine("Entrée invalide.");
                        break;
                    }

                    Console.Write("Entrez le nom : ");
                    string nom = Console.ReadLine();
                    Console.Write("Entrez le prénom : ");
                    string prenom = Console.ReadLine();

                    if (type == 1)
                    {
                        Console.Write("Entrez la matière enseignée : ");
                        string matiere = Console.ReadLine();
                        gestionnaire.AjouterPersonne(new Enseignant(nom, prenom, matiere));
                    }
                    else if (type == 2)
                    {
                        Console.Write("Entrez le niveau d'études : ");
                        string niveau = Console.ReadLine();
                        gestionnaire.AjouterPersonne(new Etudiant(nom, prenom, niveau));
                    }
                    else
                    {
                        Console.WriteLine("Type invalide.");
                    }
                    break;
                case 2:
                    gestionnaire.AfficherPersonnes();
                    break;
                case 3:
                    gestionnaire.AfficherEnseignants();
                    break;
                case 4:
                    gestionnaire.AfficherEtudiants();
                    break;
                case 5:
                    Console.WriteLine("Au revoir !");
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    break;
            }
        } while (choix != 5);
    }
}
