using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Personnage : MonoBehaviour
{
    [Header("Données joueur")] //Sert à créer une section pour les variables public du joueur dans unity
    public CharacterController controleur; //sevira à modifier les valeurs pour le personnage (mouvement)
    public Animator animHero; // Sert à aller chercher l'animator du personnage
    public Transform positionJoueur; // Sert à aller chercher la position du joueur à n'importe quel moment dans la partie


    private float vitesse = 4f; //Sert à pouvoir modifier les valeurs pour la vitesse
    private float saut = 1f; //Sert à pouvoir modifier les valeurs pour le saut

    [Header("Donnees environnement")] //Sert à créer une section pour les variables public de l'environnement dans unity
    public float gravity = -9f;  //Sert à pouvoir modifier les valeurs pour la gravité
    static public string Scene; // Sert à savoir sur quelle scène nous sommes



    //Pour mouvements

    private float MouvementsAvant; //Servira à savoir si le personnage bouge avec les flèches avants
    private float MouvementsCote;  //Servira à savoir si le personnage bouge avec les flèches de cotés
    private Vector3 nouvellePosition;  //Servira à modifier la position du personnage

    //Mouvements vers le bas
    private Vector3 velocity; //(0, 0, 0)
    public Transform piedsJoueur; // Sert à aller chercher la position des pieds du joueur
    private float distanceDuSol = 0.4f; // Sert à définir la distance entre les pieds du joueur et du sol
    public LayerMask leSol; // Sert à aller charcher le layer du sol

    public float tempsDeRotation = 0.1f; // Sert à définir un temps de rotation en troisième personne
    private float adoucirTempsDeRotation; // Sert à aller adoucir le temps de rotation  en troisième personne

    public Transform camera3P; // Sert à aller chercher les données de positions et de rotation de la caméra 3e personne
    public GameObject CameraTP; // Sert à aller chercher le gameobject de la caméra 3e personne
    public GameObject CameraPP; // Sert à aller chercher le gameobject de la caméra 1er personne

    private bool toucheAuSol = false;  // Sert à créer une variable booléenne qui verifiera si nous touchons au sol ou pas
    private bool switchCamera = false; // Sert à créer une variable booléenne qui verifiera sur quelle caméra nous nous trouvons

    private bool menuActif = false; // Sert à créer une variable booléenne qui verifiera si le menu est actif ou non
    public GameObject menu; // Sert à aller chercher le menu sur unity

    //Niveau 2
    [Header("Donnees Niveau 2")]
    public GameObject lampeFrontale; //Servira à trouver le GameObject lampeFrontale
    public GameObject lampeFrontaleTetePP; //Servira à trouver le GameObject LampeFrontaleTête
    public GameObject clee; //Servira à trouver le GameObject clée
    public GameObject serrure; //Servira à trouver le GameObject serrure
    public GameObject levierSolaire; //Servira à trouver le GameObject levierSolaire
    public GameObject protecteur; //Servira à trouver le GameObject protecteur
    public GameObject jour; //Servira à trouver le GameObject jour
    public GameObject nuit; //Servira à trouver le GameObject nuit
    private Vector3 positionDepart = new Vector3(2.24f, 0, -33.01f); // Sert à créer un nouveau Vecteur 3 qui gardera en mémoire la position de départ du personnage
    public GameObject sonCriquets; //Servira à trouver le GameObject criquets


    //coins 
    public float score; //Servira à savoir à quel score le joueur est rendu

    //monstres
    [Header("Donnees monstres")]
    public GameObject monstre; //Servira à trouver le GameObject du monstre1
    public GameObject monstre2; //Servira à trouver le GameObject du monstre2

    //Objets control

    private GameObject boitier; //Servira à trouver le GameObject du boitier
    private GameObject levier;  //Servira à trouver le GameObject du levier
    private GameObject trappe;  //Servira à trouver le GameObject de la trappe
    private GameObject control; //Servira à trouver le GameObject du controls
    private GameObject ecran1;  //Servira à trouver le GameObject de l'ecran1
    private GameObject ecran2;  //Servira à trouver le GameObject de l'ecran2
    private GameObject ecran3;  //Servira à trouver le GameObject de l'ecran3
    private GameObject ecran4;  //Servira à trouver le GameObject de l'ecran4
    private GameObject manette; //Servira à trouver le GameObject de la manette

    [Header("Donnees caisson")]
    public Animator caissonHaut; //Servira à trouver l'animator du caisson
    public Animator caissonBas;  //Servira à trouver l'animator du caisson

    //camion
    [Header("Donnees camion")]
    public GameObject boutonDerriere; //Servira à trouver le GameObject du boutonDerriere
    public GameObject boutonCote; //Servira à trouver le GameObject du boutonCote
    public Animator MurGauche;  //Servira à trouver l'animator du MurGauche
    public Animator MurDroit;   //Servira à trouver l'animator du MurDroit
    public Animator lumiereGauche;  //Servira à trouver l'animator de la lumiereGauche
    public Animator lumiereDroite;  //Servira à trouver l'animator de la lumiereDroite
    public Animator Camion;  //Servira à trouver l'animator du Camion
    private float ObjetsActives = 0f; //Servira à compter les objects activés sur le camion
    public GameObject SupportALumiere; //Servira à trouver le GameObject du SupportALumiere

    [Header("Donnees objets heritage")]
    public int pointageTotal = 0;  // Sert à calculer le pointage totale acquis par le joueur


    void Start()
    {
        Scene = SceneManager.GetActiveScene().name;  // Nous allon chercher le nom de la scene dans laquelle nous sommes présentement

        if (Scene == "Niveau-1") // Lorsque nous sommes sur la scène du premier niveau
        {
            score = GameObject.Find("coin").GetComponent<Coins>().score;  //Sert à aller charcher la variable score dans le script du coin\

            //levier
            boitier = GameObject.Find("Disjoncteur_couvercle"); //Sert à aller chercher le GameObject du Disjoncteur_couvercle
            levier = GameObject.Find("Disjoncteur_manette");  //Sert à aller chercher le GameObject du Disjoncteur_manette

            //Panneau de controle
            trappe = GameObject.Find("PanneauCtrl_Trappe"); //Sert à aller chercher le GameObject du PanneauCtrl_Trappe
            control = GameObject.Find("PanneauCtrl"); //Sert à aller chercher le GameObject du PanneauCtrl
            ecran1 = GameObject.Find("PanneauCtrl_Ecran-1"); //Sert à aller chercher le GameObject du PanneauCtrl_Ecran-1
            ecran2 = GameObject.Find("PanneauCtrl_Ecran-2"); //Sert à aller chercher le GameObject du PanneauCtrl_Ecran-2
            ecran3 = GameObject.Find("PanneauCtrl_Ecran-3"); //Sert à aller chercher le GameObject du PanneauCtrl_Ecran-3
            ecran4 = GameObject.Find("PanneauCtrl_Ecran-4"); //Sert à aller chercher le GameObject du PanneauCtrl_Ecran-4
            manette = GameObject.Find("PanneauCtrl_Manette"); //Sert à aller chercher le GameObject du PanneauCtrl_Manette
        }

        if (Scene == "Niveau-2") // Lorsque nous sommes sur la scène du deuxième niveau
        {
            ObjetsActives = 0; // Sert à vérifier le nombre d'objets activés par le joueur
        }




    }


    void Update()
    {
        MouvementsCote = Input.GetAxisRaw("Horizontal");  //Sert à aller chercher les Axes des X
        MouvementsAvant = Input.GetAxisRaw("Vertical");  //Sert à aller chercher les Axes des Y


        Animations();
        Tomber(); //Appelle la methode Tomber
        Courir(); //Appelle la methode Courir
        Saute(); //Appelle la methode Saute
        ObjectifsTermines(); //Appelle la methode ObjectifsTermines
        SwitchCamera(); //Appelle la methode SwitchCamera
        Menu(); //Appelle la methode Menu
        


    }


    void AvancerPP()
    {
        nouvellePosition = (transform.right * MouvementsCote) + (transform.forward * MouvementsAvant); //Vector3(1, 0, 0) Augmente de 1 la position
        controleur.Move(nouvellePosition * vitesse * Time.deltaTime); //Bouge notre personnage de 1 multiplié par la vitesse 
        if (Input.GetKeyDown(KeyCode.F2))  // Si nous appuyons sur la touche F2
        {
            positionJoueur.position = positionDepart; //La position du joueur devient égal à la position de départ du joueur 
        }
    }

    void AvancerTP()
    {
        Vector3 direction = new Vector3(MouvementsCote, 0, MouvementsAvant).normalized; // Sert à créer un nouveau Vecteur 3 pour la direction du joueur

        if (direction.magnitude >= 0.1f) // Si la magnitude de la direction est plus grande ou égal à 0.01f
        {
            float angleVoulue = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera3P.eulerAngles.y; //Sert faire tourner le personnage avec la camera 
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angleVoulue, ref adoucirTempsDeRotation, tempsDeRotation); //Sert a adoucir le mouvement de rotation
            transform.rotation = Quaternion.Euler(0, angle, 0); // Sert à aller modifier les valeurs de la rotation du personnage

            Vector3 directionFinale = Quaternion.Euler(0, angleVoulue, 0) * Vector3.forward; // Sert à aller définir l'angle de la direction finale

            controleur.Move(directionFinale * vitesse * Time.deltaTime); //Sert à aller changer d'angle le personnage avec une certaine vitesse
        }

        if (Input.GetKeyDown(KeyCode.F2)) // Si nous appuyons sur la touche F2
        {
            positionJoueur.position = positionDepart; //La position du joueur devient égal à la position de départ du joueur 

        }

    }

    void SwitchCamera()
    {
        if (Input.GetKeyDown(KeyCode.F3) && switchCamera == true) // Si nous appuyons sur la touche F3 et que le switch de la caméra est à vrai
        {
            switchCamera = false; // Nous mettons le switch de la caméra à faux
        }

        else if (Input.GetKeyDown(KeyCode.F3) && switchCamera == false) // Sinon si nous appuyons sur la touche F3 et que le switch de la caméra est à faux
        {
            switchCamera = true; // Nous mettons le switch de la caméra à vrai
        }


        if (switchCamera == true) // Si le switch de la caméra est à vrai
        {
            AvancerTP(); // Apelle la méthode AvancerTP
            CameraTP.SetActive(true); // Mettre la caméra 3e personne active
            CameraPP.SetActive(false); // Mettre la caméra 1er personne inactive

        }
        else
        {
            AvancerPP();  //Appelle la methode AvancerPP
            CameraTP.SetActive(false); // Mettre la caméra 3e personne inactive
            CameraPP.SetActive(true); // Mettre la caméra 1er personne active

        }


    }


    void Animations()
    {


        if (MouvementsAvant == 1)  //Si le personnage est en mouvement
        {
            animHero.SetBool("marche", true); // Démarrer l'animation de marche
        }
        else if (MouvementsAvant == -1)  // Si le personnage est en reculon
        {
            if (switchCamera == true)  // Si switch caméra est à vrai
               
            {
                animHero.SetBool("marche", true);  // Démarrer l'animation de marche
            }
            else if (switchCamera == false)  // Si switch caméra est à faux
            {
                animHero.SetBool("reculer", true); // Démarrer l'animation de recul
            }

        }
        else if (MouvementsAvant == 0) //Si le personnage n'est pas en mouvement
        {
            animHero.SetBool("marche", false); // Arrêter l'animation de marche
            animHero.SetBool("reculer", false); // Arrêter l'animation de recul
        }

        if (Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1)  //Si le joueur est en mouvement
        {
            animHero.SetBool("marche", true); // Démarrer l'animation de marche
        }

    }

    void Tomber()
    {
        toucheAuSol = Physics.CheckSphere(piedsJoueur.position, distanceDuSol, leSol);  //Sert à vérifier si les pieds du joeueur touche au sol

        if (toucheAuSol && velocity.y < 0) // Si le joueur touche au sol et que la vélocité est plus petite que 0
        {
            velocity.y = -1f; // La vélocité est égale à -1
        }


        velocity.y += gravity * Time.deltaTime;  // La vitesse en Y augmentera de la valeur de la gravitée multiplié par le temps du jeu
        controleur.Move(velocity * Time.deltaTime);  //Le personnage sera affecté  par la gravité

    }

    void Courir()
    {
        if (Input.GetButtonDown("Fire3")) //Si on appuie sur Shift Gauche
        {
            vitesse = 10f;  //La vitesse sera de 10f
            animHero.SetBool("run", true);  //L'animation de course sera mise en marche
           
        }
        else if (Input.GetButtonUp("Fire3")) //Si nous relachons Shift Gauche
        {
            vitesse = 4f; //La vitesse revient à 4f
            animHero.SetBool("run", false); //l'animation de course est arrêtée
           
        }

    }

    void Saute()
    {
        toucheAuSol = Physics.CheckSphere(piedsJoueur.position, distanceDuSol, leSol); // La vitesse en Y augmentera de la valeur de la gravitée multiplié par le temps du jeu

        if (Input.GetButtonDown("Jump") && toucheAuSol) // Si on appuie sur espace et que le joueur touche au sol
        {
            velocity.y = Mathf.Sqrt(saut * -2 * gravity); // Le joueur va sauter
            animHero.SetBool("saute", true); // On démarre l'animation de saut

        }
        else if (Input.GetButtonUp("Jump")) //Si on relache espace
        {
            animHero.SetBool("saute", false);  //L'animation du saut s'arrête
        }

    }


    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if (Scene == "Niveau-1") //si la scene active est celle du niveau 1
        {
            if (hit.collider.tag == "ennemis") // Si la collision du CharacterControler touche le collider avec le tag ennemis
            {
                vitesse = 0f; //la vitesse sera de zéro
                animHero.SetBool("marche", false); // L'animation de marche est arrêtée 
            }
            else if (hit.collider.tag == "Hotspot1" && score == 2) // Si la collision du CharacterControler touche le collider avec le tag HotSpot1
            {
                caissonHaut.GetComponent<Animator>().enabled = true; //L'animator du caisson est mis actif
                caissonBas.GetComponent<Animator>().enabled = true;  //L'animator du caisson est mis actif

                Vector3 rotationEuler = transform.eulerAngles;  //créer les valeurs de rotation et les mettre à zero (0, 0, 0)
                rotationEuler.y = 0; // La rotation en y vas être égal à 0
                rotationEuler.z = 205; // La rotation en z vas être égal à 205
                rotationEuler.x = 90; // La rotation en x vas être égal à 90
                levier.transform.rotation = Quaternion.Euler(rotationEuler); // la rotation du levier va être modifier de la rotation en Euler par un calcul de Quaternion.
            }
            else if (hit.collider.tag == "boutonDerriere") // Si la collision du CharacterControler touche le collider avec le tag boutonDerriere       
            {
                
                MurGauche.GetComponent<Animator>().enabled = true; // L'animator du MurGauche sera activé
                MurDroit.GetComponent<Animator>().enabled = true; // L'animator du MurDroit sera activé
                Destroy(boutonDerriere); //Le bouton derriere sera détruit
                ObjetsActives++; // Nous augmenterons de 1 les objects actifs


            }
            else if (hit.collider.tag == "boutonCote") // Si la collision du CharacterControler touche le collider avec le tag boutonCote       
            {
                {
                    ObjetsActives++; // Nous augmenterons de 1 les objects actifs
                }
            };
        }

        if (Scene == "Niveau-2") // si la scene active est celle du niveau 2
        {
            if (hit.collider.tag == "boutonCote" && pointageTotal >= 50) // Si le joueur entre en collision avec le boutoncote 
            {
                Debug.Log("Start");
                Camion.GetComponent<Animator>().enabled = true; //Mettre l'animation du camion en marche
                Invoke("ChangementDeScene", 3f);  //On appelle la fonction changement de scene apres 3 secondes
            }
        }




    }


    void ObjectifsTermines()  
    {
        if (Scene == "Niveau-1") //si la scene active est celle du niveau 1
        {
            if (score == 2) //Si le score est égal à 2
            {

                monstre = GameObject.Find("monstre"); //Nous allons chercher le GameObject du monstre 1
                monstre2 = GameObject.Find("monstre2"); //Nous allons chercher le GameObject du monstre 2

                Destroy(monstre); // Le monstre 1 est détruit
                Destroy(monstre2); // Le monstre 2 est détruit

                //levier
                boitier.GetComponent<Animator>().enabled = true; // Nous mettrons l'animation du boitié en marche




                //Panneau de controle
                trappe.GetComponent<Animator>().enabled = true; // Nous mettrons l'animation de la trappe en marche
                control.GetComponent<Animator>().enabled = true; // Nous mettrons l'animation du control en marche
                ecran1.GetComponent<Animator>().enabled = true; // Nous mettrons l'animation de l'ecran1 en marche
                ecran2.GetComponent<Animator>().enabled = true; // Nous mettrons l'animation de l'ecran2 en marche
                ecran3.GetComponent<Animator>().enabled = true; // Nous mettrons l'animation de l'ecran3 en marche
                ecran4.GetComponent<Animator>().enabled = true; // Nous mettrons l'animation de l'ecran4 en marche
                manette.GetComponent<Animator>().enabled = true; // Nous mettrons l'animation de la manette en marche

            }

            if (ObjetsActives == 2) //Si il y a deux objets d'activés
            {
                Camion.GetComponent<Animator>().enabled = true; //Mettre l'animation du camion en marche
                Invoke("ChangementDeScene", 5f); // Appelle la fonction ChangementDeScene après 10 secondes


            }
        }

    }

    void ChangementDeScene()
    {
        if (Scene == "Niveau-1") //si la scene active est celle du niveau 1
        {
            SceneManager.LoadScene("Intermediaire"); // Change la scène pour la scène Intermediaire 
        }
        else if (Scene == "Niveau-2") //si la scene active est celle du niveau 2
        {
            SceneManager.LoadScene("Fin"); // Change la scène pour la scène de Fin 
        }

    }

    void Menu()
    {
        if (Input.GetKeyDown(KeyCode.F1) && menuActif == false) // Si on enfonce la touche F1 et que le menu est inactif
        {
            menuActif = true; //On active le menu
        }
        else if (Input.GetKeyDown(KeyCode.F1) && menuActif == true)// Si on enfonce la touche F1 et que le menu est actif
        {
            menuActif = false; //On desactive le menu
        }

        if (menuActif == true) // Si le menu est actif
        {
            menu.SetActive(true); //On active le menu
        }
        else if (menuActif == false) // Si le menu est inactif
        {
            menu.SetActive(false); // on desactive le menu
        }

    }


    void AjouterPoints(int nb)
    {
        pointageTotal += nb; //on augmente le pointage total par nb

        if (pointageTotal == 5) //Si le pointage total est égal à 5
        {
            lampeFrontale.SetActive(false); //On desactive la lampe frontale
            lampeFrontaleTetePP.SetActive(true); //On active la lampe frontale de la troisième personne
            clee.SetActive(true); // On active la clée
        }
        else if (pointageTotal == 15) //Si le pointage total est égal à 15
        {
            clee.SetActive(false);  //On active la clee
            serrure.GetComponent<BoxCollider>().enabled = true; //On active le box collider de la serrure
        }
        else if (pointageTotal == 30) //Si le pointage total est égal à 30
        {
            serrure.SetActive(false);  //On active la serrure
            protecteur.GetComponent<Animator>().enabled = true;  //on active l'animator du protecteur
        }
        else if (pointageTotal == 50) //Si le pointage total est égal à 50
        {
            levierSolaire.GetComponent<Animator>().enabled = true; //on active l'animator du levierSolaire
            nuit.SetActive(false); //On désactive la nuit
            jour.SetActive(true); // On active le jour
            lampeFrontaleTetePP.SetActive(false); // On desactive la lampe frontale
            sonCriquets.SetActive(false); // On désactive le son des criquets
        }



    }


}
