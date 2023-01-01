using System.Collections;
using System.Collections.Generic;
using Diplom.Presenters.Player;
using UnityEngine;
using Zenject;

namespace Diplom.Views.Player.Triggers
{
  [RequireComponent(typeof(Collider))]
  public class PlayerDamageTriggerView : MonoBehaviour
  {
    [SerializeField] private float _damage;
    [SerializeField] private bool _isTrigger;
    [SerializeField] private List<MeshRenderer> _meshes = new List<MeshRenderer>();
    [SerializeField] private float _hideAfterDamageDuration = 3f;

    private Collider _collider;

    private IPlayerStatsPresenter _presenter;

    [Inject]
    private void Construct(IPlayerStatsPresenter presenter)
    {
      _presenter = presenter;
    }

    private void Start()
    {
      _collider = GetComponent<Collider>();
      _collider.isTrigger = _isTrigger;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (!_isTrigger) return;

      _presenter.SetDamage(_damage);
      StartCoroutine(HideForTime());
    }

    private void OnCollisionEnter(Collision collision)
    {
      if (_isTrigger || collision.contactCount == 0) return;

      _presenter.SetDamage(_damage);
      StartCoroutine(HideForTime());
    }

    private IEnumerator HideForTime()
    {
      yield return new WaitForSecondsRealtime(0.2f);
      _meshes.ForEach(mesh => mesh.enabled = false);
      _collider.enabled = false;

      yield return new WaitForSecondsRealtime(_hideAfterDamageDuration);
      _meshes.ForEach(mesh => mesh.enabled = true);
      _collider.enabled = true;
    }
  }
}