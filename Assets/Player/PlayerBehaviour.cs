using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    // instantiate variables
    [SerializeField] private float speed; // controle the speed
    private Controls PlayerControle; // get the input actions
    private Vector3 direction; // controle the direction of the player


    void Start()
    {
        PlayerControle = new Controls(); // new type controls class
        PlayerControle.Enable();// activate the actionMap

        // add the fonction to actions 
        controls.Player.Move.performed += OnMovePerformed; 
        
    }
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
