using System.ComponentModel.DataAnnotations;

namespace FriendsDirectoryWeb.Models
{
    public class FriendList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
    }
}
