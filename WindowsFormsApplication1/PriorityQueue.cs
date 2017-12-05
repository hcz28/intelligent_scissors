using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication1
{
    class PriorityQueue
    {
        private ArrayList _pixels;

        public PriorityQueue()
        {
            _pixels = new ArrayList();
        }

        public Boolean hasNextPixel()
        {
            if (_pixels.Count > 0)
                return true;

            return false;
        }

        public Node nextPixel
        {
            get
            {
                Node temp = null;
                double min = 999999;
                int tempInd = -1;

                for (int i = 0; i < _pixels.Count; i++)
                {
                    if (((Node)_pixels[i]).priority < min)
                    {
                        temp = (Node)_pixels[i];
                        tempInd = i;
                        min = temp.priority;
                    }
                }

                if (tempInd != -1)
                    _pixels.RemoveAt(tempInd);

                return temp;
            }
        }

        public void Add(Node newPixel)
        {
            _pixels.Add(newPixel);
        }

        public Boolean Contains(Node ip)
        {
            for (int i = 0; i < _pixels.Count; i++)
                if (((Node)_pixels[i]).Equals(ip))
                    return true;

            return false;
        }
    }
}
