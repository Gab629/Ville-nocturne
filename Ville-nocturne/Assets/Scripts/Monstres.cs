using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstres : MonoBehaviour
{


    public Transform positionDepart; //Sert à acceuillir les valeurs de la positions de départ
    public Transform positionFinale; //Sert à acceuillir les valeurs de la positions de positionFinale
    public GameObject monstre;  //Crée un GameObject du monstre

    private float vitesse = 3f; // Crée une variable vitesse qu'on pourra modifier


    private float tempDepart; // Crée une variable pour stocker l'information du temps de départ
    private float distanceAparcourir; // Sert à calculer la distance à parcourir

    public Transform target; //Créer une variable pour stocker des informations du transform


    void Start()
    {
        tempDepart = Time.time; // Le temps de départ est égal au temps du jeu en temps réel
        distanceAparcourir = Vector3.Distance(positionDepart.position, positionFinale.position); //Calcul la distance qui reste à parcourir à l'aide d'un vecteur 3D
    }


    void Update()
    {
        Bouge();
        transform.LookAt(target, Vector3.up); //Le monstre va fixer le joueur sans arrêt 
    }


    void Bouge()
    {
        float tempActuel = Time.time;  //Le temps présent est égal au temps réel (Des vraies secondes)
        float distanceDeTempsParcouru = (tempActuel - tempDepart) * vitesse * Time.deltaTime; // Calcule la distance parcouru par le monstre depuis le départ
        float pourcentageParcourue = distanceDeTempsParcouru  / distanceAparcourir;  // Calcul le pourcentage de la distance parcourue par le monstre

        transform.position = Vector3.Lerp(positionDepart.position, positionFinale.position, pourcentageParcourue); // Sert à déplacer le monstre vers sa position finale 
    }






































}
