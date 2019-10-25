using System;
using UnityEngine;

namespace Aircraft {
    public class AircraftControlSurfaceAnimator : MonoBehaviour {

        [Serializable] public class ControlSurface {

            public enum Type {
                Aileron,
                Elevator,
                Rudder,
                RuddervatorNegative,
                RuddervatorPositive,
            }

            public Transform transform;
            public float amount;
            public Type type;

            [HideInInspector] public Quaternion originalLocalRotation;
        }

        [SerializeField] private float m_Smoothing = 5f;
        [SerializeField] private ControlSurface[] m_ControlSurfaces;

        private AircraftController m_Plane;

        private void Start() {
            m_Plane = GetComponent<AircraftController>();
            foreach (var surface in m_ControlSurfaces) {
                surface.originalLocalRotation = surface.transform.localRotation;
            }
        }

        private void Update() {
            foreach (var surface in m_ControlSurfaces) {
                switch (surface.type) {
                    case ControlSurface.Type.Aileron: {
                            Quaternion rotation = Quaternion.Euler(surface.amount * m_Plane.RollInput, 0f, 0f);
                            RotateSurface(surface, rotation);
                            break;
                        }
                    case ControlSurface.Type.Elevator: {
                            Quaternion rotation = Quaternion.Euler(surface.amount * -m_Plane.PitchInput, 0f, 0f);
                            RotateSurface(surface, rotation);
                            break;
                        }
                    case ControlSurface.Type.Rudder: {
                            Quaternion rotation = Quaternion.Euler(0f, surface.amount * m_Plane.YawInput, 0f);
                            RotateSurface(surface, rotation);
                            break;
                        }
                    case ControlSurface.Type.RuddervatorPositive: {
                            float r = m_Plane.YawInput + m_Plane.PitchInput;
                            Quaternion rotation = Quaternion.Euler(0f, 0f, surface.amount * r);
                            RotateSurface(surface, rotation);
                            break;
                        }
                    case ControlSurface.Type.RuddervatorNegative: {
                            float r = m_Plane.YawInput - m_Plane.PitchInput;
                            Quaternion rotation = Quaternion.Euler(0f, 0f, surface.amount * r);
                            RotateSurface(surface, rotation);
                            break;
                        }
                }
            }
        }

        private void RotateSurface(ControlSurface surface, Quaternion rotation) {
            Quaternion target = surface.originalLocalRotation * rotation;
            surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, target, m_Smoothing * Time.deltaTime);
        }
    }
}

