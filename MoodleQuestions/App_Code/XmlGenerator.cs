using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using QuestionsDAL;

namespace MoodleQuestions
{
    public class XmlGenerator
    {
        #region Constants

        private const string TextTag = "text";
        private const string AnswerNumberingTag = "answernumbering";
        private const string QuestionTag = "question";
        private const string CategoryTag = "category";
        private const string AnswerTag = "answer";
        private const string QuizTag = "quiz";
        private const string NameTag = "name";
        private const string QuestionTextTag = "questiontext";

        private const string TypeAttribute = "type";

        #endregion

        #region Properties

        #endregion

        #region Methods

        public XElement GenerateXml(IEnumerable<Question> questions, string category = null, AnswerNumbering numbering = AnswerNumbering.Numerical)
        {
            var quizRoot = new XElement(QuizTag);

            if (!string.IsNullOrEmpty(category))
            {
                var questionCategory = new XElement(QuestionTag);
                questionCategory.SetAttributeValue(TypeAttribute, CategoryTag);
                var categoryTag = new XElement(CategoryTag);
                questionCategory.Add(categoryTag);
                categoryTag.Add(new XElement(TextTag, category));
                quizRoot.Add(questionCategory);
            }

            foreach (var question in questions)
            {
                quizRoot.Add(GenerateXml(question, numbering));
            }

            return quizRoot;
        }

        public XElement GenerateXml(Question question, AnswerNumbering numbering = AnswerNumbering.Numerical)
        {
            var questionRoot = new XElement(QuestionTag);
            questionRoot.SetAttributeValue(TypeAttribute, "multichoice");
            if (!string.IsNullOrEmpty(question.Name))
            {
                var name = new XElement(NameTag);
                name.Add(new XElement(TextTag, question.Name));
                questionRoot.Add(name);
            }

            var questionText = new XElement(QuestionTextTag);
            questionText.SetAttributeValue("format", "html");
            var textTag = new XElement(TextTag);
            textTag.Add(new XCData(question.Content));
            questionText.Add(textTag);
            questionRoot.Add(questionText);

            foreach (var answer in question.QuestionAnswers)
            {
                var answerTag = new XElement(AnswerTag);
                answerTag.SetAttributeValue("fraction", answer.Fraction);
                var answerText = new XElement(TextTag);
                answerText.Add(new XCData(answer.Content));
                answerTag.Add(answerText);
                questionRoot.Add(answerTag);
            }

            XElement answerNumbering;

            switch (numbering)
            {
                case AnswerNumbering.None:
                    answerNumbering = new XElement(AnswerNumberingTag, "none");
                    questionRoot.Add(answerNumbering);
                    break;
                case AnswerNumbering.Alphabetical:
                    answerNumbering = new XElement(AnswerNumberingTag, "abc");
                    questionRoot.Add(answerNumbering);
                    break;
                case AnswerNumbering.AlphabeticalCapitalized:
                    answerNumbering = new XElement(AnswerNumberingTag, "ABCD");
                    questionRoot.Add(answerNumbering);
                    break;
                case AnswerNumbering.Numerical:
                    answerNumbering = new XElement(AnswerNumberingTag, "123");
                    questionRoot.Add(answerNumbering);
                    break;
            }

            return questionRoot;
        }

        #endregion
    }
}