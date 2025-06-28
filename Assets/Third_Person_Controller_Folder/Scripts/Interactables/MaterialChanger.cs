using UnityEngine;

public class MaterialChanger : MonoBehaviour, IInteractable
{
    [SerializeField] bool AutoColorChange = false;
    [SerializeField] private Renderer objectRenderer;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material changedMaterial;

    private bool isChanged = false;

    // ----- Interact -----
    public void Interact(Transform interactor)
    {
        if (objectRenderer == null || defaultMaterial == null || changedMaterial == null)
            return;

        isChanged = !isChanged;
        objectRenderer.material = isChanged ? changedMaterial : defaultMaterial;
        SoundManager.Instance.PlaySound(SoundManager.Instance.FeedBackShow);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (AutoColorChange) return;
        if (other.CompareTag("Player"))
        {
            isChanged = !isChanged;
            objectRenderer.material = isChanged ? changedMaterial : defaultMaterial;
            SoundManager.Instance.PlaySound(SoundManager.Instance.FeedBackShow);
        }
    }
}