using Unity.VisualScripting;
using UnityEngine;

public class FinalBossController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private GameObject fireball;

    [SerializeField]
    private GameObject aoeField;

    // Triggered by attackOne animation event
    private void attackOne()
    {
        GameObject newFireball = Instantiate(
            fireball,
            new Vector3(transform.position.x + 0.88f, transform.position.y + 1.76f, 0),
            Quaternion.identity
        );

        newFireball.SetActive(true);
    }

    // Triggered by attackTwo animation event
    private void attackTwo()
    {
        GameObject newAOE = Instantiate(
            aoeField,
            new Vector3(transform.position.x + 0.09f, transform.position.y + 0.05f, 0),
            Quaternion.identity
        );

        newAOE.SetActive(true);
    }

    private void attackThree()
    {
        AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);

        if (!stateInfo.IsName("PlayerRoll"))
        {
            Debug.Log("Freezing player");

            // implement code for freezing player
        }
    }

    private double attackCooldown = 5;

    private double currentAttackCooldown;

    private int currentMoveset = 0;

    // Cycles through the different attacks of the final boss
    private void triggerMoveset(int moveset)
    {
        switch (moveset)
        {
            case 1:
                animator.SetTrigger("attackOne");
                break;
            case 2:
                animator.SetTrigger("attackTwo");
                break;
            case 3:
                animator.SetTrigger("attackThree");
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentAttackCooldown += Time.deltaTime;

        if (currentAttackCooldown >= attackCooldown)
        {
            triggerMoveset(++currentMoveset);

            currentAttackCooldown = 0;

            if (currentMoveset > 2)
                currentMoveset = 0;
        }
    }
}
