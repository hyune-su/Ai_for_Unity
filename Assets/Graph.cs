﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Node[] nodeList;
    //public Node[] nodeList;
    public int set_ai = 3;
    private int Node_count;
    private int num;

    //현재 노드를 받아서 현재 노드의 연결된 노드 배열의 인덱스를 받고
    //그 인덱스의 연결된 노드를 반환
    public Node Connectednode(Node src, int i)
    {
        num = src.getConnectedNode(i);

        return nodeList[num];
    }

    private void Awake()
    {
        Node_count = GameObject.FindGameObjectsWithTag("Node").Length;
        nodeList = new Node[Node_count + 1];

        for (int i = 1; i <= Node_count; i++)
        {
            nodeList[i] = GameObject.Find(i.ToString()).GetComponent<Node>();

            //nodeList[i].GetComponent<Node>().setNodeIndex(i);

            //nodeList = new Node[Node_count + 1];

            //nodeList[i] = GameObject.Find(i.ToString()).GetComponent<Node>();

            nodeList[i].setNodeIndex(i);
        }
    }

    private void Update()
    {
        switch (set_ai)
        {
            case 1:
                for (int i = 1; i < nodeList.Length; i++)
                {
                    for (int j = 0; j < nodeList.Length; j++)
                    {
                        nodeList[i].connectNodeIndex(j, 0, 0);
                    }
                }

                nodeList[1].connectNodeIndex(1, 2, 1);
                nodeList[1].connectNodeIndex(2, 3, 1);

                nodeList[2].connectNodeIndex(1, 1, 1);
                nodeList[2].connectNodeIndex(2, 4, 1);
                nodeList[2].connectNodeIndex(3, 5, 1);

                nodeList[3].connectNodeIndex(1, 1, 1);
                nodeList[3].connectNodeIndex(2, 6, 1);

                nodeList[4].connectNodeIndex(1, 2, 1);

                nodeList[5].connectNodeIndex(1, 2, 1);

                nodeList[6].connectNodeIndex(1, 3, 1);
                break;

            case 2:
                for (int i = 1; i < nodeList.Length; i++)
                {
                    for (int j = 0; j < nodeList.Length; j++)
                    {
                        nodeList[i].connectNodeIndex(j, 0, 0);
                    }
                }

                nodeList[1].connectNodeIndex(1, 2, 1);
                nodeList[1].connectNodeIndex(2, 3, 1);

                nodeList[2].connectNodeIndex(1, 1, 1);
                nodeList[2].connectNodeIndex(2, 4, 1);
                nodeList[2].connectNodeIndex(3, 5, 1);

                nodeList[3].connectNodeIndex(1, 1, 1);
                nodeList[3].connectNodeIndex(2, 6, 1);

                nodeList[4].connectNodeIndex(1, 2, 1);

                nodeList[5].connectNodeIndex(1, 2, 1);

                nodeList[6].connectNodeIndex(1, 3, 1);
                break;

            case 3:
                for (int i = 1; i < nodeList.Length; i++)
                {
                    for (int j = 0; j < nodeList.Length; j++)
                    {
                        nodeList[i].connectNodeIndex(j, 0, 0);
                    }
                }

                nodeList[1].connectNodeIndex(1, 2, 2);
                nodeList[1].connectNodeIndex(2, 3, 5);
                nodeList[1].connectNodeIndex(3, 4, 1);

                nodeList[2].connectNodeIndex(1, 1, 2);
                nodeList[2].connectNodeIndex(2, 3, 3);
                nodeList[2].connectNodeIndex(3, 4, 2);

                nodeList[3].connectNodeIndex(1, 1, 5);
                nodeList[3].connectNodeIndex(2, 2, 3);
                nodeList[3].connectNodeIndex(3, 4, 3);
                nodeList[3].connectNodeIndex(4, 5, 1);
                nodeList[3].connectNodeIndex(5, 6, 5);

                nodeList[4].connectNodeIndex(1, 1, 1);
                nodeList[4].connectNodeIndex(2, 2, 2);
                nodeList[4].connectNodeIndex(3, 3, 3);
                nodeList[4].connectNodeIndex(4, 5, 1);

                nodeList[5].connectNodeIndex(1, 3, 1);
                nodeList[5].connectNodeIndex(2, 4, 1);
                nodeList[5].connectNodeIndex(3, 6, 2);

                nodeList[6].connectNodeIndex(1, 3, 5);
                nodeList[6].connectNodeIndex(2, 5, 2);
                break;

            case 4:
                for (int i = 1; i < nodeList.Length; i++)
                {
                    for (int j = 0; j < nodeList.Length; j++)
                    {
                        nodeList[i].connectNodeIndex(j, 0, 0);
                    }
                }

                nodeList[1].connectNodeIndex(1, 2, 10);
                nodeList[1].connectNodeIndex(2, 8, 10);

                nodeList[2].connectNodeIndex(1, 1, 10);
                nodeList[2].connectNodeIndex(2, 3, 10);
                nodeList[2].connectNodeIndex(3, 7, 10);

                nodeList[3].connectNodeIndex(1, 2, 10);
                nodeList[3].connectNodeIndex(2, 4, 10);
                nodeList[3].connectNodeIndex(3, 5, 10);

                nodeList[4].connectNodeIndex(1, 3, 10);
                nodeList[4].connectNodeIndex(2, 19, 10);

                nodeList[5].connectNodeIndex(1, 3, 10);
                nodeList[5].connectNodeIndex(2, 6, 10);

                nodeList[6].connectNodeIndex(1, 5, 10);
                nodeList[6].connectNodeIndex(2, 7, 10);
                nodeList[6].connectNodeIndex(3, 12, 10);

                nodeList[7].connectNodeIndex(1, 2, 10);
                nodeList[7].connectNodeIndex(2, 6, 10);
                nodeList[7].connectNodeIndex(3, 8, 10);
                nodeList[7].connectNodeIndex(4, 10, 10);

                nodeList[8].connectNodeIndex(1, 1, 10);
                nodeList[8].connectNodeIndex(2, 7, 10);
                nodeList[8].connectNodeIndex(3, 9, 10);

                nodeList[9].connectNodeIndex(1, 8, 10);
                nodeList[9].connectNodeIndex(2, 10, 10);
                nodeList[9].connectNodeIndex(3, 25, 10);

                nodeList[10].connectNodeIndex(1, 7, 10);
                nodeList[10].connectNodeIndex(2, 9, 10);
                nodeList[10].connectNodeIndex(3, 11, 10);

                nodeList[11].connectNodeIndex(1, 10, 10);
                nodeList[11].connectNodeIndex(2, 12, 10);
                nodeList[11].connectNodeIndex(3, 29, 10);

                nodeList[12].connectNodeIndex(1, 6, 10);
                nodeList[12].connectNodeIndex(2, 11, 10);
                nodeList[12].connectNodeIndex(3, 13, 10);

                nodeList[13].connectNodeIndex(1, 11, 10);
                nodeList[13].connectNodeIndex(2, 14, 10);

                nodeList[14].connectNodeIndex(1, 13, 10);
                nodeList[14].connectNodeIndex(2, 15, 10);
                nodeList[14].connectNodeIndex(3, 18, 10);

                nodeList[15].connectNodeIndex(1, 14, 10);
                nodeList[15].connectNodeIndex(2, 16, 10);
                nodeList[15].connectNodeIndex(3, 29, 10);

                nodeList[16].connectNodeIndex(1, 15, 10);
                nodeList[16].connectNodeIndex(2, 17, 10);

                nodeList[17].connectNodeIndex(1, 16, 10);
                nodeList[17].connectNodeIndex(2, 18, 10);
                nodeList[17].connectNodeIndex(3, 20, 10);
                nodeList[17].connectNodeIndex(4, 22, 10);

                nodeList[18].connectNodeIndex(1, 17, 10);
                nodeList[18].connectNodeIndex(2, 19, 10);
                nodeList[18].connectNodeIndex(3, 14, 10);

                nodeList[19].connectNodeIndex(1, 4, 10);
                nodeList[19].connectNodeIndex(2, 18, 10);
                nodeList[19].connectNodeIndex(3, 20, 10);

                nodeList[20].connectNodeIndex(1, 17, 10);
                nodeList[20].connectNodeIndex(2, 19, 10);
                nodeList[20].connectNodeIndex(3, 21, 10);

                nodeList[21].connectNodeIndex(1, 20, 10);
                nodeList[21].connectNodeIndex(2, 22, 10);

                nodeList[22].connectNodeIndex(1, 17, 10);
                nodeList[22].connectNodeIndex(2, 21, 10);
                nodeList[22].connectNodeIndex(3, 23, 10);

                nodeList[23].connectNodeIndex(1, 22, 10);
                nodeList[23].connectNodeIndex(2, 24, 10);
                nodeList[23].connectNodeIndex(3, 26, 10);

                nodeList[24].connectNodeIndex(1, 23, 10);
                nodeList[24].connectNodeIndex(2, 25, 10);

                nodeList[25].connectNodeIndex(1, 9, 10);
                nodeList[25].connectNodeIndex(2, 24, 10);
                nodeList[25].connectNodeIndex(3, 26, 10);

                nodeList[26].connectNodeIndex(1, 25, 10);
                nodeList[26].connectNodeIndex(2, 27, 10);

                nodeList[27].connectNodeIndex(1, 26, 10);
                nodeList[27].connectNodeIndex(2, 28, 10);

                nodeList[28].connectNodeIndex(1, 27, 10);
                nodeList[28].connectNodeIndex(2, 29, 10);

                nodeList[29].connectNodeIndex(1, 11, 10);
                nodeList[29].connectNodeIndex(2, 15, 10);
                nodeList[29].connectNodeIndex(3, 28, 10);

                for (int i = 1; i < nodeList.Length; i++)
                {
                    for (int j = 1; j < nodeList[i]._count; j++)
                    {
                        nodeList[i]._node_Weight[j] = Math.Sqrt(Math.Pow(nodeList[i].transform.position.x - nodeList[nodeList[i]._Connected_node[j]].transform.position.x, 2)
                                                              + Math.Pow(nodeList[i].transform.position.z - nodeList[nodeList[i]._Connected_node[j]].transform.position.z, 2));
                    }
                }

                break;
        }
    }
}
