using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    static public string Scene; // Sert à savoir sur quelle scène nous sommes

    void Start()
    {
        Scene = SceneManager.GetActiveScene().name;  // Nous allon chercher le nom de la scene dans laquelle nous sommes présentement
    }


    public void DebuteJeu() 
    {
        SceneManager.LoadScene("Niveau-1"); //Nous chanrgeons la scène niveau 1
    }

    public void Niveau2()
    {
        SceneManager.LoadScene("Niveau-2"); //Nous chanrgeons la scène niveau 2
    }

    




































}
