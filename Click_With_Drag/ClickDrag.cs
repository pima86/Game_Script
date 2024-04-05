[SerializeField] ScrollRect myScrollRect;

public void OnBeginDurabilitySliderDrag(BaseEventData eventData)
{
    if (myScrollRect == null)
        return;

    myScrollRect.OnBeginDrag(eventData as PointerEventData);
}

public void OnDurabilitySliderDrag(BaseEventData eventData)
{
    if (myScrollRect == null)
        return;

    myScrollRect.OnDrag(eventData as PointerEventData);
}

public void OnEndDurabilitySliderDrag(BaseEventData eventData)
{
    if (myScrollRect == null)
        return;

    myScrollRect.OnEndDrag(eventData as PointerEventData);
}
