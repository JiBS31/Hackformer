using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMoves : MonoBehaviour
{ 

    [SerializeField] float fallMultiplier;
    public GameObject KeyObject;
    public GameObject Player;
    public Rigidbody2D rbplayer;
    public float Speed = 5f;
    public bool Speedo;
    public float Jump = 5f;

    public LayerMask groundLayer;
    public UnityEngine.Transform groundCheck;
    public float groundCheckWidth;
    public float groundCheckHeight;

    public LayerMask wallLayer;
    public UnityEngine.Transform wallcheckleft;
    public UnityEngine.Transform wallcheckright;
    public float wallCheckWidth;
    public float wallCheckHeight;

    public Animator animPlayer;
    bool isGrounded;
    bool isWalled;
    bool isJumping;
    bool isRunning;
    public SpriteRenderer srplayer;
    Vector2 vecGravity;
    
    

    // Start is called before the first frame update
    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rbplayer = GetComponent<Rigidbody2D>();
        srplayer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si le joueur appuie sur K le niveau reload.
        if (Input.GetKey(KeyCode.K))
        {
            SceneManager.LoadScene("Level 1");
        }
        // Si le joueur appuie sur R le joueur retourne au spawn.
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector2(275.95f, -28.3f);
        }

        //Boolean

        // Si la velocité de Y est strictement égal à 0 isJumping est vrai sinon il est faux.
        if(rbplayer.velocity.y != 0)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
        // Si la velocité de X est strictement égal à 0 isRunning est vrai sinon faux.

        if (rbplayer.velocity.x != 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }


        //Animator

        /* Si le joueur cours et est au sol. l'animator met le isRunning et le isGrounded en vrai.
         Sinon il les mets en faux.*/

        if (Player == isRunning && Player == isGrounded)
        {
            animPlayer.SetBool("isRunning", true);
            animPlayer.SetBool("isGrounded", true);
        }
        else
        {
            animPlayer.SetBool("isRunning", false);
            animPlayer.SetBool("isGrounded", false);
        }

        /* Si le joueur saute et qu'il n'est pas au sol, l'animator met isJumping en vrai et isGrounded en faux.
         Sinon l'inverse. */

        if (Player == isJumping && Player != isGrounded)
        {
            animPlayer.SetBool("isJumping", true);
            animPlayer.SetBool("isGrounded", false);
        }
        else
        {
            animPlayer.SetBool("isJumping", false);
            animPlayer.SetBool("isGrounded", true);
        }


        // Si le joueur cours, saute et n'est pas au sol, l'animator met isRunning et isJumping en vrai et isGrounded dans faux.

        if (Player == isRunning && Player == isJumping && Player != isGrounded)
        {
            animPlayer.SetBool("isRunning", true);
            animPlayer.SetBool("isJumping", true);
            animPlayer.SetBool("isGrounded", false);
        }        

        //Moves

        //h est égal l'axe horizontal dans le InputManager * la vitesse du joueur.

        float h = Input.GetAxis("Horizontal") * Speed;

        // la velocité du rigidbody = au vecteur h sur X et la vélocité du joueur sur Y.
        rbplayer.velocity = new Vector2(h, rbplayer.velocity.y);
        // Les contraintes du rigidBody est gelée sur la rotation.
        rbplayer.constraints = RigidbodyConstraints2D.FreezeRotation;

       //Saut

        /* isGrounded = CapsuleCollider, prend la position du groundCheck, un Vector au coordonnées 1.007094 en X et 0.1766942 en Y.
        La capsule est en horizontal en 0 sur le Layer Ground.*/
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.007094f, 0.1766942f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
        rbplayer.AddForce(transform.up * Jump, ForceMode2D.Impulse);
        isJumping = true;
        }


            if (h > 0.3)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

        if (h < 0)
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
        }


        //Fall

        if (rbplayer.velocity.y < 0)
        {
        rbplayer.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }

        //Wall

        isWalled = Physics2D.OverlapCapsule(wallcheckleft.position, new Vector2(0.09301802f, 1.03652f), CapsuleDirection2D.Vertical, 0, wallLayer);
        isWalled = Physics2D.OverlapCapsule(wallcheckright.position, new Vector2(0.09301802f, 1.03652f), CapsuleDirection2D.Vertical, 0, wallLayer);

        if (isWalled == true)
        {
        rbplayer.velocity = new Vector2(0, rbplayer.velocity.y); 
            if (isWalled == true && isGrounded == true)

            {
             rbplayer.velocity = new Vector2(0, rbplayer.velocity.y);
            }

        }


        //print(isWalled);
        }

        private void OnDrawGizmos()
        {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(groundCheck.position, new Vector2(groundCheckWidth, groundCheckHeight));
        Gizmos.DrawCube(wallcheckright.position, new Vector2(wallCheckWidth, wallCheckHeight));
        Gizmos.DrawCube(wallcheckleft.position, new Vector2(wallCheckWidth, wallCheckHeight));
        }
        }