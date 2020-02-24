using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //* variables del movimiento del personaje

    public float jumpForce = 6f;
    public float runningSpeed = 2f;
    Rigidbody2D playerRB;
    Animator animator;

    const string STATE_ALIVE = "isAlive";
    const string STATE_ON_THE_GROUNG = "isOnTheGround";
    const string STATE_ACCELERATION = "aceleration";

    public LayerMask groundmask;

    public static PlayerController sharedPlayer;

    public float distance = 1.4f;

    void Awake()
    {
        sharedPlayer = this;
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUNG, false);
        animator.SetFloat(STATE_ACCELERATION, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        //* Modificar el valor del boleando con lo que retorna la funcion IsThouchingTheGround
        animator.SetBool(STATE_ON_THE_GROUNG, IsTouchingTheGround());
        //* Modificar el valor de acceleration del animator para avanzar en la animacion
        animator.SetFloat(STATE_ACCELERATION, playerRB.velocity.y);

        //* Creando un Gizmo
        Debug.DrawRay(this.transform.position, Vector2.down * distance, Color.green);
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (playerRB.velocity.x < runningSpeed)
        {
            playerRB.velocity = new Vector2(runningSpeed, playerRB.velocity.y);
        }
    }

    //* Realiza el salto
    void Jump()
    {
        if (IsTouchingTheGround())
        {
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    //* Nos indica si esta el personaje tocando o no el suelo con raycast
    bool IsTouchingTheGround()
    {
        //* inicio las fisicas para trazar el rayo invisible
        if (Physics2D.Raycast(this.transform.position, //* desde donde sale el rayo en este caso el personaje
            Vector2.down, //* hacia donde sale el rayo
            distance, //* distancia maxima
            groundmask)) //* contra la mascara del suelo
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
