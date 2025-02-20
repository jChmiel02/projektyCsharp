using System;
using System.Collections.Generic;
using System.IO;

namespace Blog2024.Library
{
    public class PostManager
    {
        private const string FilePath = "blog_posts.txt";
        private List<string> _posts;

        public PostManager()
        {
            _posts = new List<string>();
            LoadPosts();
        }
        public void AddPost(string pseudonym, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Content cannot be empty.");

            DateTime publicationDate = DateTime.Now;
            string post = $"{pseudonym}\n{publicationDate:yyyy-MM-dd HH:mm:ss}\n{content}\n";
            _posts.Add(post);
            SavePosts();
        }

        private void SavePosts()
        {
            if (_posts.Count > 0)
            {
                File.WriteAllLines(FilePath, _posts);
            }
        }

        private void LoadPosts()
        {
            if (File.Exists(FilePath))
            {
                _posts = new List<string>(File.ReadAllLines(FilePath));

                _posts.RemoveAll(post => string.IsNullOrWhiteSpace(post));
            }
        }
        public List<string> GetPosts()
        {
            return _posts;
        }
    }
}
