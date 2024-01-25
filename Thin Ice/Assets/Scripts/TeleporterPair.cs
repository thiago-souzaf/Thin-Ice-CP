using UnityEngine;

public class TeleporterPair : MonoBehaviour
{
	[SerializeField] GameObject teleporterA;
	[SerializeField] GameObject teleporterB;
	[SerializeField] Player player;

    private bool teleportable = true;

    public void UseTeleporters(string enteredTeleport)
	{
        player.isOnTopOfTeleporter = true;
        DisableTeleporters();
        

        if (!teleportable) { return; }
        teleportable = false;
        AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.teleport);

        if (enteredTeleport == "A")
		{
			player.transform.position = teleporterB.transform.position;

		} else if (enteredTeleport == "B")
		{
            player.transform.position = teleporterA.transform.position;
		} else
		{
			Debug.LogError("Teleporter ID invalid");
			return;
		}
		

    }

	void DisableTeleporters()
	{
		teleporterA.GetComponent<Animator>().SetBool("inactive", true);
        teleporterB.GetComponent<Animator>().SetBool("inactive", true);
    }
}
