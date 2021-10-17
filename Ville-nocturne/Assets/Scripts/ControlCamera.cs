using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public float CameraRotation = 1f;          // Servira à modifier les valeurs de rotations de la caméra 
    public float mouseY;                       // Servira à aller chercher l'axe des Y
    public float mouseX;                       // Servira à aller chercher l'axe des X

    public GameObject controleur;              // Sert à aller chercher le gameObject du personnage
    public float pourRotationPersonnage = 1f;  // Servira à modifier les valeurs de rotations du personnage 


    void Update()
    {
        mouseY = Input.GetAxis("Mouse Y");     //Axe des Y avec la souris
        mouseX = Input.GetAxis("Mouse X");     //Axe des X avec la souris
        Tourner(); 
    }

    void Tourner()
    {

        //Données pour la caméra

        CameraRotation += mouseY;              // Sert à lier les valeurs de la caméra avec notre souris                 
        CameraRotation = Mathf.Clamp(CameraRotation, -50, 50); // Sert à bloquer la rotation de la caméra sur l'axe des Y

        Vector3 rotationEuler = transform.eulerAngles; //créer les valeurs de rotation et les mettre à zero (0, 0, 0)
        rotationEuler.x = -CameraRotation; // La valeur en x de la rotation égale à celle de la caméra
        transform.rotation = Quaternion.Euler(rotationEuler);  //Changer les valeurs de rotation pour les mettre en Quaternion





        //Données pour le personnage (Les lignes ont les mêmes fonctions que celle pour la caméra, mais pour le personnage)

        pourRotationPersonnage += mouseX; //Le personnage tourne avec la rotation de la souris
        Vector3 rotationPersoEuler = controleur.transform.eulerAngles; // On transforme le vecteur 3 en angles euler
        rotationPersoEuler.y = pourRotationPersonnage; // Sert à modifier la valeur de la rotation en y avec la souris
        controleur.transform.rotation = Quaternion.Euler(rotationPersoEuler); //Sert à modifier la rotation du controleur
    }


































}
