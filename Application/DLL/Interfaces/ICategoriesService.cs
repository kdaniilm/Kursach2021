using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICategoriesService
    {
        public Task<bool> AddCategory(Category category);

        public Task<List<Category>> GetAllCategories();
    }
}
