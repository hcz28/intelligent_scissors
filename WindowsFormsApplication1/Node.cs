using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Node
    {
        public double[] link_cost = new double[8];
        private int _state;
        private double total_cost;
        private int _expanded_num;

        public int[] Parent;
        public int pos_x;
        public int pos_y;

        public double priority
        {
            get { return total_cost; }
            set { total_cost = value; }
        }

        public int state
        {
            get { return _state; }
            set { _state = value; }
        }
        public int expanded_num
        {
            get { return _expanded_num; }
            set { _expanded_num = value; }
        }

        public Node(int pos_x,int pos_y)
        {
            for(int i=0;i<8;i++)
            {
                this.link_cost[i] = 0;
            }
            _state = 0;
            this.total_cost = double.MaxValue;
            this.Parent = null;
            this.pos_x = pos_x;
            this.pos_y = pos_y;
        }
        
    }
}
