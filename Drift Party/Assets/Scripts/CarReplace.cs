using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Cinemachine
{
    public class CarReplace : MonoBehaviour
    {
        public GameObject FastCar;
        public GameObject OldCar;
        public CinemachineVirtualCamera CinemaCamera;
        public void OnCollisionEnter (Collision other)
        {
            FastCar.SetActive(true);
            CinemaCamera.m_LookAt = FastCar.transform;
            CinemaCamera.m_Follow = FastCar.transform;
            OldCar.SetActive(false);
        }

    }
}