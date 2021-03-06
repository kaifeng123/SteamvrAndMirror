using UnityEngine;

namespace Bolt.Samples.Photon.Lobby
{
	[BoltGlobalBehaviour("PhotonGame")]
	public class PhotonGameSceneController : Bolt.GlobalEventListener
	{
		public override void SceneLoadLocalDone(string scene)
		{
			BoltConsole.Write("Spawn Player on map " + scene, Color.yellow);
			BomberPlayerController.Spawn();
		}
	}
}