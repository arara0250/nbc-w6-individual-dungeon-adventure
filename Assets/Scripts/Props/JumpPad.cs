using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpPower;

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb == null)
            {
                return;
            }

            rb.AddForce((Vector3.forward * 10f) * jumpPower, ForceMode.Impulse);
        }
    }
}
