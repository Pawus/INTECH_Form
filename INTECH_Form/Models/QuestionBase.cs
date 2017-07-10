using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTECH_Form.Models
{


    public class QuestionBase
    {
        public static int _idSeq = 1;

        private int _id;
        private String _title;

        private List<QuestionBase> _children;
        private QuestionBase _parent;

        public QuestionBase(QuestionBase parent)
        {
            _id = _idSeq;
            _idSeq += 1;
            _children = new List<QuestionBase>();
            _parent = parent;
        }

        public String Title { get => _title; set { _title = value; } }

        public QuestionBase Parent {
            get => _parent;
            set {
                if( _parent != value)
                {
                    if (_parent != null)
                    {
                        _parent._children.Remove(this);
                    }
                    _parent = value;
                    if( _parent != null)
                    {
                        _parent._children.Add(this);
                    }
                }
            }
        }

        public IReadOnlyList<QuestionBase> Children => _children;

        public virtual Form Form => Parent?.Form;

        public QuestionBase AddChild(String questionType)
        {
            Type tQuestion = Type.GetType(questionType);
            QuestionBase q = (QuestionBase) Activator.CreateInstance(tQuestion, this);
            _children.Add(q);
            return q;
        }

        public void RemoveChild(QuestionBase c)
        {
            if (c.Parent == this) c.Parent = null;
        }



        public int Index {
            get => _parent != null
                ? _parent._children.IndexOf(this)
                : -1;
            set {
                if (_parent == null) throw new InvalidOperationException("No parent");
                if (value < 0 || value >= _parent._children.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                int oldIdx = _parent._children.IndexOf(this);
                _parent._children.RemoveAt(oldIdx);
                if (oldIdx > value)
                {
                    _parent._children.Insert(value, this);
                }
                else
                {
                    _parent._children.Insert(value - 1, this);
                }
            }
        }
    }
}
