using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    private Rigidbody rb;

    // ”гол поворота в градусах, например, 90 дл€ поворота на 90 градусов по оси Y
    [SerializeField]
    private float initialRotationY = 90f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // «афиксировать вращение по всем ос€м
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        // ”становить начальное вращение
        transform.rotation = Quaternion.Euler(0, initialRotationY, 0);
    }

    void Update()
    {
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveVertical = 1f;
        }
        // ѕреобразовать локальное направление в мировое
        Vector3 movement = transform.TransformDirection(new Vector3(moveHorizontal, 0.0f, moveVertical));
        rb.velocity = movement * moveSpeed;
    }
}