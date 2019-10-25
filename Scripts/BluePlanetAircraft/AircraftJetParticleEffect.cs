using System;
using UnityEngine;

namespace Aircraft {
    [RequireComponent(typeof(ParticleSystem))] public class AircraftJetParticleEffect : MonoBehaviour {
        public Color minColour = Color.black;
        private AircraftController m_Jet;
        private ParticleSystem m_System;
        private float m_OriginalStartSize;
        private float m_OriginalLifetime;
        private Color m_OriginalStartColor;

        private AircraftController FindAircraftParent() {
            var t = transform;
            while (t != null) {
                var air = t.GetComponent<AircraftController>();
                if (air == null) {
                    t = t.parent;
                } else {
                    return air;
                }
            }
            throw new Exception("AircraftContoller not found in object hierarchy");
        }

        private void Start() {
            m_Jet = FindAircraftParent();
            m_System = GetComponent<ParticleSystem>();
            m_OriginalLifetime = m_System.main.startLifetime.constant;
            m_OriginalStartSize = m_System.main.startSize.constant;
            m_OriginalStartColor = m_System.main.startColor.color;
        }

        private void Update() {
            ParticleSystem.MainModule mainModule = m_System.main;
            mainModule.startLifetime = Mathf.Lerp(0.0f, m_OriginalLifetime, m_Jet.Throttle);
            mainModule.startSize = Mathf.Lerp(m_OriginalStartSize * .3f, m_OriginalStartSize, m_Jet.Throttle);
            mainModule.startColor = Color.Lerp(minColour, m_OriginalStartColor, m_Jet.Throttle);
        }

        
    }
}

