using System;
using UnityEngine;

namespace Aircraft {
    public class AircraftAudio : MonoBehaviour {

        [Serializable] public class AdvancedSetttings {
            public float engineMinDistance = 50f;
            public float engineMaxDistance = 1000f;
            public float engineDopplerLevel = 1f;
            [Range(0f, 1f)] public float engineMasterVolume = 0.5f;
            public float windMinDistance = 10f;
            public float windMaxDistance = 100f;
            public float windDopplerLevel = 1f;
            [Range(0f, 1f)] public float windMasterVolume = 0.5f;
        }

        // -----------[SerializeField] Start---------------------------------//
        private AudioClip m_EngineSound;
        private float m_EngineMinThrottlePitch = 0.4f;
        private float m_EngineMaxThrottlePitch = 2f;
        private float m_EngineFwdSpeedMultiplier = 0.002f;
        private AudioClip m_WindSound;
        private float m_WindBasePitch = 0.2f;
        private float m_WindSpeedPitchFactor = 0.004f;
        private float m_WindMaxSpeedVolume = 100;
        private AdvancedSetttings m_AdvancedSetttings = new AdvancedSetttings();
        // -----------[SerializeField] End ----------------------------------//

        private AudioSource m_EngineSoundSource;
        private AudioSource m_WindSoundSource;
        private AircraftController m_Plane;
        private Rigidbody m_Rigidbody;

        private void Awake() {
            m_Plane = GetComponent<AircraftController>();
            m_Rigidbody = GetComponent<Rigidbody>();

            m_EngineSoundSource = gameObject.AddComponent<AudioSource>();
            m_EngineSoundSource.playOnAwake = false;

            m_WindSoundSource = gameObject.AddComponent<AudioSource>();
            m_WindSoundSource.playOnAwake = false;

            m_EngineSoundSource.clip = m_EngineSound;
            m_WindSoundSource.clip = m_WindSound;

            m_EngineSoundSource.minDistance = m_AdvancedSetttings.engineMinDistance;
            m_EngineSoundSource.maxDistance = m_AdvancedSetttings.engineMaxDistance;
            m_EngineSoundSource.loop = true;
            m_EngineSoundSource.dopplerLevel = m_AdvancedSetttings.engineDopplerLevel;

            m_WindSoundSource.minDistance = m_AdvancedSetttings.windMinDistance;
            m_WindSoundSource.maxDistance = m_AdvancedSetttings.windMaxDistance;
            m_WindSoundSource.loop = true;
            m_WindSoundSource.dopplerLevel = m_AdvancedSetttings.windDopplerLevel;

            Update();

            m_EngineSoundSource.Play();
            m_WindSoundSource.Play();
        }

        private void Update() {
            var enginePowerProportion = Mathf.InverseLerp(0, m_Plane.MaxEnginePower, m_Plane.EnginePower);
            m_EngineSoundSource.pitch = Mathf.Lerp(m_EngineMinThrottlePitch, m_EngineMaxThrottlePitch, enginePowerProportion);
            m_EngineSoundSource.pitch += m_Plane.ForwardSpeed * m_EngineFwdSpeedMultiplier;
            m_EngineSoundSource.volume = Mathf.InverseLerp(0, m_Plane.MaxEnginePower * m_AdvancedSetttings.engineMasterVolume, m_Plane.EnginePower);

            float planeSpeed = m_Rigidbody.velocity.magnitude;
            m_WindSoundSource.pitch = m_WindBasePitch + planeSpeed * m_WindSpeedPitchFactor;
            m_WindSoundSource.volume = Mathf.InverseLerp(0, m_WindMaxSpeedVolume, planeSpeed) * m_AdvancedSetttings.windMasterVolume;
        }
    }
}

