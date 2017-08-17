using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot_Application1.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            //context.Wait(MessageReceivedAsync);

            //return Task.CompletedTask;
            Dialogs.Cards c = new Cards();
           await c.StartAsync(context);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            // return our reply to the user
            await context.PostAsync($"Your message{activity.Text} which was {length} characters");

            context.Wait(MessageReceivedAsync);
        }
    }
}