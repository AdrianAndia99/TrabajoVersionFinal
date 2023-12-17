using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] enemyPrefab;
    public Transform targetPlayer;
    public float tiempo;
    public Puntaje controlaPuntos;
    public AudioClip[] audioClips;
    void Update()
    {
        tiempo = tiempo + Time.deltaTime;
        if (tiempo >= 5 && targetPlayer != null)
        {
            CreateEnemy();
            tiempo = 0;
        }//cada vez que el tiempo llegue a 5, y el jugador aun exista, se creara un enemigo y el tiempo volvera a 0       
    }
    void CreateEnemy()
    {
        int x = Random.Range(-13, 13);
        int y = Random.Range(-8, 8);
        int randomEnemy = Random.Range(0, enemyPrefab.Length);
        Vector2 positionEnemy = new Vector2(x,y);
        GameObject enemigo = Instantiate(enemyPrefab[randomEnemy].gameObject, positionEnemy, transform.rotation);
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioClips[randomEnemy];
        audio.Play();
        enemigo.GetComponent<Enemy>().refPlayer(targetPlayer);
        enemigo.GetComponent<Enemy>().gameManager(controlaPuntos);
    }// este si es la wbd XDDD, el enemigo se genera en un determinado rango y cada vez que se genere reproducira un sonido
    //que le corresponde a cada uno, y seguira al jugador en el refPlayer
}