using Flurl.Http;
using Microsoft.AspNetCore.Mvc;

namespace google_chat_dotnet_webhook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        [HttpPost("send")]
        public async Task SendNotification(NotificationDTO notificationDTO)
        {
            var cardsV2 = new List<CardsV2>
            {
                new CardsV2
                {
                    cardId = $"MessageFrom{notificationDTO.SentBy}",
                    card = new Card
                    {
                        header = new Header
                        {
                            title = notificationDTO.SentByTitle,
                            subtitle = $"sent at {DateTime.Now}",
                        },
                        sections = new List<Section>
                        {
                            new Section
                            {
                                widgets = new List<Widget>
                                {
                                    new Widget
                                    {
                                        decoratedText =new DecoratedText
                                        {
                                            text = notificationDTO.SentByTitle,
                                            startIcon = new StartIcon
                                            {
                                                knownIcon = "BOOKMARK"
                                            }
                                        }
                                    },
                                    new Widget
                                    {
                                        decoratedText =new DecoratedText
                                        {
                                            text = notificationDTO.Message,
                                            startIcon = new StartIcon
                                            {
                                                knownIcon = "EMAIL"
                                            }
                                        }
                                    },
                                }
                            },
                            new Section
                            {
                                widgets = new List<Widget>
                                {
                                    new Widget
                                    {
                                        decoratedText =new DecoratedText
                                        {
                                            topLabel = "notification sent by",
                                            text = notificationDTO.SentBy.ToUpper(),
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var newMessage = new GoogleChatCardMessage() { cardsV2 = cardsV2 };

            await notificationDTO.WebHookURL.PostJsonAsync(newMessage);

            await Task.CompletedTask;
        }
    }
}
