using UnityEngine;
public class ReassignBoneWeigthsToNewMesh : MonoBehaviour
{
    public string rootBoneName = "Hips";
    void Start()
    {
        Transform newArmature = transform.parent.parent.parent.Find("Visual").Find("Armature").transform;
        SkinnedMeshRenderer rend = gameObject.GetComponent<SkinnedMeshRenderer>();
        Transform[] bones = rend.bones;
        rend.rootBone = newArmature.Find(rootBoneName);
        Transform[] children = newArmature.GetComponentsInChildren<Transform>();
        bones[31] = children[41];
        bones[8] = children[12];
        bones[9] = children[13];
        bones[10] = children[14];
        rend.bones = bones;
    }
}