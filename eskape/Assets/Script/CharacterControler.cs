
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float currentMoveSpeed = 0f;
    public float targetMoveSpeed = 0f;
    public float limits = 5f;
    public float targetSpeed = 10f;
    public float currentSpeed = 0f;

    private Vector3 currentDirection = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private float currentEnergy = 0f;
    private float maxEnergy = 1000f;
    [SerializeField] private EnergyBar energyBar;

    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
        targetSpeed = maxSpeed;
    }

    void Update()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime);
        currentMoveSpeed = targetMoveSpeed * (currentSpeed / maxSpeed);

        Vector3 targetDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.Q))
        {
            targetDirection += Vector3.left;
            Debug.Log("Q");
        }
        if (Input.GetKey(KeyCode.D))
        {
            targetDirection += Vector3.right;
            Debug.Log("D");
        }

        if (transform.position.x > limits)
        {
            targetDirection = Vector3.left;
        }
        if (transform.position.x < -limits)
        {
            targetDirection = Vector3.right;
        }

        currentDirection = Vector3.SmoothDamp(currentDirection, targetDirection, ref velocity, .2f);
        transform.Translate(currentDirection * currentMoveSpeed * Time.deltaTime);

        


    }

    public void TravelDistance(float distance)
    {
        EnergyDepletion(distance *5);
    }

    public void EnergyDepletion(float amount)
    {
        currentEnergy -= amount;
        energyBar.SetEnergy(currentEnergy);
        if (currentEnergy <= 0)
        {
            targetSpeed = 0;
            Debug.Log("Game Over");
        }
    }

    public void AddEnergy(float amount)
    {
        currentEnergy += amount;
        energyBar.SetEnergy(currentEnergy);
    }


}
