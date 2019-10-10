using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINPC : MonoBehaviour {
    private NavMeshAgent thisAgent;
    public Transform playerPosition;
    public float chaseDistance = 1f;

    // ------------------------------------------------------------------------
    public enum STATES { CHASE = 0, IDLE = 1 };
    // ------------------------------------------------------------------------
    [SerializeField] // makes the underneath private var visible in inspector
    private STATES _myStates = STATES.CHASE;

    // ------------------------------------------------------------------------
    public STATES MyStates {
        get {
            return _myStates;
        }

        set {
            StopAllCoroutines();
            _myStates = value;
            switch(_myStates) {
                case STATES.CHASE:
                    StartCoroutine(StateChase());
                    break;
                case STATES.IDLE:
                    StartCoroutine(StateIdle());
                    break;
            }
        }
    }
    // ------------------------------------------------------------------------
    private void Awake() {
        thisAgent = GetComponent<NavMeshAgent>();
    }
    // ------------------------------------------------------------------------
    private void Start() {
        MyStates = _myStates;
    }
    // ------------------------------------------------------------------------
    public IEnumerator StateChase () {
        while (MyStates == STATES.CHASE) {
            // This tells the NPC to chase the player
            thisAgent.SetDestination(playerPosition.position);

            // Check the distance between the NPC and the player
            if (Vector3.Distance(playerPosition.position, transform.position) <= chaseDistance) {
                MyStates = STATES.IDLE;
                yield break;
            }
            yield return null;
        }
    }
    // ------------------------------------------------------------------------
    public IEnumerator StateIdle() {
        while (MyStates == STATES.IDLE) {
            yield return null;
        }
    }
}
