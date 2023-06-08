using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Taramali1 : MonoBehaviour
{
    [Header("AYARLAR")]
    float atesEtmeSikligi_1;
    public float atesEtmeSikligi_2;
    public float menzil;
    int toplamMermiSayisi = 200;
    int sarjorKapasitesi = 30;
    int kalanMermi;
    float darbeGucu = 25f;
    public TextMeshProUGUI toplamMermi_text;
    public TextMeshProUGUI kalanMermi_text;

    [Header("SESLER")]
    public AudioSource[] Sesler;

    [Header("EFEKTLER")]
    public ParticleSystem[] Efektler;
    //public ParticleSystem MermiIzi;
    //public ParticleSystem KanEfekti;

    [Header("GENEL ISLEMLER")]
    public Camera BenimKameram;
    public Animator KarakterinAnimatoru;

    void Start()
    {
        kalanMermi = sarjorKapasitesi;
        toplamMermi_text.text = toplamMermiSayisi.ToString();
        kalanMermi_text.text = sarjorKapasitesi.ToString();
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ReloadKontrol();
        }
        if (KarakterinAnimatoru.GetBool("reload"))
        {
            ReloadMathematic();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(Time.time > atesEtmeSikligi_1 && kalanMermi != 0)
            {
                AtesEt();
                atesEtmeSikligi_1 = Time.time + atesEtmeSikligi_2;
            }
            if(kalanMermi == 0)
            {
                Sesler[1].Play();
            }
        }
    }

    void AtesEt()
    {
        kalanMermi--;
        kalanMermi_text.text = kalanMermi.ToString();
        Efektler[0].Play();
        Sesler[0].Play();
        KarakterinAnimatoru.Play("Egilme_ates_etme");

        RaycastHit hit;

        if(Physics.Raycast(BenimKameram.transform.position, BenimKameram.transform.forward, out hit, menzil))
        {
            if (hit.transform.gameObject.CompareTag("Dusman"))
            {
                hit.transform.gameObject.GetComponent<Dusman>().SaglikDurumu(darbeGucu);
                Instantiate(Efektler[2], hit.point, Quaternion.LookRotation(hit.normal));
            }
            else
            {
                Instantiate(Efektler[1], hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }

    void ReloadKontrol()
    {
        if (kalanMermi < sarjorKapasitesi && toplamMermiSayisi != 0)
        {
            KarakterinAnimatoru.Play("sarjordegistir");
            if (!Sesler[2].isPlaying)
            {
                Sesler[2].Play();
            }
        }
    }

    void ReloadMathematic()
    {
        if (kalanMermi == 0)
        {
            if (toplamMermiSayisi <= sarjorKapasitesi)
            {
                kalanMermi = toplamMermiSayisi;
                toplamMermiSayisi = 0;
            }
            else
            {
                toplamMermiSayisi -= sarjorKapasitesi;
                kalanMermi = sarjorKapasitesi;
            }
        }
        else
        {
            if (toplamMermiSayisi <= sarjorKapasitesi)
            {
                int olusanDeger = kalanMermi + toplamMermiSayisi;

                if (olusanDeger > sarjorKapasitesi)
                {
                    kalanMermi = sarjorKapasitesi;
                    toplamMermiSayisi = olusanDeger - sarjorKapasitesi;
                }
                else
                {
                    kalanMermi += toplamMermiSayisi;
                    toplamMermiSayisi = 0;
                }
            }
            else
            {
                int harcananMermi = sarjorKapasitesi - kalanMermi;
                toplamMermiSayisi -= harcananMermi;
                kalanMermi = sarjorKapasitesi;
            }
        }
        toplamMermi_text.text = toplamMermiSayisi.ToString();
        kalanMermi_text.text = sarjorKapasitesi.ToString();

        KarakterinAnimatoru.SetBool("reload", false);
    }
}
