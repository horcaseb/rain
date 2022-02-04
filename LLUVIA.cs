using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLUVIA : MonoBehaviour
{
    public float duracion;
    ParticleSystem ps;
    ParticleSystem.MainModule mymain;
    ParticleSystem.EmissionModule myemission;
    [SerializeField] AnimationCurve curva;
    public float velocidad;
    AudioSource volum;
    AudioClip sonido;
    float t;
    // Start is called before the first frame update
    void Awake()
    {

        ps = GetComponent<ParticleSystem>();
        mymain = ps.main;
        myemission = ps.emission;
        mymain.duration = duracion;
        volum = GetComponent<AudioSource>();
        sonido = GetComponent<AudioClip>();
        mymain.startSpeed = velocidad;

        ps.Play();
        volum.Play();

        ParticleSystem.MinMaxCurve mmcurve = new ParticleSystem.MinMaxCurve(100,curva);
        myemission.rateOverTime = mmcurve;
        
    }

    // Update is called once per frame
    void Update()
    {

        volum.volume = curva.Evaluate(t/duracion);
        t += Time.deltaTime;

    }
}
