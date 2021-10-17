using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetsNiveau2 : MonoBehaviour
{
    protected int nbPoints = 0; // On crée une variable nombre de point que l'on met à zéro

    protected void OnTriggerEnter(Collider other)
    {
        if (other.tag == "joueur") // Si l'objet entre en collision avec le joueur
        {
            other.SendMessage("AjouterPoints", nbPoints); // appelle la fonction ajouter points et on ajoute nbPoints (nbPoints se trouve dans le script personnage)

 
        }
    }



}
