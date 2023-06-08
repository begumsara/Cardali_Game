using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dusman : MonoBehaviour
{
    [Header("Diger Ayarlar")]
    NavMeshAgent navmesh;
    Animator animator;
    GameObject hedef;
    public GameObject anaHedef;

    [Header("Genel Ayarlar")]
    public float atesEtmeMenzilDeger;
    public float suphlenmeMenzilDeger;
    Vector3 baslangicNoktasi;
    public GameObject kafa;
    bool suphelenme = false;
    bool atesEdiliyorMu = false;
    public GameObject atesEtmeNoktasi;

    [Header("Devriye Ayarlari")]
    public GameObject[] devriyeNoktalari1;
    public GameObject[] devriyeNoktalari2;
    public GameObject[] devriyeNoktalari3;

    [Header("SILAH AYARLARI")]
    float atesEtmeSikligi_1;
    public float atesEtmeSikligi_2;
    public float menzil;
    public float darbeGucu;

    [Header("SESLER")]
    public AudioSource[] Sesler;

    [Header("EFEKTLER")]
    public ParticleSystem[] Efektler;


    GameObject[] aktifOlanDevriyeNoktalari;
    bool devriyeVarMi;
    Coroutine devriyeAt;
    Coroutine devriyeZaman;
    bool devriyeKilit;
    public bool devriyeAtabilirMi;
    float saglik;

    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        baslangicNoktasi = transform.position;
        StartCoroutine(DevriyeZamanKontrol());
        saglik = 100;
    }

    void DevriyeKontrol()
    {
        int deger = Random.Range(1, 3);
        switch(deger)
        {
            case 1:
                aktifOlanDevriyeNoktalari = devriyeNoktalari1;
                break;
            case 2:
                aktifOlanDevriyeNoktalari = devriyeNoktalari2;
                break;
            case 3:
                aktifOlanDevriyeNoktalari = devriyeNoktalari3;
                break;
        }
        devriyeAt = StartCoroutine(devriyeTeknikIslem(aktifOlanDevriyeNoktalari));
    }

    IEnumerator DevriyeZamanKontrol()
    {
        while(true && !devriyeVarMi && devriyeAtabilirMi) 
        { 
                yield return new WaitForSeconds(5f);
                devriyeKilit = true;
                StopCoroutine(DevriyeZamanKontrol());
        }
    }

    IEnumerator devriyeTeknikIslem(GameObject[] aktifOlanDevriyeNoktalari)
    {
        navmesh.isStopped = false;
        devriyeKilit = false;
        devriyeVarMi = true;
        animator.SetBool("yuru", true);
        int toplamNokta = aktifOlanDevriyeNoktalari.Length - 1;
        int i = 0;

        while (true && devriyeAtabilirMi)
        {
            if(Vector3.Distance(transform.position, aktifOlanDevriyeNoktalari[i].transform.position) <= 1f)
            {
                if(i < toplamNokta)
                {
                    ++i;
                    navmesh.SetDestination(aktifOlanDevriyeNoktalari[i].transform.position);
                }
                else
                {
                    navmesh.stoppingDistance = 1;
                    navmesh.SetDestination(baslangicNoktasi);
                }
                
            }
            else
            {
                if(i < toplamNokta)
                {
                    navmesh.SetDestination(aktifOlanDevriyeNoktalari[i].transform.position);
                }          
            }
            yield return null;        
        }
    }

    void LateUpdate()
    {
        if (navmesh.stoppingDistance == 1 && navmesh.remainingDistance <= 1)
        {
            animator.SetBool("yuru", false);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            if (devriyeAtabilirMi)
            {
                devriyeVarMi = false;
                devriyeZaman = StartCoroutine(DevriyeZamanKontrol());
                StopCoroutine(devriyeAt);
            }     
            navmesh.stoppingDistance = 0;
            navmesh.isStopped = true;
        }

        if (devriyeKilit && devriyeAtabilirMi)
        {
            DevriyeKontrol();
        }
        SuphelenmeMenzil();
        AtesEtmeMenzil();

    }

    void AtesEtmeMenzil()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, atesEtmeMenzilDeger);

        foreach (var objeler in hitColliders)
        {
            if (objeler.gameObject.CompareTag("Player"))
            {
                AtesEt(objeler.gameObject);                
            }
            else
            {
                if (atesEdiliyorMu)
                {
                    animator.SetBool("AtesEt", false);
                    navmesh.isStopped = false;
                    animator.SetBool("yuru", true);
                    atesEdiliyorMu = false;
                }     
            }
        }
    }

    void AtesEt(GameObject hedef)
    {
        atesEdiliyorMu = true;
        Vector3 aradakiFark = hedef.gameObject.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(aradakiFark, Vector3.up);
        transform.rotation = rotation;
        animator.SetBool("yuru", false);
        navmesh.isStopped = true;
        animator.SetBool("AtesEt", true);

        RaycastHit hit;
        if (Physics.Raycast(atesEtmeNoktasi.transform.position, atesEtmeNoktasi.transform.forward, out hit, menzil))
        {
            Debug.DrawLine(atesEtmeNoktasi.transform.position, new Vector3(hedef.transform.position.x, hedef.transform.position.y+1.5f, hedef.transform.position.z), Color.blue);
            if (Time.time > atesEtmeSikligi_1)
            {
                if (hit.transform.gameObject.CompareTag("Player"))
                {
                    hit.transform.gameObject.GetComponent<KarakterKontrol>().SaglikDurumu(darbeGucu);
                    Instantiate(Efektler[1], hit.point, Quaternion.LookRotation(hit.normal));
                }
                else
                {
                    Instantiate(Efektler[2], hit.point, Quaternion.LookRotation(hit.normal));
                }
                if (!Sesler[0].isPlaying)
                {
                    Sesler[0].Play();
                    Efektler[0].Play();
                }
                atesEtmeSikligi_1 = Time.time + atesEtmeSikligi_2;
            }

        }
    }
    void SuphelenmeMenzil()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, suphlenmeMenzilDeger);

        foreach (var objeler in hitColliders)
        {
            if (objeler.gameObject.CompareTag("Player"))
            {
                if (animator.GetBool("kosma"))
                {
                    animator.SetBool("kosma", false);
                    animator.SetBool("yuru", true);
                }
                else
                {
                    animator.SetBool("yuru", true);
                }
                hedef = objeler.gameObject;
                navmesh.SetDestination(hedef.transform.position);
                suphelenme = true;
                if (devriyeAtabilirMi)
                {
                    StopCoroutine(devriyeAt);
                }
            }
            else
            {
                if(suphelenme)
                {
                    hedef = null;
                    if (transform.position != baslangicNoktasi)
                    {
                        navmesh.stoppingDistance = 1;
                        navmesh.SetDestination(baslangicNoktasi);
                        if (navmesh.remainingDistance <= 1)
                        {
                            animator.SetBool("yuru", false);
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                        }
                    }
                    suphelenme = false;
                    if (devriyeAtabilirMi)
                    {
                        devriyeAt = StartCoroutine(devriyeTeknikIslem(aktifOlanDevriyeNoktalari));
                    }
                }
            }
        }
    }

    public void SaglikDurumu(float darbeGucu)
    {
        saglik -= darbeGucu;
        if (!suphelenme)
        {
            animator.SetBool("kosma", true);
            navmesh.SetDestination(anaHedef.transform.position);
        }      
        if (saglik <= 0)
        {
            animator.Play("olme");
            Destroy(gameObject, 5f);
        } 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, atesEtmeMenzilDeger);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, suphlenmeMenzilDeger);
    }

    //kafadan isin gondererek dusmani hareket ettirme
    /*RaycastHit hit;
        if (Physics.Raycast(kafa.transform.position, kafa.transform.forward, out hit, 10f))
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                Debug.Log("Carpti");
            }
        }
        Debug.DrawRay(kafa.transform.position, kafa.transform.forward * 10f, Color.blue);*/

}
