/**
 * ****************************************************************************
 * Copyright (C) 2016 Open Universiteit Nederland
 * <p/>
 * This library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * <p/>
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 * <p/>
 * You should have received a copy of the GNU Lesser General Public License
 * along with this library.  If not, see <http://www.gnu.org/licenses/>.
 * <p/>
 * Contributors: Jan Schneider
 * ****************************************************************************
 */
using System;
using System.Web;
using System.Net;
using System.IO;

using Tweetinvi;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Controllers;
using Tweetinvi.Core.Interfaces.DTO;
using Tweetinvi.Core.Interfaces.Factories;
using Tweetinvi.Core.Interfaces.Models;
using Tweetinvi.Credentials;



namespace TheBooth
{
    public class TwitterClient
    {
        
        private string _twitterUpdateUrl = "http://twitter.com/statuses/update.json";

        public TwitterClient()
        {
            
        }


       public void sendImage()
       {
           string AccessToken = "254046229-TA51Oq4HE7XXyfcttCCRn4PcVGqz07QRExRtozdm";
           string TokenSecret = "LXrirXdQQ3ILkh520Cn3Xq3XPjBXQ8i5wP95idaBxHZ6k";
           string ConsumerKey = "1ip690Dgl75GyOYVB7j2IEjdt";
           string ConsumerSecret = "ss0MRSi3amUt0I1FZVbhq8t8VvJ2t4RUqW6DZK0sM1q7l8YZcm";

           Tweetinvi.TwitterCredentials.SetCredentials(AccessToken, TokenSecret, ConsumerKey, ConsumerSecret);

           byte[] file = File.ReadAllBytes("sample.jpg");
           
           
           var tweet = Tweet.PublishTweetWithMedia("A new Super Hero arrived", file);
           //var imageURL = tweet.Entities.Medias.First().MediaType;
          // label1.Text = "Tweet Posted With Image :)";
           int x = 0;
           x++;

       }


    }
}
