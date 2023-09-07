using UnityEngine;
using UnityEngine.UI;

namespace GF
{
    public class JaugeEvent : MonoBehaviour
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

            slider.value -= Time.deltaTime * VitesseDescente * EventPool.Instance.GameSpeed;

            if (Input.GetKeyDown(_button.MappingKeyCode))
            {
                Refill(refillValue);
            }
        }

        public void Refill(float refill)
        {
            slider.value += refill;

            SetFluid(slider.value);
        }
    }
}