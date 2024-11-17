using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealyRaceMovement : MonoBehaviour

{
    public Transform[] runners, points; // Массив с бегунами + Массив с точками
    private int currentRunnerIndex; // Индекс текущего бегуна
    private int nextPointIndex; // Индекс следующей точки
    private bool isRunning = false; //проверка бежит ли бегун
    private float pauseDuration = 0.1f; // Длительность паузы
    private float pauseTimer = 0.0f; // Таймер паузы

    [SerializeField] private float speed; // Скорость бега

    private void CheckRunnerArrival()// Метод проверки достижения точки
    {
        float offset = Vector3.Distance(runners[currentRunnerIndex].position, points[0].position);
        float nextOffset = Vector3.Distance(runners[currentRunnerIndex].position, points[nextPointIndex].position);
        if (nextOffset < 0.1f)
        {
            StopRunner();
            nextPointIndex = (nextPointIndex + 1) % points.Length; 
        }

        if (offset < 0.1f)
        {
            isRunning = true;
        }
    }
    private void Start()
    {
        StartRace();
    }
    private void StartRace()
    {
        currentRunnerIndex = 0;
        nextPointIndex = 1;
        isRunning = true;
    }
    private void MoveRunner()// Метод перемещения бегуна к следующей точке
    {
       runners[currentRunnerIndex].position = Vector3.MoveTowards(runners[currentRunnerIndex].position, points[nextPointIndex].position, speed * Time.deltaTime); 
       runners[currentRunnerIndex].LookAt(points[nextPointIndex]);
       runners[currentRunnerIndex].Rotate(0,0,0.5f);
    }
    private void StopRunner() // Метод остановки бегуна
    {
        isRunning = false;
        pauseTimer = pauseDuration;
    }
    private void StartNextRunner() //Запуск следующего бегуна
    {
        currentRunnerIndex = (currentRunnerIndex + 1) % runners.Length;
        isRunning = true;
    }
    private void Update()
    {
        UpdateMove();
    }
    private void UpdateMove()
    {
        if (isRunning)
        {
            MoveRunner();
            CheckRunnerArrival();
        }
        else if (pauseTimer > 0)
        {
            pauseTimer -= Time.deltaTime;
            if (pauseTimer <= 0)
            {
                StartNextRunner();
            }
        }
    }
}