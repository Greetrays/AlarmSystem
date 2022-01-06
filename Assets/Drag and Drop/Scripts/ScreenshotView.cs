using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Assets._4._Drag_and_Drop.Scripts.Extantions;

public class ScreenshotView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _date;

    private Transform _dragingParent;
    private Transform _previousParent;

    public void Init(Transform dragingParent)
    {
        _dragingParent = dragingParent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _previousParent = transform.parent;
        transform.parent = _dragingParent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var container = EventSystem.current.GetFirstComponentUnderPointer<DropContainer>(eventData);

        if (container != null)
        {
            transform.parent = container.Container;
        }
        else
        {
            transform.parent = _previousParent;
        }
    }

    public void Render(Screenshot screenshot)
    {
        _image.sprite = screenshot.Image;
        _date.text = screenshot.CreationTime.ToString();
    }
}
