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
    public string name { get; set; }
    public float number { get; set; }
    public int amount { get; set; }
}

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    private int currentHealth;

    private float dmg = 1f;
    private float durability = 1f;
    private float attackSpeed = 1f;
    private float moveSpeed = 1f;

    private string[] buffs;
    private string[] debuffs;

    public Body body = new Body
    {
        armLeft = new BodyPart { sacrificed = false, infected = false },
        armRight = new BodyPart { sacrificed = false, infected = false },
        legLeft = new BodyPart { sacrificed = false, infected = false },
        legRight = new BodyPart { sacrificed = false, infected = false },
        head = new BodyPart { sacrificed = false, infected = false },
        torso = new BodyPart { sacrificed = false, infected = false },
    };

    private void giveDebuff() { }

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
        buffs = new string[6];
        debuffs = new string[6];
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
