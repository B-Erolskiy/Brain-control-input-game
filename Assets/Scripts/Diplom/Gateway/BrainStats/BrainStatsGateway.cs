using System;
using System.Collections;
using System.Threading;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

namespace Diplom.Gateway.BrainStats
{
  public class BrainStatsGateway : IBrainStatsGateway
  {
    private const string BrainStatsServerUrl = "http://127.0.0.1:2336/bci";

    public IObservable<Entities.BrainStats.BrainStats> GetBrainStats()
    {
      return Observable.FromCoroutine<Entities.BrainStats.BrainStats>((observer, cancellationToken) =>
        LoadBrainStats(BrainStatsServerUrl, observer, cancellationToken));
    }

// IObserver is a callback publisher
// Note: IObserver's basic scheme is "OnNext* (OnError | Oncompleted)?" 
    static IEnumerator LoadBrainStats(string url, IObserver<Entities.BrainStats.BrainStats> observer, CancellationToken cancellationToken)
    {
      var startRequestTime = DateTime.Now;
      var request = UnityWebRequest.Get(url);
      request.SendWebRequest();
      
      while (!request.isDone && !cancellationToken.IsCancellationRequested)
      {
        yield return null;
      }

      if (cancellationToken.IsCancellationRequested) yield break;

      if (request.error != null)
      {
        observer.OnError(new Exception(request.error));
      }
      else
      {
        var json = request.downloadHandler?.text;
        var brainStatsServerDTO = JsonUtility.FromJson<BrainStatsServerDTO>(json);
        var brainStats = new Entities.BrainStats.BrainStats
        {
          ConcentrationPercent = brainStatsServerDTO.concentration,
          MeditationPercent = brainStatsServerDTO.meditation,
          ServerPing = (DateTime.Now - startRequestTime).TotalMilliseconds
        };
        
        observer.OnNext(brainStats);
        observer.OnCompleted();
      }
    }
  }
}