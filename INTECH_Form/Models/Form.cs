using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTECH_Form.Models
{
    public class Form
    {
        private String _title;

        private Dictionary<String, FormAnswer> _answers;

        private QuestionRoot _questions;


        public Form()
        {
            _title = null;
            _answers = new Dictionary<string, FormAnswer>();
            _questions = null;
        }

        public String Title { get { return _title; } set { _title = value; } }

        public int AnswerCount { get { return _answers.Count; } }

        public QuestionRoot Questions { get {
                if (_questions == null)
                    _questions = new QuestionRoot();
                return _questions; } }

        public FormAnswer FindOrCreateAnswers(String user)
        {
            if (! _answers.ContainsKey(user))
                _answers[user] = new FormAnswer(user);
            
            return _answers[user];
        }
    }
}
