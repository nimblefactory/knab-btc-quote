# Technical questions

1. *How long did you spend on the coding assignment? What would you add to your solution if you had
more time?*
- I think around 12 hours.
- Caching, to be able to manage performance and API call cost.
- Error handling, to cover more cases that would lead to an error.
- Logging, to be able to analyze what is happening in a production environment.
- Integration tests, to more confidently deploy to production.
- More unit-tests, to have even beter coverage.

2. *What was the most useful feature that was added to the latest version of your language of choice?*
- That would be collection expressions from C# 12. It allows for simplified initialization of all sorts of collections:

`var list = new[] { 1, 2, 3, 4 }.ToList();`
becomes:
`List<int> list12 = [1, 2, 3, 4];`

Also initializing non-nullable class properties becomes less of a chore:
`public List<string> ItemList { get; set; } = new List<string>();`
becomes:
`public List<string> ItemList { get; set; } = [];`

3. *How would you track down a performance issue in production? Have you ever had to do this?*
- Yes, I have done this before.
- I would begin by looking at how many resources are being used on the production environment. Then I would check to see how many resources are beig used by the process deployed there. Also I would try to figure out since when there is a performance issue, and if there is a trend/pattern to be detected. Finally I would try to debug and replicate the problem locally by duplicating the scenario from production.

4. *What was the latest technical book you have read or tech conference you have been to? What did you
learn?*
- I've been looking into all things Azure for quite some time now. And it looks like I keep finding new and interesting things to learn. My last rabbit hole brought me to Microsoft Entra ID (formerly known as Azure AD) which is an IAM service (used to host the Knab user/identity that is granted access to this web app). I learned how to use it as an IAM authority.

5. *What do you think about this technical assessment?*
- I think it is an interesting way to assess the skill set of a candidate. Especially with having the oppertunity to spend as much time as you like on it. And being asked to explain what could be added with more time. I did enjoy it.

6. *Please, describe yourself using JSON.*

`
{
	displayName: "Stefan van Maanen",
	dateOfBirth: "29-08-1981",
	sharesBirthDayWithCelebrity: "Michael Jackson",
	enjoys: [ "Drums", "Games", "Programming", "Motorcycle", "Movies", "Workout", "Travel" ],
	handDominancy: "Left",
	isParent: true
}
`
