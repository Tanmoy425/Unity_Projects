using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energybar : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMaxEnergy(float energy)
    {
        slider.maxValue = energy;
        slider.value = 60;
    }

    public void SetHEnergy(float energy)
    {
        slider.value = energy;
    }
}
