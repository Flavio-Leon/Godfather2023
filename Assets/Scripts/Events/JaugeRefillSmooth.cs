using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JaugeRefillSmooth : MonoBehaviour
{
    public Slider slider;
    public float VitesseDescente;
    public float refillValue;

    public void SetMaxFluid(float Fluid)
    {
        slider.maxValue = Fluid;
        slider.value = Fluid;
    }

    public void SetFluid(float Fluid)
    {
        slider.value = Fluid;
    }

    private void Start()
    {
        slider.value = 1;
    }

    void Update()
    {
        SetFluid(slider.value);

        if (Input.GetKey(KeyCode.L))
        {
            Refill(refillValue/1000);
        } else
        {
            slider.value -= Time.deltaTime * VitesseDescente * EventPool.GameSpeed;
        }
    }

    public void Refill(float refill)
    {
        slider.value += refill;
        SetFluid(slider.value);
    }
}
