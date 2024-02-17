using UnityEngine;

public class Digit : MonoBehaviour
{
    public int Value;

    private bool canMerge = true;
    private bool hasMerged = false;

    private Rigidbody2D _rigidBody;
    private Collider2D _collider;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canMerge && !hasMerged)
        {
            Digit otherDigit = collision.gameObject.GetComponent<Digit>();
            if (otherDigit != null && otherDigit.Value == Value)
            {
                if (!otherDigit.hasMerged || !hasMerged)
                {
                    MergeWith(otherDigit);
                    otherDigit.hasMerged = true;
                    hasMerged = true;
                }
            }
        }
    }
    public void MergeWith(Digit otherDigit)
    {
        int newValue = Value += 1;
        if (newValue == 9)
            newValue = 0;

        Vector3 mergePosition = (transform.position + otherDigit.transform.position) / 2f;
        GameObject newDigit = Instantiate(NumberSpawner.Instance.Prefabs[newValue - 1], mergePosition, Quaternion.identity, GameObject.FindObjectOfType<NumberParent>().transform);
        newDigit.GetComponent<Digit>().Value = newValue;

        NumberSpawner.Instance.CheckMaxNumber(newValue);

        Destroy(gameObject);
        Destroy(otherDigit.gameObject);
    }
    public void UpdateMerge()
    {
        hasMerged = false;
    }
    public void OnNumberSpawn()
    {
        _rigidBody.isKinematic = true;
        _collider.isTrigger = true;

    }
    public void Release()
    {
        _rigidBody.isKinematic = false;
        _collider.isTrigger = false;
    }
}
