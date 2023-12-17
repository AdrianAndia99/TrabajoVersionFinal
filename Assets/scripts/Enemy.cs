using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Yo y los seralize field")]
    [SerializeField] protected float vida;
    [SerializeField] protected Rigidbody2D _rigidbody2D;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected AudioSource _audio;
    [SerializeField] protected BoxCollider2D boxCollider;
    [SerializeField] protected float velocity;

    private float direccionJugador;
    protected Transform positionPlayer;  
    public Puntaje _gm;
    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    protected virtual void Update()
    {
        VolteoSprite();
    }//pa q se llame constantemente el metodo 

    protected void OnDamage(float damage)
    {
        if(damage >= vida)
        {
            spriteRenderer.color = new Color(1, 0, 0, 1);
            boxCollider.enabled = false;
            Destroy(this.gameObject,0.5f);
            _gm.puntajeConstante();
            //print("gaa"); este print era para probar nomas si funciona, y si funciona gaaaaa
        }//si el daño que recibe es mayor a la vida del enemigo, se destruye el enemigo,cambia su color a rojo y el puntaje aumenta
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {          
        if (other.gameObject.tag == "bala")
        {
            float a = other.gameObject.GetComponent<BulletVelocity>().damage;
            this.OnDamage(a);// aca se llama p el metodo de la bala pa q reciba el daño que tiene
        }        
    }
    public void refPlayer(Transform transform)
    {
        positionPlayer = transform;        
    }//posicion del jugador
    public virtual void anotherTargetPlayer()
    {       
        if(positionPlayer.gameObject != null)
        {
            Vector2 direction = positionPlayer.position - transform.position;
            direction.Normalize();
            _rigidbody2D.velocity = direction * velocity;
        }//calcular la direccion al jugador
    }
    protected void FixedUpdate()
    {
        anotherTargetPlayer();//el metodo del jugador p aca se actualiza cada tanto
    }
    protected void VolteoSprite()
    {
        direccionJugador = positionPlayer.position.x - transform.position.x;
        if(direccionJugador > 0)
        {
            spriteRenderer.flipX = true;
        }else if(direccionJugador < 0)
        {
            spriteRenderer.flipX = false;
        }
    }//metodo pa q se gire el sprite de los enemigos gaaa
    public void gameManager(Puntaje gm)
    {
        this._gm = gm;
    }//referencia de los puntitos p 
}