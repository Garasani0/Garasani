using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //�ν����� â���� ������ �� �ֵ��� �� 
public class Dialogue //��ӹ��� �ʰ� ����
{
    [Tooltip("��� ġ�� ĳ���� �̸�")]
    public string name; //���� ��縦 �ϴ��� 

    [Tooltip("��系��")]
    public string[] contexts;
}

[System.Serializable]
public class DialogueEvent //�������� ���� -> Ŭ������ �迭�� ����
{
    public string name; //� �̺�Ʈ���� ��� 
    public Vector2 line; //���° �ٺ��� ���° �ٱ��� ��� ���� 
    public Dialogue[] dialouges;
}