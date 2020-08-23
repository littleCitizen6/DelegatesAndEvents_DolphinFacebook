using MamaFacebook.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DolphinFacebook
{
    class DolphinsFacebookClient : IFacebookClient
    {
        private IDisplay _displayer;
        public event Action<string> NewWallPost;

        public DolphinsFacebookClient(IDisplay displayer)
        {
            _displayer = displayer;
        }
        public void Subscribe(IFacebookClient publisher)
        {
            publisher.NewWallPost += _displayer.DisplayWallPost;
        }
        public void Unsubscribe(IFacebookClient publisher)
        {
            publisher.NewWallPost -= _displayer.DisplayWallPost;
        }
        public void WriteNewWallPost(string wallPost)
        {
            NewWallPost?.Invoke(wallPost);
        }
    }
}
