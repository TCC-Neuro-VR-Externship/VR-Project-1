using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Vehicles.Aeroplane {
    public class LandingGear : MonoBehaviour {
        public float raiseAtAltitude = 40;
        public float lowerAtAltitude = 40;

        private GearState m_State = GearState.Lowered;
        private Animator m_Animator;
        private Rigidbody m_Rigidbody;
        private AeroplaneController m_Plane;
        private enum GearState {
            Raised = -1,
            Lowered = 1
        }

        private void Start() {
            m_Plane = GetComponent<AeroplaneController>();
            m_Animator = GetComponent<Animator>();
            m_Rigidbody = GetComponent<Rigidbody>();
        }

        private void Update() {
            if (SceneManager.GetActiveScene().buildIndex == 1) {
                if (m_State == GearState.Lowered && m_Plane.Altitude > raiseAtAltitude
                && m_Rigidbody.velocity.y > 0) m_State = GearState.Raised;
                if (m_State == GearState.Raised && m_Plane.Altitude < lowerAtAltitude
                    && m_Rigidbody.velocity.y < 0) m_State = GearState.Lowered;
            } else if (SceneManager.GetActiveScene().buildIndex >= 2) {
                m_State = GearState.Raised;
            }
            m_Animator.SetInteger("GearState", (int) m_State);
        }
    }
}
