using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControlle : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float speed = 4;
    private float horizontal;
    private float vertical;
    public GameObject _bala;
    public Transform _guardabala;
    private Vector2 direccionbala;
    public GamecontrolXD gameController;
    public AudioSource audioGrito;
    private int puntaje = 0;
    public Animator animacionMRDCTM;

    void Awake()
    {
        animacionMRDCTM = GetComponent<Animator>();
    }
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        direccionbala = new Vector2(0,1);
    }
    void Update()
    {
        if(horizontal == 1 || horizontal == -1)
        {
            direccionbala = new Vector2(horizontal, 0);
        }else if(vertical ==1 || vertical == -1)
        {
            direccionbala = new Vector2(0, vertical);
        }
        if (horizontal == 0)
        {
            vertical = Input.GetAxisRaw("Vertical");
        }
        if(vertical == 0)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }//pa q detecte movimientos 

        if (Input.GetKey(KeyCode.A)==true)
        {
            animacionMRDCTM.SetBool("IsIzquierda", true);
            animacionMRDCTM.SetBool("IsDerecha", false);
            animacionMRDCTM.SetBool("IsAbajo", false);
            animacionMRDCTM.SetBool("IsArriba", false);
        }
        else if (Input.GetKey(KeyCode.W) == true)
        {
            animacionMRDCTM.SetBool("IsArriba", true);
            animacionMRDCTM.SetBool("IsDerecha", false);
            animacionMRDCTM.SetBool("IsAbajo", false);
            animacionMRDCTM.SetBool("IsIzquierda", false);
        }
        else if (Input.GetKey(KeyCode.S) == true)
        {
            animacionMRDCTM.SetBool("IsAbajo", true);
            animacionMRDCTM.SetBool("IsArriba", false);
            animacionMRDCTM.SetBool("IsDerecha", false);
            animacionMRDCTM.SetBool("IsIzquierda", false);
        }
        else if (Input.GetKey(KeyCode.D) == true)
        {
            animacionMRDCTM.SetBool("IsDerecha", true);
            animacionMRDCTM.SetBool("IsArriba", false);
            animacionMRDCTM.SetBool("IsAbajo", false);
            animacionMRDCTM.SetBool("IsIzquierda", false);
        }else if (Input.GetKey(KeyCode.W) == false&& Input.GetKey(KeyCode.A) == false&& Input.GetKey(KeyCode.S) == false&& Input.GetKey(KeyCode.D) == false)
        {
            animacionMRDCTM.SetBool("IsDerecha", false);
            animacionMRDCTM.SetBool("IsArriba", false);
            animacionMRDCTM.SetBool("IsAbajo", false);
            animacionMRDCTM.SetBool("IsIzquierda", false);
        }//y pensar que me tomo solo 2 ciclos usar las malditas animaciones ._.

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject gameObjectBala = Instantiate(_bala, transform.position, transform.rotation, _guardabala);
            gameObjectBala.GetComponent<BulletVelocity>().VelocityBullet(direccionbala);
            audioGrito.Play();
        }//generar bala cada vez de que se presione espacio
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemigo")
        {
            Destroy(collision.gameObject);
            gameController.Perder();
        }
    }//choca con un enemigo y se muere p
    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(horizontal * speed, vertical * speed);
    }//velocidad del personaje
    public void IncrementoPuntaje(int puntosGanados)
    {
        puntaje = puntaje + puntosGanados;

    }//esto es para el tema de los puntos
}