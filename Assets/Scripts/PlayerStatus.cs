using System.Collections;
using UnityEngine;

public enum Parts
{
    Arm,
    Leg,
    Body,
    Head,
}

public enum InfectionStage
{
    Healthy,
    Minor,
    Major,
    Severe,
}

public class BodyPart
{
    public Parts part { get; set; }
    public int health { get; set; }
    public InfectionStage infectionStage { get; set; }
    public double timer { get; set; }
}

/*
public class Body
{
    public BodyPart leftArm = new BodyPart
    {
        part = Parts.Arm,
        health = 10,
        infected = false,
    };
    public BodyPart rightArm = new BodyPart
    {
        part = Parts.Arm,
        health = 10,
        infected = false,
    };
    public BodyPart leftLeg = new BodyPart
    {
        part = Parts.Leg,
        health = 10,
        infected = false,
    };
    public BodyPart rightLeg = new BodyPart
    {
        part = Parts.Leg,
        health = 10,
        infected = false,
    };
    public BodyPart body = new BodyPart
    {
        part = Parts.Body,
        health = 35,
        infected = false,
    };
    public BodyPart head = new BodyPart
    {
        part = Parts.Head,
        health = 25,
        infected = false,
    };
}
*/

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    private int currentHealth;

    private BodyPart[] body = new BodyPart[6]
    {
        new BodyPart
        {
            part = Parts.Arm,
            health = 10,
            infectionStage = InfectionStage.Healthy,
            timer = 0f,
        },
        new BodyPart
        {
            part = Parts.Arm,
            health = 10,
            infectionStage = InfectionStage.Healthy,
            timer = 0f,
        },
        new BodyPart
        {
            part = Parts.Leg,
            health = 10,
            infectionStage = InfectionStage.Healthy,
            timer = 0f,
        },
        new BodyPart
        {
            part = Parts.Leg,
            health = 10,
            infectionStage = InfectionStage.Healthy,
            timer = 0f,
        },
        new BodyPart
        {
            part = Parts.Body,
            health = 35,
            infectionStage = InfectionStage.Healthy,
            timer = 0f,
        },
        new BodyPart
        {
            part = Parts.Head,
            health = 25,
            infectionStage = InfectionStage.Healthy,
            timer = 0f,
        },
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void damagePart()
    {
        int i = Random.Range(0, 6);

        body[i].health -= 5;

        Debug.Log(string.Format("Body part {0} now has {1} health", body[i].part, body[i].health));

        if (Random.Range(0, 3) == 0)
        {
            body[i].infectionStage = InfectionStage.Minor;
            Debug.Log(string.Format("Body part {0} was infected", body[i].part));
        }
    }

    void OnCollisionEnter2D(Collision2D entity)
    {
        if (entity.gameObject.tag == "Enemy")
        {
            damagePart();

            Debug.Log("First collide with " + entity.gameObject.GetInstanceID());
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
                damagePart();

                timer = 0f;
            }
        }
    }

    private void updateInfection()
    {
        foreach (BodyPart bodyPart in body)
        {
            if (bodyPart.infectionStage != InfectionStage.Healthy)
            {
                if (bodyPart.timer >= 5 && bodyPart.infectionStage != InfectionStage.Severe)
                {
                    ++bodyPart.infectionStage;
                    bodyPart.timer = 0;
                    Debug.Log(string.Format("Infection now at {0} stage", bodyPart.infectionStage));
                }
                else
                    bodyPart.timer += Time.deltaTime;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateInfection();
    }
}
