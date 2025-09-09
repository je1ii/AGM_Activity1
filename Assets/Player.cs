using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform goal;
    public Transform target;
    public float moveSpeed = 1f;
    public float deathRange = 0.5f;
    public float dangerRange = 2f;

    public float shakeAmount = 10f;

    private Vector2 origPosition;

    void Update()
    {
        if (this.transform != null) Move();

        if (target != null)
        {
            origPosition = this.transform.position;
            var distance = Mathf.Sqrt(Mathf.Pow(target.position.x - this.transform.position.x, 2) + Mathf.Pow(target.position.y - this.transform.position.y, 2));

            var vectorDist = Vector3.Distance(target.position, this.transform.position);
            Debug.Log($"Distance {distance:F2}, Vector {vectorDist:F2}");

            if (distance < deathRange)
            {
                Debug.Log("The player is dead.");
            }
            else if (distance < dangerRange)
            {
                Shake();
                Debug.Log("Shaking");
            }
        }

        if (goal != null)
        {
            var distance = Mathf.Sqrt(Mathf.Pow(goal.position.x - this.transform.position.x, 2) + Mathf.Pow(goal.position.y - this.transform.position.y, 2));

            var vectorDist = Vector3.Distance(goal.position, this.transform.position);

            if (distance < deathRange)
            {
                Debug.Log("The player won.");
            }
        }
    }

    private void Move()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        this.transform.Translate(hInput * moveSpeed * Time.deltaTime, 0, 0);
        this.transform.Translate(0, vInput * moveSpeed * Time.deltaTime, 0);
    }

    private void Shake()
    {
        float offsetX = Random.Range(-1f, 1f) * shakeAmount * 0.1f;
        float offsetY = Random.Range(-1f, 1f) * shakeAmount * 0.1f;

        this.transform.position = origPosition + new Vector2(offsetX, offsetY);
        // var newVector = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2));
        // this.transform.position += newVector * Time.deltaTime * shakeAmount;
    }
}
