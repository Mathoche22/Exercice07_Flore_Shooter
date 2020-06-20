using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed; // controle the player's speed in the inspector

    private PlayerControle PlayerControle;
    // private Vector2 direction;
    
    public Rigidbody2D rb; // get the rigidbody of the player
    public Camera cam;

    Vector2 movement; // get the directions of the player
    Vector2 mousePos; // get the directions of the mouse


    void Start()
    {
        PlayerControle = new PlayerControle(); // new controls's type class
        PlayerControle.Enable();// activate l'actionMap
        PlayerControle.Player.Move.performed += OnMovePerformed; // add fonction to the input actions
        PlayerControle.Player.Move.canceled += OnMoveCanceled; // add fonction to the input actions

    }

    /// <summary> 
    /// make the player move
    /// </summary>
    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        movement = obj.ReadValue<Vector2>();
        /*var directions = obj.ReadValue<float>();
        var direction = new Vector3(0, directions, 0);
        transform.position += direction;*/
    }

    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        movement = Vector2.zero;
        /*var directions = obj.ReadValue<float>();
        var direction = new Vector3(0, directions, 0);
        transform.position += direction;*/
    }


    void Update()
    {
        /*// get the direction on the x axis
        movement.x = Input.GetAxisRaw("Horizontal"); 
        // get the direction on the y axis
        movement.y = Input.GetAxisRaw("Vertical");*/

        // set the position of the mouse from the screen to the world of the game
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); 
        
    }

    void FixedUpdate()
    {
        // uniform and fluid movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // substracte the two vectors to get the direction the player needs to go to
        Vector2 lookDir = mousePos - rb.position;
        
        // apply to a variable "get the player's position to face the mouse"
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;// get from gradiants to percents
       
        // apply to the player
        rb.rotation = angle; 

    }
}

