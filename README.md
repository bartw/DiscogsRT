
DiscogsRT
=
Description
-
DiscogsRT is a Windows 8.1 and Windows Phone 8.1 library for talking to Discogs.
DiscogsRT is under heavy development and by no means stable.
Disclaimer
-
DiscogsRT is a hobby project that I do because I love developing. I do however have a life and family. Therefore I can't give any guarantees about deadlines, crashes or any other problems.
Features
-
* Rate limited to 1 request per second
* Authentication flow
* Get identity and profile
* Get wantlist
* Get collection
* Get release
* Get master release
* Get master release versions
* Get artist
* Get label
* Get label releases
* Search

Problems, questions and suggestions
-
If you have problems, questions or suggestions you can post them in the [issues](https://github.com/bartw/DiscogsRT/issues) of this repository.
NuGet
-
You can add DiscogsRT to you project using the following command in the package manager console: 
Install-Package BeeWee.DiscogsRT, or go to [NuGet.org](https://www.nuget.org/packages/BeeWee.DiscogsRT/).
Dependencies
-
DiscogsRT uses [Rester](https://github.com/bartw/Rester) and [Json.NET](http://james.newtonking.com/json).
Usage
-
```c#
//create a DiscogsRT client
var client = new Client(useragent, consumerkey, consumersecret);
//oauth flow
var requestToken = await client.GetOAuthRequestAsync();
//go to requestToken.Uri, login on Discogs and acquire the pin
var accessToken = await GetOAuthAccesAsync(requestToken.Key, requestToken.Secret, Pin);
//you can use this accessToken to perform requests that need authentication
var identity = await client.GetIdentityAsync(accessToken.Key, accessToken.Secret);
//basic release lookup
var release = await client.GetReleaseAsync("2817604");
//paged search
var query = new SearchQuery();
query.Query = "Lovage";
query.Type = SearchItemType.Release;
var searchResults = await client.Search(accessToken.Key, accessToken.Secret, query);
```
