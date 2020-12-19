
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

class NetworkPlayer : MonoBehaviour
{
    private PhotonView photonView;
    public Transform head;
    public Transform rightHand;
    public Transform leftHand;
    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            rightHand.gameObject.SetActive(false);
            leftHand.gameObject.SetActive(false);
            head.gameObject.SetActive(false);

            MapPosition(head, XRNode.Head);
            MapPosition(leftHand, XRNode.LeftHand);
            MapPosition(rightHand, XRNode.RightHand);
        }
    }
    void MapPosition(Transform target, XRNode node)
    {
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 positon);
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);
        target.position = positon;
        target.rotation = rotation;
    }
}

