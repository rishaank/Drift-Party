using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterSystem
{

    public class CarAudio : MonoBehaviour
    {
        public AudioSource audioSource;
        public float defaultPitch = 1f;
        public float maxPitch = 4f;
        private float pitchFromCar;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            pitchFromCar = (Car_controller.cc.carSpeed / 50);
            if (pitchFromCar < 1)
            {
                audioSource.pitch = defaultPitch;
            }
            else if (pitchFromCar > maxPitch)
            {
                audioSource.pitch = maxPitch;
            }
            else
            {
                audioSource.pitch = pitchFromCar;
            }
        }
    }
}
