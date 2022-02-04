using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onda2 : MonoBehaviour
{
    ParticleSystem ps;          //particulas principales
    public Gradient color1;     //gradiente 1
    float duracion;     //duracion del efecto
    float t;            //tiempo
    ParticleSystem.MainModule main; //main 1
    ParticleSystem.SizeOverLifetimeModule tamaño;       //tamaño 1
    ParticleSystem.ColorOverLifetimeModule colorvida1;      //color 1
    [SerializeField] AnimationCurve curva;      //curva tamaño
    [SerializeField] AnimationCurve curva2;      //curva radio
    [SerializeField] AnimationCurve curva3;      //curva sonido

    ParticleSystem.ShapeModule shape1;      //forma particulas 1

    [SerializeField] ParticleSystem ps2;          //particulas secundaria
    public Gradient color2;     //gradiente 2
    float t2;            //tiempo 2
    ParticleSystem.MainModule main2; //main 2
    ParticleSystem.SizeOverLifetimeModule tamaño2;       //tamaño 2
    ParticleSystem.ColorOverLifetimeModule colorvida2;      //color 2
    ParticleSystem.ShapeModule shape2;      //forma particulas 2

    [SerializeField] Light luz;
    public Gradient colorLuz;     //gradiente 3

    AudioSource sonido;


    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        ParticleSystem.MinMaxCurve mmcurve = new ParticleSystem.MinMaxCurve(10, curva);
        ParticleSystem.MinMaxCurve mmcurve2 = new ParticleSystem.MinMaxCurve(10, curva2);
        ParticleSystem.MinMaxCurve mmcurve3 = new ParticleSystem.MinMaxCurve(10, curva3);
    
        ps.Play();
        duracion = ps.main.duration;
        main = ps.main;
        tamaño = ps.sizeOverLifetime;
        colorvida1 = ps.colorOverLifetime;
        colorvida1.color = color1;
        shape1 = ps.shape;

        main2 = ps2.main;
        tamaño2 = ps2.sizeOverLifetime;
        colorvida2 = ps2.colorOverLifetime;
        colorvida2.color = color2;
        shape2 = ps2.shape;

        sonido = GetComponent<AudioSource>();
        sonido.Play();
    }

    void Update()
    {
        sonido.volume = curva3.Evaluate(t / duracion);
        Expandir();
        ColorLuz();

        if (t >= (duracion / 2))
        {
            Expandir2();
        }
    }

    public void Expandir()
    {
        tamaño.size = curva.Evaluate(t / duracion);
        shape1.radius = 10*curva2.Evaluate(t / duracion);
        t += Time.deltaTime;

        if(ps.isPlaying==false)
        {
            t = 0;
        }
        
    }
    public void Expandir2()
    {
        ps2.Play();
        tamaño2.size = curva.Evaluate(t2 / duracion);
        shape2.radius = 10 * curva2.Evaluate(t2 / duracion);
        t2 += Time.deltaTime;

        if (t>=duracion)
        {
            t2 = 0;
        }
    }

    public void ColorLuz()
    {
        luz.range = 20*curva.Evaluate(t/duracion);
        luz.color = colorLuz.Evaluate(t/duracion);
    }
}