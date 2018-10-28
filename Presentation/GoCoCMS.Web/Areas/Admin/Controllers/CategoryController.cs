using GoCoCMS.Data.Domain;
using GoCoCMS.Service;
using GoCoCMS.Web.Areas.Admin.Factories;
using GoCoCMS.Web.Areas.Admin.Models.Category;
using GoCoCMS.Web.Infrastructure.Mapper.Extensions;
using GoCoCMS.Web.Infrastructure.Mvc.ActionFillter;
using Microsoft.AspNetCore.Mvc;

namespace GoCoCMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        #region Fields

        private readonly IBlogCategoryModelFactory _categoryModelFactory;
        private readonly IBlogCategoryService _categoryService;

        #endregion

        #region Ctor

        public CategoryController(IBlogCategoryModelFactory categoryModelFactory,
            IBlogCategoryService categoryService)
        {
            _categoryModelFactory = categoryModelFactory;
            _categoryService = categoryService;
        }

        #endregion

        #region Methods

        // GET: Category
        public ActionResult Index()
        {
            var model = _categoryModelFactory.PrepareCategoryListModel(new CategorySearchModel());

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CategoryListModel model)
        {
            var categoryListModel= _categoryModelFactory.PrepareCategoryListModel(model.CategorySearchModel);

            return View(categoryListModel);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            var model = _categoryModelFactory.PrepareCategoryModel(new CategoryModel(), null);

            return View(model);
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Create(CategoryModel model, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                var category = model.ToEntity<BlogCategory>();
                _categoryService.InsertCategory(category);

                if(!continueEditing)
                    return RedirectToAction("Index");

                return RedirectToAction("Edit", new { id = category.Id });
            }

            model = _categoryModelFactory.PrepareCategoryModel(model, null);

            return View(model);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            // try get category by parameter
            var category = _categoryService.GetCategoryById(id);
            if (category?.Deleted == true)
                return RedirectToAction("Index");

            // prepare model
            var model = _categoryModelFactory.PrepareCategoryModel(null, category);

            return View(model);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]    
        public ActionResult Edit(CategoryModel model, bool continueEditing)
        {
            // try get category by parameter
            var category = _categoryService.GetCategoryById(model.Id);
            if (category?.Deleted == true)
                return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                category = model.ToEntity(category);
                _categoryService.UpdateCategory(category);

                if (!continueEditing)
                    return RedirectToAction("Index");

                return RedirectToAction("Edit", new { id = category.Id });
            }

            // prepare model
            model = _categoryModelFactory.PrepareCategoryModel(model, category);

            return View(model);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            // try get category by parameter id
            var category = _categoryService.GetCategoryById(id);
            if(category?.Deleted == true)
                return RedirectToAction("Index");

            // delete category
            _categoryService.DeleteCategory(category);

            return RedirectToAction("Index");
        }

        #endregion

        #region Utilities



        #endregion
    }
}