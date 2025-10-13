using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// IMPORTANT !!! In order to utilize DoTween, you need to make sure to include the Using DG.Tweening line.
using DG.Tweening;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    // Cam's custom script for movement.
        [SerializeField] private GameObject player;
        
        [SerializeField] private float moveSpeed;
        
        [SerializeField] private float originRadius;
        private Vector2 originPoint;
        private Vector3 targetPoint;

        private Sequence tweenSequence;
        
        // Start is called before the first frame update
        void Start()
        {
            tweenSequence = DOTween.Sequence();
            
            SetTarget();

            StartCoroutine(MoveEnemy());
        }

        private void Update()
        {
            
        }

        private Vector2 SetTargetPoint(Vector3 origin, float radius)
        {
            Vector3 pos = origin;
        
            pos.x += Random.Range(-radius, radius);
            pos.y += Random.Range(-radius, radius);

            return pos;
        }

        private void SetTarget()
        {
            originPoint = player.gameObject.transform.position;

            targetPoint = SetTargetPoint(originPoint, originRadius);
        }

        IEnumerator WaitToMove()
        {
            SetTarget();
            
            yield return new WaitForSecondsRealtime(2f);
            

            StartCoroutine(MoveEnemy());
        }

        IEnumerator WaitToCheckTweening()
        {
            yield return new WaitForSecondsRealtime(1f);

            StartCoroutine(MoveEnemy());
        }

        private float CalculateDistance()
        {
            var timeToDistance = Vector2.Distance(gameObject.transform.position, targetPoint)/moveSpeed;
            
            return timeToDistance;
        }
        
        //
        IEnumerator MoveEnemy()
        {
            // if we are not at our target and NOT tweening
            if (transform.position != targetPoint && !DOTween.IsTweening(transform))
            {
                // Debug.Log(gameObject.name + " is moving.");
                
                var timeToDistance = CalculateDistance();
                
                //tweenSequence.Append(transform.DOMove(targetPoint, timeToDistance));
                
                //tweenSequence.Join(transform.DOMove(targetPoint, timeToDistance));

                transform.DOMove(targetPoint, timeToDistance);
                
                yield return StartCoroutine(WaitToCheckTweening());
                
            }
            // if we are not at our target point but moving
            else if (transform.position != targetPoint & DOTween.IsTweening(transform))
            {
                yield return StartCoroutine(WaitToCheckTweening());
            }
            // if we are at our destination and not moving.
            else
            {
                
                yield return StartCoroutine(WaitToMove());
            }
            
        }
}