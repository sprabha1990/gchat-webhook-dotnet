namespace google_chat_dotnet_webhook;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Action
{
    public string function { get; set; }
    public List<Parameter> parameters { get; set; }
}

public class Button
{
    public string text { get; set; }
    public OnClick onClick { get; set; }
}

public class ButtonList
{
    public List<Button> buttons { get; set; }
}

public class Card
{
    public Header header { get; set; }
    public List<Section> sections { get; set; }
}

public class CardsV2
{
    public string cardId { get; set; }
    public Card card { get; set; }
}

public class DecoratedText
{
    public StartIcon startIcon { get; set; }
    public string text { get; set; }
    public string topLabel { get; set; }
}

public class Header
{
    public string title { get; set; }
    public string subtitle { get; set; }
    public string imageUrl { get; set; }
    public string imageType { get; set; }
    public string imageAltText { get; set; }
}

public class OnClick
{
    public OpenLink openLink { get; set; }
    public Action action { get; set; }
}

public class OpenLink
{
    public string url { get; set; }
}

public class Parameter
{
    public string key { get; set; }
    public string value { get; set; }
}

public class GoogleChatCardMessage
{
    public List<CardsV2> cardsV2 { get; set; }
}

public class Section
{
    public string header { get; set; }
    public bool collapsible { get; set; }
    public int uncollapsibleWidgetsCount { get; set; }
    public List<Widget> widgets { get; set; }
}

public class StartIcon
{
    public string knownIcon { get; set; }
}

public class Widget
{
    public DecoratedText decoratedText { get; set; }
    public ButtonList buttonList { get; set; }
}


public class NotificationDTO
{
    public string WebHookURL { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string SentBy { get; set; } = string.Empty;
    public string SentByTitle { get; set; } = string.Empty;
}
