using PetsApi.Models;
using PetsDatabaseDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetsApi.Controllers
{
    public class PostsController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        [Route("api/Posts")]
        public List<Postc> GetPost()
        {
            var postlist = db.posts.OrderByDescending(s => s.PostDateTime).ToList();
            List<Postc> potlist = new List<Postc>();
            foreach (var item in postlist)
            {
                Postc p = new Postc
                {
                    Description = item.Description,
                    PostDateTime = item.PostDateTime,
                    UserName = item.User.UserName,
                    UserId = item.UserID,
                    UserImage = item.User.Photo,
                    Likes=item.Likes,
                    ID = item.ID

                };
                foreach (var items in item.Comments)
                {
                    CommentDto c = new CommentDto
                    {
                        ID = items.ID,
                        PostID = int.Parse(items.PostID.ToString()),
                        CommentDateTime = items.CommentDateTime,
                        Description = items.Description,
                        UserId = items.UserId,
                        UserName=items.user.UserName,
                        UserPhoto=items.user.Photo
                    };
                    p.Comments.Add(c);
                }
                foreach (var items in item.PostPhotos)
                {
                    p.postPhotos.Add(items.Image);
                }
                potlist.Add(p);
            }
            return potlist;
        }
        [HttpGet]
        [Route("api/Posts/{name}")]
        public List<Postc> GetMyPost(string name)
        {
            var userId = (from n in db.Users
                          where n.UserName == name
                          select n.Id).FirstOrDefault();
            var postlist= db.posts.Where(s => s.UserID == userId).OrderByDescending(s => s.PostDateTime).ToList();
            List<Postc> potlist = new List<Postc>();
            foreach (var item in postlist)
            {
                Postc p = new Postc
                {
                    Description = item.Description,
                    PostDateTime = item.PostDateTime,
                    UserName = item.User.UserName,
                    UserId = item.UserID,
                    UserImage = item.User.Photo,
                    ID = item.ID,
                    Likes=item.Likes

                };
                foreach (var items in item.Comments)
                {
                    CommentDto c = new CommentDto
                    {
                        ID = items.ID,
                        PostID = int.Parse(items.PostID.ToString()),
                        CommentDateTime = items.CommentDateTime,
                        Description = items.Description,
                        UserId = items.UserId,
                        UserName = items.user.UserName,
                        UserPhoto = items.user.Photo
                    };
                    p.Comments.Add(c);
                }
                foreach (var items in item.PostPhotos)
                {
                    p.postPhotos.Add(items.Image);
                }
                potlist.Add(p);
            }
            return potlist;
        }
        [HttpPost]
        [Route("api/Posts/like")]
        public bool Postlike(Likes like)
        {
            var n = (from e in db.Users
                     where e.UserName == like.userName
                     select e.Id).FirstOrDefault();
            var q = (from i in db.UserLikes
                     where i.PostId == like.postId &&
                     i.UserID == n
                     select i).FirstOrDefault();
            if (q == null)
            {
                UserLikes likes = new UserLikes();
                likes.PostId = like.postId;
                likes.UserID = n;
                likes.Status = true;
                db.UserLikes.Add(likes);
                var l = (from k in db.posts
                         where k.ID == like.postId
                         select k).FirstOrDefault();
                l.Likes += 1;
                db.SaveChanges();
            }
            else
            {
                if (q.Status == false)
                {
                    q.Status = true;
                    var l = (from k in db.posts
                             where k.ID == like.postId
                             select k).FirstOrDefault();
                    l.Likes += 1;
                    db.SaveChanges();
                }
                else
                {
                    q.Status = false;
                    var l = (from k in db.posts
                             where k.ID == like.postId
                             select k).FirstOrDefault();
                    l.Likes -= 1;
                    db.SaveChanges();
                }
            }
            return true;
        }
        [HttpPost]
        [Route("api/Posts/Rlike")]
        public bool PostRlike([FromBody]int num)
        {
            var post = (from i in db.posts
                        where i.ID == num
                        select i).FirstOrDefault();
            post.Likes -= 1;
            db.SaveChanges();
            return true;
        }
        [HttpPost]
        [Route("api/Posts")]
        public bool PostPos(Postc posts)
        {
            var user = (from i in db.Users
                        where i.UserName == posts.UserName
                        select i.Id).FirstOrDefault();

            Posts p = new Posts();
            p.Description = posts.Description;
            p.UserID = user;
            p.PostDateTime = posts.PostDateTime;
            db.posts.Add(p);
            db.SaveChanges();
            PostPhotos postPhotos = new PostPhotos();
            //Save to DB
            foreach (var item in posts.postPhotos)
            {
                postPhotos.Image = item;
                postPhotos.Posts = p;
                db.PostPhoto.Add(postPhotos);
                db.SaveChanges();
            }
            return true;
        }
        [HttpPost]
        [Route("api/Posts/Update")]
        public bool PostUpdatePost(updatePost posts)
        {
            var user = (from i in db.posts
                        where i.ID == posts.ID
                        select i).FirstOrDefault();

            user.Description = posts.Description;
            user.PostDateTime = posts.PostDateTime;
            db.SaveChanges();
            PostPhotos postPhotos1 = new PostPhotos();
            var postPhotos = (from i in db.PostPhoto
                              where i.PostID == posts.ID
                              select i).ToList();
            while (postPhotos.Count > 0)
            {
                db.PostPhoto.Remove(postPhotos[postPhotos.Count - 1]);
                postPhotos.RemoveAt(postPhotos.Count - 1);
                db.SaveChanges();
            }

            foreach (var item in posts.postPhotos)
            {
                postPhotos1.Image = item;
                postPhotos1.Posts = user;
                db.PostPhoto.Add(postPhotos1);
                db.SaveChanges();
            }
            return true;
        }
        [HttpPost]
        [Route("api/Posts/comm")]
        public bool Postcomment(Comments comm)
        {
            
            Comments c = new Comments();
            c.Description = comm.Description;
            c.PostID = comm.PostID;
            c.UserId = comm.UserId;
            c.CommentDateTime = comm.CommentDateTime;
            db.Comments.Add(c);
            db.SaveChanges();
            return true;
        }
        [HttpGet]
        [Route("api/getPost/{Id}")]
        public Postc GetPost(int Id)
        {
            var Post = db.posts.FirstOrDefault(i => i.ID == Id);
            Postc pc = new Postc
            {
                ID=Post.ID,
                Description=Post.Description,
                PostDateTime=Post.PostDateTime,
                UserId=Post.UserID,
                UserImage=Post.User.Photo,
                UserName=Post.User.UserName
            };
            foreach (var item in Post.PostPhotos)
            {
                pc.postPhotos.Add(item.Image);
            }
            return pc;
        }
        [HttpPost]
        [Route("api/Posts/Delete")]
        public void PostDelete([FromBody] int Id)
        {
            var Post = (from i in db.posts
                        where i.ID == Id
                        select i).FirstOrDefault();
            db.posts.Remove(Post);
            db.SaveChanges();
        }
    }
}
