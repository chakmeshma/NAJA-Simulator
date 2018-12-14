using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesAndValues : MonoBehaviour {
    public static ReferencesAndValues instance = null;
    public Transform player;
    public Transform playerInsideCarFrontLeft;
    public Transform playerInsideCarFrontRight;
    public Transform playerInsideCarBackLeft;
    public Transform playerInsideCarBackRight;
    public Transform playerOutsideCarFrontLeft;
    public Transform playerOutsideCarFrontRight;
    public Transform playerOutsideCarBackLeft;
    public Transform playerOutsideCarBackRight;
    public GameObject outerCar;
    public GameObject innerCar;
    public Cursor cursorController;

    private void Awake()
    {
        instance = this;
    }
}
