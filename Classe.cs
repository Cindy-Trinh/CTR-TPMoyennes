using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

/// <summary>
/// Tableaux pour stocker les élèves et les matières enseignées dans la classe
/// </summary>
namespace TPMoyennes
{
	class Classe
	{
		// Déclaration des variables
		public string nomClasse { get; private set; }
		public List<Eleve> eleves { get; private set; } = new List<Eleve>();
		public List<string> matieres { get; private set; } = new List<string>();
		public int nbrEleves { get; private set; }
        public int nbrMatieres { get; private set; }
        public float moyenne { get; private set; }
        public List<float> listMoyenneMat { get; private set; } = new List<float>();
        public List<float> listMoyenneGen { get; private set; } = new List<float>();

        // Constructeur
        public Classe(string aNomClasse)
		{
			nomClasse = aNomClasse;
			nbrEleves = 0;
            nbrMatieres = 0;
 		}

		// Remplissage du tableau des élèves dans la classe
		public void ajouterEleve(string prenomEleve, string nomEleve)
		{			
			Eleve nouvEleve = new Eleve(prenomEleve, nomEleve, nbrEleves);
			eleves.Add(nouvEleve);
			nbrEleves++;	
		}

		// Remplissage du tableau des matières enseignées dans la classe
		public void ajouterMatiere(string matiere)
		{
			matieres.Add(matiere);
            nbrMatieres++;
		}

        // Calcul de la moyenne de la classe dans une matière
        public float moyenneMatiere(int numMatiere)
        {
            listMoyenneMat.Clear();
            for (int iele = 0; iele < nbrEleves; iele++)
            {
                listMoyenneMat.Add(eleves[iele].moyenneMatiere(numMatiere));
            }
            moyenne = listMoyenneMat.Average();
			moyenne = (float)Math.Round(moyenne, 2);
            return moyenne;

        }

        // Calcul de la moyenne générale de la classe
        public float moyenneGeneral()
        {
            listMoyenneGen.Clear();
            for (int imat = 0; imat < nbrMatieres; imat++)
            {
                listMoyenneGen.Add(moyenneMatiere(imat));
            }
            moyenne = listMoyenneGen.Average();
			moyenne = (float)Math.Round(moyenne, 2);
            return moyenne;
        }
    }
}
