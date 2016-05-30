using System;
using System.Collections.Generic;
using System.Data;

namespace DivideConquer
{
    internal static class Const
    {
        public const string Outlook = "Outlook";

        public const string Sunny = "Sunny";
        public const string Overcast = "Overcast";
        public const string Rainy = "Rainy";


        public const string Temperature = "Temperature";

        public const string Hot = "Hot";
        public const string Mild = "Mild";
        public const string Cool = "Cool";


        public const string Humidity = "Humidity";

        public const string High = "High";
        public const string Normal = "Normal";


        public const string Windy = "Windy";

        public const string False = "False";
        public const string True = "True";


        public const string Play = "Play";

        public const string Yes = "Yes";
        public const string No = "No";
    }

    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            A outlook = new A(Const.Outlook, new List<Option>() { new Option(Const.Sunny), new Option(Const.Overcast), new Option(Const.Rainy) });
            A temperature = new A(Const.Temperature, new List<Option>() { new Option(Const.Hot), new Option(Const.Mild), new Option(Const.Cool) });
            A humidity = new A(Const.Humidity, new List<Option>() { new Option(Const.High), new Option(Const.Normal) });
            A windy = new A(Const.Windy, new List<Option>() { new Option(Const.False), new Option(Const.True) });
            A play = new A(Const.Play, new List<Option>() { new Option(Const.Yes), new Option(Const.No) });

            List<A> attributes = new List<A>() { outlook, temperature, humidity, windy };

            table.Columns.Add(outlook.Name, typeof(string));
            table.Columns.Add(temperature.Name, typeof(string));
            table.Columns.Add(humidity.Name, typeof(string));
            table.Columns.Add(windy.Name, typeof(string));
            table.Columns.Add(play.Name, typeof(string));

            #region Weather Data

            table.Rows.Add(Const.Sunny, Const.Hot, Const.High, Const.False, Const.No);
            table.Rows.Add(Const.Sunny, Const.Hot, Const.High, Const.True, Const.No);
            table.Rows.Add(Const.Overcast, Const.Hot, Const.High, Const.False, Const.Yes);
            table.Rows.Add(Const.Rainy, Const.Mild, Const.High, Const.False, Const.Yes);
            table.Rows.Add(Const.Rainy, Const.Cool, Const.Normal, Const.False, Const.Yes);
            table.Rows.Add(Const.Rainy, Const.Cool, Const.Normal, Const.True, Const.No);
            table.Rows.Add(Const.Overcast, Const.Cool, Const.Normal, Const.True, Const.Yes);
            table.Rows.Add(Const.Sunny, Const.Mild, Const.High, Const.False, Const.No);
            table.Rows.Add(Const.Sunny, Const.Cool, Const.Normal, Const.False, Const.Yes);
            table.Rows.Add(Const.Rainy, Const.Mild, Const.Normal, Const.False, Const.Yes);
            table.Rows.Add(Const.Sunny, Const.Mild, Const.Normal, Const.True, Const.Yes);
            table.Rows.Add(Const.Overcast, Const.Mild, Const.High, Const.True, Const.Yes);
            table.Rows.Add(Const.Overcast, Const.Hot, Const.Normal, Const.False, Const.Yes);
            table.Rows.Add(Const.Rainy, Const.Mild, Const.High, Const.True, Const.No);

            #endregion

            Tree decisionTree = new Tree();

            decisionTree.BuildDecisionTree(table, attributes, null);

            decisionTree.PrintDecisionTree(decisionTree.Nodes[0]);

