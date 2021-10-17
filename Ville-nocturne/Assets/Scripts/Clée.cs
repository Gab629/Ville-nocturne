using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clée : ObjetsNiveau2 //On met le script ObjetNiveau2 en héritage 
{
    private int nbPointsAjoute = 10; // On met le nombre de points à 10

    void Start()
    {
        nbPoints = nbPointsAjoute; // On met le nombre de points égal au nombre de points ajoutés
    }

   
    
}
