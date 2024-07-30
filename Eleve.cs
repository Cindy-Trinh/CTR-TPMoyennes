using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMoyennes
{
    class Eleve
    {
        //Déclaration des variables
        public string prenom { get; private set; }
        public string nom { get; private set; }
        public int numero { get; private set; }
        public static List<List<List<float>>> notes { get; private set; } = new List<List<List<float>>>(); // notes de tous les élèves dans toutes les matières
        public List<List<float>> notesEleve { get; private set; } = new List<List<float>>();               // notes d'un élève dans toutes les matières
        public List<float> notesMatiere { get; private set; } = new List<float>();                         // notes d'un élève dans une matière
        public int k1 { get; private set; } // compteur pour le remplissage du tableau des notes
        public int k2 { get; private set; } // compteur pour le remplissage du tableau des notes
        public float moyenne { get; private set; }
        public List<float> listMoyenne { get; private set; } = new List<float>();

        // Constructeur
        public Eleve(string aPrenomEleve, string aNomEleve, int aNumEleve)
        {
            prenom = aPrenomEleve;
            nom = aNomEleve;
            numero = aNumEleve;
            k1 = 0;
            k2 = 0;
        }
        
        // Remplissage du tableau des notes des élèves
        public void ajouterNote(Note n)
        {
            notesMatiere.Add(n.note);
            k1++;
            if (k1 == 5)
            {
                notesEleve.Add(notesMatiere.ToList());
                k1 = 0; 
                notesMatiere.Clear();
                k2++;
            }
            if (k2 == 4)
            {
                notes.Add(notesEleve.ToList());
                k2 = 0;
                notesEleve.Clear();
            }
        }

        // Calcul de la moyenne d'un élève une matière
        public float moyenneMatiere(int numMatiere)
        {
            moyenne = notes[numero][numMatiere].Average();
            moyenne = (float)Math.Round(moyenne, 2);
            return moyenne;
        }

        // Calcul de la moyenne générale d'un élève
        public float moyenneGeneral()
        {
            listMoyenne.Clear();
            for (int i= 0; i < 4; i++) {
                listMoyenne.Add(moyenneMatiere(i));
            }
            moyenne = listMoyenne.Average();
            moyenne =(float)Math.Round(moyenne, 2);
            return moyenne;
        }
    }
}