            Console.ReadKey();
        }
    }

    internal class A
    {
        public string Name;

        public List<Option> options;

        public double averageInformationValue;
        public void setAverageInfVal()
        {
            int overallYes = 0;
            int overallNo = 0;

            foreach (Option option in this.options)
            {
                overallYes += option.yesAmount;
                overallNo += option.noAmount;
            }


            double tempYes = (double)overallYes / (overallYes + overallNo);
            double tempNo = (double)overallNo / (overallYes + overallNo);


            double tempInformationValue = -(tempYes * Math.Log(tempYes, 2) + tempNo * Math.Log(tempNo, 2));

            int overallYesNo = 0;
            double tempResult = 0;

            foreach (Option option in this.options)
            {
                overallYesNo = option.yesAmount + option.noAmount;

                tempResult += (double)overallYesNo / (overallYes + overallNo) * option.informationValue;
            }

            this.averageInformationValue = tempInformationValue - tempResult;

            Console.WriteLine("   " + this.averageInformationValue);
        }

        public A(string attributeName, List<Option> options)
        {
            this.Name = attributeName;

            this.options = options;
        }
       
        
    }

  
    internal class Tree
    {
        public List<Node> Nodes;

        public Tree()
        {
            this.Nodes = new List<Node>();
        }

      
        public void PrintDecisionTree(Node treeNode)
        {
            if (treeNode.nodeData != Const.Yes && treeNode.nodeData != Const.No)
            {
                Console.WriteLine(treeNode.nodeData);
            }
            else
            {
                Console.WriteLine("                      " + treeNode.nodeData);
            }

            if (treeNode.relations != null)
            {
                foreach (Relation relation in treeNode.relations)
                {
                    Console.WriteLine("           " + relation.childEdge);

                    PrintDecisionTree(relation.childNode);
                }
            }
        }
        public void BuildDecisionTree(DataTable table, List<A> attributes, Relation relation)
        {


            for (int i = 0; i < table.Columns.Count - 1; i++)
            {

                foreach (A attribute in attributes)//
                {

                    if (table.Columns[i].Caption == attribute.Name)
                    {


                        for (int j = 0; j < table.Rows.Count; j++)
                        {
                            foreach (Option option in attribute.options)
                            {
                                if (table.Rows[j][i].ToString() == option.optionName)
                                {
                                    if (table.Rows[j].Field<string>("Play") == Const.Yes)
                                    {
                                        option.yesAmount++;
                                    }
                                    else if (table.Rows[j].Field<string>("Play") == Const.No)
                                    {
                                        option.noAmount++;
                                    }
                                }
                            }
                        }


                        foreach (Option option in attribute.options)
                        {

                            option.setInformationValue();

                            if (Double.IsNaN(option.informationValue))
                            {
                                option.informationValue = 0;
                            }

                            Console.WriteLine(option.informationValue);
                        }


                        attribute.setAverageInfVal();

                        Console.WriteLine("      " + attribute.averageInformationValue);
                    }
                }
            }

            A choosenAttribute = attributes[0];


            for (int i = 1; i < attributes.Count; i++)
            {
                if (attributes[i].averageInformationValue > choosenAttribute.averageInformationValue)
                {
                    choosenAttribute = attributes[i];
                }
            }

            Console.WriteLine("         " + choosenAttribute.averageInformationValue);
            Console.WriteLine(Environment.NewLine + Environment.NewLine);


            List<Relation> relations = new List<Relation>();

            DataTable dataTable;

            foreach (Option option in choosenAttribute.options)
            {
                if (option.informationValue != 0)
                {
                    dataTable = table.Copy();

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {


                        if (dataTable.Rows[i].Field<string>(choosenAttribute.Name) != option.optionName)
                        {
                            dataTable.Rows.Remove(dataTable.Rows[i]);
                            i--;
                        }
                    }


                    relations.Add(new Relation(null, option.optionName, dataTable));
                }
                else
                {
                    string nodeData = "";

                    if (option.yesAmount == 0)
                    {
                        nodeData = Const.No;
                    }
                    else if (option.noAmount == 0)
                    {
                        nodeData = Const.Yes;
                    }

                    relations.Add(new Relation(new Node(nodeData, null, null), option.optionName, null));
                }
            }

            List<A> tempAttributes = new List<A>();


            foreach (A attribute in attributes)
            {
                if (attribute != choosenAttribute)
                {
                    tempAttributes.Add(attribute);
                }
            }

            Node tempTreeNode = new Node(choosenAttribute.Name, relations, tempAttributes);


            this.Nodes.Add(tempTreeNode);

            if (relation != null)
            {
                relation.childNode = tempTreeNode;
            }

            foreach (A attribute in attributes)
            {
                foreach (Option option in attribute.options)
                {
                    option.yesAmount = 0;
                    option.noAmount = 0;
                }

                attribute.averageInformationValue = 0;
            }


            foreach (Relation newRelation in relations)
            {
                if (newRelation.childNode == null)
                {

                    BuildDecisionTree(newRelation.dataTable, tempTreeNode.attributes, newRelation);
                }
                else
                {
                    continue;
                }
            }
        }

    }

    internal class Option
    {
        public string optionName;

        public int yesAmount;
        public int noAmount;

        public double informationValue;

        public Option(string optionName)
        {
            this.optionName = optionName;
        }


        public void setInformationValue()
        {
            double tempYes = (double)this.yesAmount / (this.yesAmount + this.noAmount);
            double tempNo = (double)this.noAmount / (this.yesAmount + this.noAmount);

            this.informationValue = -(tempYes * Math.Log(tempYes, 2) + tempNo * Math.Log(tempNo, 2));
        }
    }

    internal class Relation
    {
        public Node childNode;
        public string childEdge;

        public DataTable dataTable;

        public Relation(Node childNode, string childEdge, DataTable dataTable)
        {
            this.childNode = childNode;
            this.childEdge = childEdge;

            this.dataTable = dataTable;
        }
    }

    internal class Node
    {
        public string nodeData;

        public List<Relation> relations;

        public List<A> attributes;

        public Node(string nodeData, List<Relation> relations, List<A> attributes)
        {
            this.nodeData = nodeData;

            this.relations = relations;

            this.attributes = attributes;
        }
    }
}
