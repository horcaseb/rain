using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onda : MonoBehaviour
{
    ParticleSystem ps;
    public Gradient color1;
    public Gradient color2;

    float duracion;

    float t;
    float t2;


    ParticleSystem.ColorOverLifetimeModule colorvida1;
    ParticleSystem.ColorOverLifetimeModule colorvida2;

    [SerializeField] AnimationCurve curva;
    ParticleSystem ps2;

    ParticleSystem.ShapeModule shape1;
    ParticleSystem.ShapeModule shape2;
    bool play;

    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        ps2 = GetComponentInChildren<ParticleSystem>();
        ParticleSystem.MinMaxCurve mmcurve = new ParticleSystem.MinMaxCurve(100, curva);

        duracion = ps.main.duration;

        ps.Play();
        colorvida1 = ps.colorOverLifetime;
        colorvida1.color = color1;

        colorvida2 = ps2.colorOverLifetime;
        colorvida2.color = color2;

        shape1 = ps.shape;
        shape2 = ps2.shape;

    }

    void Update()
    {
        if (t >= duracion / 2 && play==true)
        {
            ps2.Play();
            play = false;
        }
        shape1.radius = 10*curva.Evaluate(t/duracion);
        t += Time.deltaTime;
        if (ps2.isPlaying)
        {
            shape2.radius = 10 * curva.Evaluate(t2 / duracion);

            t2 += Time.deltaTime;
        }
        if (t2 >= duracion)
        {
            t = 0;
            t2 = 0;
        }
    }
}
