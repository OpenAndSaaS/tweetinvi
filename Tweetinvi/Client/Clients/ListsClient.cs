using System.Threading.Tasks;
using Tweetinvi.Client.Requesters;
using Tweetinvi.Models;
using Tweetinvi.Parameters.ListsClient;

namespace Tweetinvi.Client
{
    public class ListsClient : IListsClient
    {
        private readonly ITwitterListsRequester _twitterListsRequester;

        public ListsClient(ITwitterListsRequester twitterListsRequester)
        {
            _twitterListsRequester = twitterListsRequester;
        }

        public Task<ITwitterList> CreateList(string name)
        {
            return CreateList(new CreateListParameters(name));
        }

        public Task<ITwitterList> CreateList(string name, PrivacyMode privacyMode)
        {
            return CreateList(new CreateListParameters(name)
            {
                PrivacyMode = privacyMode
            });
        }

        public async Task<ITwitterList> CreateList(ICreateListParameters parameters)
        {
            var twitterResult = await _twitterListsRequester.CreateList(parameters).ConfigureAwait(false);
            return twitterResult?.Result;
        }

        public Task<ITwitterList> GetList(long? listId)
        {
            return GetList(new GetListParameters(listId));
        }

        public Task<ITwitterList> GetList(ITwitterListIdentifier listId)
        {
            return GetList(new GetListParameters(listId));
        }

        public async Task<ITwitterList> GetList(IGetListParameters parameters)
        {
            var twitterResult = await _twitterListsRequester.GetList(parameters).ConfigureAwait(false);
            return twitterResult?.Result;
        }

        public Task DestroyList(long? listId)
        {
            return DestroyList(new DestroyListParameters(listId));
        }

        public Task DestroyList(ITwitterListIdentifier listId)
        {
            return DestroyList(new DestroyListParameters(listId));
        }

        public async Task DestroyList(IDestroyListParameters parameters)
        {
            await _twitterListsRequester.DestroyList(parameters).ConfigureAwait(false);
        }
    }
}