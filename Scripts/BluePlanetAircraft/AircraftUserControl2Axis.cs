using UnityEngine;

namespace Aircraft {
    [RequireComponent(typeof(AircraftController))] public class AircraftUserControl2Axis : MonoBehaviour {
        public float maxRollAngle = 80;
        public float maxPitchAngle = 80;
        private AircraftController m_Aircraft;

        private void Awake() {
            m_Aircraft = GetComponent<AircraftController>();
        }

        private void FixedUpdate() {
            float roll = Input.GetAxis("Horizontal");
            //float pitch = Input.GetAxis("Vertical");
            bool airBrakes = Input.GetButton("Fire1");
            float throttle = airBrakes ? -1 : 1;
            //m_Aircraft.Move(roll, pitch, 0, throttle, airBrakes);
            m_Aircraft.Movers(roll, 0, throttle, airBrakes);
        }
    }
}

