using BepInEx;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilla;
namespace NoWind
{
    [BepInPlugin("OctoBurr.NoWind", "NoWind", "2.0.0")]
    public class Main : BaseUnityPlugin
    {
        bool inModded;
        GameObject Beach, Sky, Forest, Mountains, Canyons;
        void Start()
        {
            ZoneManagement.SetActiveZone(GTZone.forest);
            Forest = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Environment/Forest_ForceVolumes");
            ZoneManagement.SetActiveZone(GTZone.mountain);
            Mountains = GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Mountain_ForceVolumes/LevelBoundaryForceVolume");
            ZoneManagement.SetActiveZone(GTZone.canyon);
            Canyons = GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon/Canyon/Canyon_ForceVolumes");
            ZoneManagement.SetActiveZone(GTZone.beach);
            Beach = GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/ForceVolumesOcean_Combo_V2");
            ZoneManagement.SetActiveZone(GTZone.skyJungle);
            Sky = GameObject.Find("Environment Objects/LocalObjects_Prefab/skyjungle/Force Volumes/Border");
            ZoneManagement.SetActiveZone(GTZone.forest);

        }
        void Update()
        {
            if (!PhotonNetwork.InRoom || inModded)
            {
                Forest.gameObject.SetActive(false);
                Mountains.gameObject.SetActive(false);
                Canyons.gameObject.SetActive(false);
                Beach.gameObject.SetActive(false);
                Sky.gameObject.SetActive(false);
            }
            if (PhotonNetwork.InRoom && !inModded)
            {
                Forest.gameObject.SetActive(true);
                Mountains.gameObject.SetActive(true);
                Canyons.gameObject.SetActive(true);
                Beach.gameObject.SetActive(true);
                Sky.gameObject.SetActive(true);
            }
        }
        [ModdedGamemodeJoin] public void OnJoin(string gamemode) => inModded = true;
        [ModdedGamemodeLeave] public void OnLeave(string gamemode) => inModded = false;
    }
}