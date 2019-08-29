using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class Categories
    {
        public Category Create(Category newCategory)
        {
            Category Result = null;

            using (var context = RepositoryFactory.CreateRepository())
            {
                Category c = context.Retrieve<Category>(x => x.CategoryName == newCategory.CategoryName);

                if (c == null)
                {
                    Result = context.Create(newCategory);
                }
                else
                {

                }
            }

            return Result;
        }

        public Category RetrieveByID(int ID)
        {
            Category Result = null;

            using (var context = RepositoryFactory.CreateRepository())
            {
                Result = context.Retrieve<Category>(x => x.CategoryID == ID);
            }

                return Result;
        }

        public bool Update(Category categoryToUpdate)
        {
            bool Result = false;

            using (var context = RepositoryFactory.CreateRepository())
            {
                Category tmp = context.Retrieve<Category>(x => x.CategoryName == categoryToUpdate.CategoryName
                                && x.CategoryID != categoryToUpdate.CategoryID);

                if (tmp != null)
                {
                    Result = context.Update(categoryToUpdate);
                }
                else
                {
                }
            }
            return Result;
        }

        public bool Delete(int ID)
        {
            bool Result = false;
            var categoryToDelete = RetrieveByID(ID);

            if (categoryToDelete != null)
            {
                using (var context = RepositoryFactory.CreateRepository())
                {
                    
                    var listOfProducts = new Products().FilterByCategoryID(categoryToDelete.CategoryID);

                    if (listOfProducts == null)
                    {
                        Result = context.Delete(categoryToDelete);
                    }
                    else
                    {
                        //avisa que la categoria tiene productos ligados.
                    }
                }
            }
            else
            {
                // avisa que la categoria no existe.
            }

            return Result;
        }

    }
}
