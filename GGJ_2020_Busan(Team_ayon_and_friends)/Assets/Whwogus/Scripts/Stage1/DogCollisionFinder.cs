using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DogCollisionFinder : MonoBehaviour
{
    public AIDestinationSetter petGoal;
    public PetAnim dogAnim;
    public GameObject inCircle;

    void Start()
    {
        petGoal = GetComponentInParent<AIDestinationSetter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "outCircle")
        {
            petGoal.target = inCircle.transform;
        }
        if (collision.tag == "inCircle")
        {
            SoundManager.instance.SoundPlay("Bark");
            StartCoroutine(Bark2Times());
        }
    }

    IEnumerator Bark2Times()
    {
        dogAnim.isBarking = true;
        dogAnim.SetAnim(PetAnim.AnimState.Angry);
        yield return new WaitForSeconds(4f);
        dogAnim.SetAnim(PetAnim.AnimState.sit);
    }
}
