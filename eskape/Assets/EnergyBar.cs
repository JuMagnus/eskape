using UnityEngine.UI;
using UnityEngine;

public class EnergyBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetMaxEnergy(float energy)
    {
        slider.maxValue = energy;
        slider.value = energy;
    }

    public void SetEnergy(float energy)
    {
        slider.value = energy;
    }
}

