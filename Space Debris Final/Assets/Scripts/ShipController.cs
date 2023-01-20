

using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 moveDirection;
    private bool canMove = true;
    private bool isAlive = true;

    void Start()
    {
        moveDirection = new Vector3();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveDirection.y = 1;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveDirection.y = -1;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate (0, -90 * Time.deltaTime * rotationSpeed, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate (0, 90 * Time.deltaTime * rotationSpeed, 0);
            }
            Vector3 newPosition = transform.position;
            newPosition += moveDirection.y * transform.forward * moveSpeed * Time.deltaTime;
            newPosition.z = startPosition.z;
            transform.position = newPosition;
        }
    }

 
    public void OnTriggerEnter(Collider collider)
    {
        if (isAlive)
        {
            SkinnedMeshRenderer[] renderers = GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach (SkinnedMeshRenderer renderer in renderers)
            {
                renderer.enabled = false;
            }
            canMove = false;
            isAlive = false;
            IonCannon ionCannon = gameObject.GetComponent<IonCannon>();
            if (ionCannon)
            {
                ionCannon.SetCanShoot(false);
            }
        }
        StartCoroutine(Reset());
    }

   
    public IEnumerator Reset()
    {
        yield return new WaitForSeconds(2);
        SkinnedMeshRenderer[] renderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer renderer in renderers)
        {
            renderer.enabled = true;
        }
        moveDirection = new Vector3();
        canMove = true;
        isAlive = true;
        IonCannon ionCannon = gameObject.GetComponent<IonCannon>();
        ionCannon.SetCanShoot(true);
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
