using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //�ν����� â���� ������ �� �ֵ��� �� 
public class Dialogue //��ӹ��� �ʰ� ����
{
    [Tooltip("ID")]
    public int id;

    [Tooltip("ĳ���� �̸�")]
    public string name; //���� ��縦 �ϴ��� 

    [Tooltip("��系��")]
    public string contexts;

    [Tooltip("������1")]
    public string chosen1;

    [Tooltip("������1 ID")]
    public int chosen1_ID;

    [Tooltip("������2")]
    public string chosen2;

    [Tooltip("������2 ID")]
    public int chosen2_ID;
}

[System.Serializable]
public class DialogueEvent //�������� ���� -> Ŭ������ �迭�� ����
{
    public string name; //� �̺�Ʈ���� ��� 
    public Vector2 line; //���° �ٺ��� ���° �ٱ��� ��� ���� 
    public Dialogue[] dialouges;
}