using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestionsDAL;

namespace MoodleQuestions
{
    public static class CategoryHelper
    {
        #region Methods

        public static void ConcatCategoryName(IEnumerable<QuestionCategory> categories)
        {
            foreach (var category in categories)
            {
                if (category.ParentCategoryId != null)
                {
                    CategoryHelper.ConcatCategoryName(category);
                }
            }
        }

        public static void ConcatCategoryName(QuestionCategory rootCategory)
        {
            ConcatCategoryName(rootCategory, rootCategory);
        }

        private static void ConcatCategoryName(QuestionCategory rootCategory, QuestionCategory childCategory)
        {
            var parentCategory = GetQuestionCategory(childCategory.ParentCategoryId.Value);

            rootCategory.Name = parentCategory.Name + "/" + rootCategory.Name;

            if (parentCategory.ParentCategoryId != null)
            {
                ConcatCategoryName(rootCategory, parentCategory);
            }
        }

        private static QuestionCategory GetQuestionCategory(int id)
        {
            using (var context = new Entities())
            {
                return (from item in context.QuestionCategories
                        where item.Id == id
                        select item).FirstOrDefault();
            }
        }

        #endregion
    }
}