using UnityEngine;

public class FPSInput : MonoBehaviour
{
    [SerializeField]
    private float speed = 6.0f;

    [SerializeField]
    private float gravity = -9.8f;

    private CharacterController characterController;
    private PlayerCharacter player;
    private bool isAlive;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        player = GetComponent<PlayerCharacter>();
        isAlive = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isAlive) {
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;

            Vector3 movement = new Vector3(deltaX, 0, deltaZ);

            movement = Vector3.ClampMagnitude(movement, speed);
            movement.y = gravity;
            movement *= Time.deltaTime;

            movement = transform.TransformDirection(movement);

            characterController.Move(movement);
        }
        if (Input.GetMouseButtonDown(1))
        {
            setAlive(false);
            player.Hurt(25);
        }

    }
    public void setAlive(bool set)
    {
        this.isAlive = set;
    }

}
