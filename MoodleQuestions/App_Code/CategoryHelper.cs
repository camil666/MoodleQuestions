using System.Collections.Generic;
using System.Linq;
using MoodleQuestions.Repositories;
using QuestionsDAL;

namespace MoodleQuestions
{
    public static class CategoryHelper
    {
        #region Methods

        /// <summary>
        /// Makes the full category names.
        /// </summary>
        /// <param name="categories">The categories.</param>
        public static void MakeFullCategoryNames(IEnumerable<QuestionCategory> categories)
        {
            foreach (var category in categories)
            {
                if (category.ParentCategoryId != null)
                {
                    CategoryHelper.MakeFullCategoryName(category);
                }

                category.Name = "/" + category.Name;
            }
        }

        private static void MakeFullCategoryName(QuestionCategory rootCategory)
        {
            MakeFullCategoryName(rootCategory, rootCategory);
        }

        private static void MakeFullCategoryName(QuestionCategory rootCategory, QuestionCategory childCategory)
        {
            var parentCategory = QuestionCategoryRepository.GetById(childCategory.ParentCategoryId.Value);

            rootCategory.Name = parentCategory.Name + "/" + rootCategory.Name;

            if (parentCategory.ParentCategoryId != null)
            {
                MakeFullCategoryName(rootCategory, parentCategory);
            }
        }

        #endregion
    }
}