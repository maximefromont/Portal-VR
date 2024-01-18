using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class OffSet : XRGrabInteractable
{
  
  
private void MatchAttachmentPoints(XRBaseInteractor interactor)
{
    bool hasAttach = attachTransform != null;
    Vector3 playerPosition = interactor.transform.position;
    Vector3 directionToPlayer = (playerPosition - transform.position).normalized;
    Vector3 newPosition = playerPosition + directionToPlayer * -2.0f; // 1.0f is the distance from the player

    interactor.attachTransform.position = hasAttach ? attachTransform.position : newPosition;
    interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
}

}
