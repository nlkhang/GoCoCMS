using GoCoCMS.Data.Domain;
using GoCoCMS.Service;
using GoCoCMS.Web.Areas.Admin.Factories;
using GoCoCMS.Web.Areas.Admin.Models.Post;
using GoCoCMS.Web.Infrastructure.Mapper.Extensions;
using GoCoCMS.Web.Infrastructure.Mvc.ActionFillter;
using Microsoft.AspNetCore.Mvc;

namespace GoCoCMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostController : Controller
    {
        #region Fields

        private readonly IBlogPostModelFactory _blogPostModelFactory;
        private readonly IBlogPostService _blogPostService;

        #endregion

        #region Ctor

        public BlogPostController(IBlogPostModelFactory blogPostModelFactory,
            IBlogPostService blogPostService)
        {
            _blogPostModelFactory = blogPostModelFactory;
            _blogPostService = blogPostService;
        }

        #endregion

        #region Methods

        // GET: BlogPost
        public ActionResult Index()
        {
            var model = _blogPostModelFactory.PrepareBlogPostListModel(new BlogPostSearchModel());

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BlogPostListModel model)
        {
            var blogPostListModel = _blogPostModelFactory.PrepareBlogPostListModel(model.BlogPostSearchModel);

            return View(blogPostListModel);
        }

        // GET: BlogPost/Create
        public ActionResult Create()
        {
            var model = _blogPostModelFactory.PrepareBlogPostModel(new BlogPostModel(), null);

            return View(model);
        }

        // POST: BlogPost/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Create(BlogPostModel model, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                var blogPost = model.ToEntity<BlogPost>();
                _blogPostService.InsertBlogPost(blogPost);

                if (!continueEditing)
                    return RedirectToAction("Index");

                return RedirectToAction("Edit", new { id = blogPost.Id });
            }

            model = _blogPostModelFactory.PrepareBlogPostModel(model, null);

            return View(model);
        }

        // GET: BlogPost/Edit/5
        public ActionResult Edit(int id)
        {
            // try get blog post by parameter
            var blogPost = _blogPostService.GetBlogPostById(id);
            if (blogPost?.Deleted == true)
                return RedirectToAction("Index");

            // prepare model
            var model = _blogPostModelFactory.PrepareBlogPostModel(null, blogPost);

            return View(model);
        }

        // POST: BlogPost/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Edit(BlogPostModel model, bool continueEditing)
        {
            // try get blog post by parameter
            var blogPost = _blogPostService.GetBlogPostById(model.Id);
            if (blogPost?.Deleted == true)
                return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                blogPost = model.ToEntity(blogPost);
                _blogPostService.UpdateBlogPost(blogPost);

                if (!continueEditing)
                    return RedirectToAction("Index");

                return RedirectToAction("Edit", new { id = blogPost.Id });
            }

            // prepare model
            model = _blogPostModelFactory.PrepareBlogPostModel(model, blogPost);

            return View(model);
        }

        // GET: BlogPost/Delete/5
        public ActionResult Delete(int id)
        {
            // try get blog post by parameter id
            var blogPost = _blogPostService.GetBlogPostById(id);
            if (blogPost?.Deleted == true)
                return RedirectToAction("Index");

            // delete blog post
            _blogPostService.DeleteBlogPost(blogPost);

            return RedirectToAction("Index");
        }

        #endregion

        #region Utilities



        #endregion
    }
}