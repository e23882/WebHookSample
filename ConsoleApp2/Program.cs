// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using Teams.WebHooks;

namespace ConsoleApp2
{
    public class Program
    {
        const string webHookIRL =
            "https://viewsonic0.webhook.office.com/webhookb2/5a1b5963-64bd-4830-8947-11f7b8d4d4e8@f7a08210-8cd2-459f-9459-ddb19785f376/IncomingWebhook/df886187d4ad43de8d20fddf720727a0/02e2dbfc-3a5f-462e-82c1-52a97d79cf42";

        public static async Task Main(string[] args)
        {
            //await SendEasyMessage();
            await SendSectionMessage();
            await SendFormMessage();
        }

        public static async Task SendEasyMessage()
        {
            var card = new Message();
            card.ThemeColor = "8625D2";
            card.Summary = "Some summary here";
            var payload = JsonConvert.SerializeObject(card);
            var isSuccess = await MessageClient.SendAsync(webHookIRL, card);
            if (isSuccess)
                Console.WriteLine("發送一般訊息成功");
        }

        public static async Task SendSectionMessage()
        {
            var card = new Message();
            card.ThemeColor = "8625D2";
            card.Summary = "Some summary here";
            card.Sections.Add(new Section
            {
                ActivityTitle = "Section Title here",
                ActivitySubtitle = "Section Subtitle here",
                ActivityImage = "https://some-image.png",
                Markdown = true,
                Facts = new List<Fact>()
                {
                    new()
                    {
                        Name = "Assigned to",
                        Value = "some@email.com"
                    },
                    new()
                    {
                        Name = "Due date",
                        Value = "27/07/2021"
                    },
                    new()
                    {
                        Name = "Status",
                        Value = "Active"
                    }
                },
            });
            var payload = JsonConvert.SerializeObject(card);
            var isSuccess = await MessageClient.SendAsync(webHookIRL, card);
            if (isSuccess)
                Console.WriteLine("發送SECTION訊息成功");
        }

        static async Task SendFormMessage()
        {
            var card = new Message();
            card.ThemeColor = "8625D2";
            card.Summary = "Some summary here";
            card.PotentialAction.Add(new PotentialAction
            {
                Name = "Comentar",
                Inputs = new List<Input>()
                 {
                     new() { Id = "email", Title = "Email here", Type = "TextInput", IsMultiline = false },
                     new() { Id = "date", Title = "Date", Type = "DateInput", IsMultiline = false }
                 },
                Actions = new List<ActionItem>()
                 {
                     new()
                     {
                         Body = "comment={{email.value}}", // Capture the value of the input
                         Name = "Aprove",
                         Target = "https://your-api-endpoint"
                     }
                 }
            });
            var payload = JsonConvert.SerializeObject(card);
            var isSuccess = await MessageClient.SendAsync(webHookIRL, card);
            if (isSuccess)
                Console.WriteLine("發送FORM訊息成功");
        }
    }
}

//const string webHookIRL = "https://viewsonic0.webhook.office.com/webhookb2/5a1b5963-64bd-4830-8947-11f7b8d4d4e8@f7a08210-8cd2-459f-9459-ddb19785f376/IncomingWebhook/df886187d4ad43de8d20fddf720727a0/02e2dbfc-3a5f-462e-82c1-52a97d79cf42";
//var card = new Message();
//card.ThemeColor = "8625D2";
//card.Summary = "Some summary here";
//card.Sections.Add(new Section
//{
//    ActivityTitle = "Section Title TEST here",
//    ActivitySubtitle = "Section Subtitle TEST here",
//    ActivityImage = "https://avatars.githubusercontent.com/u/16596732?v=4",
//    Markdown = true,
//});

//var isSuccess = await MessageClient.SendAsync(webHookIRL, card);
//if (isSuccess)
//    Console.WriteLine("發送一般訊息成功");