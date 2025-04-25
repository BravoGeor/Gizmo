using UnityEngine;

public class IdleCameraBob : MonoBehaviour
{
    public float bobSpeed = 1f;         // Speed of the bob
    public float bobAmount = 0.02f;     // Height of the bob

    private float defaultY;
    private float timer;

    void Start()
    {
        defaultY = transform.localPosition.y;
    }

    void Update()
    {
        timer += Time.deltaTime * bobSpeed;
        float newY = defaultY + Mathf.Sin(timer) * bobAmount;
        transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
    }
}
