using System;
using System.IO;
using System.Text;
using UnityEngine;

public class SaveGameFileCod : MonoBehaviour
{
	private const string AAAAAAAAAAAAAAAAAAAcf = "AutoSave";

	private const string Save = "Save";

	private const string Save1 = "Save1";

	private const string Save2 = "Save2";

	private const string Save3 = "Save3";

	private string AAAAAAAAAAAAAAAbx;

	private string AAAAAAAAAAAAAAAAAAAAAck;

	private string AAAAAAAAAAAAAAAby;

	private string AAAAAAAAAAAAAAAbz;

	private string AAAAAAAAAAAAAAce;

	private string AAAAAAAAAAAAAAAAAAAAcn;

	private string AAAAAAAAAAAAAAAAAAAcg;

	private string AAAAAAAAAAAAAAAAAAAAAcl;

	private string AAAAAAAAAAAAAAcf;

	private string AAAAAAAAAAAAAAAAAAdb;

	private string AAAAAAAAAAAAAAAAcb;

	private SaveOneMap AAAAAAAAAAAAAAAAAAAAco = new SaveOneMap();

	private void Start()
	{
		AAAAAAAAAAAAAAAbx = Path.Combine(Application.persistentDataPath, "AutoSave.json");
		AAAAAAAAAAAAAAAAAAAAAck = Path.Combine(Application.persistentDataPath, "CipherAutoSave.json");
		AAAAAAAAAAAAAAAby = Path.Combine(Application.persistentDataPath, "Save.json");
		AAAAAAAAAAAAAAAbz = Path.Combine(Application.persistentDataPath, "CipherSave.json");
		AAAAAAAAAAAAAAce = Path.Combine(Application.persistentDataPath, "Save1.json");
		AAAAAAAAAAAAAAAAAAAAcn = Path.Combine(Application.persistentDataPath, "CipherSave1.json");
		AAAAAAAAAAAAAAAAAAAcg = Path.Combine(Application.persistentDataPath, "Save2.json");
		AAAAAAAAAAAAAAAAAAAAAcl = Path.Combine(Application.persistentDataPath, "CipherSave2.json");
		AAAAAAAAAAAAAAcf = Path.Combine(Application.persistentDataPath, "Save3.json");
		AAAAAAAAAAAAAAAAAAdb = Path.Combine(Application.persistentDataPath, "CipherSave3.json");
		if (!File.Exists(AAAAAAAAAAAAAAAAAAAAAck) && File.Exists(AAAAAAAAAAAAAAAbx))
		{
			AAAAAAAAAAAAAAAAcb = File.ReadAllText(AAAAAAAAAAAAAAAbx);
			byte[] bytes = Encoding.UTF8.GetBytes(AAAAAAAAAAAAAAAAcb);
			string text = BitConverter.ToString(bytes);
			File.WriteAllText(AAAAAAAAAAAAAAAAAAAAAck, text.Replace("-", string.Empty));
			Debug.Log("СipherAutoSave");
		}
		if (!File.Exists(AAAAAAAAAAAAAAAbz) && File.Exists(AAAAAAAAAAAAAAAby))
		{
			AAAAAAAAAAAAAAAAcb = File.ReadAllText(AAAAAAAAAAAAAAAby);
			byte[] bytes2 = Encoding.UTF8.GetBytes(AAAAAAAAAAAAAAAAcb);
			string text2 = BitConverter.ToString(bytes2);
			File.WriteAllText(AAAAAAAAAAAAAAAbz, text2.Replace("-", string.Empty));
			Debug.Log("СipherSave");
		}
		if (!File.Exists(AAAAAAAAAAAAAAAAAAAAcn) && File.Exists(AAAAAAAAAAAAAAce))
		{
			AAAAAAAAAAAAAAAAcb = File.ReadAllText(AAAAAAAAAAAAAAce);
			byte[] bytes3 = Encoding.UTF8.GetBytes(AAAAAAAAAAAAAAAAcb);
			string text3 = BitConverter.ToString(bytes3);
			File.WriteAllText(AAAAAAAAAAAAAAAAAAAAcn, text3.Replace("-", string.Empty));
			Debug.Log("СipherSave1");
		}
		if (!File.Exists(AAAAAAAAAAAAAAAAAAAAAcl) && File.Exists(AAAAAAAAAAAAAAAAAAAcg))
		{
			AAAAAAAAAAAAAAAAcb = File.ReadAllText(AAAAAAAAAAAAAAAAAAAcg);
			byte[] bytes4 = Encoding.UTF8.GetBytes(AAAAAAAAAAAAAAAAcb);
			string text4 = BitConverter.ToString(bytes4);
			File.WriteAllText(AAAAAAAAAAAAAAAAAAAAAcl, text4.Replace("-", string.Empty));
			Debug.Log("СipherSave2");
		}
		if (!File.Exists(AAAAAAAAAAAAAAAAAAdb) && File.Exists(AAAAAAAAAAAAAAcf))
		{
			AAAAAAAAAAAAAAAAcb = File.ReadAllText(AAAAAAAAAAAAAAcf);
			byte[] bytes5 = Encoding.UTF8.GetBytes(AAAAAAAAAAAAAAAAcb);
			string text5 = BitConverter.ToString(bytes5);
			File.WriteAllText(AAAAAAAAAAAAAAAAAAdb, text5.Replace("-", string.Empty));
			Debug.Log("СipherSave3");
		}
	}
}
