using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyItem
{
    public string itemName;
    public int itemType;
}

public class MyNode<T> where T : class
{
    public MyItem myItem;
    public MyNode<T> nextNode;
    public MyNode<T> prevNode;

    public string GetMyItemName()
    {
        return myItem.itemName;
    }
}

public class MyLinkedList<T>where T : class
{
    public MyNode<T> head;
    public MyNode<T> tail;
    public uint length = 0;

    public MyLinkedList()
    {
        head = new MyNode<T>()
        {
            myItem = null
        };

        tail = new MyNode<T>()
        {
            myItem = null
        };

        head.prevNode = null;
        head.nextNode = tail;

        tail.prevNode = head;
        tail.nextNode = null;

    }
    public bool IsEmpty()
    {
        return (length == 0);
    }

    public void Print()
    {
        MyNode<T> searchNode = head;
        Debug.Log("======================����======================");
        while(searchNode.nextNode != tail)
        {
            Debug.Log(searchNode.nextNode.myItem.itemName);
            searchNode = searchNode.nextNode;
        }
    }

    public void Add(MyItem _value)
    {
        MyNode<T> newNode = new MyNode<T>
        {
            myItem = _value
        };

        if(IsEmpty())
        {
            head.nextNode = newNode;
            newNode.prevNode = head;
            newNode.nextNode = tail;
            tail.prevNode = newNode;
            Debug.Log(_value.itemName + "�� ó������ ���濡 �־����ϴ�. ");
        }
        else
        {
            MyNode<T> searchNode = head;
            while (searchNode.nextNode != tail)
            {
                searchNode = searchNode.nextNode;
            }
            searchNode.nextNode.prevNode = newNode;
            newNode.nextNode = searchNode.nextNode;
            newNode.prevNode = searchNode;
            searchNode.nextNode = newNode;
            Debug.Log(_value.itemName + "�� ���濡 �־����ϴ�.");
        }
        ++length;
    }

    public void Remove(MyItem _value)
    {
        MyNode<T> searchNode = head;
        
        while (searchNode != tail)
        {
            if (searchNode.myItem != null && searchNode.myItem.itemType == _value.itemType)
            {
                searchNode.nextNode.prevNode = searchNode.prevNode;
                searchNode.prevNode.nextNode = searchNode.nextNode;
                Debug.Log(_value.itemName + "�� �����ϴ�.");

                --length;
                return;
            }
            searchNode = searchNode.nextNode;
        }
        Debug.Log("��" + _value.itemName + "�� �����ϴ�. ");
    }

    public bool Constrain(MyItem _value)
    {
        MyNode<T> searchNode = head;
        while (searchNode.nextNode != tail)
        {
            if(searchNode.myItem == _value)
            {
                return true;
            }
        }
        return false;
    }
}
public class MyBag : MonoBehaviour
{
    MyLinkedList<string> linkedList = new MyLinkedList<string>();
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            MyItem temp = new MyItem();
            temp.itemName = "HP ����";
            temp.itemType = 1;
            linkedList.Add(temp);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            MyItem temp = new MyItem();
            temp.itemName = "������";
            temp.itemType = 2;
            linkedList.Add(temp);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            linkedList.Print();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            MyItem temp = new MyItem();
            temp.itemName = "HP ����";
            temp.itemType = 1;
            linkedList.Remove(temp);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            MyItem temp = new MyItem();
            temp.itemName = "������";
            temp.itemType = 2;
            linkedList.Remove(temp);
        }
    }
}
