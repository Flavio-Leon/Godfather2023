using UnityEngine;
using UnityEngine.UI;

namespace GF
{
    public class JaugeRefillSmoothEvent : MonoBehaviour
    {
        [SerializeField] private Button _button0;
        [SerializeField] private Button _button1;

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

            if (Input.GetKey(_button0.MappingKeyCode) && Input.GetKey(_button1.MappingKeyCode))
            {
                Refill(refillValue / 1000);
            }
            else
            {
                slider.value -= Time.deltaTime * VitesseDescente * EventPool.Instance.GameSpeed;
            }

            if (slider.value <= 0)
            {
                EventPool.Instance.LoseGame();
            }

            if (slider.value < 0.3f)
            {
                Alerte.SetActive(true);
                Debug.Log("Alrte");
            }
            else
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