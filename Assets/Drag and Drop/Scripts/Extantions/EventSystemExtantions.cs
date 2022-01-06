using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets._4._Drag_and_Drop.Scripts.Extantions
{
    static class EventSystemExtantions
    {
        public static T GetFirstComponentUnderPointer<T>(this EventSystem system, PointerEventData eventData) where T : class
        {

            var result = new List<RaycastResult>();
            system.RaycastAll(eventData, result);

            foreach (var gameObj in result)
            {
                if (gameObj.gameObject.TryGetComponent<T>(out T component))
                {
                    return component;
                }
            }

            return null;
        }
    }
}
