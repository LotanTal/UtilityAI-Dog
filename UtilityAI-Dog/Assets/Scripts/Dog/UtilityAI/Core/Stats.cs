using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace CorgiTools.Core
{
    public class Stats : MonoBehaviour
    {
        private int _energy;
        public int energy
        {
            get { return _energy; }
            set
            {
                _energy = Mathf.Clamp(value, 0, 100);
                OnStateValueChanged?.Invoke();
            }
        }

        private int _hunger;
        public int hunger
        {
            get { return _hunger; }
            set
            {
                _hunger = Mathf.Clamp(value, 0, 100);
                OnStateValueChanged?.Invoke();
            }
        }

        private int _money;
        public int money
        {
            get { return _money; }
            set
            {
                _money = Mathf.Clamp(value, 0, 100);
                OnStateValueChanged?.Invoke();
            }
        }

        [SerializeField] private float timeToDecreaseHunger = 5f;
        [SerializeField] private float timeToDecreaseEnergy = 5f;
        private float timeLeftEnergy;
        private float timeLeftHunger;
        [SerializeField] private Billboard billboard;
        public delegate void StateValueChangedHandler();
        public event StateValueChangedHandler OnStateValueChanged;

        void Start()
        {
            // hunger = Random.Range(20, 80);
            // energy = Random.Range(20, 80);
            // money = Random.Range(20, 80);

            //Test case: NPC will likely work
            hunger = 0;
            energy = 100;
            money = 50;

            //Test case: NPC will likely eat
            // hunger = 90;
            // energy = 50;
            // money = 500;

            //Test case: NPC will likely sleep
            // hunger = 0;
            // energy = 10;
            // money = 500;
        }
        private void Update()
        {
            UpdateHunger();
            UpdateEnergy();
        }

        private void OnEnable()
        {
            // OnStateValueChanged += UpdateDisplayText;

        }
        private void OnDisable()
        {
            // OnStateValueChanged -= UpdateDisplayText;
        }

        public void UpdateHunger()
        {
            if (timeLeftHunger > 0)
            {
                timeLeftHunger -= Time.deltaTime;
                return;
            }
            timeLeftHunger = timeToDecreaseHunger; ;
            hunger += 5;
        }

        public void UpdateEnergy()
        {
            if (timeLeftEnergy > 0)
            {
                timeLeftEnergy -= Time.deltaTime;
                return;
            }
            timeLeftEnergy = timeToDecreaseEnergy; ;
            energy -= 10;
        }

        // void UpdateDisplayText()
        // {
        //     billboard.UpdateStatsText(energy, hunger, money);
        // }
    }

}
