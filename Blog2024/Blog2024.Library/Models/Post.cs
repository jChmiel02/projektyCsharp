namespace Blog2024.Library.Models
{
    public class Post
    {
        public string Pseudonym { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Content { get; set; }

        public Post(string pseudonym, string content)
        {
            Pseudonym = pseudonym;
            Content = content;
            PublicationDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Pseudonym}\n{PublicationDate:yyyy-MM-dd HH:mm:ss}\n{Content}\n";
        }
    }
}
