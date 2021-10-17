using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{


    public Transform positionDepart; // Sert à définir les valeurs pour la position de départ
    public Transform positionFinale; // Sert à définir les valeurs pour la position finale

    private float tempDepart; // Crée une variable pour stocker l'information du temps de départ
    private float distanceAparcourir; // Sert à calculer la distance à parcourir
    private float randomX; // Crée une variable pour générer un chiffre aléatoire pour l'axe des X
    private float randomZ; // Crée une variable pour générer un chiffre aléatoire pour l'axe des Z

    public float score = 0f;  //Servira à savoir à quel score le joueur est rendu

    public float ralentissement = 0.5f;  //Sert à définir à quel point la pièce ralentira avant d'atteindre sa position finale
    private Vector3 velo = Vector3.zero; // Vector3(0,0,0)
    //private Vector3 velo =  new Vector3(0f,2f,0f);

    void Start()
    {
        tempDepart = Time.time; // Le temps de départ est égal au temps du jeu en temps réel
        distanceAparcourir = Vector3.Distance(positionDepart.position, positionFinale.position);  //Calcul la distance qui reste à parcourir à l'aide d'un vecteur 3D
        InvokeRepeating("positionCoin", 5f, 5f); // Appelle la fonction PositionCoin en boucle à toutes les 5 secondes à partir des 5 premières secondes du jeu 
    }


    void FixedUpdate()
    {
        Bouge();        
    }


    void Bouge()
    {

        transform.position = Vector3.SmoothDamp(positionDepart.position, positionFinale.position, ref velo, ralentissement); // Sert à déplacer le monstre vers sa position finale 

    }



    void positionCoin()
    {
        randomX = Random.Range(-50f, 50f);  // Génère un nombre aléatoire entre -50 et 50
        randomZ = Random.Range(-30f, 30f);  // Génère un nombre aléatoire entre -30 et 30
        positionFinale.transform.position = new Vector3(randomX, -17, randomZ); // Change la position de la position finale pour la mettre égale aux nombre aléatoire obtenus précédemment
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "joueur")  // Si la pièce entre en collision avec le joueur
        {
            Destroy(gameObject); // La pièce est détruite
            score = GameObject.Find("Personnage").GetComponent<Personnage>().score += 1; // La variable du score situé dans le script du personnage augmente de 1
        }
    }












}
