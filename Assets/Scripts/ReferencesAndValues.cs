using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesAndValues : MonoBehaviour {
    public static ReferencesAndValues instance = null;
    public Transform player;
    public Vector3 playerInsideCarPositionFrontLeft;
    public Vector3 playerInsideCarPositionFrontRight;
    public Vector3 playerInsideCarPositionBackLeft;
    public Vector3 playerInsideCarPositionBackRight;
    public Vector3 playerOutsideCarPositionFrontLeft;
    public Vector3 playerOutsideCarPositionFrontRight;
    public Vector3 playerOutsideCarPositionBackLeft;
    public Vector3 playerOutsideCarPositionBackRight;
    public Vector3 playerInsideCarRotation;
    public Vector3 playerOutsideCarRotation;
    public GameObject outerCar;
    public GameObject innerCar;

    private void Awake()
    {
        instance = this;
    }
}
