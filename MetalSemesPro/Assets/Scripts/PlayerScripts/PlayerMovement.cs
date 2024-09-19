using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    private Rigidbody rb;

    // ���� �������� � ��������, ��������, 90 ��� �������� �� 90 �������� �� ��� Y
    [SerializeField]
    private float initialRotationY = 90f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // ������������� �������� �� ���� ����
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        // ���������� ��������� ��������
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
        // ������������� ��������� ����������� � �������
        Vector3 movement = transform.TransformDirection(new Vector3(moveHorizontal, 0.0f, moveVertical));
        rb.velocity = movement * moveSpeed;
    }
}