using System.Runtime.InteropServices;
using UnityEngine;

public class API4399 : MonoBehaviour {

	[DllImport("__Internal")]
    private static extern void progress(float num);

	[DllImport("__Internal")]
	private static extern void submitScore(int score);

	[DllImport("__Internal")]
	private static extern void getRank();

	[DllImport("__Internal")]
	private static extern bool canPlayAd();

	[DllImport("__Internal")]
	private static extern void playAd();

	public void submitScoreCallback(int code){
		Debug.Log("submitScoreCallback(); code:"+code);
	}
	public void getRankCallback(string data){
		string[]datas=data.Split(',');
		int code =int.Parse(datas[0]);
		Debug.Log("getRankCallback(); code:"+code);
		if(code==10000){
			for(int i=1;i<datas.Length;i+=2){
				int score=int.Parse(datas[i]);//积分
				int rank=int.Parse(datas[i+1]);//排名
				Debug.Log("getRankCallback(); score:"+score+",rank:"+rank);
			}
		}
	}
	public void playAdCallback(int code){
		//10000开始播放
		//10001播放结束
		Debug.Log("playAdCallback();code:"+code);
	}

	private void Update() {
		if(_isStartProgress){
			_progress++;
			if(_progress>=100){
				_progress=100;
				_isStartProgress=false;
			}
			progress(_progress);
		}
	}



	private bool _isStartProgress;
	private float _progress;
	public void showProgressHandler(){
		_isStartProgress=true;
		_progress=0;
		
	}

	public void submitScoreHandler(){
		submitScore(Random.Range(10,10000));
	}

	public void getRankHandler(){
		getRank();
	}

	public void playAdHandler(){
		Debug.Log("canPlayAd:"+canPlayAd());
		if(canPlayAd()) {
			playAd();
		}
	}
	
}
