using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class OffSet : XRGrabInteractable
{

    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;
   

     protected override void Awake()
    {
        base.Awake();

         
    }
        // Function to find XR Interactor Line Visual by name
  
    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        base.OnSelectEnter(interactor);
        StoreInteractor(interactor);
        MatchAttachmentPoints(interactor);

    }

    private void StoreInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = interactor.attachTransform.localPosition;
        interactorRotation = interactor.attachTransform.localRotation;
    }

private void MatchAttachmentPoints(XRBaseInteractor interactor)
{
    bool hasAttach = attachTransform != null;
    Vector3 playerPosition = interactor.transform.position;
    Vector3 directionToPlayer = (playerPosition - transform.position).normalized;
    Vector3 newPosition = playerPosition + directionToPlayer * -3.0f; // 1.0f is the distance from the player

    interactor.attachTransform.position = hasAttach ? attachTransform.position : newPosition;
    interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
}
    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        base.OnSelectExit(interactor);
        ResetAttachmentPoints(interactor);
        ClearInteractor(interactor);

      
    }
    private void ResetAttachmentPoints(XRBaseInteractor interactor)
    {
       ;
        interactor.attachTransform.localPosition = interactorPosition ;
        interactor.attachTransform.localRotation = interactorRotation;
    }

private void ClearInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = Vector3.zero;
        interactorRotation = Quaternion.identity;
    }
}