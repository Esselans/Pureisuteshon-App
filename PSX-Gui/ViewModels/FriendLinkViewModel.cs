﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Chat;
using Windows.ApplicationModel.Email;
using Windows.ApplicationModel.Resources;
using Newtonsoft.Json;
using PlayStation.Managers;
using PlayStation_App.Models.Response;
using PlayStation_App.Tools.Debug;
using PlayStation_App.Tools.Helpers;
using PlayStation_Gui.Views;
using Template10.Mvvm;

namespace PlayStation_Gui.ViewModels
{
    public class FriendLinkViewModel : ViewModelBase
    {
        private readonly FriendManager _friendManager = new FriendManager();
        private readonly ResourceLoader _loader = new ResourceLoader();

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                Set(ref _isLoading, value);
            }
        }

        public async Task<string> CreateFriendLink()
        {
            await Shell.Instance.ViewModel.UpdateTokens();
            var result = await _friendManager.GetFriendLink(Shell.Instance.ViewModel.CurrentTokens);
            await AccountAuthHelpers.UpdateTokens(Shell.Instance.ViewModel.CurrentUser, result);
            var resultCheck = await ResultChecker.CheckSuccess(result);
            if (!resultCheck)
            {
                return string.Empty;
            }
            var tokenEntity = JsonConvert.DeserializeObject<TokenResponse>(result.ResultJson);
            return tokenEntity.Token;
        }

        public async Task SendFriendLinkViaSms()
        {
            IsLoading = true;
            var result = await ChatMessageManager.GetTransportsAsync();
            if (!result.Any())
            {
                IsLoading = false;
                await ResultChecker.SendMessageDialogAsync(_loader.GetString("NoSMS/Text"), false);
                return;
            }
            var link = await CreateFriendLink();

            if (!string.IsNullOrEmpty(link))
            {
                var chat = new ChatMessage
                {
                    Subject = _loader.GetString("FriendRequestBody/Text"),
                    Body = string.Format("{0} {1}", _loader.GetString("FriendRequestBody/Text"), link)
                };
                await ChatMessageManager.ShowComposeSmsMessageAsync(chat);
            }
            IsLoading = false;
        }

        public async Task SendFriendLinkViaEmail()
        {
            IsLoading = true;
            var link = await CreateFriendLink();
            if (!string.IsNullOrEmpty(link))
            {
                var em = new EmailMessage
                {
                    Subject = _loader.GetString("FriendRequestBody/Text"),
                    Body = string.Format("{0} {1}", _loader.GetString("FriendRequestBody/Text"), link)
                };
                await EmailManager.ShowComposeNewEmailAsync(em);
            }
            IsLoading = false;
        }
    }
}
