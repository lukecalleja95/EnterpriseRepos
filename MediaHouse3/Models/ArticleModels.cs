using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MediaHouse3.Models
{
    public class ArticlesContext : DbContext
    {
        public ArticlesContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Article> Articles { get; set; }
    }

    [Table("Article")]
    public class Article
    {
        public int articleId { get; set; }

        [Required]
        [Display(Name = "Article Title")]
        [StringLength(50)]
        public string articleTitle { get; set; }

        [Display(Name = "Sub Header")]
        public string subHeader { get; set; }

        [Required]
        [Display(Name = "Article Content")]
        public string articleContent { get; set; }
        public DateTime dateCreated { get; set; }
        public string imageArticle { get; set; }

        [Display(Name = "Breaking News?")]
        public bool isBreaking { get; set; }
        public int UserId { get; set; }

        [Display(Name = "Category")]
        public int categoryId { get; set; }
    }

    [Table("Category")]
    public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
    }
}