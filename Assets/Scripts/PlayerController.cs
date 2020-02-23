using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //* variables del movimiento del personaje

    public float jumpForce = 6f;
    Rigidbody2D playerRB;

    public LayerMask groundmask;

    public float distance = 1.4f;

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }


        //* Creando un Gizmo
        Debug.DrawRay(this.transform.position, Vector2.down * distance , Color.green);
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
            //TODO: programar logica de contacto con el suelo
            return true;
        }
        else
        {
            //TODO: profrmar logica de noo contacto
            return false;
        }
    }
}
