// See https://aka.ms/new-console-template for more information

using Octokit;

Octokit.Connection c = new Connection(new ProductHeaderValue("dotnet"));
GitHubClient client = new GitHubClient(c);

for (var i = 0; i < args.Length; i++)
{
    var issue = await client.Issue.Get("dotnet", "aspnetcore", Int32.Parse(args[i]));
    Console.Out.WriteLine($"{issue.Id}, {issue.Title}, {issue.HtmlUrl}, {GetArea(issue)}");
}

string GetArea(Issue issue)
{
    return string.Join(',', issue.Labels.Where(l => l.Name.StartsWith("area-", StringComparison.OrdinalIgnoreCase)).Select(item=>item.Name));
}