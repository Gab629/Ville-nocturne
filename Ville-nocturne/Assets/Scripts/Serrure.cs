using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serrure : ObjetsNiveau2 //On met le script ObjetNiveau2 en héritage 
{
    private int nbPointsAjoute = 15; // On met le nombre de points à 15

    void Start()
    {
        nbPoints = nbPointsAjoute; // On met le nombre de points égal au nombre de points ajoutés
    }
}
