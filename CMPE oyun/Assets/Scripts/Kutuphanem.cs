using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BenimKutuphanem{
    public class Animasyon
    {
        float maxSpeedClass;
        float inputXClass;

        public float YonuDisariCikar()
        {
            return inputXClass;
        }

        public void Sol_Hareket(Animator anim, string AnaParametre, string KontrolParametre, List<float> parametredegerleri)
        {
            if (Input.GetKey(KeyCode.A))
            {
                anim.SetBool(KontrolParametre, true);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetFloat(AnaParametre, parametredegerleri[1]);
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    anim.SetFloat(AnaParametre, parametredegerleri[2]);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    anim.SetFloat(AnaParametre, parametredegerleri[3]);
                }
                else
                {
                    anim.SetFloat(AnaParametre, parametredegerleri[0]);
                }
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetFloat(AnaParametre, 0f);
                anim.SetBool(KontrolParametre, false);
            }
        }

        public void Sag_Hareket(Animator anim, string AnaParametre, string KontrolParametre, List<float> parametredegerleri)
        {
            if (Input.GetKey(KeyCode.D))
            {
                anim.SetBool(KontrolParametre, true);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetFloat(AnaParametre, parametredegerleri[1]);
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    anim.SetFloat(AnaParametre, parametredegerleri[2]);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    anim.SetFloat(AnaParametre, parametredegerleri[3]);
                }
                else
                {
                    anim.SetFloat(AnaParametre, parametredegerleri[0]);
                }
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetFloat(AnaParametre, 0f);
                anim.SetBool(KontrolParametre, false);
            }
        }

        public void Geri_Hareket(Animator anim, string AnaParametre)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetBool(AnaParametre, true);
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetBool(AnaParametre, false);
            }
        }

        public void Egilme_Hareket(Animator anim, string AnaParametre, List<float> parametredegerleri)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                anim.SetBool("Egilme_aktifmi", true);
                if (Input.GetKey(KeyCode.W))
                {
                    anim.SetFloat(AnaParametre, parametredegerleri[1]);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    anim.SetFloat(AnaParametre, parametredegerleri[2]);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    anim.SetFloat(AnaParametre, parametredegerleri[3]);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    anim.SetFloat(AnaParametre, parametredegerleri[4]);
                }
                else
                {
                    anim.SetFloat(AnaParametre, parametredegerleri[0]);
                }
            }

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                anim.SetFloat(AnaParametre, 0f);
                anim.SetBool("Egilme_aktifmi", false);
            }
        }

        public void Karakter_Hareket(Animator anim, string hizdegeri, float maxuzunluk, float tamHiz, float yurumeHizi)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                maxSpeedClass = tamHiz;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                maxSpeedClass = yurumeHizi;
                inputXClass = 1;

            }
            else
            {
                maxSpeedClass = 0f;
                inputXClass = 0f;
            }

            anim.SetFloat(hizdegeri, Vector3.ClampMagnitude(new Vector3(inputXClass, 0, 0), maxSpeedClass).magnitude, maxuzunluk, Time.deltaTime * 10);
        }

        public void Karakter_Rotation(Camera MainCam, float rotationspeed, GameObject Karakter)
        {
            Vector3 CamOfset = MainCam.transform.forward;
            CamOfset.y = 0;
            Karakter.transform.forward = Vector3.Slerp(Karakter.transform.forward, CamOfset, Time.deltaTime * rotationspeed);
        }

        public List<float> ParametreOlustur(float[] degerler)
        {
            List<float> list = new List<float>();

            foreach(float item in degerler)
            {
                list.Add(item);
            }

            return list;
        }
    }
}
