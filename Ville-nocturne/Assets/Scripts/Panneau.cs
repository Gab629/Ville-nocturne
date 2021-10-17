using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panneau : MonoBehaviour
{
    public GameObject[] listeSection; //On crée un tableau 
    public GameObject contenantImages; //On crée un gameObject pour le contenant des images
    public GameObject mask; //On crée un mask pour les images

    private float largeurMask; //Créer une valeur pour la largeur du mask
    private float posDepart; // Crée une valeur pour la position de depart
    private bool peutBouger = false; // crée une variable booléenne pour savoir si les images peuvent bouger
    private int numeroSection = 1; //Sert à savoir dans quelle section nous sommes rendus

    public int pointageFinal; // Sert à savoir quel est notre pointage 
    private float etapeTermine = 1f; // Sert à savoir combien d'étapes ont été terminés


    void Start()
    {

        largeurMask = mask.GetComponent<RectTransform>().rect.width;  // Définis les grandeurs du mask
        posDepart = contenantImages.transform.localPosition.x; // Sert à définir les valeurs position de depart



    }


    void Update()
    {
        pointageFinal = GameObject.Find("Personnage").GetComponent<Personnage>().pointageTotal; // sert à aller chercher le pointage final dans le script de notre personnage

        if (pointageFinal == 5 && etapeTermine == 1) // si le pointage final est égal à 5 et qu'une étape est terminé
        {
            peutBouger = true;  // Le contenant peut bouger
        }
        else if (pointageFinal == 15 && etapeTermine == 2) // si le pointage final est égal à 15 et que deux étape sont terminé
        {
            peutBouger = true; // Le contenant peut bouger
        }
        else if (pointageFinal == 30 && etapeTermine == 3) // si le pointage final est égal à 30 et que trois étape sont terminé
        {
            peutBouger = true; // Le contenant peut bouger
        }
        else if (pointageFinal == 50 && etapeTermine == 4) // si le pointage final est égal à 50 et que quatre étape sont terminé
        {
            peutBouger = true; // Le contenant peut bouger
        }

        if (peutBouger) // Le contenant peut bouger
        {
            if (numeroSection < listeSection.Length) // Si le nombre de section est plus petit que la liste des sections
            {
                Bouge(); // On appelle la fonction bouge
            }

        }


    }

    void Bouge()
    {
        float posFin = posDepart - (numeroSection * largeurMask);  // On bouge le contenant vers la gauche

        if (contenantImages.transform.localPosition.x > posFin) // Si la position du contenant est plus grande que la position fin
        {
            contenantImages.transform.Translate(-(Time.deltaTime * 4), 0, 0); // On bouge le contenant vers la gauche
        }
        else // Sinon
        {
            peutBouger = false; //On ne peut pas bouger le contenant
            numeroSection++; //On augmente le numero de la section
            etapeTermine++; // On augmente les étapes terminés

        }


    }














}
