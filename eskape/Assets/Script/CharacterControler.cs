
using UnityEngine;
using UnityEngine.Events;

public class CharacterControler : MonoBehaviour
{


    public float currentSpeed { get; private set; } = 0f;
    public UnityEvent<float> onSetEnergy;
    public UnityEvent<float> onSetMaxEnergy;

    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float targetSpeed = 10f;
    [SerializeField] private float targetDirectionSpeed = 10f;
    [SerializeField] private float maxEnergy = 1000f;
    [SerializeField] private float limits = 5f;

    
    private Vector3 currentDirection = Vector3.zero;
    private float currentDirectionSpeed = 0f;
    private Vector3 velocity = Vector3.zero;
    private float currentEnergy = 0f;
    

    void Start()
    {
        currentEnergy = maxEnergy;
        onSetMaxEnergy.Invoke(maxEnergy);  
        targetSpeed = maxSpeed;
    }

    void Update()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime);
        currentDirectionSpeed = targetDirectionSpeed * (currentSpeed / maxSpeed);

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
        transform.Translate(currentDirection * currentDirectionSpeed * Time.deltaTime);

        


    }

    public void TravelDistance(float distance)
    {
        EnergyDepletion(distance *5);
    }

    public void EnergyDepletion(float amount)
    {
        currentEnergy -= amount;
        onSetEnergy.Invoke(currentEnergy);
        if (currentEnergy <= 0)
        {
            targetSpeed = 0;
            Debug.Log("Game Over");
        }
    }

    public void AddEnergy(float amount)
    {
        currentEnergy += amount;
        onSetEnergy.Invoke(currentEnergy); ;
    }


}
