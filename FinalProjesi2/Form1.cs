using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjesi2
{
    public partial class Form1 : Form
    {
        Node root;
        public Form1()
        {
            InitializeComponent();
            root = new Node();
            root = null;
        }

        public class Node
        {
            public int data;
            public Node left;
            public Node right;


            public Node()
            {

                left = null;
                right = null;

            }
            public Node(int data)
            {
                this.data = data;
            }



        }
        public Node NewNode(int data)
        {
            Node root = new Node(data);
            return root;
        }
        public Node Insert(Node root, int data) // ekleme 
        {
            Node node = new Node(data);
            if (root != null)
            {
                if (data < root.data)
                {
                    root.left = Insert(root.left, data);
                }
                else
                {
                    root.right = Insert(root.right, data);
                }
            }
            else
            {
                root = NewNode(data);
            }
            return root;

        }

        public void goster(Node kok)
        {
            if (kok == null)
            {
                return;


            }
            goster(kok.left);
            richTextBox1.Text += kok.data.ToString() + "-->";
            goster(kok.right);

        }
        public void inOrder(Node root)
        {

            if (root == null)
            {
                return;
            }

            inOrder(root.left);
            textBox6.Text = textBox6.Text + root.data.ToString() + " ";
            inOrder(root.right);
        }
        public void postOrder(Node root)
        {

            if (root == null)
            {
                return;
            }

            postOrder(root.left);
            postOrder(root.right);
            textBox7.Text = textBox7.Text + root.data.ToString() + " ";

        }
        public void preOrder(Node root)
        {

            if (root == null)
            {
                return;
            }
            textBox5.Text = textBox5.Text + root.data.ToString() + " ";
            preOrder(root.left);
            preOrder(root.right);
        }
        public int Height(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                int l, r;
                l = Height(root.left);
                r = Height(root.right);
                if (l > r)
                {
                    return l + 1;
                }
                else
                {
                    return r + 1;
                }
            }
        }
        public int Size(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                return Size(root.left) + 1 + Size(root.right);
            }
        }

        public Node delete(Node root, int num)
        {
            if (root == null)
            {

                return root;
            }
            if (num < root.data)
            {
                root.left = delete(root.left, num);
            }
            else if (num > root.data)
            {
                root.right = delete(root.right, num);
            }

            else
            {

                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;


                root.data = FindMin(root.right);


                root.right = delete(root.right, root.data);
            }

            return root;
        }
        public void yaprakGoster(Node y)
        {
            if (y != null)
            {
                if (y.right == null && y.left == null)
                {
                    textBox10.Text += y.data.ToString() + " , ";
                    return;
                }

                if (y.left != null)
                    yaprakGoster(y.left);

                if (y.right != null)
                    yaprakGoster(y.right);

            }

        }
        public int FindMin(Node mn)
        {


            while (mn.left != null)
            {
                mn = mn.left;
            }
            return mn.data;


        }
        public int FindMax(Node mx)
        {


            while (mx.right != null)
            {
                mx = mx.right;
            }
            return mx.data;

        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            int yeni = int.Parse(textBox1.Text);
            root = Insert(root, yeni);
            textBox1.Text = "";
        }

        private void btn_Agac_goster_Click(object sender, EventArgs e)
        {

            richTextBox1.Text = "";
            goster(root);

        }

        private void btn_agac_bilgileri_Click(object sender, EventArgs e)
        {

            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            Aranan_duzey.Text = "";


            preOrder(root);
            inOrder(root);
            postOrder(root);
            textBox8.Text = Size(root).ToString();
            textBox9.Text = Height(root).ToString();
            yaprakGoster(root);
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            int silinecek = int.Parse(textBox2.Text);
            root = delete(root, silinecek);




        }
        int duzey = 1;
        private void btn_bul_Click(object sender, EventArgs e)
        {
            Node dugumduzey = root;
            int girilenN = int.Parse(textBox3.Text);
            Aranan_duzey.Text = "";
            while (true)
            {
                if (dugumduzey.data == girilenN)
                {
                    Aranan_duzey.Text += duzey + "   duzeyde";
                    duzey = 1;
                    return;
                }
                else if (dugumduzey.data < girilenN)
                {
                    dugumduzey = dugumduzey.right;
                    duzey++;
                }
                else if (dugumduzey.data > girilenN)
                {
                    dugumduzey = dugumduzey.left;
                    duzey++;
                }
                textBox3.Text = "";
            }
        }
    }
}   


