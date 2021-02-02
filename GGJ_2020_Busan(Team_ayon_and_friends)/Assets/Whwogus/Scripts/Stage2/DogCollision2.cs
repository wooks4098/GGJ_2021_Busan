using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DogCollision2 : MonoBehaviour
{
    public AIDestinationSetter petGoal;
    public PetAnim dogAnim;
    public GameObject inCircle;

    void Start()
    {
        petGoal = GetComponentInParent<AIDestinationSetter>();
        StartCoroutine(OnStartGame());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "inCircle")
        {
            SoundManager.instance.SoundPlay("Bark");
            StartCoroutine(Bark2Times());
        }
    }

    IEnumerator OnStartGame()
    {
        yield return new WaitForSeconds(2f);
        petGoal.GetComponent<AIDestinationSetter>().enabled = true;
    }

    IEnumerator Bark2Times()
    {
        dogAnim.isBarking = true;
        dogAnim.SetAnim(PetAnim.AnimState.Angry);
        yield return new WaitForSeconds(4f);
        dogAnim.SetAnim(PetAnim.AnimState.sit);
    }
}
