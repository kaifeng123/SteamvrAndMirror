using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLinked : MonoBehaviour
{
	MyLinkedList ll = new MyLinkedList();
	Node n2;
	void Start()
	{

		//添加三个结点 1 2（在1后） 3（在2后）
		Node n1 = new Node(1);
		n2 = new Node(22222);
		Node n3 = new Node(3);
		ll.AddLast(n1);
		ll.AddLast(n2);
		ll.AddLast(n3);
		//添加三个结点 1.5（在1后） 2.5（在2后） 3.5（在3后）
		Node n1dot5 = new Node("n1toN5value");
		Node n2dot5 = new Node("n2toN5value");
		Node n3dot5 = new Node("n3toN5value");
		ll.AddAfter(n1, n1dot5);
		ll.AddAfter(n2, n2dot5);
		ll.AddAfter(n3, n3dot5);
		//删除结点 2 和 3，将结点 2.5 的值改为 "ThisNodeIsModified!"
		//ll.Delete(n2);
		//ll.Delete(n3);
		//ll.Modify(n2dot5, "ThisNodeIsModified!");
		Debug.Log("========================");
		//打印链表
		ll.Print();

	}
	public void butn()
	{
		//删除节点n2的数据
		ll.Delete(n2);
		Debug.Log("========================");
		//打印出整个链表
		ll.Print();
		//通过连表指针获取链表的数据
		ll.GetNode(n2);
	}
	public void btn()
	{
		//修改节点n2的值
		ll.Modify(n2, "链表的值改变成功!");
		Debug.Log("========================");
		ll.Print();
	}
}
