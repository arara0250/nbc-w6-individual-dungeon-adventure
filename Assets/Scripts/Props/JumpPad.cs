using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpPower;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb == null)
            {
                return;
            }

            rb.AddForce((Vector3.up + Vector3.forward * 2) * jumpPower, ForceMode.Impulse);
        }
    }
}
