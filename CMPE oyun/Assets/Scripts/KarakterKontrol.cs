using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BenimKutuphanem;

public class KarakterKontrol : MonoBehaviour
{
    float inputX;
    Animator anim;
    Vector3 mevcutyon;
    Camera MainCam;
    float maxuzunluk = 5;
    float rotationspeed = 10;
    float maxspeed;
    Animasyon animasyon = new Animasyon();
    public static float saglik;
    public Image healthBar;
    public GameObject gameManager;
    float[] Sol_Yon_Parametreleri = {0.12f, 0.34f, 0.63f, 0.92f};
    float[] Sag_Yon_Parametreleri = {0.12f, 0.34f, 0.63f, 0.92f};
    float[] Egilme_Yon_Parametreleri = {0.2f, 0.35f, 1f, 0.40f, 0.45f};

    
    void Start()
    {
        anim = GetComponent<Animator>();
        MainCam = Camera.main;
        saglik = 100;
    }

    public void SaglikDurumu(float darbeGucu)
    {
        saglik -= darbeGucu;
        healthBar.fillAmount = saglik / 100;
        if(saglik <= 0)
        {
            gameManager.GetComponent<GameManager>().Kaybettin();
        }
    }


    void LateUpdate()
    {
        animasyon.Karakter_Hareket(anim, "speed", maxuzunluk, 1, 0.2f);

        animasyon.Karakter_Rotation(MainCam, rotationspeed, gameObject);

        animasyon.Sol_Hareket(anim, "Sol_Hareket", "Sol_aktifmi", animasyon.ParametreOlustur(Sol_Yon_Parametreleri));

        animasyon.Sag_Hareket(anim, "Sag_Hareket", "Sag_aktifmi", animasyon.ParametreOlustur(Sag_Yon_Parametreleri));

        animasyon.Geri_Hareket(anim, "geriyuru");

        animasyon.Egilme_Hareket(anim, "Egilme_Hareket", animasyon.ParametreOlustur(Egilme_Yon_Parametreleri));

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OyunSonu"))
        {
            gameManager.GetComponent<GameManager>().Kazandin();
        }
    }

}
