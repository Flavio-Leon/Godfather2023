using UnityEngine;
using UnityEngine.UI;

namespace GF
{
    public class JaugeRefillSmoothEvent : MonoBehaviour
    {
        [SerializeField] private Button _button;

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

        private void Update()
        {
            SetFluid(slider.value);

            if (Input.GetKey(_button.MappingKeyCode))
            {
                Refill(refillValue / 1000);
            }
            else
            {
                slider.value -= Time.deltaTime * VitesseDescente * EventPool.Instance.GameSpeed;
            }
        }

        public void Refill(float refill)
        {
            slider.value += refill;
            SetFluid(slider.value);
        }
    }
}