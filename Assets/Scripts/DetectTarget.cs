using UnityEngine;

public class DetectTarget : MonoBehaviour
{
    [SerializeField]
    private string targetTag;
    private float range;
    [SerializeField]
    private float rayHeighOffset = 0.5f;
    private bool isActive;
    private System.Action<Transform> onTargetDetected;
    public System.Action<Transform> OnTargetDetected => onTargetDetected;
    public void SetRange(bool newActive)
    {
        isActive = newActive;
    }
    private void Update()
    {
        if (!isActive) return;
        if (Physics.Raycast(transform.position + Vector3.up * rayHeighOffset, transform.forward, out RaycastHit hit, range))
        {
            if (hit.collider.CompareTag(targetTag))
            {
                onTargetDetected?.Invoke(hit.transform);
            }
        }
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * rayHeighOffset, transform.forward * range);
    }
}
