using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlistClass
{

}
/// <summary>
/// 链表的模型类
/// </summary>
class Node
{
	//结点数据，前后结点
	public object Data;
	public Node PreviousNode;
	public Node NextNode;
	//构造函数
	public Node(object data = null)
	{
		Data = data;
		PreviousNode = null;
		NextNode = null;
	}
	//输出结点信息
	public override string ToString()
	{
		return Data.ToString();
	}
}
/// <summary>
/// 链表类
/// </summary>
class MyLinkedList
{
	//首结点、尾结点
	public Node First;
	public Node Last;
	//下一个结点、上一个结点
	public Node NextNode(Node n)
	{
		return n.NextNode;
	}
	public Node PreviousNode(Node n)
	{
		return n.PreviousNode;
	}
	//结点总数
	public int Count;
	//构造函数
	public MyLinkedList()
	{
		this.First = null;
		this.Last = null;
		Count = 0;
	}
	/// <summary>
	/// 在结点node1之后增加结点node2，如果没有该结点则在最后增加
	/// </summary>
	/// <param name="node1">结点1</param>
	/// <param name="node2">结点2</param>
	public void AddAfter(Node node1, Node node2)
	{
		//链表为空的情况
		if (First == null)
		{
			Debug.Log("链表为空,不能找到第一个node1的值");
			return;
		}
		Node temp = First;
		do
		{
			if (temp.Data.Equals(node1.Data))
			{
				//如果node1是尾结点
				if (node1.NextNode == null)
				{
					node2.NextNode = null;
					node2.PreviousNode = node1;
					node1.NextNode = node2;
				}
				else //如果node1不是尾结点
				{
					node2.NextNode = node1.NextNode;
					node2.PreviousNode = node1;
					node2.NextNode.PreviousNode = node2;
					node1.NextNode = node2;
					;
				}
				Count++;
				return;
			}
			temp = temp.NextNode;
		}
		while (temp != null);
	}
	/// <summary>
	/// 在链表尾部增加结点
	/// </summary>
	public void AddLast(Node node)
	{
		//链表为空的情况
		if (this.First == null)
		{
			node.NextNode = null;
			node.PreviousNode = null;
			this.First = node;
			this.Last = node;
		}
		else //链表不为空的情况
		{
			Node temp = First;
			while (temp.NextNode != null)
			{
				temp = temp.NextNode;
			}
			temp.NextNode = node;
			node.PreviousNode = temp;
			Last = node;
		}
		Count++;
	}
	/// <summary>
	/// 删除指定结点
	/// </summary>
	/// <param name="node">被删除结点</param>
	public void Delete(Node node)
	{
		if (Count == 0)
		{
			Debug.Log("Can not find node(" + node + ")");
			return;
		}
		Node temp = First;
		do
		{
			//如果数据部分匹配，则删去该结点
			if (temp.Data.Equals(node.Data))
			{
				//temp是尾结点
				if (temp.NextNode == null)
				{
					temp.PreviousNode.NextNode = null;
					temp = null;
				}
				else //temp不是尾结点 
				{
					temp.PreviousNode.NextNode = temp.NextNode;
					temp.NextNode.PreviousNode = temp.PreviousNode;
					temp = null;
				}
				Count--;
				return;
			}
			temp = temp.NextNode;
		}
		while (temp != null);
	}
	/// <summary>
	/// 修改结点值
	/// </summary>
	/// <param name="node">被修改结点</param>
	/// <param name="value">结点值</param>
	public void Modify(Node node, object value)
	{
		if (Count == 0)
		{
			return;
		}
		Node temp = First;
		do
		{
			if (temp.Data.Equals(node.Data))
			{
				temp.Data = value;
				return;
			}
			temp = temp.NextNode;
		}
		while (temp != null);
	}
	/// <summary>
	/// 通过链表的指针获取链表的值
	/// </summary>
	/// <param name="node"></param>
	public void GetNode(Node node)
	{
		Debug.Log(node.ToString());
	}
	/// <summary>
	/// 单链表的反向排序
	/// </summary>
	public void AgainstSort()
	{
		try
		{
			Node note1;
			Node note = First;
			Node note2 = null;
			do
			{
				note1 = note.NextNode;
				if (note1 == null)
				{
					note.NextNode = note2;
					note.PreviousNode = null;
					First = note;
					return;
				}
				else
				{
					note.NextNode = note.PreviousNode;
					note.PreviousNode = note1;
					note2 = note;
					note = note1;
				}

			} while (note != null);

		}
		catch (System.Exception)
		{

			throw;
		}

	}
	/// <summary>
	/// 打印链表
	/// </summary>
	public void Print()
	{

		Debug.Log("===========周亚威=======");
		if (First == null)
		{
			Debug.Log("链表第一个为空");
			return;
		}
		else
		{
			Node temp = First;
			do
			{
				Debug.Log(temp);
				temp = temp.NextNode;
			}
			while (temp != null);
		}
		Debug.Log("===========周亚威End=======");
	}
}
