using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LinkedList : MonoBehaviour
{
    public Node head;
    public TextMeshProUGUI outputText;
    public TMP_InputField dataInput, indexInput;

    public void insert(string data, int index)
    {
        Node temp = head;
        if (index == 0)
        {
            head = new Node();
            head.data = data;
            head.next = temp;
        }
        else
        {
            Node temp2 = new Node();
            temp2.data = data;

            for (int i = 0; i < index - 1; i++)
            {
                if (temp.next != null)
                {
                    temp = temp.next;
                }
                else
                {
                    temp.next = temp2;
                    return;
                }
            }

            temp2.next = temp.next;
            temp.next = temp2;
        }
    }

    public void set(int index, string data)
    {
        Node temp = head;

        for (int i = 0; i < index; i++)
        {
            if (temp.next != null)
            {
                temp = temp.next;
            }
            else
            {
                temp.data = data;
                return;
            }
        }

        temp.data = data;
    }

    public void delete(int index)
    {
        Node temp = head;
        if (index == 0)
        {
            head = head.next;
        }
        else
        {
            for (int i = 0; i < index - 1; i++)
            {
                if (temp.next != null)
                {
                    temp = temp.next;
                }
                else
                {
                    temp = null;
                    return;
                }
            }
            
            Node temp2 = temp.next;
            if (temp2 == null) { temp = null; return; }
            temp.next = temp2.next;
        }
    }

    public void reverse()
    {
        Node temp2 = head;
        Node temp1 = null, temp3 = null;

        while (temp2 != null)
        {
            temp3 = temp2.next;            
            temp2.next = temp1;
            temp1 = temp2;
            temp2 = temp3;
        }
        head = temp1;
    }

    public void printLinkedList()
    {
        string r = "";
        Node temp = head;

        while (temp != null)
        {
            r += temp.data + "-·";
            temp = temp.next;
        }

        if (r == "")
        {
            indexInput.text = "0";
            r = "null";
        }

        outputText.text = r;
    }

    public void insertFromUI()
    {
        insert(dataInput.text,int.Parse( indexInput.text));
    }

    public void deleteFromUI()
    {
        delete(int.Parse(indexInput.text));
    }

    public void setFromUI()
    {
        set(int.Parse(indexInput.text), dataInput.text);
    }

    private void Start()
    {
        head = new Node();
        head.data = "1";
        insert("2", 1);
        insert("3", 40);
        insert("4", 2);
        set(4, "mil");
        printLinkedList();
        delete(3);
        printLinkedList();
    }
}

public class Node
{
    public string data;
    public Node next;
}