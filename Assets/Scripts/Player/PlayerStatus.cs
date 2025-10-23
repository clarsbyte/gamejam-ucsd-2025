using System.Runtime.CompilerServices;
using UnityEngine;

public class BodyPart
{
    public bool sacrificed { get; set; }
    public bool infected { get; set; }
}

public class Body
{
    public BodyPart armLeft { get; set; }
    public BodyPart armRight { get; set; }
    public BodyPart legLeft { get; set; }
    public BodyPart legRight { get; set; }
    public BodyPart head { get; set; }
    public BodyPart torso { get; set; }
}

public class Modifier
{
    public string status { get; set; }
    public float amount { get; set; }
}

public class PlayerStatus : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;

    private float dmg = 1f;
    private float durability = 1f;
    private float attackSpeed = 1f;
    private float moveSpeed = 1f;

    private Modifier[] buffs;
    private Modifier[] debuffs;

    public Body body = new Body
    {
        armLeft = new BodyPart { sacrificed = false, infected = false },
        armRight = new BodyPart { sacrificed = false, infected = false },
        legLeft = new BodyPart { sacrificed = false, infected = false },
        legRight = new BodyPart { sacrificed = false, infected = false },
        head = new BodyPart { sacrificed = false, infected = false },
        torso = new BodyPart { sacrificed = false, infected = false },
    };

    /*
        Debuffs:
        maxhealth down
        attackspeed down
        movespeed down
    */
    private void giveDebuff()
    {
        int debuffSelector = Random.Range(0, 5);
    }

    /*
        Buffs:
        maxhealth down
        attackpower up
        movespeed down
    */
    private void giveBuff() { }

    private void onHit()
    {
        if (Random.Range(0, 5) == 0)
        {
            if (Random.Range(0, 3) == 0)
            {
                if (!body.head.infected)
                {
                    body.head.infected = true;
                }
            }
            else
            {
                if (!body.torso.infected)
                {
                    body.torso.infected = true;
                }
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        buffs = new Modifier[6];
        debuffs = new Modifier[6];
    }

    void OnCollisionEnter2D(Collision2D entity)
    {
        if (entity.gameObject.tag == "Enemy")
        {
            onHit();
        }
    }

    private double timer = 0;

    void OnCollisionStay2D(Collision2D entity)
    {
        if (entity.gameObject.tag == "Enemy")
        {
            timer += Time.deltaTime;

            if (timer >= 1.5f)
            {
                onHit();

                timer = 0f;
            }
        }
    }

    // Update is called once per frame
    void Update() { }
}
