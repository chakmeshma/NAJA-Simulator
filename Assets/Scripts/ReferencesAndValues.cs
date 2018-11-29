using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesAndValues : MonoBehaviour {
    public static ReferencesAndValues instance = null;
    public Transform player;
    public Vector3 playerInsideCarPosition;
    public Vector3 playerInsideCarRotation;
    public Vector3 playerOutsideCarPosition;
    public Vector3 playerOutsideCarRotation;
    public GameObject outerCar;
    public GameObject innerCar;

    private void Awake()
    {
        instance = this;
    }
}
