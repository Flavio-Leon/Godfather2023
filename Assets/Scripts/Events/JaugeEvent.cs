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
        public GameObject Alerte;

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

            if (slider.value <= 0)
            {
                EventPool.Instance.LoseGame();
            }

            if (slider.value <= 0.3f)
            {
                Alerte.SetActive(true);
            } else
            {
                Alerte.SetActive(false);
            }
        }

        public void Refill(float refill)
        {
            slider.value += refill;

            SetFluid(slider.value);
        }
    }
}